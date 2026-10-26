using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortolioHomeWork.DAL.Context;
using MyPortolioHomeWork.DAL.Entities;
using MyPortolioHomeWork.Models;

namespace MyPortolioHomeWork.Controllers;

public class AccountController : Controller
{
    private readonly MyPortfolioContext context = new();
    private readonly PasswordHasher<AdminUser> hasher = new();

    [HttpGet]
    public IActionResult Login(string? returnUrl)
    {
        if (User.Identity?.IsAuthenticated == true) return RedirectToAction("Index", "Statistic");
        if (!context.AdminUsers.Any()) return RedirectToAction(nameof(Setup));
        return View(new LoginModel { ReturnUrl = returnUrl });
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (!ModelState.IsValid) return View(model);
        var user = context.AdminUsers.FirstOrDefault(x => x.UserName == model.UserName.Trim());
        if (user == null || user.LockoutUntil > DateTime.UtcNow)
        {
            ModelState.AddModelError("", "Giriş bilgileri geçersiz veya hesap geçici olarak kilitli.");
            return View(model);
        }
        var verification = hasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
        if (verification == PasswordVerificationResult.Failed)
        {
            user.FailedAttempts++;
            if (user.FailedAttempts >= 5) { user.LockoutUntil = DateTime.UtcNow.AddMinutes(15); user.FailedAttempts = 0; }
            context.SaveChanges();
            ModelState.AddModelError("", "Giriş bilgileri geçersiz veya hesap geçici olarak kilitli.");
            return View(model);
        }
        if (verification == PasswordVerificationResult.SuccessRehashNeeded)
            user.PasswordHash = hasher.HashPassword(user, model.Password);
        user.FailedAttempts = 0;
        user.LockoutUntil = null;
        context.SaveChanges();
        await SignIn(user);
        return Url.IsLocalUrl(model.ReturnUrl) ? LocalRedirect(model.ReturnUrl!) : RedirectToAction("Index", "Statistic");
    }

    private bool CanSetup() => HttpContext.Connection.RemoteIpAddress is { } ip && IPAddress.IsLoopback(ip) && !context.AdminUsers.Any();

    [HttpGet]
    public IActionResult Setup()
    {
        if (context.AdminUsers.Any()) return RedirectToAction(nameof(Login));
        if (!CanSetup()) return StatusCode(403);
        return View(new SetupModel());
    }

    [HttpPost]
    public async Task<IActionResult> Setup(SetupModel model)
    {
        if (!CanSetup()) return Forbid();
        if (string.IsNullOrEmpty(model.Password) || model.Password.Length < 8)
            ModelState.AddModelError("Password", "Şifre en az 8 karakter olmalı.");
        if (!ModelState.IsValid) return View(model);
        using var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.Serializable);
        if (context.AdminUsers.Any()) return Forbid();
        var user = new AdminUser { UserName = model.UserName.Trim(), DisplayName = model.DisplayName.Trim(), Email = model.Email.Trim() };
        user.PasswordHash = hasher.HashPassword(user, model.Password);
        context.AdminUsers.Add(user);
        context.SaveChanges();
        transaction.Commit();
        await SignIn(user);
        return RedirectToAction("Index", "Statistic");
    }

    [Authorize, HttpGet]
    public IActionResult Profile()
    {
        var user = CurrentUser();
        if (user == null) return Challenge();
        return View(new ProfileModel { DisplayName = user.DisplayName, Email = user.Email });
    }

    [Authorize, HttpPost]
    public async Task<IActionResult> Profile(ProfileModel model)
    {
        if (!ModelState.IsValid) return View(model);
        var user = CurrentUser();
        if (user == null) return Challenge();
        user.DisplayName = model.DisplayName.Trim();
        user.Email = model.Email.Trim();
        context.SaveChanges();
        await SignIn(user);
        TempData["Success"] = "Profil güncellendi.";
        return RedirectToAction(nameof(Profile));
    }

    [Authorize, HttpGet]
    public IActionResult ChangePassword() => View(new ChangePasswordModel());

    [Authorize, HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
    {
        var user = CurrentUser();
        if (user == null) return Challenge();
        if (!ModelState.IsValid) return View(model);
        if (hasher.VerifyHashedPassword(user, user.PasswordHash, model.CurrentPassword) == PasswordVerificationResult.Failed)
        {
            ModelState.AddModelError("CurrentPassword", "Mevcut şifre yanlış.");
            return View(model);
        }
        user.PasswordHash = hasher.HashPassword(user, model.NewPassword);
        user.SecurityStamp = Guid.NewGuid().ToString();
        context.SaveChanges();
        await SignIn(user);
        TempData["Success"] = "Şifre değiştirildi. Diğer oturumlar kapatıldı.";
        return RedirectToAction(nameof(Profile));
    }

    [Authorize, HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction(nameof(Login));
    }

    private AdminUser? CurrentUser() => int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var id) ? context.AdminUsers.Find(id) : null;
    private Task SignIn(AdminUser user)
    {
        var identity = new ClaimsIdentity(new[] {
            new Claim(ClaimTypes.NameIdentifier, user.AdminUserId.ToString()),
            new Claim(ClaimTypes.Name, user.DisplayName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("SecurityStamp", user.SecurityStamp)
        }, CookieAuthenticationDefaults.AuthenticationScheme);
        return HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
    }
    protected override void Dispose(bool disposing) { if (disposing) context.Dispose(); base.Dispose(disposing); }
}

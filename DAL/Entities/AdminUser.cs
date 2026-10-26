namespace MyPortolioHomeWork.DAL.Entities;

public class AdminUser
{
    public int AdminUserId { get; set; }
    public string UserName { get; set; } = "";
    public string DisplayName { get; set; } = "";
    public string Email { get; set; } = "";
    public string PasswordHash { get; set; } = "";
    public string SecurityStamp { get; set; } = Guid.NewGuid().ToString();
    public int FailedAttempts { get; set; }
    public DateTime? LockoutUntil { get; set; }
}

namespace MyPortolioHomeWork.Models;
public static class ContentRules
{
    public static bool IsWebUrl(string value) =>
        Uri.TryCreate(value, UriKind.Absolute, out var uri) &&
        (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
    public static bool IsImagePath(string value) =>
        IsWebUrl(value) || ((value.StartsWith("/") || value.StartsWith("~/")) &&
        !value.StartsWith("//") && !value.Contains('\\') && !value.Contains(".."));
}

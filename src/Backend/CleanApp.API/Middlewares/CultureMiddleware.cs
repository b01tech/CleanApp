using System.Globalization;

namespace CleanApp.API.Middlewares;
public class CultureMiddleware
{
    private readonly RequestDelegate _next;
    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var allCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
        var languageTag = context.Request.Headers.AcceptLanguage.FirstOrDefault();
        var culture = new CultureInfo("pt-BR");

        if (!string.IsNullOrWhiteSpace(languageTag) && allCultures.Any(c => c.Name.Equals(languageTag)))
        {
            culture = new CultureInfo(languageTag);
        }
        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;

        await _next(context);

    }
}

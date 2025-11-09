namespace Vinder.Comanda.Payments.WebApi.Extensions;

[ExcludeFromCodeCoverage(Justification = "contains only dependency injection registration with no business logic.")]
public static class HttpClientsExtension
{
    public static void AddHttpClients(this IServiceCollection services, ISettings settings)
    {
        services.AddHttpClient<IAbacatePayClient, AbacatePayClient>(client =>
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {settings.AbacatePay.Credential}");
            client.BaseAddress = new Uri(settings.AbacatePay.Url);
        });
    }
}
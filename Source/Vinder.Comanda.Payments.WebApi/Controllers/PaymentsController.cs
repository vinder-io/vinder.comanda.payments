namespace Vinder.Comanda.Payments.WebApi.Controllers;

[ApiController]
[Route("api/v1/payments")]
public sealed class PaymentsController(IDispatcher dispatcher) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPaymentsAsync(
        [FromQuery] PaymentsFetchParameters request, CancellationToken cancellation)
    {
        var result = await dispatcher.DispatchAsync(request, cancellation);

        // we know the switch here is not strictly necessary since we only handle the success case,
        // but we keep it for consistency with the rest of the codebase and to follow established patterns.
        return result switch
        {
            { IsSuccess: true } => StatusCode(StatusCodes.Status200OK, result.Data),
        };
    }

    [HttpPost("offline")]
    public async Task<IActionResult> CreateOfflinePaymentChargeAsync(
        [FromBody] OfflinePaymentChargeScheme request,  CancellationToken cancellation)
    {
        var result = await dispatcher.DispatchAsync(request, cancellation);

        // we know the switch here is not strictly necessary since we only handle the success case,
        // but we keep it for consistency with the rest of the codebase and to follow established patterns.
        return result switch
        {
            { IsSuccess: true } when result.Data is not null =>
                StatusCode(StatusCodes.Status201Created, result.Data),
        };
    }

    [HttpPost]
    [Authorize(Roles = Permissions.MakePayment)]
    public async Task<IActionResult> CreateCheckoutSessionAsync(
        [FromBody] CheckoutSessionCreationScheme request, CancellationToken cancellation)
    {
        var result = await dispatcher.DispatchAsync(request, cancellation);

        return result switch
        {
            { IsSuccess: true } =>
                StatusCode(StatusCodes.Status200OK, result.Data),

            { IsFailure: true } =>
                StatusCode(StatusCodes.Status400BadRequest, result.Error)
        };
    }
}
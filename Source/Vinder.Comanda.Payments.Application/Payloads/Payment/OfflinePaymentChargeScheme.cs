namespace Vinder.Comanda.Payments.Application.Payloads.Payment;

public sealed record OfflinePaymentChargeScheme : IMessage<Result<PaymentScheme>>
{
    public string Reference { get; init; } = default!;
    public decimal Amount { get; init; } = default!;
    public Method Method { get; init; } = Method.Unspecified;
}

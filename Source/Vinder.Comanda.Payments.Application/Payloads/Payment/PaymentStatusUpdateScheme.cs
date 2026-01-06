namespace Vinder.Comanda.Payments.Application.Payloads.Payment;

public sealed record PaymentStatusUpdateScheme : IMessage<Result<PaymentScheme>>
{
    [property: JsonIgnore]
    public string Identifier { get; init; } = default!;
    public Status Status { get; init; }
}

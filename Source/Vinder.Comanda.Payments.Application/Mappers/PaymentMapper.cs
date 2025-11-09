namespace Vinder.Comanda.Payments.Application.Mappers;

public static class PaymentMapper
{
    public static Payment AsPayment(this CheckoutSessionCreationScheme parameters) => new()
    {
        Amount = parameters.Amount,
        Status = Status.Pending,
        Metadata = new PaymentMetadata(Identifier: string.Empty, Reference: parameters.Reference),
        Payer = new User(parameters.Payer.Identifier, parameters.Payer.Username),
    };

    public static PaymentScheme AsResponse(this Payment payment) => new()
    {
        Identifier = payment.Id,
        Reference = payment.Metadata.Reference,
        Amount = payment.Amount,
        Payer = payment.Payer,
        Status = payment.Status
    };
}
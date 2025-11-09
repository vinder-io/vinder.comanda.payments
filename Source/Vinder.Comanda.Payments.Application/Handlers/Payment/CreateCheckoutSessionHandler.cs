namespace Vinder.Comanda.Payments.Application.Handlers.Payment;

public sealed class CreateCheckoutSessionHandler(
    IPaymentGateway paymentGateway,
    IPaymentRepository repository,
    IActivityRepository activityRepository
) : IMessageHandler<CheckoutSessionCreationScheme, Result<CheckoutSession>>
{
    public async Task<Result<CheckoutSession>> HandleAsync(
        CheckoutSessionCreationScheme message, CancellationToken cancellation = default)
    {
        var payment = await repository.InsertAsync(message.AsPayment(), cancellation);
        var activity = new Activity
        {
            Action = "comanda.actions.payment.creation",
            Description = $"customer '{message.Payer.Username}' started a new payment process.",
            Resource = Resource.From(payment.Id, nameof(Payment)),
            User = new User(message.Payer.Identifier, message.Payer.Username),
            Metadata = new Dictionary<string, string>
            {
                { "payer.identifier", payment.Payer.Identifier },
                { "payment.method", payment.Method.ToString() },
                { "payment.amount", payment.Amount.ToString() }
            }
        };

        await activityRepository.InsertAsync(activity, cancellation);

        return await paymentGateway.CreateCheckoutSessionAsync(message, payment, cancellation);
    }
}
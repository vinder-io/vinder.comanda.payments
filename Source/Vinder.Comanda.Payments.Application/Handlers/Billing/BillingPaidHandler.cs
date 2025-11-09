#pragma warning disable S3626

namespace Vinder.Comanda.Payments.Application.Handlers.Billing;

public sealed class BillingPaidHandler(IPaymentRepository repository, IActivityRepository activityRepository) :
    IEventHandler<BillingPaidNotificationScheme>
{
    public async Task HandleAsync(BillingPaidNotificationScheme message, CancellationToken cancellation = default)
    {
        var metadata = message.Data.PixQrCode.Metadata;
        var paymentId = metadata.GetValueOrDefault("payment.identifier");

        var filters = PaymentFilters.WithSpecifications()
            .WithIdentifier(paymentId)
            .Build();

        var payments = await repository.GetPaymentsAsync(filters, cancellation);
        var payment = payments.FirstOrDefault();

        if (payment is null)
        {
            return;
        }

        payment.MarkAsPaid();
        payment.Metadata = new PaymentMetadata(
            Identifier: message.Data.PixQrCode.Id,
            Reference: payment.Metadata.Reference
        );

        var activity = new Activity
        {
            Action = "comanda.actions.payment.paid",
            Description = $"customer '{payment.Payer.Username}' completed a payment successfully.",
            Resource = Resource.From(payment.Id, nameof(Payment)),
            User = new User(payment.Payer.Identifier, payment.Payer.Username),
            Metadata = new Dictionary<string, string>
            {
                { "payer.identifier", payment.Payer.Identifier },
                { "payment.method", payment.Method.ToString() },
                { "payment.amount", payment.Amount.ToString("F2") }
            }
        };

        await repository.UpdateAsync(payment, cancellation);
        await activityRepository.InsertAsync(activity, cancellation);
    }
}
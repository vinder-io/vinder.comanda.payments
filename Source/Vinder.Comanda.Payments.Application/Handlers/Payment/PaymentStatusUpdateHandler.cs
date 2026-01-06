namespace Vinder.Comanda.Payments.Application.Handlers.Payment;

public sealed class PaymentStatusUpdateHandler(IPaymentRepository repository) :
    IMessageHandler<PaymentStatusUpdateScheme, Result<PaymentScheme>>
{
    public async Task<Result<PaymentScheme>> HandleAsync(
        PaymentStatusUpdateScheme parameters, CancellationToken cancellation = default)
    {
        var filters = PaymentFilters.WithSpecifications()
            .WithIdentifier(parameters.Identifier)
            .Build();

        var payments = await repository.GetPaymentsAsync(filters, cancellation);
        var payment = payments.FirstOrDefault();

        if (payment is null)
        {
            return Result<PaymentScheme>.Failure(PaymentErrors.PaymentDoesNotExist);
        }

        payment.Status = parameters.Status;

        await repository.UpdateAsync(payment, cancellation);

        return Result<PaymentScheme>.Success(payment.AsResponse());
    }
}

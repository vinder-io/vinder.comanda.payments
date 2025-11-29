namespace Vinder.Comanda.Payments.Application.Handlers.Payment;

public sealed class OfflinePaymentChargeHandler(IPaymentRepository repository) :
    IMessageHandler<OfflinePaymentChargeScheme, Result<PaymentScheme>>
{
    public async Task<Result<PaymentScheme>> HandleAsync(
        OfflinePaymentChargeScheme parameters, CancellationToken cancellation = default)
    {
        if (parameters.Method == Method.Pix)
        {
            /* for tracking purposes: raise error #COMANDA-ERROR-947B5 */
            return Result<PaymentScheme>.Failure(PaymentErrors.MethodNotAllowed);
        }

        var payment = await repository.InsertAsync(parameters.AsPayment(), cancellation);

        return Result<PaymentScheme>.Success(payment.AsResponse());
    }
}

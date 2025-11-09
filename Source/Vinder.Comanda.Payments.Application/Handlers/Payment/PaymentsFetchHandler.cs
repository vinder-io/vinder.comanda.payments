namespace Vinder.Comanda.Payments.Application.Handlers.Payment;

public sealed class PaymentsFetchHandler(IPaymentRepository repository) :
    IMessageHandler<PaymentsFetchParameters, Result<PaginationScheme<PaymentScheme>>>
{
    public async Task<Result<PaginationScheme<PaymentScheme>>> HandleAsync(
        PaymentsFetchParameters parameters, CancellationToken cancellation = default)
    {
        var filters = PaymentFilters.WithSpecifications()
            .WithIdentifier(parameters.Id)
            .WithPayerId(parameters.PayerId)
            .WithExternalId(parameters.ExternalId)
            .WithReferenceId(parameters.ReferenceId)
            .WithStatus(parameters.Status)
            .WithMethod(parameters.Method)
            .WithSort(parameters.Sort)
            .WithPagination(parameters.Pagination)
            .WithMinAmount(parameters.MinAmount)
            .WithMaxAmount(parameters.MaxAmount)
            .WithCreatedAfter(parameters.CreatedAfter)
            .WithCreatedBefore(parameters.CreatedBefore)
            .Build();

        var payments = await repository.GetPaymentsAsync(filters, cancellation);
        var totalCount = await repository.CountPaymentsAsync(filters, cancellation);

        var pagination = new PaginationScheme<PaymentScheme>
        {
            Items = [.. payments.Select(payment => payment.AsResponse())],
            Total = (int)totalCount,
            PageNumber = parameters.Pagination?.PageNumber ?? 1,
            PageSize = parameters.Pagination?.PageSize ?? 20,
        };

        return Result<PaginationScheme<PaymentScheme>>.Success(pagination);
    }
}
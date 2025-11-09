namespace Vinder.Comanda.Payments.Domain.Repositories;

public interface IPaymentRepository : IBaseRepository<Payment>
{
    public Task<IReadOnlyCollection<Payment>> GetPaymentsAsync(
        PaymentFilters filters,
        CancellationToken cancellation = default
    );

    public Task<long> CountPaymentsAsync(
        PaymentFilters filters,
        CancellationToken cancellation = default
    );
}
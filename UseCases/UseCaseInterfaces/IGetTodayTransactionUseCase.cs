using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public interface IGetTodayTransactionUseCase
    {
        IEnumerable<Transaction> Execute(string cashierName);
    }
}
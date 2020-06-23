using System.Collections.Generic;
using RefactoringTest.Entities;
namespace RefactoringTest
{
    public interface IDataService
    {
        List<PaymentInfo> GetPendingPayments();
        void ReleasePayment(int id);
    }
}
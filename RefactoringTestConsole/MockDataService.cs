using System.Collections.Generic;
using RefactoringTest;
using RefactoringTest.Entities;
using RefactoringTest.ToRefactor;
namespace RefactoringTestConsole
{
    public class MockDataService : IDataService
    {
        public List<PaymentInfo> GetPendingPayments()
        {
            //implementation to return payments
            return new List<PaymentInfo>
                       {
                           new PaymentInfo(){ID = 1, Method = PaymentMethod.Fax, ReverseLeg = new ReverseLeg(){PaymentMethod = PaymentMethod.Fax}},
                           new PaymentInfo(){ID = 2, Method = PaymentMethod.Online, ReverseLeg = new ReverseLeg(){PaymentMethod = PaymentMethod.Online}},
                           new PaymentInfo(){ID = 3, Method = PaymentMethod.WebEntry, ReverseLeg = new ReverseLeg(){PaymentMethod = PaymentMethod.WebEntry}},
                           new PaymentInfo(){ID = 4, Method = PaymentMethod.Fax, ReverseLeg = new ReverseLeg(){PaymentMethod = PaymentMethod.Online}},
                       };
        }

        public void ReleasePayment(int id)
        {
            System.Console.WriteLine("Released Payment {0}", id);
        }
    }
}
using System;
using System.Collections.Generic;
using RefactoringTest.Entities;
using RefactoringTest.ToRefactor;
using RefactoringTest.ToRefactor.PaymentMethods;

namespace RefactoringTest.ToRefactor
{
    public class PaymentService
    {
        public void ProcessPendingPayments(IDataService dataService)
        {
            try
            {
                List<PaymentInfo> payments = dataService.GetPendingPayments();
                //Refactored Code from this point
                PaymentsServiceManager paymentsServiceManager = new PaymentsServiceManager(dataService);
                foreach (var pay in payments)
                {
                    paymentsServiceManager.Execute(pay);
                    Logger.Log("Executing Payment: " + pay.ID);
                }

            }
            catch (Exception exPendingPayments)
            {
                Logger.Log(exPendingPayments.Message);
            }
        }
    }
}

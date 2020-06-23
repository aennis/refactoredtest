using RefactoringTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringTest.ToRefactor.PaymentMethods
{

    /// <summary>
    /// Handler Manager has one public method, this calls whatever needs to be done
    /// This could be refactored further with more time
    /// </summary>
    public class WebEntryInstructionHandlerManager
        : IInstructionHandler
    {
        public PaymentInfo PaymentInfo { get; set; }
        public readonly IDataService dataService;
        public WebEntryInstructionHandlerManager(PaymentInfo pay, IDataService _dataService)
        {
            PaymentInfo = pay;
            dataService = _dataService;
        }
        public void Handle()
        {
            UdateCompleted();
            PaymentReceipt();
        }

        private void UdateCompleted()
        {
            dataService.ReleasePayment(PaymentInfo.ID);
        }

        private void PaymentReceipt()
        {
            System.Console.WriteLine("processPaymentReceipt on Payment {0}", PaymentInfo.ID);
            // Call the conversion method and get back the path to the converted PDF document
            var fileName = PDFBuilder.GenerateReceiptFax(PaymentInfo);
            Emailer.SendEmailWithAttachment(Config.EmailContact, fileName);
        }
    }
}

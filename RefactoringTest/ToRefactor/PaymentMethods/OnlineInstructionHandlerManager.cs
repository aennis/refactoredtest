using RefactoringTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringTest.ToRefactor.PaymentMethods
{
    public class OnlineInstructionHandlerManager : IInstructionHandler
    {
        public PaymentInfo PaymentInfo { get; set; }
        public readonly IDataService dataService;
        public OnlineInstructionHandlerManager(PaymentInfo pay, IDataService _dataService)
        {
            PaymentInfo = pay;
            dataService = _dataService;
        }

        public void Handle()
        {
            ProcessInstruction();
            UdateCompleted();
            ProcessReverse();
            PaymentReceipt();
        }

        private void ProcessInstruction()
        {
            OnlineInstructionBuilder.BuildOnlineInstructionFile(PaymentInfo);
        }
        private void ProcessReverse()
        {
            OnlineInstructionBuilder.BuildOnlineInstructionFile(PaymentInfo);
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

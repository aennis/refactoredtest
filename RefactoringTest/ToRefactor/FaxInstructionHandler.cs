using System;
using RefactoringTest.Entities;

namespace RefactoringTest.ToRefactor
{
    public class FaxInstructionHandler : IInstructionHandler
    {
        public void ProcessInstruction(PaymentInfo pay)
        {
            string file = PDFBuilder.GeneratePaymentFax(pay);
            Emailer.SendEmailWithAttachment(Config.EmailContact, file);
        }

        public void ProcessInstruction(PaymentInfo pay, bool originalLeg)
        {
            throw new NotImplementedException("Fax instruction handler does not support this overload of ProcessInstruction");
        }

        public void ProcessReverseInstruction(PaymentInfo pay)
        {
            string file = PDFBuilder.GenerateReversePaymentFax(pay);
            Emailer.SendEmailWithAttachment(Config.EmailContact, file);
        }
    }
}
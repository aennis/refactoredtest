using RefactoringTest.Entities;

namespace RefactoringTest.ToRefactor

{

    //TODO Needs to be amended to a proper factory
    public class InstructionHandlerFactory
    {
        private readonly IDataService dataService;

        public InstructionHandlerFactory(IDataService dataService)
        {
            this.dataService = dataService;
        }

        public void ProcessInstruction(PaymentInfo paymentInfo)
        {
            System.Console.WriteLine("ProcessInstruction on Payment {0}", paymentInfo.ID);

            switch (paymentInfo.Method)
            {
                case PaymentMethod.Fax:
                    processFaxInstruction(paymentInfo);
                    break;

                case PaymentMethod.Online:
                    processOnlineInstruction(paymentInfo, true);
                    break;

                case PaymentMethod.WebEntry:
                    processWebEntryInstruction(paymentInfo);
                    break;

                default:
                    break;
            }

           
            ProcessReverseInstruction(paymentInfo);


            if (paymentInfo.Method == PaymentMethod.Fax)
            {
                processPaymentReceipt(paymentInfo);
            }


            System.Console.WriteLine();

        }

        private void ProcessReverseInstruction(PaymentInfo paymentInfo)
        {
            if (paymentInfo.ReverseLeg==null) return;

            ReverseLeg reverseLegDetails = paymentInfo.ReverseLeg;

            switch (reverseLegDetails.PaymentMethod)
            {
                case PaymentMethod.Fax:
                    System.Console.WriteLine("ProcessReverseInstruction on Payment {0}", paymentInfo.ID);
                    ProcessReverseFaxInstruction(paymentInfo);
                    break;

                case PaymentMethod.Online:
                    System.Console.WriteLine("ProcessReverseInstruction on Payment {0}", paymentInfo.ID);
                    processOnlineInstruction(paymentInfo, false);
                    break;

                case PaymentMethod.WebEntry:
                    // Nothing to do - assuming user realises there is work to do e.g. notify JPMorgan that there is a receipt
                    break;
            }
        }

        private void processFaxInstruction(PaymentInfo pay)
        {
            var faxHandler = new FaxInstructionHandler();
            faxHandler.ProcessInstruction(pay);
            updateCompleted(pay);
        }

        private void ProcessReverseFaxInstruction(PaymentInfo pay)
        {
            var faxHandler = new FaxInstructionHandler();
            faxHandler.ProcessReverseInstruction(pay);
        }

        private void processOnlineInstruction(PaymentInfo pay, bool originalLeg)
        {
            var onlineHandler = new OnlineInstructionHandler();
            onlineHandler.ProcessInstruction(pay, originalLeg);

            if (originalLeg)
            {
                updateCompleted(pay);
            }
        }
        
        private void processWebEntryInstruction(PaymentInfo pay)
        {
            updateCompleted(pay);
        }

        private void processPaymentReceipt(PaymentInfo pay)
        {
            System.Console.WriteLine("processPaymentReceipt on Payment {0}", pay.ID);
            // Call the conversion method and get back the path to the converted PDF document
            var fileName = PDFBuilder.GenerateReceiptFax(pay);
            Emailer.SendEmailWithAttachment(Config.EmailContact, fileName);
        }

        private void updateCompleted(PaymentInfo pay)
        {
            dataService.ReleasePayment(pay.ID);
        }
    }
}
using RefactoringTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringTest.ToRefactor.PaymentMethods
{
    public class WebEntryInstructionHandlerFactory : InstructionHandlerFactory
    {
        public override IInstructionHandler Create(PaymentInfo pay, IDataService service) => new WebEntryInstructionHandlerManager(pay,service);

    }
}

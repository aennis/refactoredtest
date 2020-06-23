using RefactoringTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringTest.ToRefactor.PaymentMethods
{
  public class OnlineInstructionHandlerFactory : InstructionHandlerFactory
    {
        public override IInstructionHandler Create(PaymentInfo pay, IDataService service) => new OnlineInstructionHandlerManager(pay,service);

    }
}

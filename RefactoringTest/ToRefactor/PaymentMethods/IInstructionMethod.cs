using RefactoringTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringTest.ToRefactor.PaymentMethods
{
   public interface IInstructionMethod
    {
        void Execute(PaymentInfo pay);
    }


 
}

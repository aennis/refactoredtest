using System;
using RefactoringTest.Entities;

namespace RefactoringTest.ToRefactor
{
    public class OnlineInstructionHandler : IInstructionHandler
    {
        //VIOLATION
        public void ProcessInstruction(PaymentInfo pay)
        {
            throw new NotImplementedException("Online instructions do not support this overload of ProcessInstruction");
        }

        public void ProcessInstruction(PaymentInfo pay, bool originalLeg)
        {
            OnlineInstructionBuilder.BuildOnlineInstructionFile(pay, originalLeg);
        }
    }
}


using RefactoringTest.Entities;

namespace RefactoringTest.ToRefactor
{

    //TODO needs to be split into 2 Interfaces
    public interface IInstructionHandler
    {
        void ProcessInstruction(PaymentInfo pay);
        void ProcessInstruction(PaymentInfo pay, bool originalLeg);
    }
}
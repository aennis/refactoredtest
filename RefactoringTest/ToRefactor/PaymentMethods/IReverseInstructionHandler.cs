using RefactoringTest.Entities;

namespace RefactoringTest.ToRefactor.PaymentMethods
{
    public interface IReverseInstructionHandler
    {
        void ProcessReverse(PaymentInfo pay);
    }
}
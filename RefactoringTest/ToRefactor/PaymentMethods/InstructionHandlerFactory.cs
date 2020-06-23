using RefactoringTest.Entities;

namespace RefactoringTest.ToRefactor.PaymentMethods

{

    public abstract class InstructionHandlerFactory
    {
        public abstract IInstructionHandler Create(PaymentInfo pay, IDataService service);
    }
}
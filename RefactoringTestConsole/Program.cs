using RefactoringTest;
using RefactoringTest.ToRefactor;
using RefactoringTestConsole;
namespace PaymentServiceConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentService paymentService = new PaymentService();
            paymentService.ProcessPendingPayments(new MockDataService());
            
            System.Console.ReadLine();
        }
    }
}

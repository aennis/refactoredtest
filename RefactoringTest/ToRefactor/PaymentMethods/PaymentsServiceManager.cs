using RefactoringTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringTest.ToRefactor.PaymentMethods
{
    /// <summary>
    /// Andrew Ennis Tech Test
    /// Class Manages the InstructionHandler Creation and Initilization 
    /// </summary>
    public class PaymentsServiceManager
    {
        public Dictionary<PaymentMethod, InstructionHandlerFactory> factories;
        public readonly IDataService dataService;
        public PaymentsServiceManager(IDataService _dataService)
        {
            dataService = _dataService;
            InitializeFactories();
            Logger.Log("Factories Initilised");
        }

        private void InitializeFactories()
        {
            factories = new Dictionary<PaymentMethod, InstructionHandlerFactory>();
            foreach (PaymentMethod method in Enum.GetValues(typeof(PaymentMethod)))
            {
                var factory = (InstructionHandlerFactory)Activator.CreateInstance(Type.GetType("RefactoringTest.ToRefactor.PaymentMethods." + Enum.GetName(typeof(PaymentMethod), method) + "InstructionHandlerFactory"));
                factories.Add(method, factory);
            }
        }

        public IInstructionHandler ExecuteCreation(PaymentMethod action, PaymentInfo pay) => factories[action].Create(pay, dataService);

        //This replaces the mutiple methods on the initial spec, the handlerManagers do the rest
        public void Execute(PaymentInfo paymentInfo)
        {

            System.Console.WriteLine("ProcessInstruction on Payment {0}", paymentInfo.ID);
            switch (paymentInfo.Method)
            {
                case PaymentMethod.Fax:
                    factories[PaymentMethod.Fax]
                    .Create(paymentInfo, dataService)
                    .Handle();
                    Logger.Log("Fax Payment Method Handled");
                    break;

                case PaymentMethod.Online:
                    factories[PaymentMethod.Online]
                   .Create(paymentInfo, dataService)
                   .Handle();
                    Logger.Log("Online Payment Method Handled");
                    break;

                case PaymentMethod.WebEntry:
                    factories[PaymentMethod.WebEntry]
                     .Create(paymentInfo, dataService)
                     .Handle();
                    Logger.Log("WebEntry Payment Method Handled");
                    break;

                default:
                    break;
            }
        }
    }
}

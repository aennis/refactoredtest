using RefactoringTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringTest.ToRefactor.PaymentMethods
{
    public class WebEntryInstructionHandler : IInstructionHandler
    {

        private readonly IDataService dataService;
        public WebEntryInstructionHandler(IDataService dataService)
        {
            this.dataService = dataService;
        }

        public void Handle()
        {
        
        }

    }
}

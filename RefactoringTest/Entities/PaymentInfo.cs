using System;
using System.Data;
using RefactoringTest.ToRefactor;

namespace RefactoringTest.Entities
{
    /// <summary>
    /// Stores key information about a payment
    /// </summary>
    public class PaymentInfo
    {
        public int ID { get; set; }
        public PaymentMethod Method { get; set; }
        public ReverseLeg ReverseLeg { get; set; }
    }
}
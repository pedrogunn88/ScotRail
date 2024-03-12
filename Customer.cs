using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScotRail
{
    abstract class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Customer(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public abstract double CalculateTicketCost();
    }
    class FirstClassPassenger : Customer
    {
        public string AccountNumber { get; set; }

        public FirstClassPassenger(string name, string email, string accountNumber)
            : base(name, email)
        {
            AccountNumber = accountNumber;
        }
        public override double CalculateTicketCost()
        {
            return 0.9 * 50; // 10% discount for first class
        }
    }
    class OrdinaryPassenger : Customer
    {
        public OrdinaryPassenger(string name, string email)
            : base(name, email)
        {
        }
        public override double CalculateTicketCost()
        {
            return 50;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba8Semestr2.Interfaces
{
    public interface IComposter
    {
        bool CheckTicket(string ticketNumber);
        void Control(string ticketNumber);
        void Control();
        void OutputAllInstances(IComposter[] composters);
    }
}

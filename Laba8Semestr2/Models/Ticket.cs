using Laba8Semestr2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba8Semestr2.Models
{
    [Serializable]
    public sealed class Ticket
    {
        public bool IsMarked { get; set; }
        public string TicketNumber { get; set; }
        public DateTime DateOfLastCheck { get; set; }

        public override string ToString()
        {
            return $"IsMarked: {IsMarked} \n" +
                $"TicketNumber: {TicketNumber} \n" +
                $"DateOfLastCheck: {DateOfLastCheck}  \n";
        }
    }
}

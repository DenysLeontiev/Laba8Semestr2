using Laba8Semestr2.Interfaces;
using Laba8Semestr2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba8Semestr2.Helpers
{
    public abstract class ComposterBase
    {
        public void SortInstances(Composter[] composters)
        {
            int length = composters.Length;
            for (int i = 0; i < length - 1 ; i++)
            {
                for (int j = 0; j < length - 1; j++)
                {
                    if (int.Parse(composters[j].BusNumber) > int.Parse(composters[j + 1].BusNumber))
                    {
                        var temp = composters[j];
                        composters[j] = composters[j + 1];
                        composters[j + 1] = temp;
                    }
                }
            }
        }
    }
}

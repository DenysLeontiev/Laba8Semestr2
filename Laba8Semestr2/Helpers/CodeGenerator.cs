using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba8Semestr2.Helpers
{
    public static class CodeGenerator
    {
        static string LastGeneratedCode;
        public static string GenerateUniqueCode()
        {
            LastGeneratedCode = Guid.NewGuid().ToString();
            return LastGeneratedCode;
        }
    }
}

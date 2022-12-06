using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b_Calculatrice
{
    internal static class Calculator
    {

        static public double calculerResultat(double nombre1, double nombre2, String operation)
        {
            switch (operation)
            {
                case "+": return nombre1 + nombre2;
                case "-": return nombre1 - nombre2;
                case "/": if (nombre2 != 0) return (nombre1 / nombre2); return 0;
                case "*": return (nombre1 * nombre2);
                case "%": return (nombre1 % nombre2);
                case "e": return (Math.Pow(nombre1, nombre2));
                default: return 0;
            }
        }
        static public double calculerResultat(double nombre1, String operation)
        {
            switch (operation)
            {
                case "!": return fact(nombre1);
                default: return 0;
            }
        }

        static public double fact(double n)
        {
            if (n == 0) return 1;
            else return (n * fact(n - 1));
        }
    }

}

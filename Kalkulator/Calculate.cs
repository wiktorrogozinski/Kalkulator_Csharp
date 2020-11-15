using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc
{
    class Calculate
    {
        public static double solution(string a, string b, string operation)
        {
            double numberA, numberB;

            Double.TryParse(a, out numberA);
            Double.TryParse(b, out numberB);

            switch (operation)
            {
                case "M":
                    return numberA * numberB;
                case "D":
                    return numberA / numberB;
                case "PX":
                    return Math.Pow(numberA, numberB);
                case "A":
                    return numberA + numberB;
                case "S":
                    return numberA - numberB;
                case "P":
                    return Math.Pow(numberB, 1 / numberA);
                case "EXP":
                    return Math.Exp(numberA);
                case "LOG":
                    return Math.Log(numberA, numberB);
            }

            return 0.0d;
        }
    }
}
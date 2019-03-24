using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    class SingleMission : IMission
    {
        string name;
        private CalcDelegate funCon;

        public String Name { get; }

        public String Type { get; }

        public SingleMission(CalcDelegate fun, string myName)
        {
            Name = myName;
            Type = "Single";
            funCon = fun;
        }

        public event EventHandler<double> OnCalculate;

        public double Calculate(double value)
        {
            double result = funCon(value);
            OnCalculate?.Invoke(this, result);
            return result;
        }
    }
}

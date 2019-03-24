using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    class ComposedMission : IMission
    {
        string name;
        IList<CalcDelegate> funs;
        public ComposedMission(string myName)
        {
            Name = myName;
            Type = "Composed";
            funs = new List<CalcDelegate>();
        }
        public String Name { get; }

        public String Type { get; }

        public event EventHandler<double> OnCalculate;

        public double Calculate(double value)
        {
            foreach (CalcDelegate fun in funs)
            {
                value = fun(value);
            }
            OnCalculate?.Invoke(this, value);
            return value;
        }
        public ComposedMission Add(CalcDelegate fun)
        {
            funs.Add(fun);
            return this;
        }
    }
}

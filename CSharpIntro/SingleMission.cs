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
        /// <summary>
        /// property
        /// </summary>
        public String Name { get; }
        /// <summary>
        /// property
        /// </summary>
        public String Type { get; }
        /// <summary>
        /// constructor - initialize the name, delegate and type
        /// </summary>
        /// <param name="fun"></param>
        /// <param name="myName"></param>
        public SingleMission(CalcDelegate fun, string myName)
        {
            Name = myName;
            Type = "Single";
            funCon = fun;
        }

        public event EventHandler<double> OnCalculate;
        /// <summary>
        /// the function calculates the new value and before it returns it, raises the event with the result
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public double Calculate(double value)
        {
            double result = funCon(value);
            // raise the event
            OnCalculate?.Invoke(this, result);
            return result;
        }
    }
}

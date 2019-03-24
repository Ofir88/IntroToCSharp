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
        /// <summary>
        /// constructor- initialize the name, list of delegates and type
        /// </summary>
        /// <param name="myName"></param>
        public ComposedMission(string myName)
        {
            Name = myName;
            Type = "Composed";
            funs = new List<CalcDelegate>();
        }
        /// <summary>
        /// property
        /// </summary>
        public String Name { get; }
        /// <summary>
        /// property
        /// </summary>
        public String Type { get; }

        public event EventHandler<double> OnCalculate;
        /// <summary>
        /// the function acticates all the function of the object on $value, and before it returns it, raises the event with the result
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public double Calculate(double value)
        {
            // going through all the delegates in the list
            foreach (CalcDelegate fun in funs)
            {
                value = fun(value);
            }
            // raise the event
            OnCalculate?.Invoke(this, value);
            return value;
        }
        /// <summary>
        /// the method adds a new delagate to the list of delegates
        /// </summary>
        /// <param name="fun"></param>
        /// <returns></returns>
        public ComposedMission Add(CalcDelegate fun)
        {
            funs.Add(fun);
            return this;
        }
    }
}

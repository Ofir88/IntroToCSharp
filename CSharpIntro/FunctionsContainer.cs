using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Excercise_1
{
    /// <summary>
    /// declaring the delagate
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    delegate double CalcDelegate(double x);
    class FunctionsContainer
    {
        /// <summary>
        /// the dictionary will map from the string we need to the matching delagate
        /// </summary>
        Dictionary<string, CalcDelegate> dic;
        /// <summary>
        /// constructor- initializing the dictionary
        /// </summary>
        public FunctionsContainer()
        {
            dic = new Dictionary<string, CalcDelegate>();
        }
        /// <summary>
        /// indexer for our object
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public CalcDelegate this [string idx]
        {
            get
            {
                CalcDelegate val;
                // if the value is already in the dictionary - just get it
                if (dic.TryGetValue(idx, out val))
                {
                    return val;
                } else // otherwise - add it as the identity function and return it
                {
                    dic[idx] = x => x;
                    return dic[idx];
                }
            }
            set
            {
                // add/set idx's value in the dictionary to $value
                dic[idx] = value;
            }
        }
        /// <summary>
        /// the function returns a list of all the functions the dictionary has
        /// </summary>
        /// <returns></returns>
        public List<string> getAllMissions()
        {
            return dic.Keys.ToList();
        }
    }
}

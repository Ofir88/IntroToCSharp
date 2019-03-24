using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Excercise_1
{
    delegate double CalcDelegate(double x);
    class FunctionsContainer
    {
        //delegate double CalcDelegate(double x);
        Dictionary<string, CalcDelegate> dic;
        public FunctionsContainer()
        {
            dic = new Dictionary<string, CalcDelegate>();
        }
        public CalcDelegate this [string idx]
        {
            get
            {
                CalcDelegate val;
                if (dic.TryGetValue(idx, out val))
                {
                    return val;
                } else
                {
                    dic[idx] = x => x;
                    return dic[idx];
                }
            }
            set
            {
                dic[idx] = value;
            }
        }
        public List<string> getAllMissions()
        {
            return dic.Keys.ToList();
        }
    }
}

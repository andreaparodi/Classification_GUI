using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classification_GUI
{
    //convertire da x, y a lista perchè altrimenti non si gestiscono più di 2 features
    class ClassifiedDatapoint
    {
        public List<double> attributes;
        public int label;

        public ClassifiedDatapoint()
        {
            attributes = new List<double>();
            label = 10;
        }
        public ClassifiedDatapoint(List<double> atr, int label_val)
        {
            attributes = atr;
            label = label_val;
        }
    }
    class UnclassifiedDatapoint
    {
        public List<double> attributes;

        public UnclassifiedDatapoint()
        {
            attributes = new List<double>();
        }
        public UnclassifiedDatapoint(List<double> atr)
        {
            attributes = atr;
        }
    }

}

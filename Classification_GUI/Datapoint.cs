using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classification_GUI
{
    class ClassifiedDatapoint
    {
        public double x;
        public double y;
        public int label;

        public ClassifiedDatapoint()
        {
            x = 0;
            y = 0;
            label = 10;
        }
        public ClassifiedDatapoint(double x_val, double y_val, int label_val)
        {
            x = x_val;
            y = y_val;
            label = label_val;
        }
    }
    class UnclassifiedDatapoint
    {
        public double x;
        public double y;
        
        public UnclassifiedDatapoint()
        {
            x = 0;
            y = 0;
            }
        public UnclassifiedDatapoint(double x_val, double y_val, int label_val)
        {
            x = x_val;
            y = y_val;
        }
    }

}

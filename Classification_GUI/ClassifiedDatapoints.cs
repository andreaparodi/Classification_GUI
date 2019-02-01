using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classification_GUI
{
    class ClassifiedDatapoints
    {
        public double x;
        public double y;
        public int label;

        public ClassifiedDatapoints()
        {
            x = 0;
            y = 0;
            label = 10;
        }
        public ClassifiedDatapoints(double x_val, double y_val, int label_val)
        {
            x = x_val;
            y = y_val;
            label = label_val;
        }
    }
    class Datapoints
    {
        public double x;
        public double y;
        
        public Datapoints()
        {
            x = 0;
            y = 0;
            }
        public Datapoints(double x_val, double y_val, int label_val)
        {
            x = x_val;
            y = y_val;
        }
    }

}

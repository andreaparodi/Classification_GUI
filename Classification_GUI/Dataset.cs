using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classification_GUI
{
    class Dataset
    {
        public List<ClassifiedDatapoint> classified_data;
        public List<UnclassifiedDatapoint> unclassified_data;

        public Dataset()
        {
        }

        public Dataset(string x)
        {
        }
    }
}

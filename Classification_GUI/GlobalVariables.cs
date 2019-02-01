using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classification_GUI
{
    class GlobalVariables
    {
        private int numberOfClasses = 2;

        private enum labelsColors
        {
            Blue = 1,
            Yellow = -1,
            Red = 0
        }

        public static string datasetFilePath = "";
        public static string DatasetFilePath
        {
            get { return datasetFilePath; }
            set { datasetFilePath = value; }
        }
    }
}

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

        public enum classifiers
        {
            KNN = 1,
            NeuralNetwork = 2,
            SVN = 3
        }
        //public List<int> classifiersList = new List<int>

        public static int selectedClassifier = 0;
        public static int SelectedClassifier
        {
            get { return selectedClassifier; }
            set { selectedClassifier = value; }
        }

        public static string datasetFilePath = "";
        public static string DatasetFilePath
        {
            get { return datasetFilePath; }
            set { datasetFilePath = value; }
        }
    }
}

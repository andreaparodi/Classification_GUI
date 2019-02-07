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

        #region classifiers parameters

        //TODO: enum per le etichette? in mdoo che se volessi cambiarle globalmente per qualche motivo le cambio qua invece di assegnarle puntualmente in tutte le assegnazioni
        public enum labelsStandardValue
        {
            pos = 1,
            neg = 0
        }
        //kNN
        public enum distanceMode
        {
            Euclidean = 1,
            Approx = 2
        }
        public static int voteModeValue;
        public static int VoteModeValue
        {
            get { return voteModeValue; }
            set { voteModeValue = value; }
        }

        public enum voteMode
        {
            Majority = 1,
            Weighted = 2
        }

        public static int kValue;
        public static int KValue
        {
            get { return kValue; }
            set { kValue = value; }
        }
            //NN

            //pseudoSVN


            #endregion classifiers parameters
        }
    }

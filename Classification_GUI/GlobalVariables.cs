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
        //fa riferimento all'enum sopra
        public static int selectedClassifier = 0;
        public static int SelectedClassifier
        {
            get { return selectedClassifier; }
            set { selectedClassifier = value; }
        }
        //percorso file da cui pescare i dati (impostato da utente tramite gui GuiForm
        public static string datasetFilePath = "";
        public static string DatasetFilePath
        {
            get { return datasetFilePath; }
            set { datasetFilePath = value; }
        }
        //numero di features del dataset, >=2 se =2 rappresentabile
        public static int datasetFeatures = 0;
        public static int DatasetFeatures
        {
            get { return datasetFeatures; }
            set { datasetFeatures = value; }
        }

        #region classifiers parameters

        //TODO: enum per le etichette? in mdoo che se volessi cambiarle globalmente per qualche motivo le cambio qua invece di assegnarle puntualmente in tutte le assegnazioni
        //per il momento supporta class binaria
        public enum labelsStandardValue
        {
            pos = 1,
            neg = 0,
            alterNeg =-1
        }

        //per il logger, livello del messaggio Errore/Debug/Info
        public static string sticazzi = "";

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

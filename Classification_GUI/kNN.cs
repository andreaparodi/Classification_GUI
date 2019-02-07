using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classification_GUI
{
    class kNN
    {
        int mode;
        int k;

        public kNN()
        {

        }

        public kNN(int knnMode, int kNum)
        {
            mode = knnMode;
            k = kNum;
        }

        //functions
        public int classificatePoint(UnclassifiedDatapoint datapoint, Dataset dataset)
        {
            int label = 0;
            //giusto per comodità
            int datasetSize = dataset.classified_data.Count();
            //serve per contenere le distanze che utilizzo in fase di voto
            double[] distances = new double[datasetSize];
            //serve in fase di voto (per semplificazione) per avere i primi k indici salvati e non dover passare anche la madonna alle funzioni di voto
            int[] classifiedLabels = new int[GlobalVariables.kValue];

            for (int i = 0; i < datasetSize; i++)
            {
                distances[i] = calculateDistance(dataset.classified_data[i], datapoint);
            }
            //ora ordino in maniera crescente distanze e punti 
            for (int i = 0; i < datasetSize; i++)
            {
                for (int j = 0; j < datasetSize; j++)
                {
                    if (distances[j] > distances[i])
                    {
                        double tmp = distances[i];
                        distances[i] = distances[j];
                        distances[j] = tmp;

                        ClassifiedDatapoint tempDP = dataset.classified_data[i];
                        dataset.classified_data[i] = dataset.classified_data[j];
                        dataset.classified_data[j] = tempDP;
                    }
                }

            }
            //TODO una volta ottenute le distanze e i punti ordinati trovo l'etichetta 
            for (int i = 0; i < GlobalVariables.kValue; i++)
            {
                classifiedLabels[i] = dataset.classified_data[i].label;
            }
            return label;
        }

        //restituisco una lista di punti classificati
        public List<ClassifiedDatapoint> classificateDataset(Dataset dataset)
        {
            List<ClassifiedDatapoint> outputPoints = new List<ClassifiedDatapoint>();
            int outputLabel;
            foreach (var point in dataset.unclassified_data)
            {
                outputLabel = classificatePoint(point, dataset);
                ClassifiedDatapoint classifiedPoint = new ClassifiedDatapoint(point.x, point.y, outputLabel);

                outputPoints.Add(classifiedPoint);
            }
            return outputPoints;
        }

        //mode può essere euclidea o approssimata
        //--TODO: non riceve un "dataset" ma un punto classificato
        public double calculateDistance(ClassifiedDatapoint classifiedPoint, UnclassifiedDatapoint unclassifiedPoint)
        {
            double dist=-1;

              switch (GlobalVariables.voteModeValue)
              {
                case (int)GlobalVariables.distanceMode.Euclidean:
                    {
                        dist = euclideanDistance(unclassifiedPoint, classifiedPoint);
                        break;
                    }
                case (int)GlobalVariables.distanceMode.Approx:
                    {
                        dist = approxDistance(unclassifiedPoint, classifiedPoint);
                        break;
                    }
                default:
                    {
                        throw new Exception("Non è stato selezionato nessun tipo di distanza!");
                    }
              }
        return dist;
        }
        
        public double euclideanDistance(UnclassifiedDatapoint UCpoint, ClassifiedDatapoint CLpoint)
        {
            return Math.Sqrt( Math.Pow((UCpoint.x-CLpoint.x),2) + Math.Pow((UCpoint.y-CLpoint.y),2) );
        }
        //TODO: è cosi cioè |d1|+|d2| oppure |d1 + d2| oppure |d1 - d2|
        public double approxDistance(UnclassifiedDatapoint UCpoint, ClassifiedDatapoint CLpoint)
        {
            return (Math.Abs(UCpoint.x - CLpoint.x) + Math.Abs(UCpoint.y - CLpoint.y));
        }
        public int findLabel(double[] dist, int[] knownLabels)
        {
            int label = 0;
            float temp = 0;
            switch (GlobalVariables.voteModeValue)
            {
                case (int)GlobalVariables.voteMode.Majority:
                    {
                        for (int i = 0; i < GlobalVariables.kValue; i++)
                        {
                            temp += knownLabels[i];
                        }
                        if (temp > Math.Floor(temp / 2))
                            temp = (float)GlobalVariables.labelsStandardValue.pos;
                        else
                            temp = (float)GlobalVariables.labelsStandardValue.neg;
                        break;
                    }
                case (int)GlobalVariables.voteMode.Weighted:
                    {
                        break;
                    }
                default:
                    {
                        throw new Exception("Non definito il modo in cui viene stabilita l'etichetta");
                    }
            }
        return label;
        }

        double voteWeight(double distance)
        {
            double w = 0;

            w=1/(1+distance);

            return w;
        }
    }
}

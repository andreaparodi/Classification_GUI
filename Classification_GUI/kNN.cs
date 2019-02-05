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
            double[] distances = new double[datasetSize];

            for (int i = 0; i < datasetSize; i++)
            {
                distances[i] = calculateDistance(dataset, datapoint);
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




             /*
             for (int i = 0; i <nOfSamples; i++)
	{
		for (int j = 0; j < nOfSamples; j++)
		{
			if (distances[j] > distances[i])
			{
				float tmp = distances[i];
				distances[i] = distances[j];
				distances[j] = tmp;

				int tmpIndex = index[i];
				index[i] = index[j];
				index[j] = tmpIndex;
			}
		}
}
             */
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
        public double calculateDistance(Dataset dataset, UnclassifiedDatapoint point)
        {
            double dist=-1;

              switch (GlobalVariables.voteModeValue)
              {
                case (int)GlobalVariables.distanceMode.Euclidean:
                    {
                        
                        break;
                    }
                case (int)GlobalVariables.distanceMode.Approx:
                    {
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
        public double approxDistance(UnclassifiedDatapoint UCpoint, ClassifiedDatapoint CLpoint)
        {
            return (Math.Abs(UCpoint.x - CLpoint.x) + Math.Abs(UCpoint.y - CLpoint.y));
        }
        
    }
}

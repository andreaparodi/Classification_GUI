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

        //lascio vuoto e aggiungo poi con funzione punto per punto?
        public Dataset()
        {
            classified_data = new List<ClassifiedDatapoint>();
            unclassified_data = new List<UnclassifiedDatapoint>();
        }
        //la funzione così definita verrà chiamata nella funzione TODO di lettura dati da file e ad ogni punto letto lo aggiunge
        //volendo si può difinire di tipo bool e restituire il list.contains point come verifica
        public void addClassifiedPoint(ClassifiedDatapoint point)
        {
            classified_data.Add(point);
        }
        public void addClassifiedPoint(UnclassifiedDatapoint point)
        {
            unclassified_data.Add(point);
        }
        //TODO
        //organizzo i dati come .csv?
        //posso fare 3 colonne sempre o leggere il numero di punti e virgola nella prima riga e capirlo da quello
        //importante pensare come gestire il multidimensione rispetto a dati 2D => piu dimensioni disabilita la visualizzazione

        public static void readDataFromFile(string pathDataFile)
        {
            //immagino di leggere dati
            string[] sticazzi;
            //readfile bla bla bla ...
            //per ogni indice dell'array di stringhe vi sarà una riga del file = un punto

            try { }
            catch (Exception e)
            {
                
            }



        }
        /*
        public Dataset(string x)
        {
        }
        */
    }
}

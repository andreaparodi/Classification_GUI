using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Classification_GUI
{
    class NN
    {
        public int hiddenNodesnumber = 0;
        public int hiddenLayersNumber = 0;
        public int featuresInputNUmber = 0;
        public int classesNumber = 0;

        //test
        public Layer inputLayer;
        public Layer outputLayer;
        public List<Layer> hiddenLayerMatrix;
        //da togliere
        //public List<Node> inputLayer;
        //public List<Node> outputLayer;

        public NN()
        {
            hiddenNodesnumber = GlobalVariables.numberOfHiddenNodes;
            hiddenLayersNumber = GlobalVariables.numberOfHiddenLayers;
            //inputLayer = new List<Node>();
            //outputLayer = new List<Node>();

            inputLayer = new Layer((int)GlobalVariables.nnNodeType.Input);
            outputLayer = new Layer((int)GlobalVariables.nnNodeType.Output);

            hiddenLayerMatrix = new List<Layer>();
        }
        //non serve a nulla per ora 
        public void addLayer(int type)
        {
            if (type == (int)GlobalVariables.nnNodeType.Input)
            {
                Layer il = new Layer(type);
                for(int i=0;i<GlobalVariables.inputFeatures;i++)
                {
                    il.addNode(type);
                }
                this.inputLayer = il;
                
            }
            else if (type == (int)GlobalVariables.nnNodeType.Hidden)
            {
                //se non è nulla la inizializzo
                if (this.hiddenLayerMatrix.Count() == 0)
                {
                    this.hiddenLayerMatrix = new List<Layer>();
                }
                Layer hl = new Layer(type);
                //se il count dei livelli hidden è uguale al totale meno uno vuol dire che sto creando l'ultimo layer hid e devo scriverlo nella apposita var globale
                if (this.hiddenLayerMatrix.Count() == GlobalVariables.numberOfHiddenLayers - 1)
                {
                    GlobalVariables.ultimoLayerHidden = true;
                    /*
                    for (int i = 0; i < GlobalVariables.classesNumber; i++)
                    {
                        hl.addNode(type);
                    }
                    */
                }
                //else
                //{ 
                    for (int i = 0; i < GlobalVariables.numberOfHiddenNodes; i++)
                    {
                        hl.addNode(type);
                    }   
                //}

                this.hiddenLayerMatrix.Add(hl);
                //resetto anche il flag
                GlobalVariables.ultimoLayerHidden = false;
            }
            else if (type == (int)GlobalVariables.nnNodeType.Output)
            {
                Layer ol = new Layer(type);
                for (int i = 0; i < GlobalVariables.classesNumber; i++)
                {
                    ol.addNode(type);
                }
                this.outputLayer = ol;
            }
            //if (type != (int)GlobalVariables.nnNodeType.Input || type != (int)GlobalVariables.nnNodeType.Hidden || type != (int)GlobalVariables.nnNodeType.Output)
            else //(type != (int)GlobalVariables.nnNodeType.Input || type != (int)GlobalVariables.nnNodeType.Hidden || type != (int)GlobalVariables.nnNodeType.Output)
            {
                throw new Exception("Tipo di nodo per rete neurale non riconosciuto!");
            }
        }
        public void initializeNetwork()
        {
            this.addLayer((int)GlobalVariables.nnNodeType.Input);
            for (int i = 0; i < GlobalVariables.numberOfHiddenLayers; i++)
            {
                this.addLayer((int)GlobalVariables.nnNodeType.Hidden);
            }
            this.addLayer((int)GlobalVariables.nnNodeType.Output);
        }
    }

    //valutare se fare 3 tipi
    class Node
    {
        //valutare se punto di sopra e fare un tipo apposito
        public int type = 0;
        public double value;
        public List<double> weights;

        public Node()
        {
            weights = new List<double>();
        }
        //TODO così funziona a unico layer hidden ma non se multipli
        public Node(int nodeType)
        {
            type = nodeType;
            int nodenumber = 0;
            if (nodeType == (int)GlobalVariables.nnNodeType.Input)
                nodenumber = GlobalVariables.numberOfHiddenNodes;
            //se non è l'ultimo layer hidden ne ho successivi dopo ergo i pesi devono essere uguali al numero di nodi hidden per livello
            else if (nodeType == (int)GlobalVariables.nnNodeType.Hidden && !GlobalVariables.ultimoLayerHidden)
                nodenumber = GlobalVariables.numberOfHiddenNodes;
            //se invece è lulitmo livello hidden esso si connette a quello di out e quindi ha tanti pesi quante classi (=numero nodi out)
            else if (nodeType == (int)GlobalVariables.nnNodeType.Hidden && GlobalVariables.ultimoLayerHidden)
                nodenumber = GlobalVariables.classesNumber;
            //implicito un else per gli output nodes che hanno zero pesi (di default)

            weights = new List<double>(nodenumber);
            for (int i = 0; i < nodenumber; i++)
            {
                weights.Add(0);
            }
        }
        public void randomizeNode()
        {
            //questo è un problema perchè girando voeloce a nastro becca sempre lo stesso millisecondo 
            //Random rnd = new Random(DateTime.Now.Millisecond);

            //questo funge
            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            // -.5 perchè rnd restituisce tra 0 ed 1 e io voglio tra -0.5 e 0.5
            this.value = rnd.NextDouble() - 0.5;
            
            //this.value
            for (int i = 0; i < this.weights.Count(); i++)
            {
                this.weights[i] = rnd.NextDouble() - 0.5;
            }
        }
    }
    //da verificare che così funzioni cioè facendo una lista nuova 
    class Layer
    {
        public List<Node> nodes;
        public int type=0;

        public Layer()
        {
            nodes = new List<Node>();
        }
        //al momento inutile
        public Layer(int nodeType)
        {
            type = nodeType;
            nodes = new List<Node>();
        }
        public void addNode(int type)
        {
            Node n = new Node(type);
            n.randomizeNode();
            this.nodes.Add(n);
        }
    }
}

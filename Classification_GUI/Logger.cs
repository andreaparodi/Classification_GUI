using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classification_GUI
{
    class Logger
    {
        //anche qui potrebbero essere campi rindondnati con informazioni del global
        string message;
        string logFilePath;

        public Logger()
        {
        }

        public Logger(string logPathFile)
        {
            logFilePath = logPathFile;
        }

        public void Log()
        {
            //cerco il file
            //searchFIle(this.logFilePath)

            //TODO creo la string da srivere: Data+Livello+
        }
    }
}

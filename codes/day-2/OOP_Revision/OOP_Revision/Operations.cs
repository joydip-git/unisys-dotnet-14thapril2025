using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Revision
{
    internal class DataOperations : IOperations, IData
    {
        string data;
        public string Data
        {
            get => data;
        }
        public void ReadData()
        {
            data = "data";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionMsSql
{
    class Processor
    {
        public int Id { get; set; }
        public string Family { get; set; }
        public string Socket { get; set; }
        public string Generation { get; set; } 
        public byte Cores { get; set; }
        public double CoreSpeed { get; set; }
        public double BusSpeed { get; set; }
        public bool Graphics { get; set; }
        public int Price { get; set; }

        public string Info { get { return ShortInfo(); } }
        //----------------------------------------------------------------------
        public string ShortInfo()
        {
            return String.Format("{0} [{1} cores, {2} GHz] - {3} UAN", Family, Cores, CoreSpeed, Price);
        }
        //----------------------------------------------------------------------
        public string FullInfo()
        {
            return String.Format("Intel {0} {1} ({2}) [{3} cores, {4} GHz, {5} GT] - {6} UAN",
                Family, Socket, Generation, Cores, CoreSpeed, BusSpeed, Price);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ibu_hamilll.model
{
    public class MO_Saran 
    {
        public string Saran { get; set; }

        public string Lifestyle { get; set; }
        public MO_Saran() { }

        public MO_Saran(string saran, string lifestyle)
        {
            Saran = saran;
            Lifestyle = lifestyle;
        }
    }
}

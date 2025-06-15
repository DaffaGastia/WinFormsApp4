using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ibu_hamilll.model
{
    public class MO_Lanjutan
    {
        public int id { get; set; }
        public string KeluhanLanjutan { get; set; }

        public MO_Lanjutan() { }

        public MO_Lanjutan(int id, string keluhanLanjutan)
        {
            this.id = id;
            this.KeluhanLanjutan = keluhanLanjutan;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4.Model
{
    public interface IKonsultasiService<T>
    {
        bool UpdateGejalaLanjutan(T data);
        DataTable AmbilDataAkunTerakhirUntukTabel();
        M_Konsultasi AmbilKonsultasiById(int id);
        M_Obat ObatL(M_Lanjutan data);
    }
}

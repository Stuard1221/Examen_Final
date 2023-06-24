using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_final
{
    internal class Shared
    {
        public static string ConnectionString { get {
                return "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Estuardo\\Escritorio\\Examen Final\\Database1.mdf\";Integrated Security=True";
            }
        }
    }
}

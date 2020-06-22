using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUBiblioteca.Transactions
{
    public class CategoriaBLL
    {
        public static List<Categoria> List()
        {
            DBEntities db = new DBEntities();
            return db.Categoria.ToList();
        }
    }
}

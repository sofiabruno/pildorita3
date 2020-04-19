using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;
using System.Data.SqlClient;

namespace Repositorios
{
    public class RepoImportaciones : IRepositorio<Importacion>
    {
        public bool Alta(Importacion obj)
        {
            throw new NotImplementedException();
        }

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public Importacion BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Modificacion(Importacion obj)
        {
            throw new NotImplementedException();
        }

        public List<Importacion> TraerTodos()
        {
            throw new NotImplementedException();
        }
    }
}

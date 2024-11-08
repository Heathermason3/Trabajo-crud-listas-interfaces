using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos 
{


    public interface IConnection : IParameter
    {
        void CreateCommand(string storeprocedure, string referente);
        int Insert();

        void InsertWithoutID();

        bool Exists();

        void Update();

        void Delete();

        DataTable List();

        DataRow Find();
    }
}
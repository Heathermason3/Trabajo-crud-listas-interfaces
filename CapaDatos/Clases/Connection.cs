using CapaDatos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Clases
{
    internal class Connection : IBasicconnection, IConnection
    {
        static Connection instance = new Connection();
        public static Connection GetInstance => instance;
        private Connection()
        {
            string PathConfig = AppDomain.CurrentDomain.BaseDirectory + "web.config";
            if (File.Exists(PathConfig))
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
                MyConnection = new SqlConnection(ConnectionString);
                return;
            }
            throw new Exception("ERROR: No se encontro la base de datos");
        }
        public void OpenConnection()
        {
            if(MyConnection.State != ConnectionState.Open)
            {
                try
                {
                    MyConnection.Open();
                }
                catch (Exception)
                {
                    throw new Exception("ERROR: No se pudo abrir la conexion");
                }
            }
        }
        #region IBasicconnection
        public SqlConnection MyConnection { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SqlCommand MyCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Referente { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

        #region IConnection
        public void CreateCommand(string storeprocedure, string referente)
        {
            MyCommand = new SqlCommand(storeprocedure, MyConnection);
            MyCommand.CommandType = CommandType.StoredProcedure;
            Referente = referente;
        }

        public void Delete()
        {
            OpenConnection();
            try
            {
                MyCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("ERROR: No se pudo eliminar el registro" + Referente);
            }
            finally
            {
                MyConnection.Close();
            }
        }

        public bool Exists()
        {
            OpenConnection();
            try
            {
                int i = int.Parse(MyCommand.ExeceuteScalar().ToString());
                return i > 0;
            }
            catch (Exception)
            {
                throw new Exception("ERROR: No se pudo encontrar" + Referente);
            }
            finally { MyConnection.Close(); }
        }

        public DataRow Find()
        {
            throw new NotImplementedException();
        }

        public int Insert()
        {
            OpenConnection();
            try
            {
                int i = int.Parse(MyCommand.ExeceuteScalar().ToString());
                return i;
            }
            catch (Exception)
            {
                throw new Exception("ERROR: No se pudo agregar" + Referente);
            }
            finally { MyConnection.Close(); }
        }

        public void InsertWithoutID()
        {
            OpenConnection();
            try
            {
                MyCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("ERROR: No se pudo encontrar" + Referente);
            }
            finally { MyConnection.Close(); }
        }

        public DataTable List()
        {
            throw new NotImplementedException();
        }

        public void OpenConnection()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

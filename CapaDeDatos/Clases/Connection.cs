using CapaDeDatos.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class Connection : IBasicConnection, IConnection
    {
        public SqlConnection MyConnection { get; set; }
        public SqlCommand MyCommand { get; set; }
        public string Referente { get; set; }
        public string ConnectionString { get; set; }


        public static  Connection instance = new Connection();
        public static Connection GetInstance => instance;
        private Connection()
        {
            string PathConfig = AppDomain.CurrentDomain.BaseDirectory + "Web.Config";
            if (File.Exists(PathConfig))
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
                MyConnection = new SqlConnection(ConnectionString);
                return;
            }
            throw new Exception("ERROR: No de encontró la base de datos");
        }
        public void OpenConnection()
        {
            if (MyConnection.State == ConnectionState.Open)
            {
                try
                {
                    MyConnection.Open();
                }
                catch (Exception)
                {
                    throw new Exception("ERROR: no se pudo abrir la conexión.");
                }
            }
        }
        public void CreateCommand(string storeprocedure, string refetente)
        {
            MyCommand = new SqlCommand(storeprocedure, MyConnection);
            MyCommand.CommandType = CommandType.StoredProcedure;
            Referente = refetente;
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
                int i = int.Parse(MyCommand.ExecuteScalar().ToString());
                return i > 0;
            }
            catch (Exception)
            {
                throw new Exception("ERROR: no de pudo encontrar " + Referente);
            }
            finally { MyConnection.Close(); }
        }

        public int Insert()
        {
            OpenConnection();
            try
            {
                int i = int.Parse(MyCommand.ExecuteScalar().ToString());
                return i; 
            }
            catch (Exception)
            {
                throw new Exception("ERROR: no de pudo agregar " + Referente);
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
                throw new Exception("ERROR: No se pudo insertar el registro");
            }
            finally
            {
                MyConnection.Close();
            }
        }

        public DataTable List()
        {
            OpenConnection();
            try
            {
                DataTable DT = new DataTable();
                DT.Load(MyCommand.ExecuteReader()); 
                return DT;
            }
            catch (Exception)
            {
                throw new Exception("ERROR: no de pudo listar " + Referente);
            }
            finally { MyConnection.Close(); }
        }
        public DataRow Find()
        {
            OpenConnection();
            try
            {
                DataTable DT = new DataTable();
                DT.Load(MyCommand.ExecuteReader()); 
                return DT.Rows[0];
            }
            catch (Exception)
            {
                throw new Exception("ERROR: no de pudo encontrar " + Referente);
            }
            finally { MyConnection.Close(); }
        }

        public void Update()
        {
            OpenConnection();
            try
            {
                MyCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("ERROR: No se pudo actualizar el registro");
            }
            finally
            {
                MyConnection.Close();
            }
        }

        public void ParameterAddVarChar(string Name, string Value)
        {
            MyCommand.Parameters.AddWithValue("@" + Name, Value);
        }

        public void ParameterAddInt(string Name, int Value)
        {
            MyCommand.Parameters.AddWithValue("@" + Name, Value);
        }

        public void ParameterAddBool(string Name, bool Value)
        {
            MyCommand.Parameters.AddWithValue("@" + Name, Value);
        }

        public void ParameterAddDateTime(string Name, DateTime Value)
        {
            MyCommand.Parameters.AddWithValue("@" + Name, Value);
        }

        public void ParameterAddFloat(string Name, double Value)
        {
            MyCommand.Parameters.AddWithValue("@" + Name, Value);
        }
    }
}

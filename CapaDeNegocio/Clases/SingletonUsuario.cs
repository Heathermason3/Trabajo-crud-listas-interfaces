using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using CapaDeNegocio.Interfaces;
using System.Data;
using CapaDatos;
using CapaDeDatos;

namespace CapaDeNegocio
{
    public partial class Singleton : ISingletonUsuario
    {
        public ISingletonUsuario ISU { get => this; }
        public IConnection conect { get => (IConnection)this; }
        public JsonConverter convert = new JsonConverter();
        void IGenericSingleton<Usuario>.Add(Usuario Data)
        {
            if (Data.DniExist()) throw new Exception("Existe otro usuario con el mismo Dni");
            if (Data.MailExist()) throw new Exception("Existe otro usuario con el mismo Mail");

            conect.CreateCommand("Usuarios_Insert", "Usuario");
            conect.ParameterAddVarChar("Nombre", Data.Nombre);
            conect.ParameterAddInt("Dni", Data.Dni);
            conect.ParameterAddVarChar("Mail", Data.Mail);
            Data.ID = conect.Insert(); // devuelve la primera columna de la primera fila, o sea el ID
        }

        void IGenericSingleton<Usuario>.Erase(Usuario Data)
        {
            conect.CreateCommand("Usuarios_Delete", "Usuarios");
            conect.ParameterAddInt("ID", Data.ID);
            conect.Delete();
        }

        string IGenericSingleton<Usuario>.Find(Usuario Data)
        {
            conect.CreateCommand("Usuarios_Find", "Usuario");
            conect.ParameterAddInt("ID", Data.ID);
            DataRow Dr = conect.Find();
            return convert.RowToJson(Dr);
        }

        void IGenericSingleton<Usuario>.Modify(Usuario Data)
        {
            if (Data.DniExist()) throw new Exception("Existe otro usuario con el mismo Dni");
            if (Data.MailExist()) throw new Exception("Existe otro usuario con el mismo Mail");

            conect.CreateCommand("Usuarios_Update", "Usuario");
            conect.ParameterAddInt("ID", Data.ID);
            conect.ParameterAddVarChar("Nombre", Data.Nombre);
            conect.ParameterAddInt("Dni", Data.Dni);
            conect.ParameterAddVarChar("Mail", Data.Mail);
            conect.Update();
        }
        bool ISingletonUsuario.MailExist(Usuario Data)
        {
            conect.CreateCommand("Usuarios_MailExists", "Usuarios");
            conect.ParameterAddInt("ID", Data.ID);
            conect.ParameterAddVarChar("Mail", Data.Mail);
            return conect.Exists();
        }

        bool ISingletonUsuario.DniExist(Usuario Data)
        {
            conect.CreateCommand("Usuarios_DniExists", "Usuarios");
            conect.ParameterAddInt("ID", Data.ID);
            conect.ParameterAddInt("Dni", Data.Dni);
            return conect.Exists();
        }

        string ISingletonUsuario.FindByDni(Usuario Data)
        {
            conect.CreateCommand("Usuarios_FindByDni", "Usuario");
            conect.ParameterAddInt("Dni", Data.Dni);
            DataRow Dr = conect.Find();
            return convert.RowToJson(Dr);
        }

        string ISingletonUsuario.FindByMail(Usuario Data)
        {
            conect.CreateCommand("Usuarios_FindByMail", "Usuarios");
            conect.ParameterAddVarChar("Mail", Data.Mail);
            DataRow Dr = conect.Find();
            return convert.RowToJson(Dr);
        }
        string ISingletonUsuario.List()
        {
            try
            {
                conect.CreateCommand("Usuarios_List", "Usuario");
                DataTable Dt = conect.List();
                return convert.TableToJson(Dt);
            }
            catch (Exception)
            {
                throw new Exception("ERROR: no se pudo listar los usuarios");
            }

        }
    }
}

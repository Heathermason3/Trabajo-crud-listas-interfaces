using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CapaDeDatos;
namespace CapaDeNegocio
{
    public class Usuario : IUsuario
    {  

        public int ID { get ; set ; }

       
        public string Nombre { get ; set ; }
        public int Dni { get; set; }
        public string Mail { get; set; }

        public bool DniExist(int dni)
        {
            return false;           
        }
        public bool MailExist(string mail)
        {
            return false;
        }
        
        public Usuario FindDni(int dni)
        {
            throw new Exception("No se ha encontrado ningun usuario con este dni");
        }

        public Usuario FindMail(string mail)
        {
            throw new Exception("No se ha encontrado ningun usuario con este mail");
        }
      
        public bool DniExist()
        {
            throw new NotImplementedException();
        }

        public bool MailExist()
        {
            throw new NotImplementedException();
        }

        public string FindMail()
        {
            throw new NotImplementedException();
        }

        public string FindDni()
        {
            throw new NotImplementedException();
        }

        string IABMC.Find()
        {
            throw new NotImplementedException();
        }

        public void Modify()
        {
            throw new NotImplementedException();
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Erase()
        {
            throw new NotImplementedException();
        }
    }
}

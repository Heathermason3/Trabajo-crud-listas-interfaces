using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;

namespace CapaDeNegocio.Interfaces
{
    public interface ISingletonUsuario : IGenericSingleton<Usuario>
    {
        bool DniExist(Usuario Data);
        bool MailExist(Usuario Data);
        string FindByMail(Usuario Data);
        string FindByDni(Usuario Data);

        //string Login(Usuario Data);
        string List();

    }
}

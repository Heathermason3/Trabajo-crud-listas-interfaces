using CapaDeDatos;
using CapaDeNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio.Clases
{
    public partial class Singleton : ParentSingleton
    {
        static Singleton instance = new Singleton();
        private Singleton() { }
        public static Singleton GetIntance => instance;
    }
}

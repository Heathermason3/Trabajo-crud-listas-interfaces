using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Interfaces
{
    internal interface IGenericSingleton<T>
    {
        void Add(T Data);
        void Erase(T Data);
        void Modify(T Data);
        string Find(T Data);
    }
}

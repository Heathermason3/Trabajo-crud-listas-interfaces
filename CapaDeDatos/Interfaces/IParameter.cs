using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public interface IParameter
    {

        void ParameterAddVarChar(string Name, string Value);

        void ParameterAddInt(string Name, int Value);

        void ParameterAddBool(string Name, bool Value);

        void ParameterAddDateTime(string Name, System.DateTime Value);
        void ParameterAddFloat(string Name, double Value);
    }
}

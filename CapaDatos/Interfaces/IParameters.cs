﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Interfaces
{
    internal interface IParameters
    {
        void ParameterAddVarChar(string name, int len, string Value);
        void ParameterAddInt(string name, int Value);
        void ParameterAddBool(string name, bool Value);
        void ParameterAddDateTime(string Name, System.DateTime Value);
        void ParameterAddFloat(string Name, double Value);
    }
}

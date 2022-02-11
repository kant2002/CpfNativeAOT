using System;
using System.Collections.Generic;
using System.Text;

namespace CPFApplication1
{
    public class ItemData : CPF.CpfObject
    {
        public string Name
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string Introduce
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}

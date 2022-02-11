using System;
using System.Collections.Generic;
using System.Text;
using CPF;

namespace CPFApplication1
{
    public class NodeData : CPF.CpfObject
    {
        public NodeData()
        {
            Nodes = new Collection<NodeData>();
        }
        public string Text
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public Collection<NodeData> Nodes
        {
            get { return GetValue<Collection<NodeData>>(); }
            set { SetValue(value); }
        }

        public bool IsChecked
        {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }
    }
}

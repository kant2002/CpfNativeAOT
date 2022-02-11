using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CPF;

namespace CPFApplication1
{
    public class Model : CpfObject
    {
        public Model()
        {
            var data = new DataTable();
            for (int i = 0; i < 9; i++)
            {
                data.Columns.Add("p" + (i + 1).ToString());
            }
            data.Columns[1].DataType = typeof(bool);
            data.Columns[3].DataType = typeof(int);
            for (int i = 0; i < 100; i++)
            {
                var row = data.NewRow();
                for (int j = 0; j < 9; j++)
                {
                    if (j != 1)
                    {
                        row[j] = i;
                    }
                }
                row[0] = i % 3;
                row[1] = true;
                data.Rows.Add(row);
            }
            Data = data.ToItems();



            Collection<node> nodes = new Collection<node>();
            for (int i = 0; i < 10; i++)
            {
                var n = new node { Text = "节点dsff" + i };
                for (int j = 0; j < 2; j++)
                {
                    var nn = new node { Text = "节点fsadad" + i + j };
                    for (int l = 0; l < 3; l++)
                    {
                        nn.Nodes.Add(new node { Text = "节点" });
                    }
                    n.Nodes.Add(nn);
                }
                nodes.Add(n);
            }
            Nodes = nodes;

            Collection<string> list = new Collection<string>();
            for (int i = 0; i < 100000; i++)
            {
                list.Add(i.ToString());
            }
            List = list;
        }
        public IList Data
        {
            get { return (IList)GetValue(); }
            set { SetValue(value); }
        }

        public IList<node> Nodes
        {
            get { return (IList<node>)GetValue(); }
            set { SetValue(value); }
        }

        public IList List
        {
            get { return (IList)GetValue(); }
            set { SetValue(value); }
        }

        public void AddNode()
        {
            Nodes.Add(new node { Text = "哈哈哈" });
        }

        public int InsertIndex { get { return GetValue<int>(); } set { SetValue(value); } }
        public string InsertText { get { return GetValue<string>(); } set { SetValue(value); } }
        public void Insert()
        {
            string data = InsertText;
            int index = InsertIndex;
            if (string.IsNullOrWhiteSpace(data))
            {
                return;
            }
            if (index < 0 || index > List.Count)
            {
                List.Add(data);
            }
            else
            {
                List.Insert(index, data);
            }
        }

        public int SelectIndex
        {
            get { return (int)GetValue(); }
            set { SetValue(value); }
        }

        public void RemoveSelect()
        {
            if (List.Count > SelectIndex && SelectIndex > -1)
            {
                List.RemoveAt(SelectIndex);
            }
        }
        /// <summary>
        /// 点击获取行号
        /// </summary>
        /// <param name="getRowId"></param>
        public void ClickCell(Func<int> getRowId)
        {
            System.Diagnostics.Debug.WriteLine(getRowId());
        }

        public string SelectValue
        {
            get { return (string)GetValue(); }
            set { SetValue(value); }
        }
        //[PropertyMetadata("默认值")]
        public string TextSize
        {
            get { return (string)GetValue(); }
            set { SetValue(value); }
        }
    }


    public class node
    {
        public object Text { get; set; }

        public List<node> Nodes { get; set; } = new List<node>();
    }
}

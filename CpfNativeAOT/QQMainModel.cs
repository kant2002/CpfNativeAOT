using CPF;
using CPF.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPFApplication1
{
    public class QQMainModel : CpfObject
    {
        public QQMainModel()
        {
            Messages = new Collection<(string name, string last)>();
            for (int i = 0; i < 20; i++)
            {
                Messages.Add(("名称" + i, "最新一条消息" + i));
            }
            Groups = new Collection<(string, Collection<(string, string)>)>();
            var groups = Groups;
            for (int i = 0; i < 50; i++)
            {
                var list = new Collection<(string, string)>();
                for (int j = 0; j < 100; j++)
                {
                    list.Add(("昵称" + i, "个人签名" + i));
                }
                groups.Add(("名称" + i, list));
            }
        }

        public Collection<(string, Collection<(string, string)>)> Groups
        {
            get { return GetValue<Collection<(string, Collection<(string, string)>)>>(); }
            set { SetValue(value); }
        }

        public Collection<(string name, string last)> Messages
        {
            get { return GetValue<Collection<(string, string)>>(); }
            set { SetValue(value); }
        }

        public void ClickMessageItem(MessageItem messageItem)
        {
            new QQChat().Show();
        }
    }
}

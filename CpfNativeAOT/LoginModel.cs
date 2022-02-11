using System;
using System.Collections.Generic;
using System.Text;
using CPF;
using CPF.Drawing;

namespace CPFApplication1
{
    public class LoginModel : CpfObject
    {
        public LoginModel()
        {
            UserList = new Collection<(Image, string, string)>();
            LoadData();
        }

        async void LoadData()
        {
            var img = await CPF.Styling.ResourceManager.GetImage("res://CpfNativeAOT/Resources/headQQ.png");
            for (int i = 0; i < 10; i++)
            {
                UserList.Add((img, "小红帽" + i, "11111111" + i));
            }
        }

        public Collection<(Image, string, string)> UserList
        {
            get { return GetValue<Collection<(Image, string, string)>>(); }
            set { SetValue(value); }
        }

        public void RemoveUserItem(CpfObject cpfObject)
        {
            var item = ((Image, string, string))cpfObject.DataContext;
            UserList.Remove(item);
        }

        public string Password
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string QQ
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}

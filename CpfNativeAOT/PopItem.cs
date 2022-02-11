using System;
using System.Collections.Generic;
using System.Text;
using CPF;
using CPF.Drawing;
using CPF.Controls;
using CPF.Shapes;
using CPF.Styling;
using CPF.Animation;
using CPF.Input;

namespace CPFApplication1
{
    public class PopItem : ListBoxItem
    {
        protected override void InitializeComponent()
        {//模板定义
            if (DesignMode)
            {
                Background = "#fff";
                Width = 300;
            }
            else
            {
                Width = "100%";
            }
            Height = "50";

            Triggers.Add(new Trigger { Property = nameof(IsMouseOver), Setters = { { nameof(Background), "100,100,100,100" } } });
            Children.Add(new Ellipse
            {
                IsAntiAlias = true,
                MarginLeft = 15f,
                Width = 35f,
                Height = 35f,
                StrokeFill = "#fff",
                Fill = new TextureFill
                {
                    Stretch = Stretch.Fill,
                    Bindings =
                    {
                        {nameof(DataContext),nameof(DataContext),this },
                        {nameof(TextureFill.Image),"Item1" }
                    }
                }
            });
            Children.Add(new TextBlock
            {
                MarginLeft = 63.5f,
                MarginTop = 7.3f,
                Text = "TextBlock1",
                Bindings =
                {
                    {nameof(TextBlock.Text),"Item2" }
                }
            });
            Children.Add(new TextBlock
            {
                Foreground = "#7E7E7E",
                MarginLeft = 62.1f,
                MarginTop = 25.6f,
                Text = "TextBlock2",
                Bindings =
                {
                    {nameof(TextBlock.Text),"Item3" }
                }
            });
            Children.Add(new CPF.Svg.SVG
            {
                Height = "Auto",
                Width = 12f,
                Fill = "#7E7E7E",
                MarginRight = 10f,
                Stretch= Stretch.Uniform,
                ToolTip = "删除账号信息",
                Source= "<svg p-id=\"2132\" width=\"16\" height=\"16\"><path d=\"M583.168 523.776L958.464 148.48c18.944-18.944 18.944-50.176 0-69.12l-2.048-2.048c-18.944-18.944-50.176-18.944-69.12 0L512 453.12 136.704 77.312c-18.944-18.944-50.176-18.944-69.12 0l-2.048 2.048c-19.456 18.944-19.456 50.176 0 69.12l375.296 375.296L65.536 899.072c-18.944 18.944-18.944 50.176 0 69.12l2.048 2.048c18.944 18.944 50.176 18.944 69.12 0L512 594.944 887.296 970.24c18.944 18.944 50.176 18.944 69.12 0l2.048-2.048c18.944-18.944 18.944-50.176 0-69.12L583.168 523.776z\" p-id=\"2133\"></path></svg>",
                Commands =
                {
                    {nameof(MouseDown),nameof(LoginModel.RemoveUserItem),null,CommandParameter.EventSender },
                    {nameof(MouseDown),(s,e)=>{(e as MouseButtonEventArgs).Handled=true; } },
                }
            });
            Commands.Add(nameof(MouseDown), nameof(Popup.Hide), a=>a.Root);
        }
    }
}

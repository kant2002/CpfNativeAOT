using System;
using System.Collections.Generic;
using System.Text;
using CPF.Controls;
using CPF.Drawing;
using CPF.Shapes;
using CPF.Styling;
using CPF.Input;
using CPF;
using CPF.Svg;

namespace CPFApplication1
{
    public class DialogView : Control
    {
        public DialogView(Window2 window)
        {
            this.window = window;
        }
        Window2 window;
        protected override void InitializeComponent()
        {
            //模板定义
            IsAntiAlias = true;
            Background = "#fff";
            CornerRadius = "8";
            Width = 448.8f;
            Height = 224.4f;
            ViewFill color = "#888";
            ViewFill hoverColor = "255,255,255,40";
            Children.Add(new TextBlock
            {
                Text = "标题",
                FontSize = 16,
                MarginTop = 8,
                MarginLeft = 10
            });
            Children.Add(new Panel
            {
                Name = "close",
                ToolTip = "关闭",
                MarginRight = 5,
                MarginTop = 5,
                Width = 30,
                Height = 30,
                Children =
                {
                    new Line
                    {
                        MarginTop=8,
                        MarginLeft=8,
                        StartPoint = new Point(1, 1),
                        EndPoint = new Point(14, 13),
                        StrokeStyle = "2",
                        IsAntiAlias=true,
                        StrokeFill=color
                    },
                    new Line
                    {
                        MarginTop=8,
                        MarginLeft=8,
                        StartPoint = new Point(14, 1),
                        EndPoint = new Point(1, 13),
                        StrokeStyle = "2",
                        IsAntiAlias=true,
                        StrokeFill=color
                    }
                },
                Commands =
                {
                    {
                        nameof(Button.MouseDown),
                        (s, e) => window.CloseDialogForm(this)
                    }
                },
                Triggers =
                {
                    new Trigger(nameof(Panel.IsMouseOver), Relation.Me)
                    {
                        Setters =
                        {
                            {
                                nameof(Panel.Background),
                                hoverColor
                            }
                        }
                    }
                },
            });
            Children.Add(new Button
            {
                MarginLeft = 110.4f,
                Content = "确认",
                Width = 73f,
                Height = 32f,
                MarginBottom = 74.9f
            });
            Children.Add(new TextBlock
            {
                MarginLeft = 119.4f,
                MarginTop = 62.2f,
                Text = "渐变背景1",
                Background = "linear-gradient(0 0,100% 0,#0021FF 0,#FF0000 0.2448276,#00FF40 0.6330049,#DAFFAA 1)"
            });
            Children.Add(new SVG
            {
                MarginLeft = 277.1f,
                MarginTop = 56.7f,
                Width=100f,
                Stretch= Stretch.Uniform,
                Source="res://CpfNativeAOT/test.svg",
            });
            Children.Add(new CheckBox
            {
                MarginLeft = 106.9f,
                MarginTop = 88.2f,
                Content = "CheckBox",
            });
        }
    }
}

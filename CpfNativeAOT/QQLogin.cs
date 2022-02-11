using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPF;
using CPF.Drawing;
using CPF.Controls;
using CPF.Shapes;
using CPF.Styling;
using CPF.Animation;
using CPF.Input;
using CPF.Platform;

namespace CPFApplication1
{
    public class QQLogin : Window
    {
        Popup popup;
        protected async override void InitializeComponent()
        {
            if (!DesignMode)
            {
                DataContext = new LoginModel();
                CommandContext = DataContext;
            }
            ViewFill color = "#fff";
            ViewFill hoverColor = "255,255,255,40";
            Title = "QQ";
            Width = 435f;
            Height = 340f;
            Background = null;
            //窗体阴影
            var frame = Children.Add(new Border
            {
                Width = "100%",
                Height = "100%",
                Background = null,
                BorderType = BorderType.BorderStroke,
                BorderStroke = new Stroke(0),
                ShadowBlur = 5,
            });
            //用来裁剪内容，不然内容超出阴影
            frame.Child = new Decorator
            {
                Child = new Panel
                {
                    Width = "100%",
                    Height = "100%",
                    Children =
                    {
                        new Panel
                        {
                            Children =
                            {
                                new Panel
                                {
                                    MarginLeft = 329f,
                                    MarginTop = -0.5f,
                                    ToolTip="设置",
                                    Name="set",
                                    Width = 30,
                                    Height = 30f,
                                    Children =
                                    {
                                        new TextBlock
                                        {
                                            Classes=
                                            {
                                                "icon_free"
                                            },
                                            FontSize=16,
                                            Text=((char)0xf013).ToString(),
                                            Foreground="#fff"
                                        },
                                    },
                                    Commands =
                                    {
                                        {
                                            nameof(Button.MouseDown),
                                            (s,e)=>
                                            {
                                                
                                            }
                                        }
                                    },
                                    Triggers=
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
                                },
                                new Panel
                                {
                                    MarginLeft = 362.8f,
                                    MarginTop = 0.3f,
                                    ToolTip="最小化",
                                    Name="min",
                                    Width = 30,
                                    Height = 30f,
                                    Children =
                                    {
                                        new Line
                                        {
                                            MarginLeft=8,
                                            MarginTop=5,
                                            StartPoint = new Point(1, 13),
                                            EndPoint = new Point(14, 13),
                                            StrokeStyle = "2",
                                            IsAntiAlias=true,
                                            StrokeFill=color
                                        },
                                    },
                                    Commands =
                                    {
                                        {
                                            nameof(Button.MouseDown),
                                            (s,e)=>
                                            {
                                                (e as MouseButtonEventArgs).Handled = true;
                                                this.WindowState = WindowState.Minimized;
                                            }
                                        }
                                    },
                                    Triggers=
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
                                },
                                new Panel
                                {
                                    MarginRight = 0f,
                                    MarginLeft = "Auto",
                                    MarginTop = 0f,
                                    Name = "close",
                                    ToolTip = "关闭",
                                    Width = 30,
                                    Height = 30f,
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
                                            (s,e)=>
                                            {
                                                
                                            }
                                        },
                                        {
                                            nameof(Button.MouseDown),
                                            (s,e)=>
                                            {
                                                (e as MouseButtonEventArgs).Handled=true;
                                                this.Close();
                                            }
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
                                },
                                new Picture
                                {
                                    Width = 29.4f,
                                    Stretch = Stretch.Fill,
                                    MarginLeft = 10.7f,
                                    MarginTop = 10.4f,
                                    Source="res://CpfNativeAOT/Resources/qq.png",
                                },
                                new Panel
                                {
                                    Name="headPanel",
                                    MarginTop = 70f,
                                    Children =
                                    {
                                        new Border
                                        {
                                            ToolTip="多账号登录",
                                            Name="more",
                                            PresenterFor=this,
                                            IsAntiAlias=true,
                                            ShadowColor = "#A9C6F7",
                                            ShadowBlur = 8,
                                            BorderStroke = "2,Solid",
                                            BorderFill = "#A9C6F7",
                                            CornerRadius = "20",
                                            Width=60,
                                            Height=60,
                                            Background="#fff",
                                            MarginTop=20,
                                            MarginLeft=20,
                                            Child =
                                            new Panel
                                            {
                                                Children =
                                                {
                                                    new Line
                                                    {
                                                        StartPoint=new Point(0,7.5f),
                                                        EndPoint=new Point(15,7.5f),
                                                        StrokeFill="#aaa"
                                                    },
                                                    new Line
                                                    {
                                                        StartPoint=new Point(7.5f,0),
                                                        EndPoint=new Point(7.5f,15),
                                                        StrokeFill="#aaa"
                                                    }
                                                }
                                            }
                                        },
                                        new Border
                                        {
                                            ShadowColor = "#05f",
                                            ShadowBlur = 10,
                                            BorderStroke = "2,Solid",
                                            BorderFill = null,
                                            CornerRadius = "35",
                                            IsAntiAlias = true,
                                            Background="#fff",
                                            //Padding=new Thickness(-8),
                                            Child =
                                            new Ellipse
                                            {
                                                StrokeStyle = "1",
                                                StrokeFill = "#fff",
                                                Fill = "url(res://CpfNativeAOT/Resources/headQQ.png) Clamp Fill 0,0,0,0",
                                                Width=70f,
                                                Height=70f,
                                            }
                                        }
                                    },
                                },
                                new TextBlock
                                {
                                    Foreground = "#FFFFFF",
                                    FontSize = 20f,
                                    MarginLeft = 48.1f,
                                    MarginTop = 13.5f,
                                    Text = "QQ",
                                },
                            },
                            Background = "#07AFFB",
                            MarginTop = 0f,
                            MinWidth = "100%",
                            Height = 125f,
                            Commands =
                            {
                                {
                                    nameof(MouseDown),
                                    (s,e)=>this.DragMove()
                                }
                            }
                        },
                        new TextBlock
                        {
                            Foreground = new SolidColorFill
                            {
                                Color = "#868686",
                            },
                            MarginLeft = 10.1f,
                            MarginTop = 302.4f,
                            Text = "注册账号",
                        },
                        new Border
                        {
                            Classes=
                            {
                                "panel"
                            },
                            PresenterFor=this,
                            Name="qqNumPanel",
                            Child = new Panel
                            {
                                Children =
                                {
                                    new TextBox
                                    {
                                        Name = "qq",
                                        FontSize = 16f,
                                        MarginLeft = 24f,
                                        MarginTop = 3f,
                                        Height = 25f,
                                        Width = 156.2f,
                                        AcceptsReturn=false,
                                        HScrollBarVisibility= ScrollBarVisibility.Hidden,
                                        VScrollBarVisibility= ScrollBarVisibility.Hidden,
                                        Bindings =
                                        {
                                            {
                                                nameof(TextBox.Text),
                                                nameof(LoginModel.QQ),
                                                null,
                                                BindingMode.TwoWay
                                            }
                                        }
                                    },
                                    new Panel
                                    {
                                        MarginRight=5,
                                        Height="100%",
                                        Children =
                                        {
                                            new Polyline
                                            {
                                                IsAntiAlias=true,
                                                StrokeFill = new SolidColorFill
                                                {
                                                    Color = "#939393",
                                                },
                                                Points =
                                                {
                                                    new Point(),
                                                    new Point(7,7),
                                                    new Point(14,0)
                                                },
                                            }
                                        },
                                        Commands =
                                        {
                                            {
                                                nameof(MouseUp),
                                                Pop
                                            }
                                        }
                                    },
                                    new TextBlock
                                    {
                                        Classes=
                                        {
                                            "icon_brands"
                                        },
                                        FontSize = 16f,
                                        Foreground = "#ACACAC",
                                        MarginLeft = 1f,
                                        MarginTop = 7.8f,
                                        FontFamily = "Font Awesome 5 Brands",
                                        Text = ((char)0xf1d6).ToString(),
                                    }
                                },
                                Height = "100%",
                                Width = "100%",
                            },
                            BorderFill = new SolidColorFill
                            {
                                Color = "#ACACAC",
                            },
                            BorderThickness = "0,0,0,1",
                            BorderType = BorderType.BorderThickness,
                            MarginLeft = 110.8f,
                            MarginTop = 160f,
                            Height = 32f,
                            Width = 208f,
                        },
                        new Border
                        {
                            Classes=
                            {
                                "panel"
                            },
                            Child = new Panel
                            {
                                Children =
                                {
                                    new TextBox
                                    {
                                        Text = "",
                                        PasswordChar = '●',
                                        FontSize = 16f,
                                        MarginLeft = 24f,
                                        MarginTop = 3f,
                                        Height = 25f,
                                        Width = 156.2f,
                                        AcceptsReturn=false,
                                        HScrollBarVisibility= ScrollBarVisibility.Hidden,
                                        VScrollBarVisibility= ScrollBarVisibility.Hidden,
                                        Bindings =
                                        {
                                            {
                                                nameof(TextBox.Text),
                                                nameof(LoginModel.Password),
                                                null,
                                                BindingMode.TwoWay
                                            }
                                        }
                                    },
                                    new Picture
                                    {
                                        Stretch = Stretch.Fill,
                                        Width = 21.8f,
                                        MarginLeft = 185.4f,
                                        MarginTop = 4.7f,
                                        Source="res://CpfNativeAOT/Resources/keyboard.png",
                                    },
                                    new TextBlock
                                    {
                                        Classes=
                                        {
                                            "icon_free"
                                        },
                                        FontSize = 16f,
                                        Foreground = "#ACACAC",
                                        MarginLeft = 1f,
                                        MarginTop = 7.8f,
                                        Text = ((char)0xf023).ToString(),
                                    }
                                },
                                Height = "100%",
                                Width = "100%",
                            },
                            BorderFill = new SolidColorFill
                            {
                                Color = "#ACACAC",
                            },
                            BorderThickness = "0,0,0,1",
                            BorderType = BorderType.BorderThickness,
                            MarginLeft = 110.8f,
                            MarginTop = 200f,
                            Height = 32f,
                            Width = 208f,
                        },
                        new CheckBox
                        {
                            Foreground = new SolidColorFill
                            {
                                Color = "#939292",
                            },
                            MarginLeft = 110.2f,
                            MarginTop = 242.7f,
                            Content = "自动登录",
                        },
                        new CheckBox
                        {
                            IsChecked = true,
                            Foreground = new SolidColorFill
                            {
                                Color = "#939292",
                            },
                            MarginLeft = 188.6f,
                            MarginTop = 242.1f,
                            Content = "记住密码",
                        },
                        new TextBlock
                        {
                            Foreground = "#9C9C9C",
                            MarginLeft = 266.9f,
                            MarginTop = 242.9f,
                            Text = "找回密码",
                        },
                        new Button
                        {
                            CornerRadius = "4",
                            FontSize = 16f,
                            Height = 33f,
                            Width = 208.6f,
                            MarginLeft = 110.2f,
                            MarginTop = 273.4f,
                            Content = "登录",
                            Commands =
                            {
                                {
                                    nameof(Button.Click),
                                    (s,e)=>
                                    {
                                        new QQMain().Show();
                                    }
                                }
                            }
                        },
                        new TextBlock
                        {
                            Classes=
                            {
                                "icon_free"
                            },
                            Name="qrcode",
                            Foreground = "#C1C1C1",
                            FontSize = 26f,
                            MarginLeft = 393f,
                            MarginTop = 295.9f,
                            Text = ((char)0xf029).ToString(),
                        },
                    }
                },
                Width = "100%",
                Height = "100%",
                ClipToBounds = true,
                Background = "#fff",
                MarginRight = 0f,
            };
            LoadStyleFile("res://CpfNativeAOT/QQLogin.css");
            //加载样式文件，文件需要设置为内嵌资源
            Icon = await ResourceManager.GetImage("res://CpfNativeAOT/Resources/headQQ.png");
        }

        void Pop(CpfObject cpfObject, object e)
        {
            if (popup == null)
            {
                var qqNumPanel = FindPresenterByName<UIElement>("qqNumPanel");
                popup = new Popup
                {
                    Background = null,
                    DataContext = DataContext,
                    CommandContext = DataContext,
                    CanActivate = false,
                    PlacementTarget = qqNumPanel,
                    StaysOpen = false,
                    Placement = PlacementMode.Margin,
                    MarginTop = 0,
                    Children =
                    {
                        new PopList
                        {
                            MarginTop=0,
                            Width=qqNumPanel.ActualSize.Width,
                        }
                    }
                };
                popup.LoadStyleFile("res://CpfNativeAOT/QQLogin.css");
            }
            popup.Visibility = Visibility.Visible;
        }
    }
}

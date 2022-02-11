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
using CPF.Platform;

namespace CPFApplication1
{
    public class QQMain : Window
    {
        protected override void InitializeComponent()
        {
            if (!DesignMode)
            {
                DataContext = new QQMainModel();
                CommandContext = DataContext;
            }
            Title = "标题";
            Width = 300f;
            Height = 500;
            Background = null;
            CanResize = true;
            MinHeight = 300;
            MinWidth = 300;
            Children.Add(new WindowFrame(this, new Panel
            {
                Width = "100%",
                Height = "100%",
                Children =
                {
                    //内容元素放这里
                    new TextBlock
                    {
                        Classes=
                        {
                            "icon_brands"
                        },
                        FontSize = 16f,
                        Foreground = "#ACACAC",
                        MarginLeft = 7f,
                        MarginTop = -21.8f,
                        FontFamily = "Font Awesome 5 Brands",
                        Text = ((char)0xf1d6).ToString(),
                    },
                    new StackPanel
                    {
                        MarginTop=-30,
                        MarginRight=60,
                        Orientation= Orientation.Horizontal,
                        Children =
                        {
                            new Label
                            {
                                Classes=
                                {
                                    "icon_free",
                                    "syt_btn"
                                },
                                Foreground = "#FFDF00",
                                Text = ((char)0xf005).ToString(),
                            },
                            new Label
                            {
                                Classes=
                                {
                                    "icon_free",
                                    "syt_btn"
                                },
                                Foreground = "#fff",
                                Text = ((char)0xf553).ToString(),
                            },
                            new Label
                            {
                                Classes=
                                {
                                    "icon_free",
                                    "syt_btn"
                                },
                                FontSize = 12f,
                                Foreground = "#fff",
                                Text = ((char)0xf0e0).ToString(),
                            },
                        }
                    },
                    new Border
                    {
                        MarginLeft = 14.9f,
                        MarginTop = 6f,
                        CornerRadius="25",
                        BorderFill=null,
                        BorderStroke="2",
                        Background="#fff",
                        IsAntiAlias=true,
                        Child =
                        new Ellipse
                        {
                            Height = 50,
                            Width = 50,
                            StrokeFill=null,
                            Fill="url(res://CpfNativeAOT/Resources/headQQ.png) Clamp Fill",
                        },
                        Triggers =
                        {
                            {
                                nameof(IsMouseOver),
                                Relation.Me,
                                null,
                                (nameof(Border.BorderFill),"#ccc")
                            }
                        }
                    },
                    new Grid
                    {
                        //LineFill="#f00",
                        //LineStroke="1",
                        MarginTop=10,
                        MarginLeft=80,
                        MarginRight=80,
                        ColumnDefinitions =
                        {
                            new ColumnDefinition
                            {
                                Width="auto"
                            },
                            new ColumnDefinition
                            {
                                Width="auto"
                            },
                            new ColumnDefinition
                            {
                                Width="auto"
                            },
                            new ColumnDefinition
                            {
                                Width="*"
                            },
                        },
                        RowDefinitions =
                        {
                            new RowDefinition
                            {
                                Height="auto"
                            },
                            new RowDefinition
                            {
                                
                            }
                        },
                        Children =
                        {
                            new TextBlock
                            {
                                Text="小红帽",
                                FontStyle= FontStyles.Bold,
                                Foreground="#fff",
                                FontSize=20,
                            },
                            new TextBlock
                            {
                                Text="lv100",
                                Foreground="#FFE000",
                                FontStyle= FontStyles.Bold,
                                Attacheds =
                                {
                                    {
                                        Grid.ColumnIndex,
                                        1
                                    }
                                }
                            },
                            new TextBlock
                            {
                                Background="#FCFF02",
                                Text="SVIP",
                                Foreground="#FF0000",
                                FontStyle= FontStyles.Bold,
                                Attacheds =
                                {
                                    {
                                        Grid.ColumnIndex,
                                        2
                                    }
                                }
                            },
                            new TextBlock
                            {
                                Background="#FCFF02",
                                Text="SVIP",
                                Foreground="#FF0000",
                                FontStyle= FontStyles.Bold,
                                Attacheds =
                                {
                                    {
                                        Grid.ColumnIndex,
                                        2
                                    }
                                }
                            },
                            new TextBlock
                            {
                                TextTrimming = TextTrimming.CharacterEllipsis,
                                Text="☆不抛弃不放弃,一切皆有可能!",
                                Foreground="#fff",
                                Width="100%",
                                ClipToBounds=true,
                                Height=18,
                                Attacheds =
                                {
                                    {
                                        Grid.ColumnIndex,
                                        0
                                    },
                                    {
                                        Grid.RowIndex,
                                        1
                                    },
                                    {
                                        Grid.ColumnSpan,
                                        4
                                    },
                                }
                            }
                        }
                    },
                    new Label
                    {
                        FontSize = 40f,
                        MarginRight = 10,
                        MarginTop = 12.4f,
                        Classes=
                        {
                            "icon_free"
                        },
                        Foreground = "#FFf",
                        Text = ((char)0xf185).ToString(),
                    },
                    new Panel
                    {
                        Children =
                        {
                            new Label
                            {
                                FontSize = 14f,
                                MarginLeft = 15,
                                Classes=
                                {
                                    "icon_free"
                                },
                                Foreground = "#CCCCCC99",
                                Text = ((char)0xf002).ToString(),
                            },
                            new TextBox
                            {
                                MarginLeft = 38f,
                                MarginRight=30,
                                HScrollBarVisibility= ScrollBarVisibility.Hidden,
                                VScrollBarVisibility=  ScrollBarVisibility.Hidden,
                                AcceptsReturn=false,
                                MinHeight=25,
                                Text="搜索",
                                FontSize=16,
                                Foreground="#fff",
                                Triggers =
                                {
                                    {
                                        nameof(IsKeyboardFocused),
                                        Relation.Me.Parent,
                                        null,
                                        (nameof(Background),"#fff")
                                    },
                                    {
                                        nameof(IsKeyboardFocused),
                                        Relation.Me,
                                        null,
                                        (nameof(Foreground),"#000")
                                    },
                                    {
                                        nameof(IsKeyboardFocused),
                                        Relation.Me.Parent.Children(a=>a.Name=="clear"),
                                        null,
                                        (nameof(Visibility),Visibility.Visible)
                                    }
                                }
                            },
                            new Label
                            {
                                Name="clear",
                                FontSize = 14f,
                                MarginRight = 10,
                                Classes=
                                {
                                    "icon_free"
                                },
                                Foreground = "#57575799",
                                Text = ((char)0xf057).ToString(),
                                Visibility= Visibility.Collapsed,
                                Commands =
                                {
                                    {
                                        nameof(MouseDown),
                                        (s,e)=>
                                        {
                                            (s as UIElement).Focus();
                                        }
                                    }
                                }
                            }
                        },
                        Background = "#FFFFFF34",
                        MarginLeft = 0,
                        MarginTop = 70f,
                        Height = 31.6f,
                        Width = "100%",
                    },
                    new TabControl
                    {
                        Items =
                        {
                            new TabItem
                            {
                                Header="消息",
                                Bindings =
                                {
                                    {
                                        nameof(Width),
                                        nameof(ActualSize),
                                        1,
                                        BindingMode.OneWay,
                                        (Size a)=>a.Width/3
                                    }
                                },
                                Content=new ListBox
                                {
                                    Size=SizeField.Fill,
                                    ItemTemplate=typeof(MessageItem),
                                    Bindings =
                                    {
                                        {
                                            nameof(ListBox.Items),
                                            nameof(QQMainModel.Messages)
                                        }
                                    }
                                }
                            },
                            new TabItem
                            {
                                Header="联系人",
                                Bindings =
                                {
                                    {
                                        nameof(Width),
                                        nameof(ActualSize),
                                        1,
                                        BindingMode.OneWay,
                                        (Size a)=>a.Width/3
                                    }
                                },
                                Content=new TreeView
                                {
                                    Size=SizeField.Fill,
                                    DisplayMemberPath="Item1",
                                    ItemsMemberPath="Item2",
                                    ItemTemplate=new GroupItem
                                    {
                                        ItemTemplate=typeof(UserItem)
                                    },
                                    Bindings =
                                    {
                                        {
                                            nameof(TreeView.Items),
                                            nameof(QQMainModel.Groups)
                                        }
                                    }
                                }
                            },
                            new TabItem
                            {
                                Header="空间",
                                Bindings =
                                {
                                    {
                                        nameof(Width),
                                        nameof(ActualSize),
                                        1,
                                        BindingMode.OneWay,
                                        (Size a)=>a.Width/3
                                    }
                                }
                            },
                        },
                        Width="100%",
                        MarginTop=101f,
                        MarginBottom=35f,
                        SwitchAction = (oldItem, newItem) =>
                        {
                            if (oldItem != null && oldItem.ContentElement != null)
                            {
                                oldItem.ContentElement.TransitionValue(nameof(UIElement.MarginLeft), (FloatField)"-100%", TimeSpan.FromSeconds(0.2), new PowerEase(), AnimateMode.EaseOut, () =>
                                {
                                    oldItem.ContentElement.Visibility = Visibility.Collapsed;
                                });
                            }
                            if (newItem != null && newItem.ContentElement != null)
                            {
                                newItem.ContentElement.Visibility = Visibility.Visible;
                                newItem.ContentElement.MarginLeft = "100%";
                                newItem.ContentElement.TransitionValue(nameof(UIElement.MarginLeft), (FloatField)"0%", TimeSpan.FromSeconds(0.2), new PowerEase(), AnimateMode.EaseOut);
                            }
                        },
                    },
                    new Panel
                    {
                        Children =
                        {
                            new Label
                            {
                                FontSize = 14f,
                                MarginLeft = 15,
                                Classes=
                                {
                                    "icon_free"
                                },
                                Foreground = "rgb(108,122,145)",
                                Text = ((char)0xf0c9).ToString(),
                            },
                            new Label
                            {
                                FontSize = 14f,
                                MarginLeft = 40,
                                Classes=
                                {
                                    "icon_free"
                                },
                                Foreground = "rgb(108,122,145)",
                                Text = ((char)0xf234).ToString(),
                            },
                        },
                        Background = "rgba(255, 255, 255, 0.8)",
                        Width = "100%",
                        Height = 35f,
                        MarginBottom=0,
                    },
                },
            }));
            LoadStyleFile("res://CpfNativeAOT/QQMain.css");
            //加载样式文件，文件需要设置为内嵌资源

            if (!DesignMode)//设计模式下不执行
            {
                
            }
        }
    }
}

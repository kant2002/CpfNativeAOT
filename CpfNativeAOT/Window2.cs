using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPF;
using CPF.Drawing;
using CPF.Controls;
using CPF.Animation;
using System.Data;
using CPF.Svg;

namespace CPFApplication1
{
    public class Window2 : Window
    {
        protected override void InitializeComponent()
        {
            Title = "CPF演示案例";
            Width = 1000;
            Height = 600;
            Background = null;
            CanResize = true;
            MinHeight = 100;
            MinWidth = 200;
            Children.Add(new WindowFrame(this, new Panel
            {
                Background = null,
                Width = "100%",
                Height = "100%",
                Children =
                {
                    //内容元素放这里
                    new TabControl
                    {
                        Name="mainTab",
                        TabStripPlacement= Dock.Left,
                        Width="100%",
                        Height="100%",
                        Items=
                        {
                            new TabItemTemplate
                            {
                                Header="基础控件",
                                Content=new Panel
                                {
                                    Width="100%",
                                    Height="100%",
                                    Background="255,255,255,200",
                                    Children=
                                    {
                                        new Button
                                        {
                                            Width=150,
                                            Height=25,
                                            Content="另外一个演示窗体",
                                            MarginTop=20,
                                            MarginLeft=20,
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    (s,e)=>
                                                    {
                                                        var w = new Window1();
                                                        w.DataContext = new Model();
                                                        w.CommandContext = w.DataContext;
                                                        w.Show();
                                                    }
                                                }
                                            }
                                        },
                                        new CheckBox
                                        {
                                            Content="复选框1",
                                            MarginTop=60,
                                            MarginLeft=20
                                        },
                                        new CheckBox
                                        {
                                            Content="复选框2",
                                            MarginTop=60f,
                                            MarginLeft=90f,
                                            IsThreeState=true
                                        },
                                        new RadioButton
                                        {
                                            Content="单选框1",
                                            MarginTop=94.8f,
                                            MarginLeft=88f,
                                            GroupName="gn1"
                                        },
                                        new RadioButton
                                        {
                                            Content="单选框2",
                                            MarginTop=150,
                                            MarginLeft=20,
                                            GroupName="gn1"
                                        },
                                        new Border
                                        {
                                            Name="shadowEffect",
                                            MarginTop=180,
                                            MarginLeft=15,
                                            Width=110,
                                            Height=35,
                                            Background="#fff",
                                            BorderType= BorderType.BorderThickness,
                                            ShadowBlur=5,
                                            ShadowColor="0,0,0,0",
                                            Child=new TextBox
                                            {
                                                Classes=
                                                {
                                                    "Single"
                                                },
                                                MarginBottom=0,
                                                MarginLeft=0,
                                                MarginRight=-1,
                                                MarginTop=0,
                                                Bindings=
                                                {
                                                    {
                                                        nameof(TextBox.Text),
                                                        nameof(TextBox.Text),
                                                        this.FindPresenter<TextBox>(a=>a.Name=="password")
                                                    }
                                                }
                                            }
                                        },
                                        //绑定当前页面里的元素，被绑定的元素需要设置PresenterFor=this
                                        new TextBox
                                        {
                                            Name="password",
                                            PresenterFor=this,
                                            Classes=
                                            {
                                                "Single"
                                            },
                                            MarginTop=220f,
                                            MarginLeft=20f,
                                            Width=105f,
                                            Height=25f,
                                            Background="#fff",
                                            PasswordChar='*',
                                            Text="test",
                                            CornerRadius="8",
                                            IsAntiAlias=true
                                        },
                                        new TextBox
                                        {
                                            MarginTop=250f,
                                            MarginLeft=20f,
                                            Width=281f,
                                            Height=200f,
                                            Background="#fff",
                                            Text="多行文本框"
                                        },
                                        new ScrollBar
                                        {
                                            MarginLeft=300,
                                            MarginTop=28,
                                            Height=20,
                                            Width=100,
                                            Orientation= Orientation.Horizontal,
                                            Background="#fff"
                                        },
                                        new ScrollBar
                                        {
                                            MarginLeft=300,
                                            MarginTop=50,
                                            Width=20,
                                            Height=100,
                                            Orientation= Orientation.Vertical,
                                            Background="#fff"
                                        },
                                        new Picture
                                        {
                                            Source="res://CpfNativeAOT/Resources/home.png",
                                            MarginTop=200,
                                            MarginLeft=300
                                        },
                                        new Picture
                                        {Width = 117f,
                                            Source="https://dss0.bdstatic.com/5aV1bjqh_Q23odCf/static/superman/img/logo_top-e3b63a0b1b.png",
                                            MarginTop=220f,
                                            MarginLeft=300f
                                        },
                                        new ComboBox
                                        {
                                            MarginTop=300f,
                                            MarginLeft=301.6f,
                                            Width=117.6f,
                                            Height=25f,
                                            Items=
                                            {
                                                "sdag",
                                                "测试",
                                                "342a"
                                            }
                                        },
                                        new ScrollViewer
                                        {
                                            Content=new Picture
                                            {
                                                Source="http://www.bbra.cn/Uploadfiles/imgs/2014/03/12/mm3/Xbzs_010.jpg"
                                            },
                                            Width="40%",
                                            Height=300,
                                            MarginTop=20,
                                            MarginRight=20
                                        },
                                    }
                                }
                            },
                            new TabItemTemplate
                            {
                                Header="动画",
                                Content=new Panel
                                {
                                    Width="100%",
                                    Height="100%",
                                    Children=
                                    {
                                        new Button
                                        {
                                            Content="弹窗动画",
                                            Width=100,
                                            Height=25,
                                            MarginLeft=20,
                                            MarginTop=20,
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    (s,e)=> ShowDialogForm()
                                                }
                                            }
                                        },
                                        new Button
                                        {
                                            Content="缓动动画1",
                                            Width=100,
                                            Height=25,
                                            MarginLeft=160,
                                            MarginTop=20,
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    (s,e)=> Animation((Button)s,new QuadraticEase())
                                                }
                                            }
                                        },
                                        new Button
                                        {
                                            Content="缓动动画2",
                                            Width=100,
                                            Height=25,
                                            MarginLeft=260,
                                            MarginTop=20,
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    (s,e)=> Animation((Button)s,new CubicEase())
                                                }
                                            }
                                        },
                                        new Button
                                        {
                                            Content="缓动动画3",
                                            Width=100,
                                            Height=25,
                                            MarginLeft=360,
                                            MarginTop=20,
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    (s,e)=> Animation((Button)s,new ElasticEase())
                                                }
                                            }
                                        },
                                        new Button
                                        {
                                            Content="缓动动画4",
                                            Width=100,
                                            Height=25,
                                            MarginLeft=460,
                                            MarginTop=20,
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    (s,e)=> Animation((Button)s,new ExponentialEase())
                                                }
                                            }
                                        },
                                        new Button
                                        {
                                            Content="缓动动画5",
                                            Width=100,
                                            Height=25,
                                            MarginLeft=560,
                                            MarginTop=20,
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    (s,e)=> Animation((Button)s,new QuinticEase())
                                                }
                                            }
                                        },
                                        new Button
                                        {
                                            Content="缓动动画6",
                                            Width=100,
                                            Height=25,
                                            MarginLeft=660,
                                            MarginTop=20,
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    (s,e)=> Animation((Button)s,new SineEase())
                                                }
                                            }
                                        },
                                        new Button
                                        {
                                            Content="复杂动画",
                                            Width=100,
                                            Height=55,
                                            MarginLeft=60,
                                            MarginTop=120,
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    (s,e)=> Animation((Button)s)
                                                }
                                            }
                                        },
                                    }
                                }
                            },
                            new TabItemTemplate
                            {
                                Header="布局",
                                Content=new Panel
                                {
                                    Width="100%",
                                    Height="100%",
                                    Children=
                                    {
                                        new StackPanel
                                        {
                                            MarginLeft=10,
                                            MarginTop=10,
                                            Orientation= Orientation.Vertical,
                                            Children=
                                            {
                                                new Button
                                                {
                                                    Content="StackPanel的Vertical"
                                                },
                                                new Button
                                                {
                                                    Content="按钮"
                                                },
                                                new Button
                                                {
                                                    Content="按钮"
                                                },
                                                new Button
                                                {
                                                    Content="按钮"
                                                },
                                            }
                                        },
                                        new StackPanel
                                        {
                                            MarginLeft=80,
                                            MarginTop=50,
                                            Orientation= Orientation.Horizontal,
                                            Children=
                                            {
                                                new Button
                                                {
                                                    Content="StackPanel的Horizontal"
                                                },
                                                new Button
                                                {
                                                    Content="按钮"
                                                },
                                                new Button
                                                {
                                                    Content="Margin调间距",
                                                    MarginLeft=5
                                                },
                                                new Button
                                                {
                                                    Content="按钮"
                                                },
                                            }
                                        },
                                        new WrapPanel
                                        {
                                            MarginRight=10,
                                            MarginTop=10,
                                            Width="50%",
                                            Orientation= Orientation.Horizontal,
                                            Children=
                                            {
                                                new Button
                                                {
                                                    Content="WrapPanel的Horizontal"
                                                },
                                                new Button
                                                {
                                                    Content="按钮"
                                                },
                                                new Button
                                                {
                                                    Content="Margin调间距",
                                                    MarginLeft=5
                                                },
                                                new Button
                                                {
                                                    Content="按钮"
                                                },
                                                new Button
                                                {
                                                    Content="宽度不够"
                                                },
                                                new Button
                                                {
                                                    Content="可以自动换行"
                                                },
                                            }
                                        },
                                        new Grid
                                        {
                                            RenderTransform=new RotateTransform(10),
                                            Name="testGrid",
                                            Background="#999",
                                            Width="80%",
                                            Height="60%",
                                            MarginTop=120,
                                            MarginLeft=20,
                                            ColumnDefinitions=
                                            {
                                                new ColumnDefinition
                                                {
                                                    Width="40*"
                                                },
                                                new ColumnDefinition
                                                {
                                                    Width = "30*"
                                                },
                                                new ColumnDefinition
                                                {
                                                    Width="200"
                                                },
                                            },
                                            RowDefinitions=
                                            {
                                                new RowDefinition
                                                {
                                                    Height="30*"
                                                },
                                                new RowDefinition
                                                {
                                                    Height="30*"
                                                },
                                                new RowDefinition
                                                {
                                                    Height="30*"
                                                }
                                            },
                                            Children=
                                            {
                                                new WrapPanel
                                                {
                                                    Name="test",
                                                    Background="#a2f",
                                                    Width="100%",
                                                    Height="100%",
                                                    Children=
                                                    {
                                                        new Button
                                                        {
                                                            Content="水平浮动布局231"
                                                        },
                                                        new Button
                                                        {
                                                            Content="按钮2"
                                                        },
                                                        new Button
                                                        {
                                                            Content="按钮3"
                                                        },
                                                        new Button
                                                        {
                                                            Content="按钮4"
                                                        },
                                                        new Button
                                                        {
                                                            Content="按钮5"
                                                        },
                                                    }
                                                },
                                                {
                                                    new WrapPanel
                                                    {
                                                        Orientation= Orientation.Vertical,
                                                        Background="#27a",
                                                        Width="100%",
                                                        Height="100%",
                                                        Children=
                                                        {
                                                            new Button
                                                            {
                                                                Content="垂直浮动布局"
                                                            },
                                                            new Button
                                                            {
                                                                Content="按钮2"
                                                            },
                                                            new Button
                                                            {
                                                                Content="按钮3"
                                                            },
                                                            new Button
                                                            {
                                                                Content="按钮4"
                                                            },
                                                            new Button
                                                            {
                                                                Content="按钮5"
                                                            },
                                                        }
                                                    },
                                                    1,
                                                    1
                                                },
                                                {
                                                    new TextBlock
                                                    {
                                                        Background="#ac2",
                                                        Width="100%",
                                                        Height="100%",
                                                        Text="Grid布局。。。。。。。"
                                                    },
                                                    2,
                                                    1
                                                },
                                                {
                                                    new TextBlock
                                                    {
                                                        Background="#b1a",
                                                        Width="100%",
                                                        Height="100%",
                                                        Text="跨列"
                                                    },
                                                    0,
                                                    2,
                                                    2
                                                },
                                                {
                                                    new TextBlock
                                                    {
                                                        Background="#186",
                                                        Width="100%",
                                                        Height="100%",
                                                        Text="跨行"
                                                    },
                                                    2,
                                                    1,
                                                    1,
                                                    2
                                                },
                                                new TextBlock
                                                {
                                                    Text="元素变换，可以旋转，倾斜，缩放等操作",
                                                    Attacheds=
                                                    {
                                                        {
                                                            Grid.ColumnIndex,
                                                            1
                                                        }
                                                    }
                                                },
                                            },
                                        }
                                    }
                                }
                            },
                            new TabItemTemplate
                            {
                                Header="ListBox",
                                Content=new Panel
                                {
                                    Width="100%",
                                    Height="100%",
                                    Children=
                                    {
                                        new ListBox
                                        {
                                            Width=300,
                                            Height=500,
                                            ItemTemplate=typeof(ListBoxItemTemplate),
                                            Bindings=
                                            {
                                                {
                                                    nameof(ListBox.Items),
                                                    nameof(Items),
                                                    this
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new TabItemTemplate
                            {
                                Header="DataGrid",
                                Content=new Panel
                                {
                                    Width="100%",
                                    Height="100%",
                                    Children=
                                    {
                                        new DataGrid
                                        {
                                            Width = "80%",
                                            Height = "80%",
                                            //Background = "#fff",
                                            Columns =
                                            {
                                                new DataGridComboBoxColumn
                                                {
                                                    Header="dfsd",
                                                    Binding=new DataGridBinding("p1",BindingMode.TwoWay),
                                                    Width=100,
                                                    Items=
                                                    {
                                                        "0",
                                                        "1",
                                                        "2",
                                                        "3"
                                                    }
                                                },
                                                new DataGridCheckBoxColumn
                                                {
                                                    Header="d1fsd",
                                                    Binding=new DataGridBinding("p2")
                                                    {
                                                        BindingMode= BindingMode.TwoWay
                                                    },
                                                    Width=100,
                                                    HeaderTemplate=typeof(ColumnTemplate),
                                                },
                                                new DataGridTextColumn
                                                {
                                                    Header="3dfsd",
                                                    Binding=new DataGridBinding("p3")
                                                    {
                                                        BindingMode= BindingMode.TwoWay
                                                    },
                                                    Width="100"
                                                },
                                                new DataGridTextColumn
                                                {
                                                    Header="输入类型验证",
                                                    Binding=new DataGridBinding("p4")
                                                    {
                                                        BindingMode= BindingMode.TwoWay
                                                    },
                                                    Width="100"
                                                },
                                                new DataGridTemplateColumn
                                                {
                                                    Header="自定义模板",
                                                    Binding=new DataGridBinding("p5"),
                                                    Width=100,
                                                    CellTemplate=typeof(CellTemplate)
                                                },
                                                new DataGridTextColumn
                                                {
                                                    Header="d1fsd",
                                                    Binding=new DataGridBinding("p6"),
                                                    Width=100
                                                },
                                                new DataGridTextColumn
                                                {
                                                    Header="3dfsd",
                                                    Binding=new DataGridBinding("p7"),
                                                    Width="100"
                                                },
                                                new DataGridTextColumn
                                                {
                                                    Header="3dfsd",
                                                    Binding=new DataGridBinding("p8"),
                                                    Width="100"
                                                },
                                                new DataGridTextColumn
                                                {
                                                    Header="3dfsd",
                                                    Binding=new DataGridBinding("p9"),
                                                    Width="100"
                                                },
                                            },
                                            Bindings =
                                            {
                                                {
                                                    nameof(DataGrid.Items),
                                                    nameof(Data),
                                                    this
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new TabItemTemplate
                            {
                                Header="TreeView",
                                Content=new Panel
                                {
                                    Width="100%",
                                    Height="100%",
                                    Children=
                                    {
                                        new TreeView
                                        {
                                            Width=300,
                                            Height=500,
                                            DisplayMemberPath=nameof(NodeData.Text),
                                            ItemsMemberPath=nameof(NodeData.Nodes),
                                            HeaderTemplate=typeof(TreeViewItemContentTemplate),
                                            ItemTemplate=typeof(TreeViewItemTemplate),
                                            Items=
                                            {
                                                new NodeData
                                                {
                                                    Text="test1",
                                                    Nodes=
                                                    {
                                                        new NodeData
                                                        {
                                                            Text="asda"
                                                        },
                                                        new NodeData
                                                        {
                                                            Text="asda"
                                                        },
                                                        new NodeData
                                                        {
                                                            Text="1asda"
                                                        },
                                                        new NodeData
                                                        {
                                                            Text="2asda"
                                                        },
                                                    }
                                                },
                                                new NodeData
                                                {
                                                    Text="测试",
                                                    Nodes=
                                                    {
                                                        new NodeData
                                                        {
                                                            Text="3asda"
                                                        },
                                                        new NodeData
                                                        {
                                                            Text="4asda",
                                                            Nodes=
                                                            {
                                                                new NodeData
                                                                {
                                                                    Text="6asda"
                                                                },
                                                                new NodeData
                                                                {
                                                                    Text="7asda"
                                                                },
                                                            }
                                                        },
                                                        new NodeData
                                                        {
                                                            Text="6asda"
                                                        },
                                                        new NodeData
                                                        {
                                                            Text="7asda"
                                                        },
                                                        new NodeData
                                                        {
                                                            Text="4asda",
                                                            Nodes=
                                                            {
                                                                new NodeData
                                                                {
                                                                    Text="6asda"
                                                                },
                                                                new NodeData
                                                                {
                                                                    Text="7asda"
                                                                },
                                                                new NodeData
                                                                {
                                                                    Text="6asda"
                                                                },
                                                                new NodeData
                                                                {
                                                                    Text="7asda"
                                                                },
                                                            }
                                                        },
                                                        new NodeData
                                                        {
                                                            Text="3asda"
                                                        },
                                                        new NodeData
                                                        {
                                                            Text="4asda",
                                                            Nodes=
                                                            {
                                                                new NodeData
                                                                {
                                                                    Text="6asda"
                                                                },
                                                                new NodeData
                                                                {
                                                                    Text="7asda"
                                                                },
                                                                new NodeData
                                                                {
                                                                    Text="6asda"
                                                                },
                                                                new NodeData
                                                                {
                                                                    Text="7asda"
                                                                },
                                                            }
                                                        },
                                                    }
                                                },
                                                new NodeData
                                                {
                                                    Text="test3"
                                                },
                                                new NodeData
                                                {
                                                    Text="test4"
                                                },
                                            }
                                        }
                                    }
                                }
                            },
                            new TabItemTemplate
                            {
                                Header="SVG",
                                Content=new Panel
                                {
                                    Size=SizeField.Fill,
                                    Children =
                                    {
                                        new SVG
                                        {
                                            MarginLeft = 62.6f,
                                            MarginTop = 32.9f,
                                            Width=225.3f,
                                            Stretch= Stretch.Uniform,
                                            Source="res://CpfNativeAOT/test.svg",
                                        },
                                        new SVG
                                        {
                                            IsAntiAlias = true,
                                            Fill = "#EEE300",
                                            MarginLeft = 506f,
                                            MarginTop = 37.2f,
                                            Width=225.3f,
                                            Stretch= Stretch.Uniform,
                                            Source="res://CpfNativeAOT/test.svg",
                                        },
                                        new SVG
                                        {
                                            RenderTransform = new GeneralTransform
                                            {
                                                Angle = 39.6f,
                                            },
                                            MarginLeft = 301.3f,
                                            MarginTop = 302.3f,
                                            Width=225.3f,
                                            Stretch= Stretch.Uniform,
                                            Source="res://CpfNativeAOT/test.svg"
                                        },
                                        new Label
                                        {
                                            Foreground = "#FFFFFF",
                                            FontSize = 16f,
                                            Text = "使用SVG做图标不会模糊，任意缩放，https://www.iconfont.cn/ 海量svg资源",
                                        },
                                    }
                                }
                            }
                        }
                    }
                }
            })
            {
                MaximizeBox = true
            });
            LoadStyleFile("res://CpfNativeAOT/Stylesheet3.css");
            //加载样式文件，文件需要设置为内嵌资源

            if (!DesignMode)//设计模式下不执行
            {
                
            }
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Items = new Collection<ItemData>();
            for (int i = 0; i < 100; i++)
            {
                Items.Add(new ItemData { Name = "马大云" + i, Introduce = "这人很帅" + i });
            }

            CPF.Styling.ResourceManager.GetImage("res://CpfNativeAOT/Resources/home.png", a =>
            {
                var data = new DataTable();
                for (int i = 0; i < 9; i++)
                {
                    data.Columns.Add("p" + (i + 1).ToString());
                }
                data.Columns[1].DataType = typeof(bool);
                data.Columns[3].DataType = typeof(int);
                data.Columns[5].DataType = typeof(Image);
                for (int i = 0; i < 1000; i++)
                {
                    var row = data.NewRow();
                    for (int j = 0; j < 9; j++)
                    {
                        if (j != 1)
                        {
                            if (j == 5)
                            {
                                row[j] = a;
                            }
                            else
                            {
                                row[j] = i;
                            }
                        }
                    }
                    row[0] = i % 3;
                    row[1] = true;
                    data.Rows.Add(row);
                }
                Data = data.ToItems();
            });
        }

        Control mask;
        Storyboard storyboard;
        void ShowDialogForm()
        {
            if (mask == null)
            {
                mask = new Control { Width = "100%", Height = "100%", Background = "0,0,0,0", Commands = { { nameof(Control.MouseDown), (s, e) => DragMove() } } };
                //淡入效果
                storyboard = new Storyboard
                {
                    Timelines =
                    {
                        new Timeline(1)
                        {
                            KeyFrames =
                            {
                                new KeyFrame<SolidColorFill>{ Property=nameof(Control.Background), Value="0,0,0,100" }
                            }
                        }
                    }
                };
            }
            this.Children.Add(mask);
            storyboard.Start(mask, TimeSpan.FromSeconds(0.3), 1, EndBehavior.Reservations);

#if !DesignMode
            var dv = new DialogView(this);
            dv.MarginTop = -100;
            dv.TransitionValue(nameof(MarginTop), (FloatField)100, TimeSpan.FromSeconds(0.3), new PowerEase { }, AnimateMode.EaseOut);
            Children.Add(dv);
#endif
        }

        public void CloseDialogForm(DialogView dialogView)
        {
            //采用过渡属性的写法定义淡出效果
            mask.TransitionValue(nameof(Control.Background), (SolidColorFill)"0,0,0,0", TimeSpan.FromSeconds(0.3), null, AnimateMode.Linear, () =>
            {
                this.Children.Remove(mask);
            });

            dialogView.TransitionValue(nameof(MarginTop), (FloatField)(-100), TimeSpan.FromSeconds(0.3), new PowerEase { }, AnimateMode.EaseIn, () =>
            {
                this.Children.Remove(dialogView);
            });
        }

        void Animation(Button button, IEase ease)
        {
            var old = button.MarginTop;
            button.TransitionValue(nameof(MarginTop), (FloatField)(button.MarginTop.Value + 150), TimeSpan.FromSeconds(0.8), ease, AnimateMode.EaseIn, () =>
            {
                button.MarginTop = old;
            });
        }

        Storyboard storyboard1;
        void Animation(Button button)
        {
            //button.RenderTransform = new GeneralTransform();
            if (storyboard1 == null)
            {
                storyboard1 = new Storyboard
                {
                    Timelines =
                    {
                        new Timeline(0.5f)
                        {
                            KeyFrames =
                            {
                                new KeyFrame<FloatField>{ Property=nameof(button.MarginLeft), Value=500, AnimateMode= AnimateMode.EaseIn, Ease=new PowerEase() },
                                new KeyFrame<GeneralTransform>{ Property=nameof(button.RenderTransform),Value=new GeneralTransform{ SkewX=50 }, AnimateMode= AnimateMode.EaseIn, Ease=new ElasticEase() },
                            }
                        },
                        new Timeline(1)
                        {
                            KeyFrames =
                            {
                                new KeyFrame<GeneralTransform>{ Property=nameof(button.RenderTransform),Value=new GeneralTransform{ Angle=130,SkewX=0,ScaleY=3 }, AnimateMode= AnimateMode.EaseIn, Ease=new ElasticEase() },
                            }
                        },
                    }
                };
            }
            storyboard1.Start(button, TimeSpan.FromSeconds(3));
        }

        Collection<ItemData> Items
        {
            get { return GetValue<Collection<ItemData>>(); }
            set { SetValue(value); }
        }

        IList Data
        {
            get { return GetValue<IList>(); }
            set { SetValue(value); }
        }
    }
}

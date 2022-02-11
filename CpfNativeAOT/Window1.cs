using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using CPF.Controls;
using CPF;
using CPF.Drawing;
using CPF.Shapes;
using CPF.Styling;
using CPF.Animation;
using CPF.Input;
using CPF.Effects;
using CPF.Documents;

namespace CPFApplication1
{
    public class Window1 : Window
    {
        public Window1()
        { }

        public Window1 Window { get; set; }

        Window1 Test()
        {
            return null;
        }

        PiecesEffect effect = new PiecesEffect { Value = 1 };
        protected override void InitializeComponent()
        {
            ViewFill color = "#fff";
            ViewFill hoverColor = "255,255,255,40";
            Title = "标题";
            CanResize = true;
            Background = null;
            MinWidth = 150;
            MinHeight = 50;
            AllowDrop = true;
            Width = 800;
            Height = 500;
            //窗体阴影
            var frame = Children.Add(new Border
            {
                Width = "100%",
                Height = "100%",
                Background = null,
                BorderType = BorderType.BorderStroke,
                BorderStroke = new Stroke(0),
                ShadowBlur = 5,
                Bindings =
                {
                    {
                        nameof(Border.ShadowBlur),
                        nameof(Window.WindowState),
                        this,
                        BindingMode.OneWay,
                        a => (WindowState)a == WindowState.Maximized ? 0 : 5
                    }
                }
            });
            //用来裁剪内容，不然内容超出阴影
            var clip = new Decorator
            {
                Width = "100%",
                Height = "100%",
                ClipToBounds = true,
                Background = "#fff"
            };
            frame.Child = clip;
            var grid = (Grid)(clip.Child = new Grid
            {
                Width = "100%",
                Height = "100%",
                ColumnDefinitions =
                {
                    new ColumnDefinition()
                },
                RowDefinitions =
                {
                    new RowDefinition
                    {
                        Height = 30
                    },
                    new RowDefinition
                    {
                        
                    }
                },
            });
            //标题栏和按钮
            grid.Children.Add(
            new Panel
            {
                Name = "caption",
                //Background = "#1E9FFF",
                Width = "100%",
                Height = "100%",
                Commands =
                {
                    {
                        nameof(Window.MouseDown),
                        nameof(Window.DragMove),
                        this
                    }
                },
                Children =
                {
                    new TextBlock
                    {
                        MarginLeft=10,
                        Bindings=
                        {
                            {
                                nameof(TextBlock.Text),
                                nameof(Window.Title),
                                this
                            }
                        },
                        Foreground="#fff"
                    },
                    new StackPanel
                    {
                        MarginRight=0,
                        Height = "100%",
                        Orientation= Orientation.Horizontal,
                        Children =
                        {
                            new Panel
                            {
                                ToolTip="最小化",
                                Name="min",
                                Width = 30,
                                Height = "100%",
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
                                ToolTip="最大化",
                                Name="max",
                                Width = 30,
                                Height = "100%",
                                Children=
                                {
                                    new Rectangle
                                    {
                                        Width=14,
                                        Height=12,
                                        StrokeStyle="2",
                                        StrokeFill = color
                                    }
                                },
                                Commands =
                                {
                                    {
                                        nameof(Button.MouseDown),
                                        (s,e)=>
                                        {
                                            (e as MouseButtonEventArgs).Handled = true;
                                            this.WindowState= WindowState.Maximized;
                                        }
                                    }
                                },
                                Bindings =
                                {
                                    {
                                        nameof(Border.Visibility),
                                        nameof(Window.WindowState),
                                        this,
                                        BindingMode.OneWay,
                                        a => (WindowState)a == WindowState.Maximized ? Visibility.Collapsed : Visibility.Visible
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
                                ToolTip="向下还原",
                                Name="nor",
                                Width = 30,
                                Height = "100%",
                                Children=
                                {
                                    new Rectangle
                                    {
                                        MarginTop=15,
                                        MarginLeft=8,
                                        Width=11,
                                        Height=8,
                                        StrokeStyle="1.5",
                                        StrokeFill = color
                                    },
                                    new Polyline
                                    {
                                        MarginTop=11,
                                        MarginLeft=12,
                                        Points=
                                        {
                                            new Point(0,3),
                                            new Point(0,0),
                                            new Point(9,0),
                                            new Point(9,7),
                                            new Point(6,7)
                                        },
                                        StrokeFill = color,
                                        StrokeStyle="2"
                                    }
                                },
                                Commands =
                                {
                                    {
                                        nameof(Button.MouseDown),
                                        (s, e) =>
                                        {
                                            (e as MouseButtonEventArgs).Handled = true;
                                            this.WindowState = WindowState.Normal;
                                        }
                                    }
                                },
                                Bindings =
                                {
                                    {
                                        nameof(Border.Visibility),
                                        nameof(Window.WindowState),
                                        this,
                                        BindingMode.OneWay,
                                        a => (WindowState)a == WindowState.Normal ? Visibility.Collapsed : Visibility.Visible
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
                                Name="close",
                                ToolTip="关闭",
                                Width = 30,
                                Height = "100%",
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
                                            (e as MouseButtonEventArgs).Handled=true;
                                            //关闭播放动画
                                    effect.Value=0;
                                            Effect = effect;
                                            Storyboard storyboard1 = new Storyboard
                                            {
                                                Timelines =
                                                {
                                                    new Timeline(1)
                                                    {
                                                        KeyFrames =
                                                        {
                                                            new KeyFrame<float>
                                                            {
                                                                Value=1,
                                                                Property="Effect.Value",
                                                                AnimateMode= AnimateMode.EaseIn,
                                                                Ease=new PowerEase
                                                                {
                                                                    Power=0.6
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            };
                                            storyboard1.Start(this, TimeSpan.FromSeconds(0.5f));
                                            storyboard1.Completed +=Storyboard_Completed;
                                        }
                                    },
                                    {
                                        nameof(Button.MouseDown),
                                        (s,e)=>
                                        {
                                            (e as MouseButtonEventArgs).Handled=true;
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
                            }
                        }
                    }
                }
            });
            var pop = new ContextMenu
            {
                //PlacementTarget = btn,
                //Placement = PlacementMode.Mouse,
                Items = new UIElement[]
                {
                    new MenuItem
                    {
                        Header = "1"
                    },
                    new Separator
                    {
                        
                    },
                    new MenuItem
                    {
                        Header = "2",
                        Items=new MenuItem[]
                        {
                            new MenuItem
                            {
                                Header = "21",
                            },
                            new MenuItem
                            {
                                Header = "22",
                                Items=new MenuItem[]
                                {
                                    new MenuItem
                                    {
                                        Header = "221"
                                    },
                                    new MenuItem
                                    {
                                        Header = "222",
                                    }
                                }
                            },
                        },
                    },
                    new MenuItem
                    {
                        Header = "3",
                        IsCheckable=true,
                        Items = new MenuItem[]
                        {
                            new MenuItem
                            {
                                Header = "31"
                            },
                            new MenuItem
                            {
                                Header = "32"
                            },
                        }
                    }
                },
            };
            var datagrid = new DataGrid
            {
                Width = "60%",
                Height = "60%",
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
                        nameof(Model.Data)
                    }
                }
            };
            grid.Children.Add(new TabControl
            {
                Width = "100%",
                Height = "100%",
                //Background = "10,255,255,255",
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
                Items =
                {
                    new TabItem
                    {
                        Header="基础控件",
                        Content=new StackPanel
                        {
                            Width="100%",
                            Height="100%",
                            //Background=Color.FromArgb(100,0,0,0),
                        //Background="linear-gradient(0 0,300 300,#fff,#000,#faa)",
                        Children=
                            {
                                new StackPanel
                                {
                                    Orientation= Orientation.Horizontal,
                                    Children=
                                    {
                                        new Button
                                        {
                                            Content = "打开文件对话框",
                                            Width=100,
                                            Height=20,
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    async (s,e)=>
                                                    {
                                                        var f=new OpenFileDialog();
                                                        var sf=await f.ShowAsync(this);
                                                    }
                                                }
                                            }
                                        },
                                        new Button
                                        {
                                            Content = "选择目录对话框",
                                            Width=100,
                                            Height=20,
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    async (s,e)=>
                                                    {
                                                        var f=new OpenFolderDialog();
                                                        var sf=await f.ShowAsync(this);
                                                    }
                                                }
                                            }
                                        },
                                        new Button
                                        {
                                            Content = "保存文件对话框",
                                            Width=100,
                                            Height=20,
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    async (s,e)=>
                                                    {
                                                        var f=new SaveFileDialog();
                                                        var sf= await f.ShowAsync(this);
                                                    }
                                                }
                                            }
                                        },
                                        new Button
                                        {
                                            Content = "模态窗体",
                                            Width=100,
                                            Height=20,
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    (s,e)=>
                                                    {
                                                        var f=new Window();
                                                        f.Background=null;
                                                        f.Width=300;
                                                        f.Height=300;
                                                        f.CanResize=true;
                                                        f.Children.Add(new WindowFrame(f,new Button
                                                        {
                                                            Content="test"
                                                        }));
                                                        f.ShowDialog(this);
                                                    }
                                                }
                                            }
                                        },
                                        new Button
                                        {
                                            Content = "切换样式2",
                                            Width=100,
                                            Height=20,
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    (s,e)=>
                                                    {
                                                        var b=s as Button;
                                                        if (b.Content.ToString()=="切换样式2")
                                                        {
                                                            LoadStyleFile("res://CpfNativeAOT.Stylesheet2.css");
                                                            b.Content="切换样式1";
                                                        }
                                                        else
                                                        {
                                                            LoadStyleFile("res://CpfNativeAOT.Stylesheet1.css");
                                                            b.Content="切换样式2";
                                                        }
                                                    }
                                                }
                                            }
                                        },
                                        new Button
                                        {
                                            Content="全屏",
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    (s,e)=>
                                                    {
                                                        //this.IsFullScreen = !IsFullScreen;
                                                    }
                                                }
                                            }
                                        },
                                    }
                                },
                                new CheckBox
                                {
                                    Content="选择1",
                                    MarginTop=2
                                },
                                new CheckBox
                                {
                                    Content="选择2",
                                    MarginTop=2,
                                    IsThreeState=true
                                },
                                new RadioButton
                                {
                                    Content=new Button
                                    {
                                        Content="单选1"
                                    },
                                    Background="#fff",
                                    MarginTop=2,
                                    GroupName="分组"
                                },
                                new RadioButton
                                {
                                    Content="单选2",
                                    MarginTop=2,
                                    GroupName="分组"
                                },
                                new ComboBox
                                {
                                    Width=100,
                                    Height=25,
                                    Items=
                                    {
                                        "sdag",
                                        "测试",
                                        "342a"
                                    },
                                    Bindings=
                                    {
                                        {
                                            nameof(ComboBox.SelectedValue),
                                            nameof(Model.SelectValue),
                                            null,
                                            BindingMode.OneWayToSource
                                        }
                                    }
                                },
                                new TextBox
                                {
                                    Classes=
                                    {
                                        "Single"
                                    },
                                    Width=100,
                                    Height=25,
                                    Bindings=
                                    {
                                        {
                                            nameof(TextBox.Text),
                                            nameof(Model.SelectValue)
                                        },
                                        {
                                            nameof(TextBlock.Text),
                                            nameof(Model.TextSize),
                                            null,
                                            BindingMode.OneWayToSource,
                                            null,
                                            a=>
                                            {
                                                var tb = Binding.Current.Owner as TextBox;
                                                return DrawingFactory.Default.MeasureString(a.ToString(), new Font(tb.FontFamily, tb.FontSize, tb.FontStyle)).ToString();
                                            }
                                        }
                                    }
                                },
                                new TextBlock
                                {
                                    Bindings=
                                    {
                                        {
                                            nameof(TextBlock.Text),
                                            nameof(Model.TextSize)
                                        }
                                    }
                                },
                                new TextBox
                                {
                                    Width="60%",
                                    Height=250,
                                    IsUndoEnabled=true,
                                    Text="TextBox",
                                    Background="#fff",
                                    IsAllowPasteImage=true,
                                    Styles=
                                    {
                                        new DocumentStyle
                                        {
                                            Foreground = "0,0,255"
                                        },
                                        new DocumentStyle
                                        {
                                            Foreground = "192,0,0"
                                        },
                                        new DocumentStyle
                                        {
                                            Foreground = "100,100,100"
                                        }
                                    },
                                    KeywordsStyles=
                                    {
                                        new KeywordsStyle
                                        {
                                            Keywords = "using |namespace |class |true|new ",
                                            IsRegex=true,
                                            StyleId = 0
                                        },
                                        new KeywordsStyle
                                        {
                                            Keywords = "(\").*(\")",
                                            IsRegex = true,
                                            StyleId = 1
                                        },
                                        new KeywordsStyle
                                        {
                                            Keywords = "(\\\').*(\\\')",
                                            IsRegex = true,
                                            StyleId = 2
                                        }
                                    }
                                },
                                new ScrollBar
                                {
                                    Width=200,
                                    Height=20,
                                    MarginTop=20,
                                    Orientation= Orientation.Horizontal
                                },
                            }
                        }
                    },
                    new TabItem
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
                                    RenderTransform=new RotateTransform(10),
                                    Content = "按住鼠标播放动画",
                                    Width=100,
                                    Height=30,
                                    MarginTop=0,
                                    MarginLeft=0,
                                    Triggers=
                                    {
                                        new Trigger
                                        {
                                            Property=nameof(Button.IsMouseCaptured),
                                            Animation= new Storyboard
                                            {
                                                Timelines =
                                                {
                                                    new Timeline(.5f)
                                                    {
                                                        //定义一个时间线，从上个时间点到这个时间点。0到1，相对整个动画的时间。现在定义的是前一半的时间
                                    KeyFrames =
                                                        {
                                                            new KeyFrame<FloatField>
                                                            {
                                                                Property = nameof(UIElement.MarginLeft),
                                                                //属性名
                                            Value = 400,
                                                                //动画目标值
                                            //Ease = new PowerEase(),//缓动方式
                                            AnimateMode = AnimateMode.Linear//线性或者缓动

                                                            },
                                                            //new KeyFrame<FloatField> {
                                        //    Property = nameof(UIElement.MarginTop),//属性名
                                        //    Value = 200,//动画目标值
                                        //}

                                                        }
                                                    },
                                                    new Timeline(1)
                                                    {
                                                        //从上一个时间点0.5到1，就是后一半的时间
                                    KeyFrames =
                                                        {
                                                            new KeyFrame<GeneralTransform>
                                                            {
                                                                Property = nameof(UIElement.RenderTransform),
                                                                Value = new GeneralTransform()
                                                                {
                                                                    Angle=720,
                                                                    ScaleX=2,
                                                                    ScaleY=2
                                                                },
                                                                Ease = new BackEase(),
                                                                AnimateMode = AnimateMode.Linear
                                                            }
                                                        }
                                                    },
                                                }
                                            },
                                            AnimationDuration = TimeSpan.FromSeconds(1)
                                        }
                                    },
                                },
                                new TextBlock
                                {
                                    MarginTop=50,
                                    MarginLeft=0,
                                    Text="鼠标移入变色CSS定义",
                                    Classes=
                                    {
                                        "testAnimation1"
                                    }
                                },
                                new Picture
                                {
                                    MarginTop=100,
                                    Source="https://dss0.bdstatic.com/5aV1bjqh_Q23odCf/static/superman/img/logo_top-e3b63a0b1b.png",
                                    Triggers=
                                    {
                                        new Trigger(nameof(IsMouseOver), Relation.Me)
                                        {
                                            Animation=new Storyboard
                                            {
                                                Timelines =
                                                {
                                                    new Timeline(1)
                                                    {
                                                        KeyFrames =
                                                        {
                                                            new KeyFrame<GeneralTransform>
                                                            {
                                                                Property = nameof(UIElement.RenderTransform),
                                                                Value = new GeneralTransform()
                                                                {
                                                                    ScaleX=1.5f,
                                                                    ScaleY=1.5f
                                                                },
                                                                Ease = new BackEase(),
                                                                AnimateMode = AnimateMode.EaseIn
                                                            }
                                                        }
                                                    }
                                                }
                                            },
                                            AnimationDuration = TimeSpan.FromSeconds(.5)
                                        }
                                    }
                                },
                                new ScrollBar
                                {
                                    Name="animationTransition",
                                    Orientation= Orientation.Horizontal,
                                    Maximum=1000,
                                    Width=500
                                },
                                new Button
                                {
                                    MarginLeft=5,
                                    MarginTop=200,
                                    Content="动态过渡到某个值",
                                    Commands=
                                    {
                                        {
                                            nameof(MouseDown),
                                            (s,e)=>
                                            {
                                                this.Find<ScrollBar>().FirstOrDefault(a=>a.Name== "animationTransition").TransitionValue(nameof(ScrollBar.Value),(float)new Random().Next(0,1000),TimeSpan.FromSeconds(0.3));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new TabItem
                    {
                        Header="虚拟模式加载大数据",
                        Content=new Panel
                        {
                            Width="100%",
                            Height="100%",
                            IsAntiAlias=true,
                            //Background="url(http://static.tieba.baidu.com/tb/editor/images/client/image_emoticon16.png) no-repeat fill",
                        Children=
                            {
                                new StackPanel
                                {
                                    MarginTop=5,
                                    Orientation= Orientation.Horizontal,
                                    Children=
                                    {
                                        new TextBlock
                                        {
                                            MarginTop=5,
                                            Text="插入数据的索引位置:"
                                        },
                                        new TextBox
                                        {
                                            MarginLeft=5,
                                            Height=25,
                                            Width=50,
                                            Classes=
                                            {
                                                "Single"
                                            },
                                            Bindings=
                                            {
                                                {
                                                    nameof(TextBox.Text),
                                                    nameof(Model.InsertIndex),
                                                    null,
                                                    BindingMode.OneWayToSource,
                                                    null,
                                                    a =>
                                                    {
                                                        int.TryParse(a.ToString(), out int result);
                                                        return result;
                                                    }
                                                }
                                            }
                                        },
                                        new TextBlock
                                        {
                                            MarginTop=5,
                                            Text="插入的数据:"
                                        },
                                        new TextBox
                                        {
                                            MarginLeft=5,
                                            Height=25,
                                            Width=50,
                                            Classes=
                                            {
                                                "Single"
                                            },
                                            Bindings=
                                            {
                                                {
                                                    nameof(TextBox.Text),
                                                    nameof(Model.InsertText),
                                                    null,
                                                    BindingMode.OneWayToSource
                                                }
                                            }
                                        },
                                        new Button
                                        {
                                            Content="插入",
                                            Width=60,
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    nameof(Model.Insert)
                                                }
                                            },
                                            Foreground="#fff"
                                        },
                                        new Button
                                        {
                                            MarginLeft=5,
                                            Content="删除选中",
                                            Width=60,
                                            Commands=
                                            {
                                                {
                                                    nameof(Button.Click),
                                                    nameof(Model.RemoveSelect)
                                                }
                                            }
                                        },
                                    }
                                },
                                new ListBox
                                {
                                    //Background="#aaa",
                                Name="listbox",
                                    IsVirtualizing=true,
                                    //VirtualizationMode= VirtualizationMode.Recycling,
                                SelectionMode= SelectionMode.Extended,
                                    Width=200,
                                    Height=300,
                                    //Items=list,
                                ItemTemplate=new ListBoxItem
                                    {
                                        Width="100%"
                                    },
                                    Bindings=
                                    {
                                        {
                                            nameof(ListBox.Items),
                                            nameof(Model.List)
                                        },
                                        {
                                            nameof(ListBox.SelectedIndex),
                                            nameof(Model.SelectIndex),
                                            null,
                                            BindingMode.OneWayToSource
                                        }
                                    }
                                },
                                //new Button{ Content="排序" },

                            }
                        }
                    },
                    new TabItem
                    {
                        Header="TreeView",
                        Content= new Panel
                        {
                            Width="100%",
                            Height="100%",
                            Children=
                            {
                                new Button
                                {
                                    Content="添加节点",
                                    Width=80,
                                    Height=30,
                                    MarginTop=2,
                                    Commands=
                                    {
                                        {
                                            nameof(Button.MouseDown),
                                            nameof(Model.AddNode)
                                        }
                                    }
                                },
                                new TreeView
                                {
                                    Width=150,
                                    Height=200,
                                    DisplayMemberPath="Text",
                                    ItemsMemberPath="Nodes",
                                    Background="#aaa",
                                    //Items= nodes
                                Bindings=
                                    {
                                        {
                                            nameof(TreeView.Items),
                                            nameof(Model.Nodes)
                                        }
                                    },
                                }
                            }
                        },
                    },
                    new TabItem
                    {
                        Header = "右键菜单",
                        Content =  new Button
                        {
                            Width = 100,
                            Height = 20,
                            Content = "右键",
                            ContextMenu = pop,
                        },
                    },
                    new TabItem
                    {
                        Header = "DataGrid",
                        Content =
                        new Panel
                        {
                            Width="100%",
                            Height="100%",
                            Children=
                            {
                                datagrid,
                            }
                        },
                    },
                    new TabItem
                    {
                        Header = "布局",
                        Content =
                        new Panel
                        {
                            Width="100%",
                            Height="100%",
                            Children=
                            {
                                new Grid
                                {
                                    Name="testGrid",
                                    Background="#999",
                                    Width="80%",
                                    Height="80%",
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
                                            Width="300"
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
                                        {
                                            new GridSplitter
                                            {
                                                MarginLeft=0,
                                                ShowsPreview=true
                                            },
                                            1,
                                            0
                                        }
                                    },
                                },
                            }
                        },
                    },
                    new TabItem
                    {
                        Header="拖拽",
                        Content =
                        new Panel
                        {
                            Width="100%",
                            Height="100%",
                            Children=
                            {
                                new TextBlock
                                {
                                    MarginLeft=0,
                                    Text="文字拖拽给我",
                                    Triggers=
                                    {
                                        new Trigger(nameof(TextBlock.IsDragOver), Relation.Me)
                                        {
                                            Setters =
                                            {
                                                {
                                                    nameof(Background),
                                                    "#f00"
                                                }
                                            }
                                        }
                                    },
                                    Commands=
                                    {
                                        {
                                            nameof(Drop),
                                            (s,e)=>
                                            {
                                                (s as TextBlock).Text = (e as DragEventArgs).Data.GetData(DataFormat.Text).ToString();
                                            }
                                        }
                                    }
                                },
                                new TextBlock
                                {
                                    MarginRight=0,
                                    Text="文字拖拽给别人",
                                    Commands=
                                    {
                                        {
                                            nameof(MouseDown),
                                            (s,e)=>
                                            {
                                                DragDrop.DoDragDrop(DragDropEffects.Copy, (DataFormat.Text, "拖拽的文字"));
                                            }
                                        }
                                    }
                                },
                            }
                        },
                    },
                    new TabItem
                    {
                        Header="位图特效",
                        Content =
                        new Panel
                        {
                            Width="100%",
                            Height="100%",
                            Children=
                            {
                                new Button
                                {
                                    MarginTop=5,
                                    Content="模糊，你撸多了",
                                    Effect=new BlurEffect
                                    {
                                        
                                    }
                                },
                                new Button
                                {
                                    MarginTop=35,
                                    Content="马赛克，你撸多了",
                                    Effect=new MosaicEffect
                                    {
                                        Size=2
                                    }
                                },
                                new Button
                                {
                                    MarginTop=65,
                                    Content="半透明",
                                    Effect=new OpacityEffect
                                    {
                                        Opacity=0.5f
                                    }
                                },
                                new Button
                                {
                                    MarginTop=95,
                                    Content="灰色",
                                    Effect=new GrayScaleEffect
                                    {
                                        
                                    }
                                },
                                new Picture
                                {
                                    MarginTop=125,
                                    Source="http://tb2.bdstatic.com/tb/img/single_member_100_0b51e9e.png",
                                    Effect= new ReliefEffect()
                                },
                                new Path
                                {
                                    StrokeFill = "#DA2D2D",
                                    IsAntiAlias = true,
                                    MarginLeft = 51.1f,
                                    MarginTop = 6.7f,
                                    Fill = "linear-gradient(0 0,100% 0,#EC2323 0,#0BE2FF 0.57980293,#FFFFFF 1)",
                                    StrokeStyle = new Stroke
                                    {
                                        Width = 10,
                                        StrokeCap = CapStyles.Round
                                    },
                                    Data = @"M153 334
C153 334 151 334 151 334
C151 339 153 344 156 344
C164 344 171 339 171 334
C171 322 164 314 156 314
C142 314 131 322 131 334
C131 350 142 364 156 364
C175 364 191 350 191 334
C191 311 175 294 156 294
C131 294 111 311 111 334
C111 361 131 384 156 384
C186 384 211 361 211 334
C211 300 186 274 156 274"
                                }
                            }
                        },
                    },
                    new TabItem
                    {
                        Header="背景特效",
                        Content =
                        new Panel
                        {
                            Width="100%",
                            Height="100%",
                            Children=
                            {
                                new TextBlock
                                {
                                    MarginTop=5,
                                    Text="渐变背景",
                                    Background="linear-gradient(0 0,30 30,#fff,#0f0,#faa)"
                                },
                                new TextBlock
                                {
                                    MarginTop=35,
                                    Height=50,
                                    Width=50,
                                    Text="径向渐变",
                                    Background=new RadialGradientFill
                                    {
                                        GradientStops=
                                        {
                                            new GradientStop(Color.Black,0),
                                            new GradientStop(Color.White,1)
                                        },
                                        Radius=10
                                    }
                                },
                                new TextBlock
                                {
                                    MarginTop=95,
                                    Height=150,
                                    Width=150,
                                    Text="图片背景",
                                    Background="url(https://tb1.bdstatic.com/tb/r/image/2019-09-29/c29109a0c0d4fe6832d41fa180ffa8f1.jpg) no-repeat fill"
                                },
                                new TextBlock
                                {
                                    MarginTop=255,
                                    Height=250,
                                    Width=250,
                                    Text="图片背景",
                                    Background="url(https://tb1.bdstatic.com/tb/r/image/2019-09-29/c29109a0c0d4fe6832d41fa180ffa8f1.jpg)"
                                },
                            }
                        },
                    }
                }
            }, 0, 1);
            //if (DesignMode)
            //{
            //   Children.Add(new Button { Content = "设计模式" });
            // }
            LoadStyleFile("res://CpfNativeAOT/Stylesheet1.css");
            Effect = effect;
            Storyboard storyboard = new Storyboard
            {
                Timelines =
                {
                    new Timeline(1)
                    {
                        KeyFrames =
                        {
                            new KeyFrame<float>
                            {
                                Value=0,
                                Property="Effect.Value",
                                AnimateMode= AnimateMode.EaseOut,
                                Ease=new CubicEase
                                {
                                    
                                }
                            }
                        }
                    }
                }
            };
            storyboard.Start(this, TimeSpan.FromSeconds(1));
            storyboard.Completed += (s, e) =>
            {
                //System.Diagnostics.Debug.WriteLine("end"); 
                this.Effect = null;
            };
        }

        private void Storyboard_Completed(object sender, StoryboardCompletedEventArgs e)
        {
            this.Close();
        }
    }
}

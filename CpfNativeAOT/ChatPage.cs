using System;
using System.Collections.Generic;
using System.Text;
using CPF;
using CPF.Drawing;
using CPF.Controls;
using CPF.Shapes;
using CPF.Styling;
using CPF.Animation;
using CPF.Platform;
using CPF.Documents;
using System.Threading;

namespace CPFApplication1
{
    [CPF.Design.DesignerLoadStyle("res://CpfNativeAOT/QQChat.css")]
    public class ChatPage : Control
    {
        protected override void InitializeComponent()
        {
            //模板定义
            if (DesignMode)
            {
                Width = 400;
                Height = 400;
                Background = "#fff";
            }
            else
            {
                Size = SizeField.Fill;
            }
            Children.Add(new TabControl
            {
                Size = SizeField.Fill,
                Items =
                {
                    new TabItem
                    {
                        Header="聊天",
                        Content=new Grid
                        {
                            Size = SizeField.Fill,//LineFill="#f00",
                            //LineStroke="1",
                            ColumnDefinitions =
                            {
                                new ColumnDefinition
                                {

                                },
                                new ColumnDefinition
                                {
                                    Width=200,
                                    MaxWidth=200,
                                    MinWidth=100
                                },
                            },
                            RowDefinitions =
                            {
                                new RowDefinition
                                {
                                    MinHeight=100
                                },
                                new RowDefinition
                                {
                                    MinHeight=100
                                }
                            },
                            Children =
                            {
                                new TextBox
                                {
                                    HScrollBarVisibility= ScrollBarVisibility.Hidden,
                                    WordWarp=true,
                                    Size=SizeField.Fill,
                                    IsReadOnly=true,
                                    Name="chatContent",
                                    PresenterFor=this,
                                },
                                new StackPanel
                                {
                                    Orientation= Orientation.Horizontal,
                                    MarginTop=5,
                                    Height=25,
                                    Width="100%",
                                    Children =
                                    {
                                        new Label
                                        {
                                            Classes=
                                            {
                                                "icon_free",
                                                "tool_btn"
                                            },
                                            Text = ((char)0xf118).ToString(),
                                        },
                                        new Label
                                        {
                                            Classes=
                                            {
                                                "icon_free",
                                                "tool_btn"
                                            },
                                            Text = ((char)0xf0c4).ToString(),
                                        },
                                        new Label
                                        {
                                            Classes=
                                            {
                                                "icon_free",
                                                "tool_btn"
                                            },
                                            Text = ((char)0xf07b).ToString(),
                                        },
                                        new Label
                                        {
                                            Classes=
                                            {
                                                "icon_free",
                                                "tool_btn"
                                            },
                                            Text = ((char)0xf03e).ToString(),
                                        },
                                    },
                                    Attacheds =
                                    {
                                        {
                                            Grid.RowIndex,
                                            1
                                        }
                                    }
                                },
                                new Label
                                {
                                    Classes=
                                    {
                                        "icon_free",
                                        "tool_btn"
                                    },
                                    Text = ((char)0xf017).ToString(),
                                    MarginRight=0,
                                    MarginTop=5,
                                    Attacheds =
                                    {
                                        {
                                            Grid.RowIndex,
                                            1
                                        }
                                    }
                                },
                                new TextBox
                                {
                                    PresenterFor = this,
                                    Name = nameof(msgInput),
                                    MarginTop=30,
                                    MarginBottom=40,
                                    Width="100%",
                                    IsAllowPasteImage=true,
                                    WordWarp=true,
                                    Attacheds =
                                    {
                                        {
                                            Grid.RowIndex,
                                            1
                                        }
                                    }
                                },
                                new GridSplitter
                                {
                                    Background=null,
                                    BorderThickness=new Thickness(0,1,0,0),
                                    BorderFill="#eee",
                                    BorderType= BorderType.BorderThickness,
                                    MarginTop=0,
                                    Height=5,
                                    Width="100%",
                                    ResizeDirection= GridResizeDirection.Rows,
                                    Attacheds =
                                    {
                                        {
                                            Grid.RowIndex,
                                            1
                                        }
                                    }
                                },
                                new Panel
                                {
                                    Size=SizeField.Fill,
                                    BorderThickness=new Thickness(1,0,0,0),
                                    BorderFill="#eee",
                                    BorderType= BorderType.BorderThickness,
                                    Attacheds =
                                    {
                                        {
                                            Grid.ColumnIndex,
                                            1
                                        },
                                        {
                                            Grid.RowSpan,
                                            2
                                        },
                                    },
                                    Children =
                                    {
                                        new Button
                                        {
                                            Content="Cpf高仿QQ界面"
                                        }
                                    }
                                },
                                new GridSplitter
                                {
                                    Background=null,
                                    MarginLeft=0,
                                    Height="100%",
                                    Attacheds =
                                    {
                                        {
                                            Grid.ColumnIndex,
                                            1
                                        }
                                    }
                                },
                                new Button
                                {
                                    Classes=
                                    {
                                        "close"
                                    },
                                    Content="关闭",
                                    Width=70,
                                    Height=25,
                                    MarginBottom=10,
                                    MarginRight=100,
                                    Attacheds =
                                    {
                                        {
                                            Grid.RowIndex,
                                            1
                                        }
                                    }
                                },
                                new Button
                                {
                                    Commands =
                                    {
                                        {
                                            "Click",
                                            nameof(SendMsg),
                                            this,
                                            CommandParameter.EventSender,
                                            CommandParameter.EventArgs
                                        },
                                    },
                                    PresenterFor = this,
                                    Name = "send",
                                    Classes=
                                    {
                                        "send"
                                    },
                                    Content="发送",
                                    Width=70,
                                    Height=25,
                                    MarginBottom=10,
                                    MarginRight=10,
                                    Attacheds =
                                    {
                                        {
                                            Grid.RowIndex,
                                            1
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new TabItem
                    {
                        Header="公告",
                    },
                    new TabItem
                    {
                        Header="相册",
                    },
                    new TabItem
                    {
                        Header="文件",
                    }
                }
            });
            var chatContent = FindPresenterByName<TextBox>("chatContent");
            chatContent.Styles.Add(new DocumentStyle
            {
                Foreground = "#aaa"
            });
            for (int i = 0;
            i < 100;
            i++)
            {
                AddMessage(chatContent);
            }
        }
        TextBox msgInput;
        protected override void OnInitialized()
        {
            base.OnInitialized();
            msgInput = FindPresenterByName<TextBox>(nameof(msgInput));
        }
        static void AddMessage(TextBox chatContent)
        {
            var block = new Block { TextAlignment = TextAlignment.Center, Width = "100%" };
            block.Add("00:00:00", 0);
            chatContent.Document.Add(block);

            var left1 = new Block { };
            left1.Add(new InlineUIContainer { UIElement = new Ellipse { Width = 30, Height = 30, IsAntiAlias = true, MarginBottom = -12, MarginRight = 10, Fill = "url(res://CpfNativeAOT/Resources/headQQ.png) Clamp Fill", StrokeFill = null } });
            left1.Add("昵称", 0);
            left1.Add(new Block("简洁、直观、强悍的netcore跨平台UI开发框架\n框架理念和WPF类似，但是没有Xaml，直接用CSS和C#代码描述")
            {
                Margin = new Thickness(30, 0, 0, 0),
                WordWarp = true,
                MaxWidth = "80%",
                Padding = new Thickness(10),
                Background = new SudokuImageFill("res://CpfNativeAOT/Resources/aio_user_bg_nor (71).png"),
            });
            chatContent.Document.Add(left1);

            var right = new Block { TextAlignment = TextAlignment.Right, Width = "100%" };
            right.Add("昵称", 0);
            right.Add(new InlineUIContainer { UIElement = new Ellipse { Width = 30, Height = 30, IsAntiAlias = true, MarginBottom = -12, MarginLeft = 10, Fill = "url(res://CpfNativeAOT/Resources/headQQ.png),Clamp,Fill", StrokeFill = null } });
            right.Add(new Block("简洁、直观、强悍的netcore跨平台UI开发框架框架理念和WPF类似，但是没有Xaml，直接用CSS和C#代码描述")
            {
                WordWarp = true,
                MaxWidth = "80%",
                Margin = new Thickness(0, 5, 30, 5),
                Padding = new Thickness(10),
                Background = new SudokuImageFill("res://CpfNativeAOT/Resources/aio_friend_bg_nor (81).png"),
                Children =
                {
                    new InlineUIContainer
                    {
                        UIElement = new Picture()
                        {
                            MarginBottom = 2,
                            MarginLeft = 2,
                            MarginRight = 2,
                            MarginTop = 2,
                            Source = "res://CpfNativeAOT/Resources/headQQ.png",
                            MaxWidth = 200,
                            Stretch = Stretch.Uniform,
                            StretchDirection = StretchDirection.DownOnly
                        }
                    },
                    new DocumentChar('a')
                }
            });
            chatContent.Document.Add(right);
        }
        void SendMsg(CpfObject obj, RoutedEventArgs eventArgs)
        {
            var chatContent = FindPresenterByName<TextBox>("chatContent");
            var right = new Block { TextAlignment = TextAlignment.Right, Width = "100%" };
            right.Add("昵称", 0);
            right.Add(new InlineUIContainer
            {
                UIElement = new Ellipse
                {
                    Width = 30,
                    Height = 30,
                    IsAntiAlias = true,
                    MarginBottom = -12,
                    MarginLeft = 10,
                    Fill = "url(res://CpfNativeAOT/Resources/headQQ.png) Clamp Fill",
                    StrokeFill = null
                }
            });
            right.Add(new Block(msgInput.Text)
            {
                WordWarp = true,
                MaxWidth = "80%",
                Margin = new Thickness(0, 5, 30, 5),
                Padding = new Thickness(10),
                Background = new SudokuImageFill("res://CpfNativeAOT/Resources/aio_friend_bg_nor (81).png"),
            });
            chatContent.Document.Add(right);
        }
    }
}

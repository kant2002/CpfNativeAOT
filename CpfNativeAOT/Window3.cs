using CPF;
using CPF.Animation;
using CPF.Controls;
using CPF.Drawing;
using CPF.Shapes;
using CPF.Styling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPFApplication1
{
    public class Window3 : Window
    {
        protected override void InitializeComponent()
        {
            Title = "标题";
            Width = 900;
            Height = 600;
            Background = null;
            Children.Add(new WindowFrame(this, new Panel
            {
                Width = "100%",
                Height = "100%",
                Children = //内容元素放这里
                {
                    new ScrollViewer{VerticalOffset = 321.5f,
                        Height = 500,
                        VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                        Content = new StackPanel{TabIndex = 0,
                        Background = "#FAFAFA",
                        Orientation= Orientation.Vertical,
                        Children = {
                           new Label{
                               BorderType = BorderType.BorderStroke,
                               BorderStroke = new Stroke(1,DashStyles.Dot),
                               BorderFill = "#aaa",
                                Width=550.031,
                                Height=54,
                                Background="rgb(32, 77, 116)",
                                CornerRadius="6",
                                FontSize=18,
                                Foreground="rgb(255, 255, 255)",
                                Text="快速开始 (word文档和例子代码)，Dll免费，网盘提取码:hnvc",
                            },
                            new Label{
                                BorderType = BorderType.BorderStroke,
                                BorderStroke = new Stroke(1,DashStyles.Dot),
                                BorderFill = "#aaa",
                                Width=585.7f,
                                Height=52f,
                                Background="rgb(252, 248, 227)",
                                CornerRadius="4",
                                FontSize=14,
                                Foreground="rgb(138, 109, 59)",
                                Text="活动：上传一个CPF案例源码（不能过于简单的），可以免费获得CPF设计器授权!",
                            },
                            new ContentControl{
                                Content = "666",
                            },
                           new WrapPanel {
                                Width = "Auto", Height = "40", Background = "rgba(0, 0, 0, 0)", CornerRadius = "0", FontSize = 12f, Foreground = "rgb(51, 51, 51)", Children = {
                                    new Panel {
                                        BorderType = BorderType.BorderStroke,
                                       BorderStroke =                                BorderStroke = new Stroke(1,DashStyles.Dot),

                                       BorderFill = "#aaa",
                                        Children = {
                                            new Label {
                                                Width = "590", Height = "36", Background = "rgba(0, 0, 0, 0)", CornerRadius = "10,0,0,10", FontSize = 12f, Foreground = "rgb(51, 51, 51)", Text = ""
                                            }, new TextBox {
                                                Padding = "0,8,0,0",
                                                Width = "484", Height = "38", Background = "rgba(0, 0, 0, 0)", CornerRadius = "2", FontSize = 16f, Foreground = "rgb(0, 0, 0)", Text = "66666666666"
                                            }
                                        }
                                    }, new Panel {
                                        Children = {
                                            new Label {
                                                Width = "112", Height = "40", Background = "rgba(0, 0, 0, 0)", CornerRadius = "0", FontSize = 12f, Foreground = "rgb(51, 51, 51)", Text = ""
                                            }, new Button {
                                                Width = "112", Height = "40", Background = "rgb(78, 110, 242)", CornerRadius = "0,10,10,0", FontSize = 17f, Foreground = "rgb(255, 255, 255)", Content = "百度一下"
                                            }
                                        }
                                    }
                                },
                           },
                           new Panel{
                               BorderType = BorderType.BorderStroke,
                               BorderStroke =                                 BorderStroke = new Stroke(1,DashStyles.Dot),

                               BorderFill = "#aaa",
                               Width = 300,
                               Height = 192,
                               Children={
                                   new Label{
                                       MarginLeft = 0,
                                       MarginTop = 0,
                                       Width="300",Height="51",Background="rgb(255,255,255)",
                                       CornerRadius="2",FontSize=14f,
                                       Foreground="rgba(0, 0, 0, 0.85)",
                                       Text=@"更新提示",
                                   },new Panel{
                                       Width = "100%",
                                       Children={
                                           new Label{
                                               Width="300",Height="84",Background="rgb(57, 61, 73)"
                                               ,CornerRadius="0",FontSize=14f,Foreground="rgb(255, 255, 255)",
                                               Text=@"layui 已更新到：v2.6.4
请注意升级！"
                                           }}},new Panel{Height = 179.2f,
                                               Children={
                                                   new Label{MarginLeft = 13.8f,MarginTop = 133.8f,
                                                       Width=81f,Height=35f,Background="rgb(30, 159, 255)",
                                                       CornerRadius="2",
                                                       FontSize=14f,Foreground="rgb(255, 255, 255)",
                                                       Text="更新日志"
                                                   },new Label{MarginLeft = 115.6f,MarginTop = 133.8f,
                                                       Width=81f,Height=35f,
                                                       Background="rgb(255, 255, 255)",CornerRadius="2",
                                                       FontSize=14f,Foreground="rgb(51, 51, 51)",
                                                       Text="朕不想升"
                                                   }
                                               }
                                           }
                               }
                           },
                           new Label{
                           Text = "-----------------------------------------------------",
                           },
                           //-------
                           new WrapPanel {
                               BorderType = BorderType.BorderStroke,
                               BorderStroke = new Stroke(1,DashStyles.Dot),
                               BorderFill = "#aaa",
    Background = "rgb(255, 255, 255)", CornerRadius = "2", FontSize = 14f, Foreground = "rgba(0, 0, 0, 0.85)", Children = {
        new WrapPanel {
            Background = "rgba(0, 0, 0, 0)", CornerRadius = "2,2,0,0", FontSize = 14f, Foreground = "rgb(51, 51, 51)", Children = {
                new ContentControl {
                    Padding ="20,12,0,0",
                    Content = "更新提示"
                }
            }, Width = 300, Height = 51
        }, new WrapPanel {
            Background = "rgb(57, 61, 73)", CornerRadius = "0", FontSize = 14f, Foreground = "rgb(255, 255, 255)", Children = {
                new WrapPanel {
                    Margin = "20",
                    Orientation = Orientation.Vertical,
                    Background = "rgba(0, 0, 0, 0)", CornerRadius = "0", FontSize = 14f, Foreground = "rgb(248, 248, 248)",
                    Children = {
                        new Label {
                            Background = "rgba(0, 0, 0, 0)", CornerRadius = "0", FontSize = 14f, Foreground = "rgb(255, 255, 255)",  Width = 136.5f, Height = 27.8f,
                            Text = "layui 已更新到：v2.6.4"
                        },new Label {
                            Text = "请注意升级！"
                        }
                    }, Width = 260, Height = 44
                }
            }, Width = 300, Height = 84
        }, new Panel {
            Background = "rgba(0, 0, 0, 0)", CornerRadius = "0", FontSize = 14f, Foreground = "rgba(0, 0, 0, 0.85)", Children = {
                new Button {MarginLeft = 59f,
                    Background = "rgb(30, 159, 255)", CornerRadius = "2", FontSize = 14f, Foreground = "rgb(255, 255, 255)", Content = new ContentControl {
                        Content = "更新日志"
                    }, Width = 88, Height = 30
                }, new Button {MarginLeft = 166f,
                    Background = "rgb(255, 255, 255)", CornerRadius = "2", FontSize = 14f, Foreground = "rgb(51, 51, 51)", Content = new ContentControl {MarginLeft = 12f,MarginRight = 14f,
                        Content = "朕不想升"
                    }, Width = 88, Height = 30
                }
            }, Width = 300, Height = 57
        }
    }, Width = 300, Height = 192
},
                           //-------
                           new Button{
                               Background="rgba(0, 0, 0, 0)",CornerRadius="0",FontSize=24f,
                               Foreground="rgb(204, 204, 204)",Content=new ContentControl{Content="立即下载"},Width=258,Height=67},
                           //--------
                           new WrapPanel {
    Background = "rgba(0, 0, 0, 0)", CornerRadius = "0", FontSize = 0f, Foreground = "rgba(0, 0, 0, 0.85)", Children = {
        new Button {
            Background = "rgba(0, 0, 0, 0)", CornerRadius = "2", FontSize = 14f, Foreground = "rgb(102, 102, 102)", Content = "原始按钮", Width = 94, Height = 38
        }, new Button {
            Background = "rgb(0, 150, 136)", CornerRadius = "2", FontSize = 14f, Foreground = "rgb(255, 255, 255)", Content = "默认按钮", Width = 94, Height = 38
        }, new Button {
            Background = "rgb(30, 159, 255)", CornerRadius = "2", FontSize = 14f, Foreground = "rgb(255, 255, 255)", Content = "百搭按钮", Width = 94, Height = 38
        }, new Button {
            Background = "rgb(255, 184, 0)", CornerRadius = "2", FontSize = 14f, Foreground = "rgb(255, 255, 255)", Content = "暖色按钮", Width = 94, Height = 38
        }, new Button {
            Background = "rgb(255, 87, 34)", CornerRadius = "2", FontSize = 14f, Foreground = "rgb(255, 255, 255)", Content = "警告按钮", Width = 94, Height = 38
        }, new Button {
            Background = "rgb(251, 251, 251)", CornerRadius = "2", FontSize = 14f, Foreground = "rgb(210, 210, 210)", Content = "禁用按钮", Width = 94, Height = 38
        }
    }
},
                           //------
                           new Button{Background="rgb(0, 150, 136)",CornerRadius="2",FontSize=14f,Foreground="rgb(255, 255, 255)",Content=new WrapPanel{Children={new ContentControl{Content="查看消息"},new Label{Background="rgb(250, 250, 250)",CornerRadius="2",FontSize=12f,Foreground="rgb(102, 102, 102)",Text="1",Width=18.6875,Height=18}}},Width=117.6875,Height=38},
                           //-----------
                           new WrapPanel {
    Background = "rgba(0, 0, 0, 0)", CornerRadius = "0", Foreground = "rgba(0, 0, 0, 85)", Children = {
        new Button {
            Background = "rgb(255, 255, 255)", CornerRadius = "2,0,0,2", FontSize = 12, Foreground = "rgb(210, 210, 210)", Content = new WrapPanel {
                Children = {
                    new ContentControl {
                        Content = "上一页"
                    }
                }
            }, Width = 68, Height = 30
        }, new Button {
            Background = "#009688", CornerRadius = "0", FontSize = 12, Foreground = "rgb(255, 255, 255)", Content = "1", Width = 38.6875, Height = 30
        }, new Button {
            Background = "rgb(255, 255, 255)", CornerRadius = "0", FontSize = 12, Foreground = "rgb(51, 51, 51)", Content = new WrapPanel {
                Children = {
                    new ContentControl {
                        Content = "2"
                    }
                }
            }, Width = 38.6875, Height = 30
        }, new Button {
            Background = "rgb(255, 255, 255)", CornerRadius = "0", FontSize = 12, Foreground = "rgb(51, 51, 51)", Content = new WrapPanel {
                Children = {
                    new ContentControl {
                        Content = "3"
                    }
                }
            }, Width = 38.6875, Height = 30
        }, new Button {
            Background = "rgb(255, 255, 255)", CornerRadius = "0", FontSize = 12, Foreground = "rgb(51, 51, 51)", Content = new WrapPanel {
                Children = {
                    new ContentControl {
                        Content = "4"
                    }
                }
            }, Width = 38.6875, Height = 30
        }, new Button {
            Background = "rgb(255, 255, 255)", CornerRadius = "0", FontSize = 12, Foreground = "rgb(51, 51, 51)", Content = new WrapPanel {
                Children = {
                    new ContentControl {
                        Content = "5"
                    }
                }
            }, Width = 38.6875, Height = 30
        }, new Label {
            Background = "rgb(255, 255, 255)", CornerRadius = "0", FontSize = 12, Foreground = "rgb(153, 153, 153)", Text = "…", Width = 44, Height = 30
        }, new Button {
            Background = "rgb(255, 255, 255)", CornerRadius = "0", FontSize = 12, Foreground = "rgb(51, 51, 51)", Content = new WrapPanel {
                Children = {
                    new ContentControl {
                        Content = "10"
                    }
                }
            }, Width = 45.359375, Height = 30
        }, new Button {
            Background = "rgb(255, 255, 255)", CornerRadius = "0,2,2,0", FontSize = 12, Foreground = "rgb(51, 51, 51)", Content = new WrapPanel {
                Children = {
                    new ContentControl {
                        Content = "下一页"
                    }
                }
            }, Width = 68, Height = 30
        }
    }, Width = 423.2f, Height = 35f
},
                           //---------
                           new Panel{
                               Background="rgba(0, 0, 0, 0)",CornerRadius="0",
                               FontSize=16,Foreground="rgb(0, 0, 0)",
                               Children={
                                   new Label{
                                       Background="rgba(0, 0, 0, 0)",
                                       FontSize=35,Foreground="#66B3FF",
                                       Text="Airdrop",Width=127.671875,Height=46
                                   }
                               },Width=150,Height=46
                           },
                           new WrapPanel{
                               Background="rgba(0, 0, 0, 0)",CornerRadius="0",
                               //MarginTop = 10,
                               Children={
                                   new Label{
                                       MarginLeft = 46,
                                       MarginTop = 0,
                                       Background="rgba(0, 0, 0, 0)",
                                       FontSize=25,Foreground="rgb(130, 224, 170)",
                                       Text="布里卡隆",Width=100,Height=33
                                   },new Label{
                                       MarginLeft = 10,
                                       MarginTop = 0,
                                       Background="rgba(0, 0, 0, 0)",
                                       FontSize=25,Foreground="rgb(210, 180, 222)",
                                       Text="1234",Width=100,Height=33
                                   }
                               },Width=300,Height=33
                           }
                           //-------------
                        },
                    },
                    },
                }
            }));

            LoadStyleFile("res://CpfNativeAOT/Stylesheet1.css");//加载样式文件，文件需要设置为内嵌资源

            if (!DesignMode)//设计模式下不执行
            {

            }
        }
    }
}

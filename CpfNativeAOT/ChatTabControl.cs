using System;
using System.Collections.Generic;
using System.Text;
using CPF;
using CPF.Drawing;
using CPF.Controls;
using CPF.Shapes;
using CPF.Styling;
using CPF.Animation;

namespace CPFApplication1
{
    public class ChatTabControl : TabControl
    {
        protected override void InitializeComponent()
        {//模板定义
            Children.Add(new Grid
            {
                Width = "100%",
                Height = "100%",
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width="auto",MinWidth=60,MaxWidth=200 },new ColumnDefinition { }
                },
                Children =
                {
                    new Border
                    {
                        Attacheds=
                        {
                            { Grid.ColumnIndex, 0 },
                            { Grid.RowIndex,0 }
                        },
                        Name="headBorder",
                        Background="36,48,70",
                        BorderThickness=new Thickness(0),
                        BorderType= BorderType.BorderThickness,
                        Width="100%",
                        Height="100%",
                        MarginLeft=0,
                        Child= new ScrollViewer
                        {
                            Size=SizeField.Fill,
                            Content=new StackPanel
                            {
                                Orientation = Orientation.Vertical,
                                Name="headerPanel",
                                PresenterFor=this,
                                MarginLeft=0,
                                MarginTop=0,
                                Width="100%",
                            }
                        }
                    },
                    new GridSplitter
                    {
                        Height="100%",
                        MarginLeft=0,
                        Background=null,
                        Attacheds =
                        {
                            { Grid.ColumnIndex, 1},{Grid.RowIndex,0 }
                        }
                    },
                    new Panel
                    {
                        Name="contentPanel",
                        Attacheds={ { Grid.ColumnIndex, 1},{Grid.RowIndex,0 } },
                        MarginLeft=5,
                        MarginRight=0,
                        PresenterFor=this,
                        Height="100%",
                        BorderFill=null,
                        ClipToBounds=true,
                        //Background="#fff",
                    }

                }
            });
        }
    }
}

using CPF;
using CPF.Controls;
using CPF.Drawing;
using CPF.Shapes;
using CPF.Styling;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPFApplication1
{
    public class GroupItem : TreeViewItem
    {
        protected override void InitializeComponent()
        {
            if (!string.IsNullOrWhiteSpace(DisplayMemberPath))
            {
                this[nameof(Header)] = DisplayMemberPath;
            }
            if (!string.IsNullOrWhiteSpace(ItemsMemberPath))
            {
                this[nameof(Items)] = ItemsMemberPath;
            }

            Width = "100%";
            var panel = ItemsPanel.CreateElement();
            panel.Name = "itemsPanel";
            panel.PresenterFor = this;
            panel.MarginLeft = 0;
            panel.MinWidth = "100%";
            panel[nameof(Visibility)] = (this, nameof(IsExpanded), a => (bool)a ? Visibility.Visible : Visibility.Collapsed);
            Children.Add(new StackPanel
            {
                MarginLeft = 0,
                Orientation = Orientation.Vertical,
                Width = "100%",
                PresenterFor = this,
                Name = "itemsPanelHost",
                Children =
                {
                    new StackPanel
                    {
                        Name="treeViewItem",
                        PresenterFor=this,
                        MarginLeft=0,
                        Width = "100%",
                        Height="30",
                        Orientation= Orientation.Horizontal,
                        Children={
                            new Polygon{
                                IsAntiAlias=true,
                                MarginLeft=3,
                                //MarginTop=3,
                                Width=12,
                                RenderTransformOrigin=new PointField("30%","70%"),
                                Points={new Point(2,2),new Point(2,10),new Point(6,6), },
                                Bindings={
                                    { nameof(Polygon.RenderTransform),nameof(IsExpanded),3,BindingMode.OneWay,a=>(bool)a?new RotateTransform(45):Transform.Identity},
                                    { nameof(Visibility),nameof(HasItems),3,BindingMode.OneWay,a=>(bool)a?Visibility.Visible:Visibility.Collapsed }
                                },
                                Triggers={
                                    new Trigger{ Property=nameof(IsMouseOver), Setters = { {nameof(Shape.StrokeFill),"4,124,205" } } }

                                }
                            },
                            new ContentControl{MarginLeft=3 ,Bindings={ {nameof(ContentControl.Content),nameof(Header),3 }, {nameof(ContentControl.ContentTemplate),nameof(HeaderTemplate),3 } } }
                        },
                        Triggers={
                            new Trigger { Property = nameof(IsMouseOver), Setters = { { nameof(Background), "232,242,252" } } },
                        },
                        Commands=
                        {
                            {nameof(MouseDown),(s,e)=> { SingleSelect(); } },
                            {nameof(MouseDown),(s,e)=> { ((RoutedEventArgs)e).Handled = true; IsExpanded = !IsExpanded; } }
                        },
                    },
                    //panel,
                },
            });
            if (IsExpanded)
            {
                FindPresenterByName<Panel>("itemsPanelHost").Children.Add(panel);
            }
        }

        [PropertyChanged(nameof(IsExpanded))]
        void OnIsExpanded(object newValue, object oldValue, PropertyMetadataAttribute attribute)
        {
            if ((bool)newValue)
            {//为了提高性能，当第一次展开的时候才加载控件
                if (ItemsHost.Root == null)
                {
                    FindPresenterByName<Panel>("itemsPanelHost").Children.Add(ItemsHost);
                }
            }
        }
    }
}

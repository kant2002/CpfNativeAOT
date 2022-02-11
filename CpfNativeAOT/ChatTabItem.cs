using CPF;
using CPF.Controls;
using CPF.Shapes;
using CPF.Styling;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPFApplication1
{
    public class ChatTabItem : TabItem
    {
        protected override void InitializeComponent()
        {
            if (DesignMode)
            {
                Background = "#aaa";
            }
            Height = 60;
            BorderType = BorderType.BorderThickness;
            BorderThickness = new Thickness(2, 0, 0, 0);
            Width = "100%";
            //BorderFill = "230,230,230,50";
            Children.Add(new Panel
            {
                MarginLeft = 0,
                Children =
                {
                    new Ellipse
                    {
                        IsAntiAlias=true,
                        MarginLeft = 7.9f,
                        Height = 40,
                        Width = 40,
                        StrokeFill = null,
                        Fill = "url(res://CpfNativeAOT/Resources/headQQ.png) Clamp Fill",
                    },
                    new TextBlock
                    {
                        FontSize = 16,
                        MarginLeft = 60,
                        Text = "TextBlock1",
                        MarginRight = 40,
                        Foreground="#fff",
                        Bindings =
                        {
                            {nameof(TextBlock.Text),nameof(Header),this }
                        }
                    },
                    new Border
                    {
                        CornerRadius="8",
                        IsAntiAlias=true,
                        MarginTop = -5,
                        MarginLeft = 38,
                        BorderFill= "247,76,49",
                        Background= "247,76,49",
                        Child = new TextBlock
                        {
                            Foreground="#fff",
                            Text = "99+",
                            FontSize=10,
                        }
                    }
                }
            });

            this.Triggers.Add(new Trigger { Property = nameof(IsSelected), TargetRelation = Relation.Me, Setters = { { nameof(Border.BorderFill), "230,230,230" }, { nameof(Border.Background), "#ffffff44" } } });
            this.Triggers.Add(new Trigger { Property = nameof(IsMouseOver), TargetRelation = Relation.Me, Setters = { { nameof(Background), "#ffffff33" } } });
        }
    }
}

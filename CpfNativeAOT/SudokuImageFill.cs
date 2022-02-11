using CPF;
using CPF.Drawing;
using CPF.Styling;
using CPF.Threading;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPFApplication1
{
    /// <summary>
    /// 定义一个九宫格切图的视图填充
    /// </summary>
    public class SudokuImageFill : ViewFill
    {
        /// <summary>
        /// 九宫格四周切割厚度
        /// </summary>
        [PropertyMetadata(typeof(Thickness), "19")]
        public Thickness Thickness
        {
            get { return GetValue<Thickness>(); }
            set { SetValue(value); }
        }

        public Image Image
        {
            get { return GetValue<Image>(); }
            set { SetValue(value); }
        }

        public SudokuImageFill(string path)
        {
            ResourceManager.GetImage(path, a =>
            {
                if (a == null)
                {
                    Image = ResourceManager.ErrorImage;
                }
                else
                {
                    Image = a;
                }
            });
        }


        public override Brush CreateBrush(in Rect rect, in float renderScaling)
        {
            var img = Image;
            if (img == null || rect.Width < 1 || rect.Height < 1)
            {
                return new SolidColorBrush(Color.Transparent);
            }
            var padding = Thickness;
            var bitmap = new Bitmap((int)rect.Width, (int)rect.Height);
            {
                using (var g = DrawingContext.FromBitmap(bitmap))
                {
                    g.Clear(Color.Transparent);
                    //填充四个角
                    //左上角
                    {
                        g.DrawImage(img, new Rect(0, 0, padding.Left, padding.Top),
                         new Rect(0, 0, padding.Left, padding.Top));
                    }
                    //右上角
                    {
                        g.DrawImage(img, new Rect(rect.Width - padding.Right, 0, padding.Right, padding.Top),
                           new Rect(img.Width - padding.Right, 0, padding.Right, padding.Top));
                    }
                    //左下角
                    {
                        g.DrawImage(img, new Rect(0, rect.Height - padding.Bottom, padding.Left, padding.Bottom),
                            new Rect(0, img.Height - padding.Bottom, padding.Left, padding.Bottom));
                    }
                    //右下角
                    {
                        g.DrawImage(img, new Rect(rect.Width - padding.Right, rect.Height - padding.Bottom, padding.Right, padding.Bottom),
                            new Rect(img.Width - padding.Right, img.Height - padding.Bottom, padding.Right, padding.Bottom));
                    }

                    //四边
                    //左边
                    if (rect.Height - padding.Vertical > 0 && img.Height - padding.Vertical > 0)
                    {
                        g.DrawImage(img, new Rect(0, 0 + padding.Top, padding.Left, rect.Height - padding.Vertical),
                        new Rect(0, padding.Top, padding.Left, img.Height - padding.Vertical));
                    }

                    //上边
                    if (rect.Width - padding.Horizontal > 0 && img.Width - padding.Horizontal > 0)
                    {
                        g.DrawImage(img, new Rect(0 + padding.Left, 0, rect.Width - padding.Horizontal, padding.Top),
                            new Rect(padding.Left, 0, img.Width - padding.Horizontal, padding.Top));
                    }
                    //右边
                    if (rect.Height - padding.Vertical > 0 && img.Height - padding.Vertical > 0)
                    {
                        g.DrawImage(img, new Rect(rect.Width - padding.Right, padding.Top, padding.Right, rect.Height - padding.Vertical),
                         new Rect(img.Width - padding.Right, padding.Top, padding.Right, img.Height - padding.Vertical));
                    }
                    //下边
                    if (rect.Width - padding.Horizontal > 0 && img.Width - padding.Horizontal > 0)
                    {
                        g.DrawImage(img, new Rect(padding.Left, rect.Height - padding.Bottom, rect.Width - padding.Horizontal, padding.Bottom),
                         new Rect(padding.Left, img.Height - padding.Bottom, img.Width - padding.Horizontal, padding.Bottom));
                    }
                    //中间
                    if (rect.Width - padding.Horizontal > 0 && rect.Height - padding.Vertical > 0 && img.Width - padding.Horizontal > 0 && img.Height - padding.Vertical > 0)
                    {
                        g.DrawImage(img,
                            new Rect(padding.Left, padding.Top, rect.Width - padding.Horizontal, rect.Height - padding.Vertical),
                            new Rect(padding.Left, padding.Top, img.Width - padding.Horizontal, img.Height - padding.Vertical));
                    }
                }

                var m = Matrix.Identity;
                m.Translate(rect.X, rect.Y);
                return new TextureBrush(bitmap, WrapMode.Tile, m);
            }


        }
    }
}

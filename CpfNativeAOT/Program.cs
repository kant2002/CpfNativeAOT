#if !Net4
//using CPF.Mac;
using CPF.Skia;
using CPF.Linux;
#endif
using CPF.Platform;
using CPF.Windows;
using System;
using System.Threading;

namespace CPFApplication1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.Initialize(
#if Net4
               (OperatingSystemType.Windows, new WindowsPlatform(), new CPF.GDIPlus.GDIPlusDrawingFactory { ClearType = true })
#else
                //(OperatingSystemType.Windows, new WindowsPlatform(), new SkiaDrawingFactory { ClearType = true })
            //,(OperatingSystemType.OSX, new MacPlatform(), new SkiaDrawingFactory()),
            (OperatingSystemType.Linux, new LinuxPlatform(), new SkiaDrawingFactory())
#endif
            );
            var w = new Window2();
            w.DataContext = new Model();
            w.CommandContext = w.DataContext;
            Application.Run(w);
            //Application.Run(new QQLogin());
        }
    }

}

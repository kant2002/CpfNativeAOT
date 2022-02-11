#if !Net4
using CPF.Mac;
using CPF.Skia;
using CPF.Linux;
#endif
using CPF.Platform;
using CPF.Drawing;
using CPF.Windows;
using System;
using System.Threading;
using System.Runtime.InteropServices;

namespace CPFApplication1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
#if Net4
            DrawingFactory drawingFactory = new CPF.GDIPlus.GDIPlusDrawingFactory { ClearType = true });
#else
            SkiaDrawingFactory drawingFactory = new SkiaDrawingFactory();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                drawingFactory.ClearType = true;
            }
#endif
            OperatingSystemType os;
            RuntimePlatform platform;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                os = OperatingSystemType.Windows;
                platform = new WindowsPlatform();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                os = OperatingSystemType.Linux;
                platform = new LinuxPlatform();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                os = OperatingSystemType.OSX;
                platform = new MacPlatform();
            }
            else throw new NotSupportedException($"OS: {RuntimeInformation.OSDescription} not supported");
            Application.Initialize((os, platform, drawingFactory));
            var w = new Window2();
            w.DataContext = new Model();
            w.CommandContext = w.DataContext;
            Application.Run(w);
            //Application.Run(new QQLogin());
        }
    }

}

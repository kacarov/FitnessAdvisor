using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;

namespace App.GUI
{
    public class MainWindow
    {
        public static void Main(string[] args)
        {
            //Application.Init();

            Toplevel top = Application.Top;
            Window win = new Window(new Rect(0, 1, top.Frame.Width, top.Frame.Height - 1), "FitApp");
        }
    }
}

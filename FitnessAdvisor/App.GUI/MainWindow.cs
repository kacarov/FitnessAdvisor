using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;

namespace App.GUI
{
    public class MainWindow
    {
        //Application.Init();

        private readonly Toplevel top;
        private readonly Window window;

        public MainWindow()
        {
            this.top = Application.Top;
            this.window = new Window(new Rect(0, 1, Application.Top.Frame.Width, Application.Top.Frame.Height - 1), "FitApp");
        }

        public Toplevel Top => this.top;

        public Window Window => this.window;
    }
}

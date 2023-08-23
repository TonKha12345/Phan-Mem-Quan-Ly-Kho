using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PM_QLK.ViewModels
{
    public class ControlBarViewModel : BaseViewModel
    {
        public ICommand CloseWindowCommand { get; set; }
        public ICommand MaximizeWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        public ICommand MouseDownCommand { get; set; }

        public ControlBarViewModel()
        {
            CloseWindowCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) =>
            {
                Window window = (Window)this.GetWindowParent(p);
                if(window != null)
                {
                    window.Close();
                }
            });

            MaximizeWindowCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) =>
            {
                Window window = (Window)this.GetWindowParent(p);
                if(window != null)
                {
                    if(window.WindowState != WindowState.Maximized)
                    {
                        window.WindowState = WindowState.Maximized;
                    }
                    else
                    {
                        window.WindowState = WindowState.Normal;
                    }
                }
                
            });

            MinimizeWindowCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) =>
            {
                Window window = (Window)this.GetWindowParent(p);
                if(window != null)
                {
                    if(window.WindowState != WindowState.Minimized)
                    {
                        window.WindowState = WindowState.Minimized;
                    }
                    else
                    {
                        window.WindowState = WindowState.Normal;
                    }
                }
            });

            MouseDownCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) =>
            {
                Window window = (Window)this.GetWindowParent(p);
                if (window != null)
                {
                    window.DragMove();
                }
            });

        }

        /// <summary>
        /// Get parent of usercontrol 
        /// </summary>
        /// <param name="p"></param>
        /// <returns>window</returns>
        private FrameworkElement GetWindowParent(UserControl p)
        {
            FrameworkElement parent = p;
            while (parent.Parent != null)
            {
                parent = (FrameworkElement)parent.Parent;
            }
            return parent;
        }
    }
}

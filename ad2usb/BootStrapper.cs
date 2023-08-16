using Caliburn.Micro;
using sam2usb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace sam2usb
{
    internal class BootStrapper : BootstrapperBase
    {
        public BootStrapper()
        {
            this.Initialize();
            
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);
            DisplayRootViewForAsync<ShellViewModel>();
        }
    }
}

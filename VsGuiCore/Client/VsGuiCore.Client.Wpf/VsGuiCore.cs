using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using VsGuiCore.Client.Wpf.WorkSpaces;

namespace VsGuiCore.Client.Wpf
{
    public class VsGuiCore
    {
        public WindowsController WindowsController { get; }

        /// <summary>
        /// If default controllers are not enough you can use this for direct access to MainMenu.
        /// </summary>
        public Menu MainMenu { get; set; }

        /// <summary>
        /// If default controllers are not enough you can use this for direct access to StatusBar.
        /// </summary>
        public StatusBar StatusBar { get; set; }

        public VsGuiCore()
        {
            WindowsController = new WindowsController(this);
        }
    }
}

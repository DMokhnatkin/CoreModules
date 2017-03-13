using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Microsoft.Practices.Unity;
using ModularSystem.Common.Wpf.Context;
using ModularSystem.Common.Wpf.Controllers;
using VsGuiCore.Client.Wpf.WorkSpaces;

namespace VsGuiCore.Client.Wpf
{
    public class VsGuiCore
    {
        private Menu _mainMenu;

        public MenuController MainMenuItemController { get; private set; }
        public WindowsController WindowsController { get; }

        /// <summary>
        /// If default controllers are not enough you can use this for direct access to MainMenu.
        /// </summary>
        public Menu MainMenu
        {
            get
            {
                return _mainMenu;
            }
            set
            {
                _mainMenu = value;
                MainMenuItemController = new MenuController(_mainMenu);
            }
        }

        /// <summary>
        /// If default controllers are not enough you can use this for direct access to StatusBar.
        /// </summary>
        public StatusBar StatusBar { get; set; }

        public static VsGuiCore GetCurInstance()
        {
            return ClientAppContext.CurrentContext.Container.Resolve<VsGuiCore>();
        }

        public VsGuiCore()
        {
            WindowsController = new WindowsController(this);
        }
    }
}

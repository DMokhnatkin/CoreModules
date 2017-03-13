using ModularSystem.Common.Wpf.Controllers;
using ModularSystem.Common.Wpf.UI;

namespace VsGuiCore.Client.Wpf.WorkSpaces
{
    public class Window : IWorkSpace
    {
        /// <inheritdoc />
        public string Title { get; set; }

        public MenuItemDescription MenuItemDescription { get; }

        public Window(MenuItemDescription menuItemDescription)
        {
            MenuItemDescription = menuItemDescription;
        }
    }
}

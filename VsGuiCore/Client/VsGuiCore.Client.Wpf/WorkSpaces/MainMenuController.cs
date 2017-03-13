using System.Collections.Generic;
using System.Windows.Controls;
using System.Text;
using System;

namespace VsGuiCore.Client.Wpf.WorkSpaces
{
    public class MainMenuController
    {
        private readonly VsGuiCore _guiCore;
        private Dictionary<string, (MenuItemDescription description, WeakReference<MenuItem> menuItem)> _addedItems;

        public MainMenuController(VsGuiCore guiCore)
        {
            _guiCore = guiCore;
            _addedItems = new Dictionary<string, (MenuItemDescription description, WeakReference<MenuItem> menuItem)>();
        }

        /// <summary>
        /// Returns (description, menu item) for path. 
        /// If path was not found or menu item was removed, null will be returned.
        /// </summary>
        public (MenuItemDescription description, MenuItem menuItem)? GetMenuItem(string path)
        {
            if (!_addedItems.ContainsKey(path))
                return null;
            _addedItems[path].menuItem.TryGetTarget(out var menuItem);
            if (menuItem == null)
                return null;
            return (_addedItems[path].description, menuItem);
        }

        public void AddMenuItem(MenuItemDescription description)
        {
            var curPath = new StringBuilder();
            string prevPath = null;
            foreach(var itemName in description.Path)
            {
                prevPath = curPath.ToString();
                if (curPath.Length != 0)
                    curPath.Append("/");
                curPath.Append($"{itemName}");

                var curItem = GetMenuItem(curPath.ToString());
                // If menu item already exist, just skip
                if (curItem != null)
                    continue;

                var item = new MenuItem()
                {
                    Header = itemName
                };

                ItemsControl parentItem = GetMenuItem(prevPath)?.menuItem;
                if (parentItem == null)
                    parentItem = _guiCore.MainMenu;

                parentItem.Items.Add(item);
                _addedItems.Add(curPath.ToString(), (description, new WeakReference<MenuItem>(item)));
            }
        }

        public void RemoveMenuItem(string path)
        {
        }
    }
}

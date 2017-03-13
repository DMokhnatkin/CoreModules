using System.Collections.Generic;
using System.Windows.Controls;
using System.Text;
using System;
using System.Text.RegularExpressions;

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
            if (description.Path.Length == 0)
                throw new ArgumentException("Menu path cannot be empty string");

            var curPath = new StringBuilder();
            foreach(var itemName in description.Path)
            {
                var prevPath = curPath.ToString();
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

                ItemsControl parentItem = GetMenuItem(prevPath)?.menuItem ?? (ItemsControl) _guiCore.MainMenu;

                parentItem.Items.Add(item);
                _addedItems.Add(curPath.ToString(), (description, new WeakReference<MenuItem>(item)));
            }
        }

        private bool IsPathRoot(string path)
        {
            return !path.Contains("/");
        }

        private string GetParentPath(string path)
        {
            if (IsPathRoot(path))
                return null;
            Regex reg = new Regex(@"^(.+)/.+$");
            return reg.Match(path).Groups[1].Value;
        }

        public void RemoveMenuItem(string path)
        {
            if (path.Length == 0)
                throw new ArgumentException("Menu path cannot be empty string");
            var t = GetMenuItem(path);
            if (t != null)
            {
                _addedItems.Remove(path);
                var parentPath = GetParentPath(path);
                if (parentPath == null)
                {
                    var item = t.Value.menuItem;
                    _guiCore.MainMenu.Items.Remove(item);
                }
                else
                {
                    var z = GetMenuItem(parentPath);
                    if (z == null)
                        throw new ArgumentException($"Can't find parent item for {parentPath} menu item");
                    z.Value.menuItem.Items.Remove(t.Value.menuItem); 
                }
            }
        }
    }
}

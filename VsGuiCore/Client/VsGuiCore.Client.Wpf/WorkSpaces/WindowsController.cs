using System.Collections.Generic;

namespace VsGuiCore.Client.Wpf.WorkSpaces
{
    public class WindowsController
    {
        private readonly VsGuiCore _guiCore;
        readonly Dictionary<string, Window> _windows = new Dictionary<string, Window>();

        public WindowsController(VsGuiCore guiCore)
        {
            _guiCore = guiCore;
        }

        public void RegisterWindow(string id, Window window)
        {
            _windows.Add(id, window);
        }

        public void UnregisterWindow(string id)
        {
            _windows.Remove(id);
        }
    }
}

﻿using System;
using Microsoft.Practices.Unity;
using ModularSystem.Common.Wpf;
using ModularSystem.Common.Wpf.Context;
using ModularSystem.Common.Wpf.UI;
using TestGuiCore.Client.Wpf;
using VsGuiCore.Client.Wpf.WorkSpaces;

namespace VsGuiCore.Client.Wpf
{
    public class WpfClientEntry : IWpfClientEntry
    {
        /// <inheritdoc />
        public void OnInstalled()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void OnRemoved()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void OnStart()
        {
            MyMainUserControl t = new MyMainUserControl();
            var p = ClientAppContext.CurrentContext.Container.Resolve<VsGuiCore>();
            p.MainMenu = t.MainMenu;
            p.StatusBar = t.StatusBar;
            ClientAppContext.CurrentContext.Container.Resolve<MainUi>().MainContent = t;

            p.MainMenuItemController.AddMenuItem(new MenuItemDescription("test/test", 0));
            p.MainMenuItemController.AddMenuItem(new MenuItemDescription("test/test2", 0));

            p.MainMenuItemController.RemoveMenuItem("test/test");
        }

        /// <inheritdoc />
        public void OnExit()
        {
            throw new NotImplementedException();
        }
    }
}

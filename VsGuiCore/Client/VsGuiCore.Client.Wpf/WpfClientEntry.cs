using System;
using Microsoft.Practices.Unity;
using ModularSystem.Common.Wpf;
using ModularSystem.Common.Wpf.Context;
using ModularSystem.Common.Wpf.UI;
using TestGuiCore.Client.Wpf;

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
        }

        /// <inheritdoc />
        public void OnExit()
        {
            throw new NotImplementedException();
        }
    }
}

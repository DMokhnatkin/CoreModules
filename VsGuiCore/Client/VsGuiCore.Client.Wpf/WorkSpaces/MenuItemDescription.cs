namespace VsGuiCore.Client.Wpf.WorkSpaces
{
    // TODO: move to common.wpf
    public struct MenuItemDescription
    {
        public string[] Path { get; set; }
        public int Order { get; set; }

        public MenuItemDescription(string path, int order)
        {
            Path = path.Split('/');
            Order = order;
        }
    }
}

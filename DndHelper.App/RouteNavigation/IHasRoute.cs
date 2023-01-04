namespace DndHelper.App.RouteNavigation
{
    public interface IHasRoute
    {
        string Route { get; }
        Func<bool> CanGo { get; }

        bool TryGo();

        public event EventHandler TriedToGo;
    }
}

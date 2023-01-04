namespace DndHelper.App.RouteNavigation
{
    public interface IHasRouteCollection
    {
        public void AddRoute(IHasRoute route);
        public IHasRoute GetNextAvailableRoute(string currentRoute);
    }
}

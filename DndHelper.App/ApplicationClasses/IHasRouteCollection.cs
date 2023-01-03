namespace DndHelper.App.ApplicationClasses
{
    public interface IHasRouteCollection
    {
        public void AddRoute(IHasRoute route);
        public IHasRoute GetNextAvailableRoute(string currentRoute);
    }
}

namespace DndHelper.App.RouteNavigation
{
    public interface IModelNavigator
    {
        void AddModel<TModel>() where TModel : BindableObject;
        bool TryGoToNextRoute(string currentRoute);
    }
}


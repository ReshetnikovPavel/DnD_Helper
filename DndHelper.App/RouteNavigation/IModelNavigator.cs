namespace DndHelper.App.RouteNavigation
{
    public interface IModelNavigator
    {
        void AddModel<TModel>(Func<bool> goCondition) where TModel : BindableObject;
        bool TryGoToNextRoute(string currentRoute);
    }
}


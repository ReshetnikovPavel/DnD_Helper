namespace DndHelper.App.RouteNavigation
{
    public interface IModelNavigator
    {
        void AddModel<TModel>(string prefix, Func<bool> goCondition) where TModel : BindableObject;
        bool TryGoToNextRoute(string currentRoute);
    }
}


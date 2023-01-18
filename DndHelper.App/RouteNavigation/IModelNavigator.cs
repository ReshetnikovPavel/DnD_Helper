namespace DndHelper.App.RouteNavigation
{
    public interface IModelNavigator
    {
        void AddModel<TModel>() where TModel : BindableObject;
        void AddModel<TModel>(Func<bool> goCondition) where TModel : BindableObject;
        bool TryGoToNextRoute(string currentRoute);
    }
}


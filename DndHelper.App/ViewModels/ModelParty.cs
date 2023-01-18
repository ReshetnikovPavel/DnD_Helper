using System.Net;
using System.Windows.Input;
using DndHelper.App.Authentication;
using DndHelper.App.RouteNavigation;
using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using DndHelper.Infrastructure;

namespace DndHelper.App.ViewModels
{
    public class ModelParty : BindableObject
    {
        public ICommand OpenCharacter {get; }
        public int id => 123456;
        public string name => "XAXAAA";
        public string dm => "Gogulk";
        public string[] characters => new string[3]{"AA", "aaaa", "AAAAAAAAAA"};
    }
}
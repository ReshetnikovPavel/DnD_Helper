using DndHelper.Infrastructure;
using DndHelper.Domain.Campaign;
using DndHelper.Domain.Dnd;
using Firebase.Database;
using Newtonsoft.Json;

namespace DndHelper.Firebase.Campaign;

public class FirebaseDndCampaign : Entity<Guid>, ICampaign<Guid>
{
    internal FirebaseClient FirebaseClient { get; set; }
    
    public FirebaseDndCampaign(Guid id, string name, GameMaster gameMaster, IEnumerable<Character> characters) : base(id)
    {
        Name = name;
        GameMaster = gameMaster;
        Characters = characters;
    }

    public new Guid Id => base.Id;
    public IEnumerable<Character> Characters { get; set; }
    public GameMaster GameMaster { get; set; }
    public string Name { get; set; }

}
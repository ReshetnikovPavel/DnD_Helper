using DndHelper.Domain.Dnd;
using DndHelper.Infrastructure;

namespace DndHelper.Domain.Party;

public class Party : Entity<Guid>
{
    public IEnumerable<Character> Characters { get; set; }  
    public GameMaster GameMaster { get; set; }
    public string Name { get; set; }
    public Party(IEnumerable<Character> characters, GameMaster gameMaster, string name) : base(Guid.NewGuid())
    {
        Characters = characters;
        GameMaster = gameMaster;
        Name = name;
    }

    public static Party Create(string name, GameMaster gameMaster)
    {
        return new Party(new List<Character>(), gameMaster, name);
    }
}
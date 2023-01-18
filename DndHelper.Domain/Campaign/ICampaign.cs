using DndHelper.Domain.Dnd;

namespace DndHelper.Domain.Campaign;

public interface ICampaign<out TId>
{
    public TId Id { get; }
    public IEnumerable<Character> Characters { get; set; }
    public GameMaster GameMaster { get; set; }
    public string Name { get; set; }
}
using DndHelper.Domain.Dnd;


namespace DndHelper.Domain.Repositories;

public interface ICharacterRepository
{
    Task<Character> GetCharacter(Guid id);
    void PutCharacter(Character character);
    Task<IEnumerable<Character>> GetCharacters();
}
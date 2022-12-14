using DndHelper.Domain.Dnd;


namespace DndHelper.Domain.Repositories;

public interface ICharacterRepository
{
    Task<Character> GetCharacter<TId>(TId id);
    void PutCharacter(Character character);
}
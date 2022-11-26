namespace Domain.Repositories;

public interface ISpellRepository : IRepository
{
    IEnumerable<string> GetNamesForClass(string schoolName);
    Spell GetSpell(string name);
}
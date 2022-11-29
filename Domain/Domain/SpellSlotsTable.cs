namespace Domain;

public class SpellSlotsTable : IDndObject
{
    private readonly int[,] table = new int[10, 20];
    public int this[int spellLevel,int classLevel]
    {
        get => table[spellLevel, classLevel-1];
        set => table[spellLevel, classLevel-1] = value;
    }

    public IEnumerable<int> GetSpellSlots(int classLevel)
    {
        for (var i = 0; i < table.GetLength(10); i++)
            yield return this[i, classLevel];
    }

    public int MaxSpellLevel => table.GetLength(0);
    public int MaxCharacterLevel => table.GetLength(1);

    public void FillClassLevelRow(int classLevel, int[] values)
    {
        for (var spellLevel = 0; spellLevel < values.Length; spellLevel++)
        {
            this[spellLevel, classLevel] = values[spellLevel];
        }
    }
}
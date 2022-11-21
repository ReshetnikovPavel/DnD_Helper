namespace Domain.Repositories;

public class XmlLanguageRepository : XmlRepository, ILanguageRepository
{
    public XmlLanguageRepository() : base("Languages", "language")
    {

    }
}
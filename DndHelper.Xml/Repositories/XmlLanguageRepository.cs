using DndHelper.Domain.Repositories;

namespace DndHelper.Xml.Repositories;

public class XmlLanguageRepository : XmlRepository, ILanguageRepository
{
    public XmlLanguageRepository() : base("Languages", "language")
    {

    }
}
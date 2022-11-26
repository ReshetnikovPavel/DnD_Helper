namespace Domain.Repositories;

public class XmlClassRepository : XmlRepository, IClassRepository
{
    public XmlClassRepository() : base("Classes", "class")
    {
    }
}
using System.Xml.Linq;

namespace Infrastructure;

public static class XElementExtensions
{
    public static XElement GetElementWithName(this IEnumerable<XElement> xElements, string name)
    {
        return xElements.FirstOrDefault(x => GetName(x) == name);
    }

    public static string GetName(this XContainer xElement)
    {
        return xElement.Element("name")?.Value;
    }

    public static string GetElementContentWithName(this XElement xElement, string tagName)
    {
        return xElement.Element(tagName)?.Value;
    }

    public static string GetAttributeContentWithName(this XElement xElement, string tagName)
    {
        return xElement.Attribute(tagName)?.Value;
    }

    public static bool HasElement(this XElement xElement, string tagName)
    {
        return xElement.Element(tagName) != null;
    }
}
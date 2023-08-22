namespace BrightSky.Parsing.Xml;

public interface IEquatableEnumeration<TItem>: IEnumerable<TItem>, IEquatable<IEquatableEnumeration<TItem>>
{
}
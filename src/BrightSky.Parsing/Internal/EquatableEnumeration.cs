using System.Collections;
using BrightSky.Parsing.Xml;

namespace BrightSky.Parsing.Internal;

internal sealed class EquatableEnumeration<TItem>: IEquatableEnumeration<TItem>
{
    private IEnumerable<TItem> Values { get; }

    public EquatableEnumeration(IEnumerable<TItem> values)
    {
        Values = values;
    }

    public IEnumerator<TItem> GetEnumerator() => Values.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => Values.GetEnumerator();

    public bool Equals(IEquatableEnumeration<TItem>? other) 
        => other is not null && (other as EquatableEnumeration<TItem>)!.Values.SequenceEqual(Values);
}
using System.Text;
using Pidgin;

namespace BrightSky.Parsing.Internal;

internal class UntilLastOfAnyString: Parser<char, string>
{
    private readonly string _terminator;

    internal UntilLastOfAnyString(string terminator)
    {
        _terminator = terminator;
    }

    public override bool TryParse(ref ParseState<char> state, ref PooledList<Expected<char>> expecteds, out string result)
    {
        result = string.Empty;
        var sb = new StringBuilder();
        var bookmarks = new List<int>();
        var start = 0;
        if (state.HasCurrent) start = state.Location;
        
        while (state.HasCurrent)
        {
            var nextChars = state.LookAhead(_terminator.Length).ToString();
            if (nextChars == _terminator)bookmarks.Add(state.Bookmark());
            sb.Append(state.Current);
            state.Advance();
        }

        if (!bookmarks.Any()) return true;
        var last = bookmarks.Last();
        state.Rewind(last);
        result = last == start ? string.Empty : sb.ToString()[..(last-start)];

        return true;
    }
}
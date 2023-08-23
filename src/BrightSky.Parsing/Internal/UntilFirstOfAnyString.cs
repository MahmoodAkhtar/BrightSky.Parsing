using System.Text;
using Pidgin;

namespace BrightSky.Parsing.Internal;

internal class UntilFirstOfAnyString: Parser<char, string>
{
    private readonly string _terminator;

    internal UntilFirstOfAnyString(string terminator)
    {
        _terminator = terminator;
    }
    
    public override bool TryParse(ref ParseState<char> state, ref PooledList<Expected<char>> expecteds, out string result)
    {
        result = string.Empty;
        var sb = new StringBuilder();
        var bookmark = 0;
        var start = 0;
        if (state.HasCurrent) start = state.Location;
        
        while (state.HasCurrent)
        {
            var nextChars = state.LookAhead(_terminator.Length).ToString();
            if (nextChars != _terminator)
            {
                sb.Append(state.Current);
                state.Advance();
                continue;
            }
            bookmark = state.Bookmark();
            break;
        }

        if (bookmark is 0) return true;
        state.Rewind(bookmark+_terminator.Length);
        result = sb.ToString()[..(bookmark-start)];

        return true;
    }   
}
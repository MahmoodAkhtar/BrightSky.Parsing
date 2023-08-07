using System.Text;
using Pidgin;

namespace BrightSky.Parsing.Internal;

internal class AnyStringExcept : Parser<char, string>
{
    private readonly string[] terminators;

    public AnyStringExcept(params string[] terminators)
    {
        this.terminators = terminators;
    }

    public override bool TryParse(ref ParseState<char> state, ref PooledList<Expected<char>> expecteds, out string result)
    {
        var sb = new StringBuilder();

        var found = false;
        while (state.HasCurrent && !found)
        {
            // unfortunately this cannot be simplified as
            // found = terminators.Any(terminator => terminator == state.LookAhead(terminator.Length).ToString());
            // because the ref parameter state cannot be used in a lambda expression

            foreach (var terminator in terminators)
            {
                var nextChars = state.LookAhead(terminator.Length).ToString();
                if (nextChars != terminator)
                    continue;

                found = true;
                break;
            }

            if (found)
                break;

            sb.Append(state.Current);
            state.Advance();
        }

        result = sb.ToString();
        return result != "";
    }
}
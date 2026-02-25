namespace Supermarket.Test
{
    public static class CharAssistant
    {
        // CoPilot generated helper method to get all printable non-alphabetic characters
        public static IEnumerable<char> GetNonAlphaChars()
        {
            for (int i = 32; i < 127; i++) // printable ASCII
            {
                var c = (char)i;
                if (!char.IsLetter(c)) yield return c;
            }
        }
    }
}

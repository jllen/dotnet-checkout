namespace Supermarket
{
    public class UnitCode
    {
        public char Value { get; private set; }

        public UnitCode(char code)
        {
            if (!char.IsLetter(code))
            {
                throw new ArgumentException($"Unsupported unit code '{code}'");
            }

            Value = code;
        }
    }
}
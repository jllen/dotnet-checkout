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

        public override bool Equals(object? obj)
        {
            return obj is UnitCode code &&
                   Value == code.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}
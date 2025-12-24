using System;

namespace Exceptions
{
    public class StringLengthOutOfRangeException : Exception
    {
        public int ActualLength { get; }
        public int MinAllowed { get; }
        public int MaxAllowed { get; }

        public StringLengthOutOfRangeException(string message, int actualLength, int minAllowed, int maxAllowed)
            : base(message)
        {
            ActualLength = actualLength;
            MinAllowed = minAllowed;
            MaxAllowed = maxAllowed;
        }

        public StringLengthOutOfRangeException(string message, Exception inner)
            : base(message, inner) { }

        public override string ToString()
        {
            return $"{base.ToString()}\nActual Length: {ActualLength}, Expected: {MinAllowed}–{MaxAllowed}";
        }
    }
}

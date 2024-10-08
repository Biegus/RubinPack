using System;

namespace Rubin
{
    public enum Equaler
    {
        Equal,
        NoEqual,
        Greater,
        GreaterOrEqual,
        Lower,
        LowerOrEqual,
        Always
    }
    public static class EqualerHelper
    {
       

        public static bool CheckEquals(this Equaler e, object a,object b)
        {
            switch (e)
            {
                case Equaler.Always:
                    return true;
                case Equaler.Equal:
                    return a.Equals(b);
                case Equaler.NoEqual:
                    return !a.Equals(b);
                default:
                    if (a is IComparable ac)
                        if (b is IComparable bc)
                        {
                            switch (e)
                            {
                                case Equaler.Greater:
                                    return ac.CompareTo(bc) == 1;
                                case Equaler.Lower:
                                    return ac.CompareTo(bc) == -1;
                                case Equaler.GreaterOrEqual:
                                    return ac.CompareTo(bc) >= 0;
                                case Equaler.LowerOrEqual:
                                    return ac.CompareTo(bc) <= 0;

                            }
                        }
                    break;
            }
            throw new ArgumentException("Incomparable objects", nameof(e));
        }
    }
}
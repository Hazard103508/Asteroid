using System;

namespace UnityShared.Structs
{
    [Serializable]
    public class RangeNumber<T> where T: IComparable<T>
    {
        public T min;
        public T max;
    }
}
using System;

namespace UnityShared.Structs
{
    [Serializable]
    public class Bounds<T>
    {
        public T left;
        public T right;
        public T top;
        public T bottom;
    }
}
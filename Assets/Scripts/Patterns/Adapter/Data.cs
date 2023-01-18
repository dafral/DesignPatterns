using System;

namespace Patterns.Adapter
{
    [Serializable]
    public class Data
    {
        public string Element1;
        public int Element2;

        public Data(string element1, int element2)
        {
            Element1 = element1;
            Element2 = element2;
        }
    }
}

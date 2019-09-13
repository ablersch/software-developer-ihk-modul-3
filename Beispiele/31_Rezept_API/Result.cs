using System.Collections.Generic;

namespace Rezept_API
{
    public class Result
    {
        public string title { get; set; }
        public double version { get; set; }
        public string href { get; set; }
        public List<Rezept> results { get; set; }
    }
}

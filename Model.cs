using System.Collections.Generic;

namespace KursovayaPrintLn
{
    public class Model
    {
        public List<string> tittles;
        public List<int> results;
        public string name;
        public string time;

        public Model(List<string> tittles, List<int> results, string name, string time)
        {
            this.tittles = tittles;
            this.results = results;
            this.name = name;
            this.time = time;
        }
    }
}

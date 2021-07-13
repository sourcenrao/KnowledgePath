using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgePath
{
    public class Subject : JObject
    {
        public string category { get; set; }
        public int UID { get; set; }
        public List<int> parents { get; set; }
        public List<int> children { get; set; }
        public List<string> blurbs { get; set; }
    }
}

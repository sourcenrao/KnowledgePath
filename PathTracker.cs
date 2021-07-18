using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgePath
{
    class PathTracker
    {
        private List<string> path = new List<string>();

        public PathTracker(Tree tree, int UID)
        {
            string _path = tree.GetCategoryForSubject(UID);
            path = new List<string>() { _path };
        }

    }
}

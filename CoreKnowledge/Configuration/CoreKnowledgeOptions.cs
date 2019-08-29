using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreKnowledge.Configuration
{
    public class CoreKnowledgeOptions
    {
        public string Version { get; set; }

        public ExceptionOptions Exception { get; set; }

        public SearchOptions SearchEngine { get; set; }
    }

    public class ExceptionOptions
    {
        public string Provider { get; set; }
    }

    public class SearchOptions
    {
        public string Provider{ get; set; }
    }
}

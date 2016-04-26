using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangaReader.Interfaces.Entity;

namespace MangachanParser.Entity
{
    class Tag : ITag
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangaReader.Interfaces.Entity;

namespace MangaReader.Interfaces.Parsers
{
    public interface IInfoParser
    {
        Task<IMangaInfo> GetInfoAsync();
    }
}

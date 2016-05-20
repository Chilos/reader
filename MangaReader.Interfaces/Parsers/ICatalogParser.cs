using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangaReader.Interfaces.Entity;

namespace MangaReader.Interfaces.Parsers
{
    public interface ICatalogParser
    {
        void GetCatalogAsync(ObservableCollection<ICatalogTile> collection, int offSet = 0);
    }
}

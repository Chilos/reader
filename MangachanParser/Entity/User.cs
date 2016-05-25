using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace MangachanParser.Entity
{
    public class User
    {
        public string UserUrl { get; set; }
        public string Name { get; set; }
        public ImageSource Avatar { get; set; }
    }
}

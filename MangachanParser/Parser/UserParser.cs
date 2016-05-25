using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using MangachanParser.Entity;

namespace MangachanParser.Parser
{
    public class UserParser
    {
        private ParserHelper _parserManager;
        public UserParser()
        {
            _parserManager = new ParserHelper();
        }

        public async Task<User> GetUser(string login,string password)
        {
            var content = await _parserManager.GetHtmlPage("http://mangachan.ru/");
            if (_parserManager.IsLogout("http://mangachan.ru/"))
            {
                content = await _parserManager.Login(login, password);
                if (_parserManager.IsLogout(content))
                    return null;
            }
            var user = new User() {UserUrl = GetUserUrl(content) };
            content = await _parserManager.GetHtmlPage(user.UserUrl);
            content = GetProfileBox(content);
            user.Name = GetProfileName(content);
            user.Avatar =await GetImage(ParseImageUrl(content));
            return user;
        }

        private string GetUserUrl(string htmlTile)
        {
            var patrn = "<a class=\"bordr\" href=\"http://mangachan.ru/user(?<sta>.*?)\">Профиль</a>";
            RegexOptions options = RegexOptions.Compiled | RegexOptions.Singleline;
            var r = new Regex(patrn, options);
            return "http://mangachan.ru/user" + r.Match(htmlTile).Groups["sta"].Value;
        }

        private string GetProfileBox(string htmlTile)
        {
            var patrn = "<div class=\"profile-box\" style=\"(.*?)\">(?<sta>.*?)<br style=\"(.*?)\">";
            RegexOptions options = RegexOptions.Compiled | RegexOptions.Singleline;
            var r = new Regex(patrn, options);
            return r.Match(htmlTile).Groups["sta"].Value;
        }

        private string GetProfileName(string htmlTile)
        {
            var patrn = "<h2>(?<sta>.*?)</h2>";
            RegexOptions options = RegexOptions.Compiled | RegexOptions.Singleline;
            var r = new Regex(patrn, options);
            return r.Match(htmlTile).Groups["sta"].Value;
        }
        private string ParseImageUrl(string htmlTile)
        {
            string patrn = "<img alt=(.*?)src=\"(.*?)\"";
            Regex r = new Regex(patrn, RegexOptions.Multiline);
            var url = r.Match(htmlTile).Groups[2].Value;
            return url.Contains("http") ? url : "http://mangachan.ru/" + r.Match(htmlTile).Groups[2].Value;
        }
        private async Task<BitmapImage> GetImage(string url)
        {
            var b = await GetImageByteAsync(url);
            var s = await ConvertTo(b);
            var ii = new BitmapImage();
            ii.SetSource(s);
            return ii;
        }

        private async Task<InMemoryRandomAccessStream> ConvertTo(byte[] arr)
        {
            InMemoryRandomAccessStream randomAccessStream = new InMemoryRandomAccessStream();
            await randomAccessStream.WriteAsync(arr.AsBuffer());
            randomAccessStream.Seek(0);
            return randomAccessStream;
        }

        private static async Task<byte[]> GetImageByteAsync(string url)
        {
            return await new HttpClient().GetByteArrayAsync(url);
        }
    }
}

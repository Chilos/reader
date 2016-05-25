using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;
using Windows.Web.Http.Headers;
using HttpClient = System.Net.Http.HttpClient;
using HttpMethod = Windows.Web.Http.HttpMethod;
using HttpRequestMessage = Windows.Web.Http.HttpRequestMessage;

namespace MangachanParser.Parser
{
    public class ParserHelper
    {
        private readonly WebView _wv;
        
        public ParserHelper()
        {
            _wv = new WebView();
        }

        public async Task<string> GetHtmlPage(string mangaImageUrl)
        {
            _wv.Navigate(new Uri(mangaImageUrl));
            var ss = await WaitForMessageSent();
            if (ss.IsSuccess)
            {
                _content = await _wv.InvokeScriptAsync("eval",
                    new[] { "document.documentElement.outerHTML;" });
            }
            return _content;
        }


        public async Task<string> Login(string login, string password)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post,
                new Uri("http://mangachan.ru/"))
            {
                Content = new HttpStringContent($"login=submit&login_name={login}&login_password={password}")
            };
            httpRequestMessage.Content.Headers.ContentType = new HttpMediaTypeHeaderValue("application/x-www-form-urlencoded");
            _wv.NavigateWithHttpRequestMessage(httpRequestMessage);
            var ss = await WaitForMessageSent();
            if (ss.IsSuccess)
            {
                _content = await _wv.InvokeScriptAsync("eval",
                    new[] { "document.documentElement.outerHTML;" });
            }
            if (IsLogout(_content))
                return null;
            return _content;
        }

        public bool IsLogout(string htmlStatus)
        {
            string patrn = @"<form action="""" method=""post"">";
            RegexOptions options = RegexOptions.Compiled | RegexOptions.Singleline;
            Regex r = new Regex(patrn, options);
            return r.IsMatch(htmlStatus);
        }
        //<form method="post" action="">
        public async Task<bool> Logout()
        {
            _wv.Navigate(new Uri("http://mangachan.ru/"));
            var ss = await WaitForMessageSent();
            if (ss.IsSuccess)
            {
                _content = await _wv.InvokeScriptAsync("eval",
                    new[] { "document.documentElement.outerHTML;" });
            }
            if (!IsLogout(_content))
            {
                _wv.Navigate(new Uri("http://mangachan.ru/index.php?action=logout"));
                var sss = await WaitForMessageSent();
                if (ss.IsSuccess)
                {
                    _content = await _wv.InvokeScriptAsync("eval",
                        new[] { "document.documentElement.outerHTML;" });
                }
            }
            return IsLogout(_content);
        }

        string _content;
        async Task<WebViewNavigationCompletedEventArgs> WaitForMessageSent()
        {
            TypedEventHandler<WebView, WebViewNavigationCompletedEventArgs> h = null;
            try
            {
                var tcs = new TaskCompletionSource<WebViewNavigationCompletedEventArgs>();
                h = (o, args) => tcs.TrySetResult(args);
                _wv.NavigationCompleted += h;
                await Task.WhenAny(tcs.Task);
                return await tcs.Task;
            }
            finally
            {
                _wv.NavigationCompleted -= h;
            }
        }
    }
}

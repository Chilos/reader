using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

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

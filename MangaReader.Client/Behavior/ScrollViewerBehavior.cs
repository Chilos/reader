using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Appointments;
using Windows.Security.Cryptography.DataProtection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MangaReader.Client.Controls;
using Microsoft.Xaml.Interactivity;

namespace MangaReader.Client.Behavior
{
    class ScrollViewerBehavior : Behavior<ScrollViewer>
    {
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(ScrollViewerBehavior), new PropertyMetadata(null));

        private ScrollViewer _scrollViewer = null;
        protected override void OnAttached()
        {
            base.OnAttached();
            _scrollViewer = AssociatedObject;
            _scrollViewer.ViewChanged += _scrollViewer_ViewChanged;

        }

        private void _scrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            
            if(Math.Abs(_scrollViewer.ScrollableHeight - _scrollViewer.VerticalOffset) <= 0)
                Command.Execute(null);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            _scrollViewer.ViewChanged -= _scrollViewer_ViewChanged;
        }
    }
}

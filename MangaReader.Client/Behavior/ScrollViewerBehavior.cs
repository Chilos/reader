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


        public double VerticalOffset
        {
            get { return (double)GetValue(VerticalOffsetProperty); }
            set { SetValue(VerticalOffsetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VerticalOffsetProperty =
            DependencyProperty.Register("VerticalOffset", typeof(double), typeof(ScrollViewerBehavior), new PropertyMetadata(0.0, new PropertyChangedCallback(VerticalOffsetChanged)));

        private static void VerticalOffsetChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            var s = (ScrollViewerBehavior)depObj;
            s._scrollViewer.ScrollToVerticalOffset((double) args.NewValue);
        }

        //public double VerticalOffset
        //{
        //    get
        //    {
        //        if (_scrollViewer == null)
        //            return -1;
        //            return _scrollViewer.VerticalOffset;
        //    }
        //    set
        //    {
        //        if(_scrollViewer!=null)
        //        _scrollViewer.ScrollToVerticalOffset(value);
        //    }
        //}

        private ScrollViewer _scrollViewer = null;
        protected override void OnAttached()
        {
            base.OnAttached();
            _scrollViewer = AssociatedObject;
            _scrollViewer.ViewChanged += _scrollViewer_ViewChanged;

        }

        private void _scrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            VerticalOffset = _scrollViewer.VerticalOffset;
            if (Math.Abs(_scrollViewer.ScrollableHeight - _scrollViewer.VerticalOffset) <= 0)
                Command.Execute(null);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            _scrollViewer.ViewChanged -= _scrollViewer_ViewChanged;
        }
    }
}

﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Windows.Input;
using MangaReader.Interfaces.Entity;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace MangaReader.Client.Controls
{
    public sealed partial class CatalogTileControl : UserControl
    {
        public ICatalogTile Tile => DataContext as ICatalogTile; 

        public CatalogTileControl()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();
        }

        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(CatalogTileControl), new PropertyMetadata(0));
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }


        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(CatalogTileControl), new PropertyMetadata(null));
    }
}

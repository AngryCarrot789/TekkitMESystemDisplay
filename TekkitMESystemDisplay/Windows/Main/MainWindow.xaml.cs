using System;
using System.IO;
using System.Windows;
using TheRFramework.Utilities;

namespace TekkitMESystemDisplay.Windows.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, BaseView<MainViewModel>
    {
        public MainViewModel Model { get => DataContext as MainViewModel; set => DataContext = value; }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}

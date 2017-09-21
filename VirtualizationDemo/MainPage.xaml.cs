using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using VirtualizationDemo.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace VirtualizationDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<ModelItem> Items { get; set; } = new ObservableCollection<ModelItem>();

        public MainPage()
        {
            this.InitializeComponent();

            for (int i = 0; i < 100; i++)
            {
                Items.Add(new ModelItem { Name = "items" });
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            

            for (int i = 0; i < 100; i++)
            {
                Items.Add(new ModelItem { Name = "items" });
            }
        }
    }

    
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class MyPanelItems : UserControl, INotifyPropertyChanged
    {

        public ModelItem Item { set; get; }
        public MyPanelItems()
        {
            this.InitializeComponent();
        }

        public void MeasureWith(Size availableSize, object item)
        {
            SetDimensions((ModelItem)item, availableSize.Width);
            Measure(availableSize);
        }

        public void SetLayout(Size availableSize, object item)
        {
            Item = (ModelItem)item;
            SetDimensions((ModelItem)item, availableSize.Width);
        }

        private void SetDimensions(ModelItem item, double availableWidth)
        {
            var thumbnailWidth = WidthManager.GetItemWidth(availableWidth);
            Thumbnail.Width = thumbnailWidth;
            LayoutRoot.Width = thumbnailWidth;
            Thumbnail.Height = thumbnailWidth;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(storage, value))
            {
                storage = value;
                RaisePropertyChanged(propertyName);
            }
        }

        public void RaisePropertyChanged([CallerMemberName] string propertyName = null) =>
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion


        private static class WidthManager
        {
            private static Dictionary<double, double> cache;

            static WidthManager()
            {
                cache = new Dictionary<double, double>();
                cache[308] = 142;
                cache[329] = 152;
                cache[348] = 162;
                cache[468] = 144;
            }

            public static double GetItemWidth(double availableWidth)
            {
                if (!cache.ContainsKey(availableWidth))
                    cache[availableWidth] = CalculateWidth(availableWidth);
                return cache[availableWidth];
            }

            private static double CalculateWidth(double availableWidth)
            {
                const double maxWidth = 187;
                const int margin = 12;
                var effectiveItemWidth = maxWidth + margin;
                int possibleNoOfColumns = (int)Math.Floor(availableWidth / effectiveItemWidth);
                int requiredColumns = possibleNoOfColumns + 1;
                var itemWidth = (availableWidth / requiredColumns) - margin;
                itemWidth = Math.Floor(itemWidth);
                return itemWidth;
            }
        }
    }
}

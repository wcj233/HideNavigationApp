using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NavigationViewApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {

                foreach (NavigationViewItemBase item in NavigationViewControl.MenuItems)
                {
                    if ((string)item.Tag == contentFrame.CurrentSourcePageType.Name)
                    {
                        NavigationViewControl.SelectedItem = item;
                    }
                }
            }
         
            base.OnNavigatedTo(e);
        }

        private void NavigationViewControl_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var selectedItem = (NavigationViewItem)args.SelectedItem;
            if ((string)selectedItem.Tag == "SinglePage")
            {
                this.Frame.Navigate(typeof(SinglePage));
                /********Method 2*******/
                //contentFrame.Navigate(typeof(SinglePage));
                //NavigationViewControl.OpenPaneLength = 0;
                //NavigationViewControl.IsBackButtonVisible = NavigationViewBackButtonVisible.Collapsed;
                //NavigationViewControl.IsPaneToggleButtonVisible = false;
            }
            else
            {
                contentFrame.Navigate(typeof(NormalPage));
            }
        }

        
    }
}

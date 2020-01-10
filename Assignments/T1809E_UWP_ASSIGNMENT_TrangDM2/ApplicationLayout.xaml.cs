using Newtonsoft.Json.Linq;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Pages;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Services;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Services.Implements;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace T1809E_UWP_ASSIGNMENT_TrangDM2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ApplicationLayout : Page
    {
        private IFileIoService fileIoService = new FileIoService();
        private IMemberService memberService = new MemberService();

        public static String token;
        public ApplicationLayout()
        {
            this.InitializeComponent();
            ContentFrame.Navigate(typeof(LoginPage));
        }

        public async void ReadToken(object sender, RoutedEventArgs e)
        {
            ContentFrame.Visibility = Visibility.Collapsed;
            loading.Visibility = Visibility.Visible;
            loading.IsActive = true;
            var fi = await fileIoService.ReadFile("token.dat");
            token = await fileIoService.ReadFile("token.dat");
            if (token.Length!=0)
            {
                var info = await memberService.GetMemberInformation(token);
                var status = (string)JObject.Parse(info)["status"];
                if (status == "1") 
                {
                    ContentFrame.Navigate(typeof(UserInformationPage));
                } else
                {
                    ContentFrame.Navigate(typeof(LoginPage));
                }
            } else
            {
                ContentFrame.Navigate(typeof(LoginPage));
            }
            loading.Visibility = Visibility.Collapsed;
            loading.IsActive = false;
            ContentFrame.Visibility = Visibility.Visible;
        }

        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        // List of ValueTuple holding the Navigation Tag and the relative Navigation Page
        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
            ("home", typeof(Pages.Home)),
            ("music", typeof(Pages.SongListPage)),
            ("addMusic", typeof(Pages.AddSong)),
            ("information", typeof(Pages.UserInformationPage)),
        };

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (token.Length != 0)
            {
                if (args.IsSettingsInvoked == true)
                {
                    NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
                }
                else if (args.InvokedItemContainer != null)
                {
                    var navItemTag = args.InvokedItemContainer.Tag.ToString();
                    NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
                }
            } else
            {
                ContentFrame.Navigate(typeof(LoginPage));
            }
            
        }

        // NavView_SelectionChanged is not used in this example, but is shown for completeness.
        // You will typically handle either ItemInvoked or SelectionChanged to perform navigation,
        // but not both.
        private void NavView_SelectionChanged(NavigationView sender,
                                              NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected == true)
            {
                NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
            }
            else if (args.SelectedItemContainer != null)
            {
                var navItemTag = args.SelectedItemContainer.Tag.ToString();
                NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            }
        }

        private void NavView_Navigate(string navItemTag, NavigationTransitionInfo transitionInfo)
        {
            Type _page = null;
            if (navItemTag == "settings")
            {
                _page = typeof(Pages.LoginPage);
            }
            else
            {
                var item = _pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));
                _page = item.Page;
            }
            // Get the page type before navigation so you can prevent duplicate
            // entries in the backstack.
            var preNavPageType = ContentFrame.CurrentSourcePageType;

            // Only navigate if the selected page isn't currently loaded.
            if (!(_page is null) && !Type.Equals(preNavPageType, _page))
            {
                ContentFrame.Navigate(_page, null, transitionInfo);
            }
        }
    }
}

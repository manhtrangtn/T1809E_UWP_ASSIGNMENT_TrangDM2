using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Services;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Services.Implements;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace T1809E_UWP_ASSIGNMENT_TrangDM2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserInformationPage : Page
    {
        private IFileIoService fileIoService = new FileIoService();
        public UserInformationPage()
        {
            this.InitializeComponent();
        }

        private void LogoutHandle(object sender, RoutedEventArgs e)
        {
            ApplicationLayout.token = "";
            fileIoService.WriteToFile("token.dat", "");
            this.Frame.Navigate(typeof(LoginPage));
        }
    }
}

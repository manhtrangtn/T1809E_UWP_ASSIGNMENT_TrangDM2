﻿#pragma checksum "C:\Users\TrangDM2\Documents\Visual Studio Projects\T1809E_UWP_ASSIGNMENT_TrangDM2\Pages\AddSong.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9C95B940DD1835E55AE99F02B04F6CBC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace T1809E_UWP_ASSIGNMENT_TrangDM2.Pages
{
    partial class AddSong : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Pages\AddSong.xaml line 12
                {
                    this.loading = (global::Windows.UI.Xaml.Controls.ProgressRing)(target);
                }
                break;
            case 3: // Pages\AddSong.xaml line 13
                {
                    this.MainContent = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 4: // Pages\AddSong.xaml line 47
                {
                    this.SongName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // Pages\AddSong.xaml line 50
                {
                    this.AuthorName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // Pages\AddSong.xaml line 53
                {
                    this.Singer = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // Pages\AddSong.xaml line 56
                {
                    this.Thubnail = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // Pages\AddSong.xaml line 59
                {
                    this.Description = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9: // Pages\AddSong.xaml line 62
                {
                    this.Song = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Song).Click += this.SelectSong;
                }
                break;
            case 10: // Pages\AddSong.xaml line 63
                {
                    this.songNameVisis = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11: // Pages\AddSong.xaml line 65
                {
                    this.songAlert = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12: // Pages\AddSong.xaml line 66
                {
                    this.submit = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.submit).Click += this.UploadSong;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}


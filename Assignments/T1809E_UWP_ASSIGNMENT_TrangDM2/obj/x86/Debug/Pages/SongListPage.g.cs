﻿#pragma checksum "C:\Users\TrangDM2\Documents\Visual Studio Projects\Assignments\T1809E_UWP_ASSIGNMENT_TrangDM2\Pages\SongListPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F66981484F8FC0B31F4DA8EF39444F42"
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
    partial class SongListPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Automation_AutomationProperties_Name(global::Windows.UI.Xaml.DependencyObject obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                global::Windows.UI.Xaml.Automation.AutomationProperties.SetName(obj, value);
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Controls_PersonPicture_ProfilePicture(global::Windows.UI.Xaml.Controls.PersonPicture obj, global::Windows.UI.Xaml.Media.ImageSource value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), targetNullValue);
                }
                obj.ProfilePicture = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class SongListPage_obj8_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            ISongListPage_Bindings
        {
            private global::T1809E_UWP_ASSIGNMENT_TrangDM2.Models.Song dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj8;
            private global::Windows.UI.Xaml.Controls.PersonPicture obj9;
            private global::Windows.UI.Xaml.Controls.TextBlock obj10;
            private global::Windows.UI.Xaml.Controls.TextBlock obj11;
            private global::Windows.UI.Xaml.Controls.TextBlock obj12;
            private global::Windows.UI.Xaml.Controls.TextBlock obj13;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj8NameDisabled = false;
            private static bool isobj9ProfilePictureDisabled = false;
            private static bool isobj10TextDisabled = false;
            private static bool isobj11TextDisabled = false;
            private static bool isobj12TextDisabled = false;
            private static bool isobj13TextDisabled = false;

            public SongListPage_obj8_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 42 && columnNumber == 54)
                {
                    isobj8NameDisabled = true;
                }
                else if (lineNumber == 47 && columnNumber == 48)
                {
                    isobj9ProfilePictureDisabled = true;
                }
                else if (lineNumber == 49 && columnNumber == 48)
                {
                    isobj10TextDisabled = true;
                }
                else if (lineNumber == 51 && columnNumber == 52)
                {
                    isobj11TextDisabled = true;
                }
                else if (lineNumber == 52 && columnNumber == 52)
                {
                    isobj12TextDisabled = true;
                }
                else if (lineNumber == 53 && columnNumber == 52)
                {
                    isobj13TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 8: // Pages\SongListPage.xaml line 42
                        this.obj8 = new global::System.WeakReference((global::Windows.UI.Xaml.Controls.Grid)target);
                        break;
                    case 9: // Pages\SongListPage.xaml line 47
                        this.obj9 = (global::Windows.UI.Xaml.Controls.PersonPicture)target;
                        break;
                    case 10: // Pages\SongListPage.xaml line 49
                        this.obj10 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 11: // Pages\SongListPage.xaml line 51
                        this.obj11 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 12: // Pages\SongListPage.xaml line 52
                        this.obj12 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 13: // Pages\SongListPage.xaml line 53
                        this.obj13 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            (this.obj8.Target as global::Windows.UI.Xaml.Controls.Grid).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::T1809E_UWP_ASSIGNMENT_TrangDM2.Models.Song) item, 1 << phase);
            }

            public void Recycle()
            {
            }

            // ISongListPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::T1809E_UWP_ASSIGNMENT_TrangDM2.Models.Song)newDataRoot;
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::T1809E_UWP_ASSIGNMENT_TrangDM2.Models.Song obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_name(obj.name, phase);
                        this.Update_thumbnail(obj.thumbnail, phase);
                        this.Update_author(obj.author, phase);
                        this.Update_singer(obj.singer, phase);
                        this.Update_description(obj.description, phase);
                    }
                }
            }
            private void Update_name(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Pages\SongListPage.xaml line 42
                    if (!isobj8NameDisabled)
                    {
                        if ((this.obj8.Target as global::Windows.UI.Xaml.Controls.Grid) != null)
                        {
                            XamlBindingSetters.Set_Windows_UI_Xaml_Automation_AutomationProperties_Name((this.obj8.Target as global::Windows.UI.Xaml.Controls.Grid), obj, null);
                        }
                    }
                    // Pages\SongListPage.xaml line 49
                    if (!isobj10TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj10, obj, null);
                    }
                }
            }
            private void Update_thumbnail(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Pages\SongListPage.xaml line 47
                    if (!isobj9ProfilePictureDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_PersonPicture_ProfilePicture(this.obj9, (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), obj), null);
                    }
                }
            }
            private void Update_author(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Pages\SongListPage.xaml line 51
                    if (!isobj11TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj11, obj, null);
                    }
                }
            }
            private void Update_singer(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Pages\SongListPage.xaml line 52
                    if (!isobj12TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj12, obj, null);
                    }
                }
            }
            private void Update_description(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Pages\SongListPage.xaml line 53
                    if (!isobj13TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj13, obj, null);
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Pages\SongListPage.xaml line 12
                {
                    global::Windows.UI.Xaml.Controls.StackPanel element2 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element2).Loaded += this.LoadSongList;
                }
                break;
            case 3: // Pages\SongListPage.xaml line 13
                {
                    this.MyPlayer = (global::Windows.UI.Xaml.Controls.MediaPlayerElement)(target);
                }
                break;
            case 4: // Pages\SongListPage.xaml line 37
                {
                    this.loading = (global::Windows.UI.Xaml.Controls.ProgressRing)(target);
                }
                break;
            case 5: // Pages\SongListPage.xaml line 38
                {
                    this.ListSongs = (global::Windows.UI.Xaml.Controls.ScrollViewer)(target);
                }
                break;
            case 6: // Pages\SongListPage.xaml line 39
                {
                    this.Songs = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.Songs).ItemClick += this.SongSelectedHandle;
                }
                break;
            case 14: // Pages\SongListPage.xaml line 34
                {
                    global::Windows.UI.Xaml.Controls.Button element14 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element14).Click += this.MySongsHandle;
                }
                break;
            case 15: // Pages\SongListPage.xaml line 35
                {
                    global::Windows.UI.Xaml.Controls.Button element15 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element15).Click += this.NewSongsHandle;
                }
                break;
            case 16: // Pages\SongListPage.xaml line 15
                {
                    global::Windows.UI.Xaml.Controls.AppBarToggleButton element16 = (global::Windows.UI.Xaml.Controls.AppBarToggleButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarToggleButton)element16).Click += this.ShuffleHandle;
                }
                break;
            case 17: // Pages\SongListPage.xaml line 16
                {
                    global::Windows.UI.Xaml.Controls.AppBarToggleButton element17 = (global::Windows.UI.Xaml.Controls.AppBarToggleButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarToggleButton)element17).Click += this.RepeatHandle;
                }
                break;
            case 18: // Pages\SongListPage.xaml line 18
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element18 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element18).Click += this.PreviousHandle;
                }
                break;
            case 19: // Pages\SongListPage.xaml line 19
                {
                    this.PlayButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.PlayButton).Click += this.PlayPauseHandle;
                }
                break;
            case 20: // Pages\SongListPage.xaml line 20
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element20 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element20).Click += this.NextHandle;
                }
                break;
            case 21: // Pages\SongListPage.xaml line 23
                {
                    this.StatusText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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
            switch(connectionId)
            {
            case 8: // Pages\SongListPage.xaml line 42
                {                    
                    global::Windows.UI.Xaml.Controls.Grid element8 = (global::Windows.UI.Xaml.Controls.Grid)target;
                    SongListPage_obj8_Bindings bindings = new SongListPage_obj8_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element8.DataContext);
                    element8.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element8, bindings);
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element8, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}


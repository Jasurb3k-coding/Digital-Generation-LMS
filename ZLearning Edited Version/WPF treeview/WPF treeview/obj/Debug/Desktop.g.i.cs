#pragma checksum "..\..\Desktop.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E35ADCC57A6AF186EA05561387E92856F79EA294E42A6F957EFE26DB42A54091"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WPF_treeview;


namespace WPF_treeview {
    
    
    /// <summary>
    /// Desktop
    /// </summary>
    public partial class Desktop : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\Desktop.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTxtOffline;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Desktop.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listbox;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\Desktop.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel PacketInfoPanel;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\Desktop.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AuthorNameTxt;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\Desktop.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PacketNameTxt;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\Desktop.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteBtn;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\Desktop.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OpenVideoBtn;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\Desktop.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock VideosCountTxt;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\Desktop.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel VideoListPanel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPF treeview;component/desktop.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Desktop.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\Desktop.xaml"
            ((WPF_treeview.Desktop)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_LoadedAsync);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SearchTxtOffline = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.listbox = ((System.Windows.Controls.ListBox)(target));
            
            #line 43 "..\..\Desktop.xaml"
            this.listbox.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.listbox_MouseUpAsync);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PacketInfoPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.AuthorNameTxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.PacketNameTxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.DeleteBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.OpenVideoBtn = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\Desktop.xaml"
            this.OpenVideoBtn.Click += new System.Windows.RoutedEventHandler(this.OpenVideoBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.VideosCountTxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.VideoListPanel = ((System.Windows.Controls.WrapPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


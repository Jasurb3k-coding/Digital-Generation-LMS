#pragma checksum "..\..\MessageDownloadItem.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0D6263709E463BFC87C2069E8F890E9C6945904357B34CFD3CFC29D0959EEE7C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Raqamli_Avlod;
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


namespace Raqamli_Avlod {
    
    
    /// <summary>
    /// MessageDownloadItem
    /// </summary>
    public partial class MessageDownloadItem : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 47 "..\..\MessageDownloadItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MessageOrderTxt;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\MessageDownloadItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Messagetxt;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\MessageDownloadItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel CopyBtn;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\MessageDownloadItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolTip SharxToolTip;
        
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
            System.Uri resourceLocater = new System.Uri("/ZLearning Desktop;component/messagedownloaditem.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MessageDownloadItem.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            this.MessageOrderTxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.Messagetxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.CopyBtn = ((System.Windows.Controls.DockPanel)(target));
            
            #line 53 "..\..\MessageDownloadItem.xaml"
            this.CopyBtn.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.CopyBtn_MouseUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SharxToolTip = ((System.Windows.Controls.ToolTip)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\PacketDownloadItem.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "05B00B4AA8B04689DB734AC2A57686444ADEB9B94390B4143CD53418FE342F72"
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
    /// PacketDownloadItem
    /// </summary>
    public partial class PacketDownloadItem : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 85 "..\..\PacketDownloadItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ImageBrush PacketImg;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\PacketDownloadItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PacketName;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\PacketDownloadItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AuthorName;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\PacketDownloadItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DownloadDemoBtn;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\PacketDownloadItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DownloadBtn;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\PacketDownloadItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar progressBar;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\PacketDownloadItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LessonCountTxt;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\PacketDownloadItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DownloadTxt;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\PacketDownloadItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock InfoTxt;
        
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
            System.Uri resourceLocater = new System.Uri("/ZLearning Desktop;component/packetdownloaditem.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PacketDownloadItem.xaml"
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
            
            #line 10 "..\..\PacketDownloadItem.xaml"
            ((WPF_treeview.PacketDownloadItem)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.UserControl_MouseEnter);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PacketImg = ((System.Windows.Media.ImageBrush)(target));
            return;
            case 3:
            this.PacketName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.AuthorName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.DownloadDemoBtn = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\PacketDownloadItem.xaml"
            this.DownloadDemoBtn.Click += new System.Windows.RoutedEventHandler(this.DownloadDemoBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DownloadBtn = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\PacketDownloadItem.xaml"
            this.DownloadBtn.Click += new System.Windows.RoutedEventHandler(this.DownloadBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.progressBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 8:
            this.LessonCountTxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.DownloadTxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.InfoTxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


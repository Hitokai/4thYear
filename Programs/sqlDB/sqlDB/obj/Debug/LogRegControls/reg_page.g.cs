﻿#pragma checksum "..\..\..\LogRegControls\reg_page.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D4121911008A9940BC810523E7F0465FF000600B4AE6B1D2249A99B3E4A45CB5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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
using sqlDB;


namespace sqlDB {
    
    
    /// <summary>
    /// reg_page
    /// </summary>
    public partial class reg_page : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\LogRegControls\reg_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid pageContent;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\LogRegControls\reg_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\LogRegControls\reg_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox loginBlock;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\LogRegControls\reg_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordBlock;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\LogRegControls\reg_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox emailBlock;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\LogRegControls\reg_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox fnameBlock;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\LogRegControls\reg_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lnameBlock;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\LogRegControls\reg_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backToLogin;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\LogRegControls\reg_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button regBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/sqlDB;component/logregcontrols/reg_page.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\LogRegControls\reg_page.xaml"
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
            this.pageContent = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.textBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.loginBlock = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.passwordBlock = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 5:
            this.emailBlock = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.fnameBlock = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.lnameBlock = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.backToLogin = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\LogRegControls\reg_page.xaml"
            this.backToLogin.Click += new System.Windows.RoutedEventHandler(this.backToLogin_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.regBtn = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\LogRegControls\reg_page.xaml"
            this.regBtn.Click += new System.Windows.RoutedEventHandler(this.regBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\Pages\RegistrPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9F4D274F8A40F8C5307A0F3CB6D0849A94BF9AB2C366FD5909BB6A91264FC841"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using Variant1.Pages;


namespace Variant1.Pages {
    
    
    /// <summary>
    /// RegistrPage
    /// </summary>
    public partial class RegistrPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\Pages\RegistrPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBID;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Pages\RegistrPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBFIO;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Pages\RegistrPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TBGender;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Pages\RegistrPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBPhone;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Pages\RegistrPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBCountries;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\Pages\RegistrPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBEmail;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\Pages\RegistrPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBPassword;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\Pages\RegistrPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Photo;
        
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
            System.Uri resourceLocater = new System.Uri("/Variant1;component/pages/registrpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\RegistrPage.xaml"
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
            this.TBID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TBFIO = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TBGender = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            
            #line 60 "..\..\..\Pages\RegistrPage.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.SwitchGender);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TBPhone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.CBCountries = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.TBEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.TBPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.Photo = ((System.Windows.Controls.Image)(target));
            return;
            case 10:
            
            #line 113 "..\..\..\Pages\RegistrPage.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ChangePhoto);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 123 "..\..\..\Pages\RegistrPage.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Save);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


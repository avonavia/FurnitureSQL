﻿#pragma checksum "..\..\CharRedactAddWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D5AA06F91E1BD5425E4474AC820F259A444A0F9233D2E9B034D7BD5CDD894C2C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FurnitureSQL;
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


namespace FurnitureSQL {
    
    
    /// <summary>
    /// CharRedactAddWindow
    /// </summary>
    public partial class CharRedactAddWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\CharRedactAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name_box;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\CharRedactAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox value_box;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\CharRedactAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Enter_button;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\CharRedactAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back_button;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\CharRedactAddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Exit_button;
        
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
            System.Uri resourceLocater = new System.Uri("/FurnitureSQL;component/charredactaddwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CharRedactAddWindow.xaml"
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
            this.name_box = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.value_box = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Enter_button = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\CharRedactAddWindow.xaml"
            this.Enter_button.Click += new System.Windows.RoutedEventHandler(this.Enter_button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Back_button = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\CharRedactAddWindow.xaml"
            this.Back_button.Click += new System.Windows.RoutedEventHandler(this.Back_button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Exit_button = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\CharRedactAddWindow.xaml"
            this.Exit_button.Click += new System.Windows.RoutedEventHandler(this.Exit_button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


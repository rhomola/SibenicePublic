﻿#pragma checksum "..\..\..\VyberDat_Window.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2E42E13C54264CC6534FBC0D300C28CC1E5E85A0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Sibenice;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Sibenice {
    
    
    /// <summary>
    /// VyberDat_Window
    /// </summary>
    public partial class VyberDat_Window : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\VyberDat_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Sibenice.VyberDat_Window VyberDat_Window1;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\VyberDat_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton interni_RadioButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\VyberDat_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton databaze_RadioButton;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\VyberDat_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox connectionString_TextBox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\VyberDat_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label connectionString_label;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\VyberDat_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OK_Button;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\VyberDat_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label napoveda_label;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\VyberDat_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox typSlov_GroupBox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\VyberDat_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton ceske_radioButton;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\VyberDat_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton anglicke_radioButton;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\VyberDat_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton ceskoAnglicke_RadioButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Sibenice;component/vyberdat_window.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\VyberDat_Window.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.VyberDat_Window1 = ((Sibenice.VyberDat_Window)(target));
            return;
            case 2:
            this.interni_RadioButton = ((System.Windows.Controls.RadioButton)(target));
            
            #line 26 "..\..\..\VyberDat_Window.xaml"
            this.interni_RadioButton.Checked += new System.Windows.RoutedEventHandler(this.interni_RadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.databaze_RadioButton = ((System.Windows.Controls.RadioButton)(target));
            
            #line 27 "..\..\..\VyberDat_Window.xaml"
            this.databaze_RadioButton.Checked += new System.Windows.RoutedEventHandler(this.databaze_RadioButton_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.connectionString_TextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.connectionString_label = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.OK_Button = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\VyberDat_Window.xaml"
            this.OK_Button.Click += new System.Windows.RoutedEventHandler(this.OK_Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.napoveda_label = ((System.Windows.Controls.Label)(target));
            
            #line 33 "..\..\..\VyberDat_Window.xaml"
            this.napoveda_label.MouseEnter += new System.Windows.Input.MouseEventHandler(this.napoveda_label_MouseEnter);
            
            #line default
            #line hidden
            return;
            case 8:
            this.typSlov_GroupBox = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 9:
            this.ceske_radioButton = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 10:
            this.anglicke_radioButton = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 11:
            this.ceskoAnglicke_RadioButton = ((System.Windows.Controls.RadioButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

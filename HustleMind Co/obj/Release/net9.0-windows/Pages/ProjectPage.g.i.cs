﻿#pragma checksum "..\..\..\..\Pages\ProjectPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93EB4D97B206DCADA95E99BC0CFD3938EF6CD97F"
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


namespace HustleMind_Co_.Pages {
    
    
    /// <summary>
    /// ProjectPage
    /// </summary>
    public partial class ProjectPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 112 "..\..\..\..\Pages\ProjectPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCustomerId;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\..\Pages\ProjectPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTitle;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\..\Pages\ProjectPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescription;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\..\Pages\ProjectPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbStatus;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\..\Pages\ProjectPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ProjectDataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HustleMind Co.;component/pages/projectpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\ProjectPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 37 "..\..\..\..\Pages\ProjectPage.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.OnDashboardClick);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 44 "..\..\..\..\Pages\ProjectPage.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.OnCustomersClick);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 51 "..\..\..\..\Pages\ProjectPage.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.OnProjectsClick);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 58 "..\..\..\..\Pages\ProjectPage.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.OnPaymentsClick);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 65 "..\..\..\..\Pages\ProjectPage.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.OnReviewsClick);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 74 "..\..\..\..\Pages\ProjectPage.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.OnLogoutClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtCustomerId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txtTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.txtDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.cmbStatus = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            
            #line 134 "..\..\..\..\Pages\ProjectPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddProject_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 138 "..\..\..\..\Pages\ProjectPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveChanges_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.ProjectDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 14:
            
            #line 302 "..\..\..\..\Pages\ProjectPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditButton_Click);
            
            #line default
            #line hidden
            break;
            case 15:
            
            #line 307 "..\..\..\..\Pages\ProjectPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteButton_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}


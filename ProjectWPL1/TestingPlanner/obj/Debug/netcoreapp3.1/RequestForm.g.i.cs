﻿#pragma checksum "..\..\..\RequestForm.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "923EEA3473E5F60446C218A6E31F04F179E17F75"
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
using TestingPlanner;


namespace TestingPlanner {
    
    
    /// <summary>
    /// RequestForm
    /// </summary>
    public partial class RequestForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\RequestForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal TestingPlanner.RequestForm Request;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\RequestForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbDivision;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\RequestForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpEndDate;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\RequestForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLinkTestPlan;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\RequestForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbJobNature;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\RequestForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRequestDate;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\RequestForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtJrNr;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\RequestForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbInternal;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\RequestForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSpecialRemarks;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\RequestForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListEUT;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TestingPlanner;V1.0.0.0;component/requestform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\RequestForm.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Request = ((TestingPlanner.RequestForm)(target));
            
            #line 9 "..\..\..\RequestForm.xaml"
            this.Request.Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cmbDivision = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.dpEndDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.txtLinkTestPlan = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.cmbJobNature = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.txtRequestDate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtJrNr = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.cbInternal = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 9:
            this.txtSpecialRemarks = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.ListEUT = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


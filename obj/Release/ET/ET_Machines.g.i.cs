﻿#pragma checksum "..\..\..\ET\ET_Machines.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2A434E779F246B97AE33E5E61657F90C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.18408
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


namespace MachineDefiner.ET {
    
    
    /// <summary>
    /// ET_Machines
    /// </summary>
    public partial class ET_Machines : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\..\ET\ET_Machines.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainGrid;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\ET\ET_Machines.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid mainDG;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\ET\ET_Machines.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_characteristics;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\ET\ET_Machines.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_value;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\ET\ET_Machines.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ch_value;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\ET\ET_Machines.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_value;
        
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
            System.Uri resourceLocater = new System.Uri("/MachineDefiner;component/et/et_machines.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ET\ET_Machines.xaml"
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
            
            #line 4 "..\..\..\ET\ET_Machines.xaml"
            ((MachineDefiner.ET.ET_Machines)(target)).Loaded += new System.Windows.RoutedEventHandler(this.load);
            
            #line default
            #line hidden
            return;
            case 2:
            this.mainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.mainDG = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.cb_characteristics = ((System.Windows.Controls.ComboBox)(target));
            
            #line 34 "..\..\..\ET\ET_Machines.xaml"
            this.cb_characteristics.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cb_characteristics_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cb_value = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.ch_value = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.tb_value = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 44 "..\..\..\ET\ET_Machines.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddCharacteristic);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 47 "..\..\..\ET\ET_Machines.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteCurrentCharacteristic);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 50 "..\..\..\ET\ET_Machines.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveData);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 55 "..\..\..\ET\ET_Machines.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


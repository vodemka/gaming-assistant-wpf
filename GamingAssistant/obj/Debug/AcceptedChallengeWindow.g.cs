﻿#pragma checksum "..\..\AcceptedChallengeWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "69051C6F74014307BDCD438538E931984FFAF5EC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using GamingAssistant;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
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


namespace GamingAssistant {
    
    
    /// <summary>
    /// AcceptedChallengeWindow
    /// </summary>
    public partial class AcceptedChallengeWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\AcceptedChallengeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label activeChallengeTitle;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\AcceptedChallengeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image activeChallengeGameImage;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\AcceptedChallengeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock activeChallengeGame;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\AcceptedChallengeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock activeChallengeText;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\AcceptedChallengeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock activeChallengeDate;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\AcceptedChallengeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox proofLinkTextBox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\AcceptedChallengeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UserReadyButton;
        
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
            System.Uri resourceLocater = new System.Uri("/GamingAssistant;component/acceptedchallengewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AcceptedChallengeWindow.xaml"
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
            
            #line 14 "..\..\AcceptedChallengeWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.RangeDragWindow_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.activeChallengeTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.activeChallengeGameImage = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.activeChallengeGame = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.activeChallengeText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.activeChallengeDate = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.proofLinkTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 34 "..\..\AcceptedChallengeWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeclineChallenge);
            
            #line default
            #line hidden
            return;
            case 9:
            this.UserReadyButton = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\AcceptedChallengeWindow.xaml"
            this.UserReadyButton.Click += new System.Windows.RoutedEventHandler(this.UserReadyWithChallenge_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 40 "..\..\AcceptedChallengeWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExitButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


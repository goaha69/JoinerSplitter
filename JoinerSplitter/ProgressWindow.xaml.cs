﻿using System;
using System.Windows;

namespace JoinerSplitter
{
    /// <summary>
    /// Interaction logic for ProgressWindow.xaml
    /// </summary>
    partial class ProgressWindow : Window
    {
        private bool wasEnabled;

        private ProgressWindow()
        {
            InitializeComponent();
        }
        public static ProgressWindow Show(Window owner, double total = 100)
        {
            var dlg = new ProgressWindow();
            dlg.Owner = owner;
            if (owner != null)
            {
                dlg.wasEnabled = owner.IsEnabled;
            }
            dlg.progress.Maximum = total;
            dlg.Show();
            return dlg;
        }

        protected override void OnClosed(EventArgs e)
        {
            if (Owner != null)
            {
                Owner.IsEnabled = wasEnabled;
            }
            base.OnClosed(e);
        }
    }
}
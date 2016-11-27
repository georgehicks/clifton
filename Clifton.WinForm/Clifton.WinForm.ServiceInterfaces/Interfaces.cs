﻿using System;
using System.Windows.Forms;

using Clifton.Core.ServiceManagement;

namespace Clifton.WinForm.ServiceInterfaces
{
    public enum DockState
    {
        Unknown = 0,
        Float = 1,
        DockTopAutoHide = 2,
        DockLeftAutoHide = 3,
        DockBottomAutoHide = 4,
        DockRightAutoHide = 5,
        Document = 6,
        DockTop = 7,
        DockLeft = 8,
        DockBottom = 9,
        DockRight = 10,
        Hidden = 11
    }

    public enum DockAlignment
    {
        Left = 0,
        Right = 1,
        Top = 2,
        Bottom = 3
    }

    public class ProcessCmdKeyEventArgs : EventArgs
    {
        public Keys KeyData { get; set; }
        public bool Handled { get; set; }
    }

    public class ContentLoadedEventArgs : EventArgs
    {
        public Control DockContent { get; set; }
        public string Metadata { get; set; }
    }

    public interface IBaseForm
    {
        event EventHandler<ProcessCmdKeyEventArgs> ProcessCmdKeyEvent;
    }

    public interface IDockingFormService : IService
    {
        event EventHandler<ContentLoadedEventArgs> ContentLoaded;

        Form CreateMainForm();

        /// <summary>
        /// Create a document in the document area.
        /// </summary>
        Control CreateDocument(DockState dockState, string tabText, string metadata = "");

        /// <summary>
        /// Create a document adjacent to another document, in a separate pane.
        /// </summary>
        Control CreateDocument(Control pane, DockAlignment dockAlignment, string tabText, string metadata = "", double portion = 0.25);

        void LoadLayout(string filename);
        void SaveLayout(string filename);
    }
}

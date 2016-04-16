/************************************************************************************/
//
//      This file is part of Map2Civilization.
//      Map2Civilization is free software: you can redistribute it and/or modify
//      it under the terms of the GNU General Public License as published by
//      the Free Software Foundation, either version 3 of the License, or
//      (at your option) any later version.
//
//      Map2Civilization is distributed in the hope that it will be useful,
//      but WITHOUT ANY WARRANTY; without even the implied warranty of
//      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//      GNU General Public License for more details.
//
//      You should have received a copy of the GNU General Public License
//      along with Map2Civilization.  If not, see http://www.gnu.org/licenses/.
//
/************************************************************************************/


using Map2Civilization.Properties;
using Map2CivilizationCtrl;
using Map2CivilizationCtrl.Listener;
using System;
using System.Windows.Forms;

namespace Map2CivilizationView.UserControls
{
    /// <summary>
    /// Custom windows control based on the ToolStripSplitButton that presents to the
    /// user the current zoom value. It was declared as sealed in order to avoid any
    /// possible pitfalls as stated in warning CA2214
    /// (for more invomation, check https://msdn.microsoft.com/library/ms182331.aspx)
    /// </summary>
    public sealed class ZoomSplitButton : ToolStripSplitButton, IUiListenerZoom
    {
        private ToolStripComboBox _zoomCombo;
        private bool _parentAssigned = false;

        public ZoomSplitButton()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            _zoomCombo = new ToolStripComboBox();
            _zoomCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _zoomCombo.Name = "zoomCombo";
            _zoomCombo.Size = new System.Drawing.Size(100, 23);

            AutoSize = false;
            DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._zoomCombo});
            Enabled = false;
            Name = "zoomButton";
            Size = new System.Drawing.Size(140, 22);

            Text = string.Concat(Resources.Str_ZoomSplitButtonText, (int)(Math.Round(GridCoordinateHelperCtrl.GetZoomFactor())),
                Resources.Str_ZoomSplitButtonText_Percent);

            PopulateZoomCombo();
            RegisteredListenersCtrl.ZoomListeners.RegisterObserver(this);

            Paint += ZoomSplitButton_Paint;
        }

        /// <summary>
        /// Used to detect when the control is added in a toolstrip.
        /// When the event occurs, the control registers to the 'HandleDestroyed'
        /// event of the containing toolstrip, so that it deregisters
        /// itself from any IListener interaces that it has registered during
        /// it's lifetime
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomSplitButton_Paint(object sender, PaintEventArgs e)
        {
            if (Parent != null && !_parentAssigned)
            {
                Parent.HandleDestroyed += Parent_HandleDestroyed;
                _parentAssigned = true;
            }
        }

        private void Parent_HandleDestroyed(object sender, EventArgs e)
        {
            RegisteredListenersCtrl.ZoomListeners.DeregisterObserver(this);
        }

        private void PopulateZoomCombo()
        {
            foreach (float temp in GridCoordinateHelperCtrl.GetAvailableZoomFactors())
            {
                _zoomCombo.Items.Add(temp);
            }

            _zoomCombo.SelectedItem = 100f;

            _zoomCombo.SelectedIndexChanged += zoomCombo_SelectedIndexChanged;

            _zoomCombo.Text = string.Concat(Resources.Str_ZoomSplitButtonText,
                (int)(Math.Round(((float)_zoomCombo.SelectedItem))), Resources.Str_ZoomSplitButtonText_Percent);
        }

        private void zoomCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegisteredListenersCtrl.ZoomChangedUpdate(((float)_zoomCombo.SelectedItem));

            Text = string.Concat(Resources.Str_ZoomSplitButtonText,
                (int)(Math.Round((float)_zoomCombo.SelectedItem)), Resources.Str_ZoomSplitButtonText_Percent);
        }

        public void ZoomChanged(float value)
        {
            //Detach the listener so that we do not raise unecessary events caused by the change of the selected item..
            _zoomCombo.SelectedIndexChanged -= zoomCombo_SelectedIndexChanged;
            _zoomCombo.SelectedItem = value;
            //Reattach the listener..
            _zoomCombo.SelectedIndexChanged += zoomCombo_SelectedIndexChanged;

            Text = string.Concat(Resources.Str_ZoomSplitButtonText,
                (int)(Math.Round(value)), Resources.Str_ZoomSplitButtonText_Percent);
        }
    }
}
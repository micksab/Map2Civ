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
using Map2CivilizationView.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Map2CivilizationView
{
    public partial class KeyboardShortcutSelectorForm : Form
    {
        private Keys _key;
        private bool _requiresKeyModifier = false;

        public bool RequiresKeyModifier
        {
            set
            {
                _requiresKeyModifier = value;
            }
            get
            {
                return _requiresKeyModifier;
            }
        }

        public KeyboardShortcutSelectorForm()
        {
            InitializeComponent();
            PopulateKeysCombo();
        }

        public KeyboardShortcutSelectorForm(Keys key, bool requiresKeyModifier)
        {
            InitializeComponent();

            _requiresKeyModifier = requiresKeyModifier;
            _key = key;
            PopulateKeysCombo();
        }

        private void PopulateKeysCombo()
        {
            keysCombo.SelectedIndexChanged -= keysCombo_SelectedIndexChanged;
            controlBox.CheckedChanged -= controlBox_CheckedChanged;
            shiftBox.CheckedChanged -= controlBox_CheckedChanged;
            altBox.CheckedChanged -= controlBox_CheckedChanged;

            List<Keys> values = new List<Keys>();
            values.InsertRange(0, (Keys[])Enum.GetValues(typeof(System.Windows.Forms.Keys)));
            values.Remove(Keys.Control);
            values.Remove(Keys.Shift);
            values.Remove(Keys.ShiftKey);
            values.Remove(Keys.Alt);
            keysCombo.DataSource = values;
            keysCombo.DisplayMember = ToString();

            controlBox.Checked = _key.HasFlag(Keys.Control);
            shiftBox.Checked = _key.HasFlag(Keys.Shift);
            altBox.Checked = _key.HasFlag(Keys.Alt);

            keysCombo.SelectedItem = _key & Keys.KeyCode;

            keysCombo.SelectedIndexChanged += keysCombo_SelectedIndexChanged;
            controlBox.CheckedChanged += controlBox_CheckedChanged;
            shiftBox.CheckedChanged += controlBox_CheckedChanged;
            altBox.CheckedChanged += controlBox_CheckedChanged;
        }

        private void AssignNewKeyValue()
        {
            _key = (Keys)keysCombo.SelectedItem;

            if (controlBox.Checked)
            {
                _key = _key | Keys.Control;
            }

            if (shiftBox.Checked)
            {
                _key = _key | Keys.Shift;
            }

            if (altBox.Checked)
            {
                _key = _key | Keys.Alt;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void keysCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AssignNewKeyValue();
        }

        private void controlBox_CheckedChanged(object sender, EventArgs e)
        {
            AssignNewKeyValue();
        }

        public Keys SelectedValue
        {
            get
            {
                switch (DialogResult)
                {
                    case DialogResult.Cancel:
                        throw new InvalidOperationException("Attempt to retrieve value from form marked as cancelled");
                    default:
                        return _key;
                }
            }
        }

        private void controlBox_Validating(object sender, CancelEventArgs e)
        {
            if (_requiresKeyModifier && !controlBox.Checked && !altBox.Checked)
            {
                CultureAwareMessageBox.Show(Resources.Str_KeyboardShortcutSelectorForm_ModifierRequiredText,
                    Resources.Str_KeyboardShortcutSelectorForm_ModifierRequiredCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                e.Cancel = true;
            }
        }
    }
}
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
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Map2CivilizationView.UserControls
{
    public partial class KeyboardShortcutSettingSelector : UserControl, ISettingControl
    {
        private Keys _currentlySelectedShortcut;
        private List<Keys> _assignedKeysList = new List<Keys>();
        private bool _requiresKeyModifier = false;
        private string _propertyName = String.Empty;

        public event EventHandler<KeyboardShortcutSelectorValueChangedEventArgs> KeyboardShortcutSelectorValueChangedEventHandler;

        public KeyboardShortcutSettingSelector()
        {
            InitializeComponent();
        }

        public void AssignKeyShortcutProperty(string propertyName, bool requiresKeyModifier)
        {
            _propertyName = propertyName;
            _currentlySelectedShortcut = (Keys)Settings.Default[propertyName];
            ShowKeyTextRepresentation();

            _requiresKeyModifier = requiresKeyModifier;
        }

        private void ShowKeyTextRepresentation()
        {
            shortcutBox.Text = VariousUtilityMethods.FormatKeyStringRepresentation(_currentlySelectedShortcut);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public void SetAssignedKeysList(List<Keys> list)
        {
            _assignedKeysList.Clear();
            _assignedKeysList.AddRange(list);
        }

        public Keys CurrentlySelectedShortcut
        {
            get
            {
                return _currentlySelectedShortcut;
            }
        }

        private void newShortcutButton_Click(object sender, EventArgs e)
        {
            using (KeyboardShortcutSelectorForm selectorForm =
                new KeyboardShortcutSelectorForm(_currentlySelectedShortcut, _requiresKeyModifier))
            {
                DialogResult result = selectorForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Keys newValue = selectorForm.SelectedValue;
                    if (_assignedKeysList != null && _assignedKeysList.Contains(newValue)
                        && newValue != _currentlySelectedShortcut)
                    {
                        CultureAwareMessageBox.Show(Resources.Str_KeyboardShortcutSelector_MessageBoxAlreadyAssignedText,
                            Resources.Str_KeyboardShortcutSelector_MessageBoxAlreadyAssignedCaption,
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    _currentlySelectedShortcut = newValue;
                    ShowKeyTextRepresentation();

                    if (KeyboardShortcutSelectorValueChangedEventHandler != null)
                    {
                        KeyboardShortcutSelectorValueChangedEventArgs ke =
                            new KeyboardShortcutSelectorValueChangedEventArgs();
                        ke.Shortcut = _currentlySelectedShortcut;
                        KeyboardShortcutSelectorValueChangedEventHandler(this, ke);
                    }
                }
            }
        }

        public void SavePropertySetting()
        {
            Settings.Default[_propertyName] = _currentlySelectedShortcut;
        }
    }

    public class KeyboardShortcutSelectorValueChangedEventArgs : EventArgs
    {
        private Keys _shortcut = Keys.None;

        public Keys Shortcut
        {
            get
            {
                return _shortcut;
            }

            set
            {
                _shortcut = value;
            }
        }
    }
}
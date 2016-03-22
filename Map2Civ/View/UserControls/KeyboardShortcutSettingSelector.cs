using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Map2Civilization.Properties;
using Map2CivilizationCtrl;

namespace Map2CivilizationView.UserControls
{
    public partial class KeyboardShortcutSettingSelector : UserControl, ISettingControl
    {
        Keys _currentlySelectedShortcut;
        List<Keys> _assignedKeysList = new List<Keys>();
        bool _requiresKeyModifier = false;
        string _propertyName = String.Empty;

        

        public event EventHandler<KeyboardShortcutSelectorValueChangedEventArgs> KeyboardShortcutSelectorValueChangedEventHandler;
        

        public KeyboardShortcutSettingSelector()
        {
            InitializeComponent();
        }

        public void AssignKeyShortcutProperty(string propertyName, bool requiresKeyModifier )
        {
            _propertyName = propertyName;
            _currentlySelectedShortcut = (Keys)Settings.Default[propertyName];
            ShowKeyTextRepresentation();

            _requiresKeyModifier = requiresKeyModifier;
        }

         void ShowKeyTextRepresentation()
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

        void newShortcutButton_Click(object sender, EventArgs e)
        {
            using(KeyboardShortcutSelectorForm selectorForm = 
                new KeyboardShortcutSelectorForm(_currentlySelectedShortcut, _requiresKeyModifier))
            {
                DialogResult result = selectorForm.ShowDialog();

                if(result == DialogResult.OK)
                {
                    Keys newValue = selectorForm.SelectedValue;
                    if (_assignedKeysList!=null && _assignedKeysList.Contains(newValue)
                        && newValue!=_currentlySelectedShortcut)
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
       

         Keys _shortcut = Keys.None;

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

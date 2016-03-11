using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Map2Civilization.Properties;

namespace Map2CivilizationView.UserControls
{
    public partial class KeyboardShortcutSelector : UserControl
    {
        Keys _currentlySelectedShortcut;
        List<Keys> _assignedKeysList = new List<Keys>();
        bool _requiresKeyModifier = false;

       
        public event EventHandler<KeyboardShortcutSelectorValueChangedEventArgs> KeyboardShortcutSelectorValueChangedEventHandler;
        

        public KeyboardShortcutSelector()
        {
            InitializeComponent();
        }

        public KeyboardShortcutSelector(Keys currentlySelectedShortcut, bool requiresKeyModifier )
        {
            InitializeComponent();

            _currentlySelectedShortcut = currentlySelectedShortcut;

            ShowKeyTextRepresentation();

            _requiresKeyModifier = requiresKeyModifier;
        }

        private void ShowKeyTextRepresentation()
        {
            shortcutBox.Text = _currentlySelectedShortcut.ToString().Replace(',', '+');   
        }

        public Keys CurrentlySelectedShortcut
        {
            get
            {
                return _currentlySelectedShortcut;
            }

            set
            {
                _currentlySelectedShortcut = value;
                ShowKeyTextRepresentation();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public List<Keys> AssignedKeysList
        {
            get
            {
                return _assignedKeysList;
            }
        }

        public bool RequiresKeyModifier
        {
            get
            {
                return _requiresKeyModifier;
            }

            set
            {
                _requiresKeyModifier = value;
            }
        }

        private void newShortcutButton_Click(object sender, EventArgs e)
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

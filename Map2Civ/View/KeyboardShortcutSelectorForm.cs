using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Map2Civilization.Properties;
using Map2CivilizationView.UserControls;


namespace Map2CivilizationView
{
    public partial class KeyboardShortcutSelectorForm : Form
    {
        Keys _key;
        bool _requiresKeyModifier =false;

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


         void PopulateKeysCombo()
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


         void AssignNewKeyValue()
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

         void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

         void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

         void keysCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AssignNewKeyValue();
        }

         void controlBox_CheckedChanged(object sender, EventArgs e)
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

         void controlBox_Validating(object sender, CancelEventArgs e)
        {
            if(_requiresKeyModifier && !controlBox.Checked && !altBox.Checked)
            {
                CultureAwareMessageBox.Show(Resources.Str_KeyboardShortcutSelectorForm_ModifierRequiredText,
                    Resources.Str_KeyboardShortcutSelectorForm_ModifierRequiredCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                e.Cancel = true;
            }
        }
    }
}

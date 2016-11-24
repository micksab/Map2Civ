using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Map2CivilizationView.UserControls
{
    /// <summary>
    /// Based on code found at https://msdn.microsoft.com/en-us/library/9k5etstz.aspx
    /// </summary>
    class ToolStripCheckBox : ToolStripControlHost
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public ToolStripCheckBox() : base(new CheckBox()) { }

        public CheckBox CheckBoxControl
        {
            get
            {
                return Control as CheckBox;
            }
        }


        public bool Checked
        {
            get
            {
                return CheckBoxControl.Checked;
            }
            set
            {
                CheckBoxControl.Checked = value;
            }
        }


        override public string Text
        {
            get
            {
                return CheckBoxControl.Text;
            }
            set
            {
                CheckBoxControl.Text = value;
            }
        }

        
        


        // Subscribe and unsubscribe the control events you wish to expose.
        protected override void OnSubscribeControlEvents(Control c)
        {
            // Call the base so the base events are connected.
            base.OnSubscribeControlEvents(c);

            // Cast the control to a MonthCalendar control.
            CheckBox checkBoxControl = (CheckBox)c;

            // Add the event.
            checkBoxControl.CheckedChanged += OnCheckedChanged;
                
        }

        

        protected override void OnUnsubscribeControlEvents(Control c)
        {
            // Call the base method so the basic events are unsubscribed.
            base.OnUnsubscribeControlEvents(c);

            // Cast the control to a MonthCalendar control.
            CheckBox checkBoxControl = (CheckBox)c;

            // Add the event.
            checkBoxControl.CheckedChanged -= OnCheckedChanged;
        }


        public event EventHandler CheckChanged;

        private void OnCheckedChanged(object sender, EventArgs e)
        {
            CheckChanged?.Invoke(this, e);
        }


        

    }
}

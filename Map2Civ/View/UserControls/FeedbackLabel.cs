using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Map2CivilizationView.UserControls
{
    sealed class FeedbackToolstripLabel : ToolStripLabel
    {
        Queue<String> _messages = new Queue<String>();
        System.ComponentModel.BackgroundWorker _backWorker = new System.ComponentModel.BackgroundWorker();

        public FeedbackToolstripLabel()
        {

            Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            Size = new System.Drawing.Size(0, 32);
            Margin = new System.Windows.Forms.Padding(30, 0, 30, 0);
            Text = String.Empty;

            _backWorker.WorkerReportsProgress = true;
            _backWorker.DoWork += BackWorker_DoWork;
            _backWorker.ProgressChanged += BackWorker_ProgressChanged;
            _backWorker.RunWorkerCompleted += BackWorker_RunWorkerCompleted;
        }

       


        public void AddFeedbackMessage(String message)
        {
           
            _messages.Enqueue(message);
            Image = Map2Civilization.Properties.Resources.Info_Image;

            if (!_backWorker.IsBusy)
            {
                _backWorker.RunWorkerAsync(_messages);
            }
            
            
        }

        

        private void BackWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Queue<String> theMessages = (Queue<String>)e.Argument;

            while (theMessages.Count > 0)
            {
                String message = theMessages.Dequeue();
                int rgbElementValue = 0;
                int rgbElementStep = 10;
                Boolean isFirstIteration = true;

                while (rgbElementValue < 255)
                {
                    _backWorker.ReportProgress(rgbElementValue, (Object)message);

                    if (isFirstIteration)
                    {
                        System.Threading.Thread.Sleep(2000);
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(50);
                    }
                    
                    rgbElementValue = rgbElementValue + rgbElementStep;

                    isFirstIteration = false;

                }
            }
        }


        private void BackWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int rgbElement = e.ProgressPercentage;
            String message = (String)e.UserState;
            ForeColor = Color.FromArgb(rgbElement, rgbElement, rgbElement);
            Text = message;
        }


        private void BackWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Image = null;
            Text = String.Empty;
        }

    }
}

using System;
using System.Collections.Generic;


using System.Windows.Forms;
using Map2CivilizationView;
using System.Diagnostics;
using Map2Civilization.Properties;

namespace Map2Civilization
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
         {

            // Set the unhandled exception mode to force all Windows Forms errors to go through
            // our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Add the event handler for handling non-UI thread exceptions to the event. 
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            System.Threading.Thread.CurrentThread.CurrentCulture = Map2Civilization.Properties.Settings.Default.UICulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = Map2Civilization.Properties.Settings.Default.UICulture;


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

        }



        
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            using (ErrorForm toShow = new ErrorForm(true, Resources.Str_UnhandledError, ex))
            {
                toShow.ShowDialog();
            }
        }

    }
}

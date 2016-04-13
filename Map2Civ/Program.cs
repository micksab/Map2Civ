using Map2Civilization.Properties;
using Map2CivilizationView;
using System;
using System.Windows.Forms;

namespace Map2Civilization
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // Set the unhandled exception mode to force all Windows Forms errors to go through
            // our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Add the event handler for handling non-UI thread exceptions to the event.
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            System.Threading.Thread.CurrentThread.CurrentCulture = Settings.Default.UICulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = Settings.Default.UICulture;

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
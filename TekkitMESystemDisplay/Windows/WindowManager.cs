using System.Windows;
using TekkitMESystemDisplay.Windows.Logger;
using TekkitMESystemDisplay.Windows.Main;

namespace TekkitMESystemDisplay.Windows
{
    public static class WindowManager
    {
        public static App Application { get; private set; }
        public static string[] StartupArguments { get; private set; }

        public static MainWindow Main { get; private set; }
        public static LoggerWindow Logs { get; private set; }

        public static void Initialise(App app, string[] args)
        {
            Application = app;
            StartupArguments = args;
            // the config calls the Log method in ApplicationLogger, but the logger
            // hasn't been initialised yet.......... 

            Main = new MainWindow();
            Logs = new LoggerWindow()
            {
                Model = Main.Model.Logs
            };
            ApplicationLogger.LogInformation += Logs.Model.Log;

            // have to call after the main LoggerViewModel/LoggerWindow is initialised
            // because thats the only thing that hooks the events so far
            ApplicationLogger.Log("Application", "Starting application");
            ApplicationLogger.Log("Windows Events", "Setting up window closing event hooks...");

            Main.Closing += WindowClosing;

            ApplicationLogger.Log("Windows Events", "Success!");

            Application.MainWindow = Main;

            ApplicationLogger.Log("Application", "Successfully setup application");
        }

        private static void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

            if (sender is MainWindow mainWindow)
            {
                ShutdownApplication();
            }
            else
            {
                (sender as Window)?.Hide();
            }
        }

        private static void ShutdownWindows()
        {
            Main.Closing -= WindowClosing;
        }

        public static void ShutdownApplication()
        {
            ShutdownWindows();

            Application.Shutdown();
        }

        public static void ShowLogger()
        {
            Logs.Show();
        }

        public static void HideLogger()
        {
            Logs.Hide();
        }
    }
}

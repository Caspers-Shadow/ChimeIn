namespace MauiApp2
{
    public partial class App : Application
    {
        public App()
        {
            try
            {
                InitializeComponent();

                DatabaseHere.InitializeDatabaseAsync().Wait();

                MainPage = new NavigationPage(new LoginPage());
            }
            catch (Exception ex)
            {
                // Show exception message
                System.Diagnostics.Debug.WriteLine($"App initialization error: {ex.Message}");
                // Or display a message box if possible
                Application.Current?.MainPage?.DisplayAlert("Error", ex.Message, "OK");
                throw; // Rethrow so debugger still breaks
            }
        }

    }
}

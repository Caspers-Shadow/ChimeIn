namespace MauiApp2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Initialize the database here
            DatabaseHere.InitializeDatabaseAsync().Wait();

            MainPage = new NavigationPage(new LoginPage());
        }
    }
}

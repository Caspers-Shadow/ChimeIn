namespace MauiApp2;

public partial class MoodPage : ContentPage
{

	private User _user;
	public MoodPage(User user)
	{
		InitializeComponent();
		_user = user;
		welcomeLabel.Text = $"Welcome, {_user.Username} !";
    }

	private async void OnLogMoodClicked(object sender, EventArgs e)
	{
		// Clear the user session and navigate back to the login page
		await Navigation.PushAsync(new AddMoodPage(_user));
    }

	private async void OnViewHistoryClicked(object sender, EventArgs e)
	{
		// Clear the user session and navigate back to the login page
		await Navigation.PushAsync(new MoodHistoryPage(_user));
    }
}
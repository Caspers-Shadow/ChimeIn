using MauiApp2;

namespace MauiApp2;

public partial class AddMoodPage : ContentPage
{

	private User _user;
	public AddMoodPage(User user)
	{
		InitializeComponent();
		_user = user;
    }

	private async void OnSaveClicked(object sender, EventArgs e)
	{
		var mood = moodEntry.Text;
		var notes = notesEntry.Text;

        if (string.IsNullOrWhiteSpace(mood))
		{
			await DisplayAlert("Error", "Please enter a mood.", "OK");
			return;
		}

		var db = DatabaseHere.GetDatabase();
		var newMood = new Mood
		{
			UserID = _user.ID,
			MoodType = mood,
			Date = DateTime.Now,
			Notes = notes
		};

		await db.InsertAsync(newMood);
		await DisplayAlert("Success", "Mood logged successfully!", "OK");

		// Navigate back to the MoodPage
		await Navigation.PopAsync();
    }
}
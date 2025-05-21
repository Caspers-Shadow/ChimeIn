using MauiApp2;

namespace MauiApp2;

public partial class MoodHistoryPage : ContentPage
{

	private User _user;
    public MoodHistoryPage(User user)
	{
		InitializeComponent();
		_user = user;
		LoadMoods();
    }

	private async void LoadMoods()
	{
		var db = DatabaseHere.GetDatabase();
		var moods = await db.Table<Mood>().Where(m => m.UserID == _user.ID).OrderByDescending(m => m.Date).ToListAsync();

		if (moods.Count == 0)
		{
			moodListView.ItemsSource = null;
			await DisplayAlert("No Moods", "No mood history found.", "OK");
			return;
		}

		moodListView.ItemsSource = moods;
    }
}
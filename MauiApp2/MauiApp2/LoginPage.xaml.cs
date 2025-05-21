using MauiApp2;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MauiApp2;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private async void LoginClicked(object sender, EventArgs e)
	{
		string email = emailEntry.Text;
		string password = passwordEntry.Text;

		var db = DatabaseHere.GetDatabase();

		var users = await db.Table<User>().ToListAsync();
		var user = users.FirstOrDefault(u => u.Email == email);

		if (user != null && user.PasswordHash == HashPassword(password))
		{
			// Successful login
			await DisplayAlert("Success", "Welcome, {user.Username} !", "OK");
			// Navigate to the next page or perform any other action
			await Navigation.PushAsync(new MoodPage(user));
		}
		else
		{
			// Failed login
			errorLabel.Text = "Invalid email or password.";
			errorLabel.IsVisible = true;
        }
    }

	private async void RegisterClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new RegisterPage());
    }

	private string HashPassword(string password)
	{

        //Hashes Passwords to make them safe
        using var sha256 = SHA256.Create();
		var bytes = Encoding.UTF8.GetBytes(password);
		var hash = sha256.ComputeHash(bytes);
		return Convert.ToBase64String(hash);
    }
}
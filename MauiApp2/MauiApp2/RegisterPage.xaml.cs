using MauiApp2;
using System;
using System.Security.Cryptography;
using System.Text;

namespace MauiApp2;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

	private async void RegisterClicked(object sender, EventArgs e)
	{
		string username = usernameEntry.Text;
		string email = emailEntry.Text;
		string password = passwordEntry.Text;

        //Looks for any empty fields and returns an error if any are found
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
		{
			errorLabel.Text = "Please fill in all fields.";
			errorLabel.IsVisible = true;
            return;
		}

        //Gets the database and checks if the email already exists
        var db = DatabaseHere.GetDatabase();
		var userExists = await db.Table<User>().Where(u => u.Email == email).FirstOrDefaultAsync();

		if (userExists != null)
		{
            errorLabel.Text = "Email already registered";
            errorLabel.IsVisible = true;
            return;
		}

        // Makes a new user object and hashes the password
        var newUser = new User
		{
			Username = username,
			Email = email,
			PasswordHash = HashPassword(password)
		};
		await db.InsertAsync(newUser);
		await DisplayAlert("Success", "Registration successful!", "OK");

        // Navigate to the login page
        await Navigation.PopAsync();
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
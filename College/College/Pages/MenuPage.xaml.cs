namespace College.Pages;

public partial class MenuPage : ContentPage
{
	public MenuPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushModalAsync(new NewsPage());
    }

    private async void ProfileButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ProfilePage());
    }
}
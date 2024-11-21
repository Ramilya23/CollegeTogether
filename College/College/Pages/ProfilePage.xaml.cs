namespace College.Pages;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {

        if (e.NewTextValue == "") buttonAddTag.IsVisible = false;
        else buttonAddTag.IsVisible = true;
    }

    private void Entry_TextChanged_1(object sender, TextChangedEventArgs e)
    {
        int countSymbol = e.NewTextValue.Length;

        LimitTextLabel.Text = $"{countSymbol}/250";
    }
}
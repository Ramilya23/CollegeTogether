
using College.Pages;

namespace College;

public partial class AuthorizationPage : ContentPage
{
    public AuthorizationPage()
    {
        InitializeComponent();
    }
    public void ReceivingEntry(string Email, string Password, string NumberStud = "1")
    {
        EntryStudEmail.Text = Email;
        //   EntryStudNum.Text = NumberStud;
        EntryStudPass.Text = Password;
    }
    private async void GoRegBtn(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new RegistrationPage());
    }
    // ÕŒœ ¿ ¿”“≈Õ“»‘» ¿÷»»
    private async void Authentication(object sender, EventArgs e)
    {
        isValidation(EntryStudNum);
        isValidation(EntryStudEmail);
        isValidation(EntryStudPass);
        if (!Auth(EntryStudNum.Text, EntryStudEmail.Text, EntryStudPass.Text)) return;

        await Navigation.PushModalAsync(new NewsPage());
    }
    //¿”“≈Õ“»‘» ¿÷»ﬂ ◊≈–≈« ¡ƒ
    public bool isValidation(Entry entry)
    {
        if (!string.IsNullOrWhiteSpace(entry.Text)) return true;

        entry.Placeholder = "«‡ÔÓÎÌËÚÂ ÔÓÎÂ!";
        entry.PlaceholderColor = Colors.Red;
        return false;
    }
    public bool Auth(string AuthNumber, string AuthEmail, string AuthPassword)
    {
        bool isAuth = false;
        using (ApplicationContext db = new ApplicationContext())
        {
            var users = db.Users.ToList();
            foreach (User user in users)
            {
                if (user.Number == AuthNumber && user.Email == AuthEmail && user.Password == AuthPassword) isAuth = true;
            }
            return isAuth;
        }
    }

}
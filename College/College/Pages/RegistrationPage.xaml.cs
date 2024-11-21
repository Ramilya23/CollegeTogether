using Microsoft.Maui.Controls;

namespace College.Pages;

public partial class RegistrationPage : ContentPage
{
    public RegistrationPage()
    {
        InitializeComponent();
    }
    //������� �������� � ������ ����������� � �����
    private async void Register(object sender, EventArgs e)
    {

        isValidation(EntryName);
        isValidation(EntryEmail);
        isValidation(EntrySurname);
        isValidation(EntryPassword);

        Reg(EntrySurname.Text, EntryName.Text, EntryEmail.Text, EntryPassword.Text);
        // await Navigation.PushModalAsync(new CommentPage());
    }
      

    //������� � ��������������
    private async void GoAuthBtn(object sender, EventArgs e)
    {
        //    await Navigation.PushModalAsync(new menu());
    }

    //���������� ������ ������������
    public async void Reg(string EntryRegSurname, string EntryRegName, string EntryRegEmail, string EntryRegPassword)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            var user = new User { Surname = EntryRegSurname, Name = EntryRegName, Email = EntryRegEmail, Password = EntryRegPassword, Role = "����������" };
            db.Users.Add(user);
            await db.SaveChangesAsync();
            AuthorizationPage AP = new AuthorizationPage();
            
            await Navigation.PushModalAsync(AP);
            AP.ReceivingEntry(EntryRegEmail, EntryRegPassword);
        }

    }

    public bool isValidation(Entry entry)
    {
        if (!string.IsNullOrWhiteSpace(entry.Text)) return true;

        entry.Placeholder = "��������� ����!";
        entry.PlaceholderColor = Colors.Red;
        return false;
    }
}
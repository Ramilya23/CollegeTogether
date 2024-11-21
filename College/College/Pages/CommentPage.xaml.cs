namespace College.Pages;

public partial class CommentPage : ContentPage
{
    int commentCount = 0;
    public CommentPage()
	{
		InitializeComponent();
	}

    private void AddComment(object sender, EventArgs e)
    {
        if(!isValidation(InputComment)) return;

        commentCount++;
        //������ ���� ����������� � �� ���� �� ����� ��������
        var commentBlock = new StackLayout
        {
            Margin = new Thickness(10),
            BackgroundColor = Colors.AliceBlue,
            Padding = new Thickness(10),             //��������� ���������� ��������, ����� � ������ �����������
            Children = {
                 new Label {
                     Text = $"�����������", FontSize = 12,
                     TextColor = Colors.Gray },
                 new Label {
                     LineBreakMode=LineBreakMode.WordWrap, Text = $"{InputComment.Text}",
                     FontSize = 18 },
                 new Label()
                 {
                     Text =  DateTime.Now.ToString("HH:mm")
                 },
                 new Button {
                     Style =(Style)Resources["buttonAnswerStyle"], Text = "��������",
                     //���������� ������� �� ������ ��������
                     Command = new Command(() =>
                     { // ������ ��� ��������� ������ �� �����������
                         DisplayAlert("��������", $"����� �� ����������� {commentCount}", "OK"); })
                 }
        }
        };
        CommentsStack.Children.Add(commentBlock);
        InputComment.Text = string.Empty;

    }
    public bool isValidation(Entry entry)
    {
        if (!string.IsNullOrWhiteSpace(entry.Text)) return true;

        entry.Placeholder = "��������� ����!";
        entry.PlaceholderColor = Colors.Red;
        return false;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new NewsPage());
    }
}
using Microsoft.Maui.Controls.Shapes;

namespace College.Pages;

public partial class NewsPage : ContentPage
{
    List<string> Tags = new List<string> { "Программирование", "Искусство", "Спорт", "Животные", "Игры" };
    public NewsPage()
    {
        InitializeComponent();
        using (ApplicationContext db = new ApplicationContext())
        {
            var publications = db.Publications.ToList();
            foreach (Publication news in publications)
            {
                AddPost(news.Title, news.Description);
            }
          
        }
    
    }
    private async void ClickedCommentOpen(object sender, System.EventArgs e)
    {
        await Navigation.PushModalAsync(new CommentPage());
    }
    void AddPost(string Title, string Desctiprion)
    {
        Button commentButt = new Button()
        {
            Text = "Комментировать",
            CornerRadius = 0,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            MaximumHeightRequest = 700,
            BackgroundColor = Color.FromHex("#BFD1EB"),
        };
        commentButt.Clicked += ClickedCommentOpen;
        StackLayout commentStackLayout = new StackLayout()
         {

                        new Button()
                        {
                            CornerRadius=0,
                            BackgroundColor=Color.FromHex("#BFD1EB")
                        },
                        commentButt,
                        new Button()
                        {
                            CornerRadius=0,
                            BackgroundColor=Color.FromHex("#BFD1EB")
                        }


        };
        commentStackLayout.Orientation = StackOrientation.Horizontal;
   //     commentStackLayout.HorizontalOptions = LayoutOptions.FillAndExpand;

        StackLayout newPost = new StackLayout()
        {
         new Border()
        {

            Style = (Style)Resources["BorderNew"],
            Content =
            new StackLayout()
         {

                         new Label()
                         {
                          Text = Title
                         },
                         new Label()
                         {
                             Text= Desctiprion
                         },
                         new Image()
                         {
                         Style = (Style)Resources["ImageNews"]
                         }

        }
        },
         new Border()
         {
         Style = (Style)Resources["commentBorderNew"],
         Content=commentStackLayout


         }
        };


        ListPosts.Children.Add(newPost);
    }
    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        string text = e.NewTextValue?.ToLower();
        foreach (var tag in Tags)
        {
            if (tag.ToLower().Contains(text))
            {

            }
        }
    }
    private async void OnMenuButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new MenuPage());
    }

}
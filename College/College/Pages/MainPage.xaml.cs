namespace College
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            LoadData();
        }
        private async void LoadData()
        {
            progressBar.IsVisible = true;

            int second = 1 ;
            // Симуляция загрузки данных
            for (int i = 0; i <= 100; i++)
            {
                progressBar.Progress = i / 100.0;
                await Task.Delay(10*second); // Задержка для симуляции загрузки
            }

            progressBar.IsVisible = false;
            await Navigation.PushAsync(new AuthorizationPage());
        }
    }

}

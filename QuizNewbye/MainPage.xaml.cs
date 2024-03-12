using QuizNewbye.Paginas;

namespace QuizNewbye
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SecureStorage.Default.Remove("nome");
        }

        private async void BTNIniciar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Questao1());
        }
    }

}

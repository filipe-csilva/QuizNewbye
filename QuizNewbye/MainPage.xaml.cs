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

            SecureStorage.Default.RemoveAll();

            SecureStorage.Default.SetAsync("parcial","0");

            SecureStorage.Default.SetAsync("questoes", "0");
        }

        private async void BTNIniciar_Clicked(object sender, EventArgs e)
        {
            string pergunta = await DisplayPromptAsync("Pergunta", "Qual é o seu nome?", "Confirmar");

            await SecureStorage.Default.SetAsync("nome", pergunta);

            await Navigation.PushAsync(new Questao1());
        }
    }

}

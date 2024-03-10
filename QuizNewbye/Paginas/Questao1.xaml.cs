namespace QuizNewbye.Paginas;

public partial class Questao1 : ContentPage
{
    public Questao1()
    {
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        string? nome = await SecureStorage.Default.GetAsync("nome");

        LBLTeste.Text = nome;
    }
}
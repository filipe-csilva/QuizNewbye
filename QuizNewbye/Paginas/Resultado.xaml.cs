namespace QuizNewbye.Paginas;

public partial class Resultado : ContentPage
{
	public Resultado()
	{
		InitializeComponent();
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        string? nome = await SecureStorage.Default.GetAsync("nome");

        string? parcial = await SecureStorage.Default.GetAsync("parcial");

        string? questoes = await SecureStorage.Default.GetAsync("questoes");

        double final = double.Parse(parcial!) / int.Parse(questoes!) * 100;

        LBLSaudacao.Text = $"Olá, {nome}!";

        LBLResultado.Text = $"Você acertou {final}% das respostas";
    }
}
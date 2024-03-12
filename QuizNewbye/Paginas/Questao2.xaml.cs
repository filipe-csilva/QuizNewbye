namespace QuizNewbye.Paginas;

public partial class Questao2 : ContentPage
{
    bool marcou = false;
    bool acerto = false;

    public Questao2()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    private void Verificar(object sender, EventArgs e)
    {
        if (marcou)
        {
            marcou = false;
        }
        else
        {
            RadioButton? opcao = sender as RadioButton;
            
            string? valorOpcao = opcao?.Value.ToString();

            if (valorOpcao!.Contains("certo"))
            {
                acerto = true;
            }
            else
            {
                acerto = false;
            }

            marcou = true;
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string? questao = await SecureStorage.GetAsync("questoes");

        int quantidadeQuestao = int.Parse(questao!);

        quantidadeQuestao++;

        await SecureStorage.SetAsync("questoes", quantidadeQuestao.ToString());

        if (acerto)
        {
            await DisplayAlert("Resultado", "Você Acertou!\nForam adicionados 1 Pontos", "OK");

            string? valor = await SecureStorage.GetAsync("parcial");

            double parcial = double.Parse(valor!);

            parcial = parcial + 1;

            await SecureStorage.SetAsync("parcial", parcial.ToString());

            await Navigation.PushAsync(new Resultado());
        }
        else
        {
            await DisplayAlert("Resultado", "Que pena, Você Errou!", "OK");

            await Navigation.PushAsync(new Resultado());
        }
    }
}
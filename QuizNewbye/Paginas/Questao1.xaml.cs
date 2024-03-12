namespace QuizNewbye.Paginas;

public partial class Questao1 : ContentPage
{
    bool marcou = false;
    bool acerto = false;

    public Questao1()
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
        if (acerto)
        {
            await DisplayAlert("Resultado", "Voc� Acertou!\nForam adicionados 10 Pontos", "OK");

            string? valor = await SecureStorage.GetAsync("parcial");

            double parcial = double.Parse(valor!);

            parcial = parcial + 10;

            await SecureStorage.SetAsync("parcial", parcial.ToString());

            await Navigation.PushAsync(new Questao2());
        }
        else
        {
            await DisplayAlert("Resultado", "Que pena, Voc� Errou!", "OK");

            await Navigation.PushAsync(new Questao2());
        }
    }
}
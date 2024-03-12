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

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (acerto)
        {
            DisplayAlert("Resultado", "Você Acertou!", "OK");
        }
        else
        {
            DisplayAlert("Resultado", "Que pena, Você Errou!", "OK");
        }
    }
}
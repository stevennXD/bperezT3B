namespace bperezT2B.Views;

public partial class Calificaciones : ContentPage
{
    string currentUser = "";
	public Calificaciones()
	{
		InitializeComponent();
	}

    public Calificaciones(string User)
    {
        InitializeComponent();

        if (!string.IsNullOrEmpty(User))
        {
            currentUser = User;

            DisplayAlert("Calificaciones", "Bienvenido " + User, "Cerrar");
        }
    }

    private async void OnCalcularNotaFinalClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(notaSeguimiento1.Text) ||
            string.IsNullOrWhiteSpace(notaExamen1.Text) ||
            string.IsNullOrWhiteSpace(notaSeguimiento2.Text) ||
            string.IsNullOrWhiteSpace(notaExamen2.Text))
        {
            await DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
            return;
        }

        if (!double.TryParse(notaSeguimiento1.Text, out double seguimiento1) || seguimiento1 < 0 || seguimiento1 > 10 ||
            !double.TryParse(notaExamen1.Text, out double examen1) || examen1 < 0 || examen1 > 10 ||
            !double.TryParse(notaSeguimiento2.Text, out double seguimiento2) || seguimiento2 < 0 || seguimiento2 > 10 ||
            !double.TryParse(notaExamen2.Text, out double examen2) || examen2 < 0 || examen2 > 10)
        {
            await DisplayAlert("Error", "Por favor, ingrese valores numéricos válidos entre 0 y 10.", "OK");
            return;
        }

        double notaParcial1 = (seguimiento1 * 0.3) + (examen1 * 0.2);
        double notaParcial2 = (seguimiento2 * 0.3) + (examen2 * 0.2);
        double notaFinal = notaParcial1 + notaParcial2;

        string estado;
        if (notaFinal >= 7)
            estado = "Aprobado";
        else if (notaFinal >= 5 && notaFinal < 7)
            estado = "Complementario";
        else
            estado = "REPROBADO";

        await DisplayAlert("Resultado",
            $"Nombre: {estudiantePicker.SelectedItem}\n" +
            $"Fecha: {fechaPicker.Date.ToShortDateString()}\n" +
            $"Nota Parcial 1: {notaParcial1:F2}\n" +
            $"Nota Parcial 2: {notaParcial2:F2}\n" +
            $"Nota Final: {notaFinal:F2}\n" +
            $"Estado: {estado}",
            "OK");
    }
}
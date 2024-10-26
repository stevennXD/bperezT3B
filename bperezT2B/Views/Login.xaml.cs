namespace bperezT2B.Views;

public partial class Login : ContentPage
{
    string[] user = ["Carlos", "Ana", "Jose"];
    string[] pass = ["carlos123", "ana123", "jose123"];

    public Login()
	{
		InitializeComponent();
	}

    private void btnIniciar_Clicked(object sender, EventArgs e)
    {
        var userLogin = user.FirstOrDefault(x => x == txtUsuario.Text);

        if (userLogin != null)
        {
            var indexUser = Array.IndexOf(user, userLogin);

            if(indexUser != -1)
            {
                var passLogin = pass[indexUser];

                if (passLogin != null) {
                    if (passLogin == txtPassword.Text) {
                        Navigation.PushAsync(new Views.Calificaciones(userLogin));
                    }
                    else
                    {
                        DisplayAlert("Error", "Contraseña incorrecta", "Cerrar");
                    }

                }
                else
                {
                    DisplayAlert("Error", "Datos no encontrados", "Cerrar");

                }

            }
            else
            {
                DisplayAlert("Error", "Datos no encontrados", "Cerrar");
            }
        }
        else
        {
            DisplayAlert("Error", "Usuario no encontrado", "Cerrar");
        }

    }

}
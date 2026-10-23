using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace practicaGuiada
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSaludar_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) {

                MessageBox.Show("El nombre es obligatorio", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                
            } else {

                lblMensaje.Content = "Hola " + txtNombre.Text;
            }
           
        }

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblVistaNombre.Content = txtNombre.Text;
        }

        //metodo que recoge la opcion del combobox seleccionada y la muestra en el label
        private void cbPerfil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbPerfil.SelectedItem != null)
            {

                ComboBoxItem opcion =
                    (ComboBoxItem)cbPerfil.SelectedItem;

                lblPerfil.Content = "Perfil seleccionado: " + opcion.Content;
            }
            else {

                lblPerfil.Content = "Sin seleccionar";
            }
        }

        private void chkNotificaciones_Checked(object sender, RoutedEventArgs e)
        {
            lblAviso.Visibility = Visibility.Visible;
        }

        private void chkNotificaciones_Unchecked(object sender, RoutedEventArgs e)
        {
            lblAviso.Visibility = Visibility.Collapsed;
        }

        //mover la barra de progreso segun la poscion del slider
        private void slNivel_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            pbNivel.Value = e.NewValue;
            lblNivel.Content = "Nivel: " + e.NewValue;

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = "";
            txtEdad.Text = "";
            cbPerfil.SelectedIndex = -1; //poner el -1 para que no pille ninguno 
            chkNotificaciones.IsChecked = false;
            rbBasico.IsChecked = false;
            rbAvanzado.IsChecked = false;
            slNivel.Value = 0;
            lblMensaje.Content = "";
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            comprobarEdad();
            comprobarPerfil();
            comprobarModalidad();

        }

        private void comprobarModalidad()
        {
            if (rbBasico.IsChecked != true && rbAvanzado.IsChecked != true)
            {

                MessageBox.Show("Hay que seleccionar una modalidad");
            }
        }

        private void comprobarPerfil()
        {
            if (cbPerfil.SelectedItem == null)
            {

                MessageBox.Show("Selecciona una opcion");
            }
        }

        private void comprobarEdad()
        {
            if (!int.TryParse(txtEdad.Text, out int edad))
            {

                MessageBox.Show("Introduce una edad valida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
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

namespace ClasesyListview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Persona> listaPersonas =
            new List<Persona>();
        public MainWindow()
        {
            InitializeComponent();
            lvPersonas.ItemsSource = listaPersonas;//asociar la lista al listview
        }

        private void BtnSaludar_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "El nombre es obligatorio",
                    "Información",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                return;
            }

            lblMensaje.Content =
                "Hola " + txtNombre.Text;
        }

        private void TxtNombre_TextChanged(
            object sender,
            TextChangedEventArgs e)
        {
            lblVistaNombre.Content =
                txtNombre.Text;
        }

        private void CbPerfil_SelectionChanged(
            object sender,
            SelectionChangedEventArgs e)
        {
            if (cbPerfil.SelectedItem != null)
            {
                string perfil =
                    (cbPerfil.SelectedItem as ComboBoxItem)?
                    .Content?
                    .ToString() ?? "";

                lblPerfil.Content =
                    "Perfil seleccionado: " + perfil;
            }
            else
            {
                lblPerfil.Content =
                    "Sin seleccionar";
            }
        }

        private void chkNotificaciones_Checked(
            object sender,
            RoutedEventArgs e)
        {
            lblAviso.Visibility =
                Visibility.Visible;
        }

        private void chkNotificaciones_Unchecked(
            object sender,
            RoutedEventArgs e)
        {
            lblAviso.Visibility =
                Visibility.Collapsed;
        }

        private void SlNivel_ValueChanged(
            object sender,
            RoutedPropertyChangedEventArgs<double> e)
        {
            pbNivel.Value = e.NewValue;

            lblNivel.Content =
                "Nivel: " + (int)e.NewValue;
        }

        private void BtnGuardar_Click(
            object sender,
            RoutedEventArgs e)
        {
            // VALIDAR NOMBRE
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "El nombre es obligatorio");
                return;
            }

            // VALIDAR EDAD
            if (!int.TryParse(
                txtEdad.Text,
                out int edad))
            {
                MessageBox.Show(
                    "Introduce una edad válida",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                return;
            }

            // VALIDAR PERFIL
            if (cbPerfil.SelectedItem == null)
            {
                MessageBox.Show(
                    "Selecciona un perfil");
                return;
            }

            // VALIDAR MODALIDAD
            if (rbBasico.IsChecked != true &&
                rbAvanzado.IsChecked != true)
            {
                MessageBox.Show(
                    "Selecciona una modalidad");
                return;
            }

            // OBTENER PERFIL
            string perfil =
                (cbPerfil.SelectedItem as ComboBoxItem)?
                .Content?
                .ToString() ?? "";

            // OBTENER MODALIDAD
            string modalidad;

            if (rbBasico.IsChecked == true)
            {
                modalidad = "Básica";
            }
            else
            {
                modalidad = "Avanzada";
            }

            // CREAR UNA PERSONA
            Persona persona =
                new Persona()
                {
                    Nombre = txtNombre.Text,
                    Edad = edad,
                    Perfil = perfil,
                    Modalidad = modalidad
                };

            // AÑADIRLA A LA LISTA
            listaPersonas.Add(persona);

            // ACTUALIZAR EL LISTVIEW
            lvPersonas.Items.Refresh();

            lblMensaje.Content =
                "Persona guardada correctamente";
        }

        private void BtnResumen_Click(
            object sender,
            RoutedEventArgs e)
        {
            // COMPROBAR QUE HAY UNA PERSONA SELECCIONADA
            if (lvPersonas.SelectedItem
                is not Persona persona)
            {
                MessageBox.Show(
                    "Selecciona una persona de la lista");
                return;
            }

            // ABRIR EL RESUMEN DE ESA PERSONA
            VentanaResumen ventana =
                new VentanaResumen(persona);

            if (ventana.ShowDialog() == true)
            {
                lblMensaje.Content =
                    "Observación: " +
                    ventana.ObservacionDevuelta;
            }
            else
            {
                lblMensaje.Content =
                    "Operación cancelada";
            }
        }

        private void BtnLimpiar_Click(
            object sender,
            RoutedEventArgs e)
        {
            MessageBoxResult resultado =
                MessageBox.Show(
                    "¿Seguro que deseas limpiar los datos del formulario?",
                    "Confirmar",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

            if (resultado !=
                MessageBoxResult.Yes)
            {
                return;
            }

            txtNombre.Text = "";
            txtEdad.Text = "";

            cbPerfil.SelectedIndex = -1;

            chkNotificaciones.IsChecked =
                false;

            rbBasico.IsChecked = false;
            rbAvanzado.IsChecked = false;

            slNivel.Value = 0;

            lblMensaje.Content = "";
        }
    }
}
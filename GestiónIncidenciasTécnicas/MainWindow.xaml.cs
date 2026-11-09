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

namespace GestiónIncidenciasTécnicas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<Incidencia> incidencias = new List<Incidencia>();
        public MainWindow()
        {
            InitializeComponent();
            lstIncidencias.ItemsSource = incidencias; //asociar lista al list view

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
           if(string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Por favor, ingrese un título para la incidencia.", "Advertencia", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

           if(cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione una categoría para la incidencia.", "Advertencia", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

           if(!int.TryParse(txtTiempoEstimado.Text, out int tiempoEstimado) || tiempoEstimado <= 0)
            {
                MessageBox.Show("Por favor, ingrese un tiempo estimado válido para la incidencia.", "Advertencia", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

           string titulo = txtTitulo.Text;
           string categoria = 
                (cmbCategoria.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "";
           tiempoEstimado = int.Parse(txtTiempoEstimado.Text);


            Incidencia nuevaIncidencia = new Incidencia
            {
                titulo = titulo,
                categoria = categoria,
                TiempoEstimado = tiempoEstimado,
                prioridad = rdoAlta.IsChecked == true ? "Alta" :
                            rdoMedia.IsChecked == true ? "Media" : "Baja"
            };
            incidencias.Add(nuevaIncidencia);
            lstIncidencias.Items.Refresh();

        }

        private void btnGestionar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
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

            txtTitulo.Text = "";
            cmbCategoria.SelectedIndex = -1;
            txtTiempoEstimado.Text = "";
            rdoBaja.IsChecked = false;
            rdoMedia.IsChecked = false;
            rdoAlta.IsChecked = false;

        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClasesyListview
{
    /// <summary>
    /// Lógica de interacción para VentanaResumen.xaml
    /// </summary>
    public partial class VentanaResumen : Window
    {
        public string ObservacionDevuelta { get; set; } = "";
        public VentanaResumen(Persona persona)
        {
            InitializeComponent();

            txtResumenNombre.Text = persona.Nombre;
            txtResumenEdad.Text = persona.Edad.ToString();
            txtResumenPerfil.Text = persona.Perfil;
            txtResumenModalidad.Text = persona.Modalidad;
        }

        private void BtnAceptar_Click(
            object sender,
            RoutedEventArgs e)
        {
            ObservacionDevuelta =
                txtObservaciones.Text;

            DialogResult = true;
        }

        private void BtnCancelar_Click(
            object sender,
            RoutedEventArgs e)
        {
            DialogResult = false;
        }


    }
}

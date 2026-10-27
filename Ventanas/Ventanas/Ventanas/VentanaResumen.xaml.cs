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

namespace Ventanas
{
    /// <summary>
    /// Lógica de interacción para VentanaResumen.xaml
    /// </summary>
    public partial class VentanaResumen : Window
    {
        public string ObservacionDevuelta { get; set; } = "";

        public VentanaResumen(
            string nombre,
            string perfil,
            int edad,
            string modalidad)
        {
            InitializeComponent();

            txtResumenNombre.Text = nombre;
            txtResumenPerfil.Text = perfil;
            txtResumenEdad.Text = edad.ToString();
            txtResumenModalidad.Text = modalidad;
        }

        private void BtnAceptar_Click(
            object sender,
            RoutedEventArgs e)
        {
            ObservacionDevuelta = txtObservaciones.Text;

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

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
using RegistroPrimerParcialAP1.Entidades;
using RegistroPrimerParcialAP1.BLL;

namespace RegistroPrimerParcialAP1.UI.Registros
{
    /// <summary>
    /// Interaction logic for rArticulos.xaml
    /// </summary>
    public partial class rArticulos : Window
    {
        private Articulos Articulo = new Articulos();
        public rArticulos()
        {
            InitializeComponent();
            this.DataContext = Articulo;

        }

        private bool Validar()
        {
            bool esValido = true;
            if (DescripcionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debe introducir una descripción", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }

        private void Limpiar()
        {
            this.Articulo = new Articulos();
            this.DataContext = Articulo;

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var articulo = ArticulosBLL.Buscar(Utilidades.ToInt(ArticuloIdTextBox.Text));

            if (articulo != null)
                this.Articulo = articulo;
            else
                this.Articulo = new Articulos();

            this.DataContext = this.Articulo;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())            
                return;

                var paso = ArticulosBLL.Guardar(Articulo);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transacción Exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ArticulosBLL.Eliminar(Utilidades.ToInt(ArticuloIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Articulo Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ValorInventarioTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {            
            
            ValorInventarioTextBox.Text = (Utilidades.ToInt(ExistenciaTextBox.Text)* Utilidades.ToInt(CostoTextBox.Text)).ToString(); 
 
        }

        private void ExistenciaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int existencia = int.Parse(ExistenciaTextBox.Text);
        }

        private void CostoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            double costo = Convert.ToDouble(CostoTextBox.Text);
        }
    }

}

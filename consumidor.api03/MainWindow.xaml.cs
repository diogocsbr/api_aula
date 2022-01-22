using Flurl.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace consumidor.api03
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://localhost:7035/";
            string endpoint = url + "api/TarefaItems";
            IEnumerable<Trabalho> listaTarefas = endpoint.GetJsonAsync<IEnumerable<Trabalho>>().Result;

            dtgGrid.ItemsSource = listaTarefas;

        }
    }
}

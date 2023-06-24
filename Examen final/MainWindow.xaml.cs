using EXAMEN_FINAL;
using Microsoft.Data.SqlClient;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Examen_final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Agregar un boton para eliminar
            DataGridTemplateColumn templateColumn = new DataGridTemplateColumn();
            templateColumn.Header = "Eliminar";
            DataTemplate dataTemplate = new DataTemplate();
            FrameworkElementFactory buttonFactory = new FrameworkElementFactory(typeof(Button));
            buttonFactory.SetValue(Button.ContentProperty, "Eliminar");
            buttonFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler(Eliminar_Click));
            dataTemplate.VisualTree = buttonFactory;
            templateColumn.CellTemplate = dataTemplate;
            DataGridAlumnos.Columns.Add(templateColumn);
            Window_Loaded(null, null);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Obtener los datos de la base de datos
            // Crear la conexion con la BD con ADDONET
            SqlConnection connection = new SqlConnection(Shared.ConnectionString);
            // Crear el comando para ejecutar la consulta
            SqlCommand command = new SqlCommand("SELECT * FROM Alumnos", connection);
            // Abrir la conexion
            connection.Open();
            // Ejecutar el comando
            SqlDataReader reader = command.ExecuteReader();
            // Pasar los datos a lista y mostrarlos en el datagrid
            List<Alumno> alumnos = new List<Alumno>();
            while (reader.Read())
            {
                Alumno alumno = new Alumno();
                alumno.Carnet = reader.GetString(0);
                alumno.Nombre = reader.GetString(1);
                alumno.Telefono = reader.GetString(2);
                alumno.Grado = reader.GetString(3);
                alumnos.Add(alumno);
            }
            // Cerrar la conexion
            connection.Close();

            // Mostrar todos los alumnos en el datagrid
            DataGridAlumnos.ItemsSource = alumnos;
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el boton que se presiono
            Button button = (Button)sender;
            // Obtener el alumno que se va a eliminar
            Alumno alumno = (Alumno)button.DataContext;
            // Crear la conexion con la BD con ADDONET
            SqlConnection connection = new SqlConnection(Shared.ConnectionString);
            // Crear el comando para ejecutar la consulta
            SqlCommand command = new SqlCommand("DELETE FROM Alumnos WHERE carnet = @carnet", connection);
            // Agregar los parametros
            command.Parameters.Add("@carnet", System.Data.SqlDbType.VarChar, 10).Value = alumno.Carnet;
            // Abrir la conexion
            connection.Open();
            // Ejecutar el comando
            command.ExecuteNonQuery();
            // Cerrar la conexion
            connection.Close();
            // Actualizar el datagrid
            Window_Loaded(null, null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Obtener los valores de los TextBox:
            string carnet = CarnetTxtBox.Text;
            string nombre = NombreTxtBox.Text;
            string telefono = TelefonoTxtBox.Text;
            string grado = GradoTxtBox.Text;
            // Crear la conexion con la BD con ADDONET
            // Usar el ConnectionString de la clase Shared
            SqlConnection connection = new SqlConnection(Shared.ConnectionString);
            // Crear el comando para ejecutar la consulta
            SqlCommand command = new SqlCommand("INSERT INTO Alumnos VALUES (@carnet, @nombre, @telefono, @grado)", connection);
            // Agregar los parametros
            command.Parameters.Add("@carnet", System.Data.SqlDbType.VarChar, 10).Value = carnet;
            command.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 50).Value = nombre;
            command.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = telefono;
            command.Parameters.Add("@grado", System.Data.SqlDbType.VarChar, 50).Value = grado;
            // Abrir la conexion
            connection.Open();
            // Ejecutar el comando
            command.ExecuteNonQuery();
            // Cerrar la conexion
            connection.Close();
            // Actualizar el datagrid
            Window_Loaded(null, null);
        }
    }
}

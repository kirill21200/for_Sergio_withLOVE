using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Passengers : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable table;
        public Passengers()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=aero;Trusted_Connection=True;");
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            dataGridView1.DataSource = table;
        }

        private void Passengers_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aeroDataSet.Passenger". При необходимости она может быть перемещена или удалена.
            this.passengerTableAdapter.Fill(this.aeroDataSet.Passenger);

        }
        private void ShowTable(string text)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            command.CommandText = text;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void remove_Click(object sender, EventArgs e)
        {
            connection.Open();
            command.CommandText = "DELETE FROM Passenger WHERE ID_comp>= 6";
            command.ExecuteReader();
            connection.Close();
            ShowTable("SELECT name FROM Passenger");
        }

        private void add_Click(object sender, EventArgs e)
        {
            connection.Open();
            command.CommandText = "INSERT INTO Passenger VALUES (\'" + pass.Text + "\');";
            command.ExecuteReader();
            connection.Close();
            ShowTable("SELECT name FROM Company");
        }

        private void pass_Click(object sender, EventArgs e)
        {
            ShowTable("SELECT name FROM Passenger");
        }
    }
}

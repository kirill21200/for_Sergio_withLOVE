using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab1
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable table;

        public Form1()
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

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aeroDataSet1.Trip". При необходимости она может быть перемещена или удалена.
            this.tripTableAdapter.Fill(this.aeroDataSet1.Trip);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aeroDataSet.Trip". При необходимости она может быть перемещена или удалена.

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

        private void company_Click(object sender, EventArgs e)
        {
            ShowTable("SELECT * FROM Company");
        }

        private void Add_Click(object sender, EventArgs e)
        {
            connection.Open();
            command.CommandText = "INSERT INTO Company VALUES (\'" + name.Text + "\');";
            command.ExecuteReader();
            connection.Close();
            ShowTable("SELECT * FROM Company");
        }

        private void remove_Click(object sender, EventArgs e)
        {
            connection.Open();
            command.CommandText = "DELETE FROM Company WHERE ID_comp>= 6";
            command.ExecuteReader();
            connection.Close();
            ShowTable("SELECT * FROM Company");
        }
    }
}

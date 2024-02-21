using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace calculator
{
    public partial class Form1 : Form
    {
        private string server = "localhost";
        private string database = "imdb";
        private string uid = "root";
        private string password = "1234";
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;
        public Form1()
        {
            InitializeComponent();

            InitializeDatabase();
            LoadData();
        }
        private void InitializeDatabase()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            connection = new MySqlConnection(connectionString);
        }
        private void LoadData()
        {
            try
            {
                string query = "SELECT * FROM film_info";

                connection.Open();

                command = new MySqlCommand(query, connection);
                adapter = new MySqlDataAdapter(command);
                dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
           
            finally
            {
                connection.Close();
            }
        }
    
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {  
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() == "Add Film")
            {   
                textBox1.Visible = true;
                label2.Visible = true;
                button1.Visible = true;
                dataGridView1.Visible = true;
                label2.Text = "Введите ключевое слово для добавление фильма";
            }
            

            if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() == "Remove Film")
            {
                label2.Text = "Введите фильм который хотите удалить";
                dataGridView1.Visible = true;
            }
            if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() == "Info")
            {
                label2.Text = "Введите дату выхода фильма для просмотра информации";
                dataGridView1.Visible = true;
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            
           
        }

        
    }
}

//gamma
//subject subscribe gamma
//subject -> gamma

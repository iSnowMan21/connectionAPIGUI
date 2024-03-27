using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace ConnectionAPIGUI
{
    public partial class Form1 : Form
    {
        private ConnectionWithDataBase con = new ConnectionWithDataBase();

        private DataTable dataTable;
        public Form1()
        {
            InitializeComponent();

            LoadData();
        }
        
        private void LoadData()
        {
            
            dataTable = new DataTable();
            con.LoadDataForDataGridView().Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void LoadDataInfoYear(string year)
        {

            dataTable = new DataTable();
            con.InfoYear(year).Fill(dataTable);
            dataGridView1.DataSource = dataTable;
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
            if(textBox1.Text != "")
            {
                button1.Visible = true;
            }
            else
            {
                button1.Visible = false;
            }

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
            if(comboBox2.SelectedItem != null)
            {
                textBox1.Visible = true;
                label2.Visible = true;
                dataGridView1.Visible = true;
                LoadData();
                dataGridView1.ForeColor = Color.Red;
                dataGridView1.GridColor = Color.Green;
            }
            if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() == "Add Film")
            {
                label2.Text = "Введите ключевое слово для добавление фильма " + comboBox2.Text;
                label3.Text = "";
            }


            if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() == "Remove Film")
            { 
                label2.Text = "Введите фильм который хотите удалить";
                label3.Text = "";
            }
            if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() == "Info")
            {
                label2.Text = "Введите дату выхода фильма для просмотра информации";
                textBox1.Visible = true;
                label2.Visible = true;
                dataGridView1.Visible = true;
                label3.Text = "";
            }

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if(comboBox2.Text == "Add Film")
            {
                label3.Text = Commands.addFilm(con, textBox1.Text);

                //label2.Text = textBox1.Text;
                LoadData();
                
            }

            if (comboBox2.Text == "Remove Film")
            {
                label3.Text = Commands.DeleteMovie(con, textBox1.Text);
                LoadData();
            }
            if (comboBox2.Text == "Info")
            {
                LoadDataInfoYear(textBox1.Text);
            }
           
           
        }

        public static void label4_Click(object sender, EventArgs e)
        {

        }

        
    }
}

//gamma
//subject subscribe gamma
//subject -> gamma

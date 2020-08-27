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

namespace lojaderoupas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Crio a estrutura da conexão com o banco de dados e passa o parametros
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "lojaderoupas";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";
            //Realizo a conexao com o banco de dados
            MySqlConnection realizaconexaoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaconexaoBD.Open();
                //MessageBox.Show("Conexão aberta !");

                MySqlCommand cmd = realizaconexaoBD.CreateCommand();
                cmd.CommandText = "INSERT INTO fabricante (nomeFabricante,idadeFabricante,nacionalidadeFabricante) " +
                "VALUES('" + textBox2.Text + "', '" + textBox1.Text + "','" + textBox3.Text + "')";
                cmd.ExecuteNonQuery();

                realizaconexaoBD.Close();
                MessageBox.Show("Inserido com sucesso");
                atualizarGrid();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Não podemos abrir a conexão");
                Console.WriteLine(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            atualizarGrid();
        }

        private void atualizarGrid()
        {
            //Crio a estrutura da conexão com o banco de dados e passa o parametros
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "lojaderoupas";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";
            //Realizo a conexao com o banco de dados
            MySqlConnection realizaconexaoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaconexaoBD.Open();

                MySqlCommand cmd = realizaconexaoBD.CreateCommand();
                cmd.CommandText = "SELECT * from fabricante";
                MySqlDataReader reader = cmd.ExecuteReader();

                dataGridView1.Rows.Clear();

                while (reader.Read())
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                    row.Cells[0].Value = reader.GetInt32(0);
                    row.Cells[1].Value = reader.GetString(1);
                    row.Cells[2].Value = reader.GetString(2);
                    row.Cells[3].Value = reader.GetString(3);
                    dataGridView1.Rows.Add(row);
                }

                realizaconexaoBD.Close();
            }




            catch (Exception ex)
            {
                //MessageBox.Show("Não podemos abrir a conexão");
                Console.WriteLine(ex.Message);
            }
        }
    }
}

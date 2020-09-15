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
            limparCampos();
            atualizarGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            atualizarGrid();
        }

        private void atualizarGrid()
        {   
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "lojaderoupas";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";
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

        private MySqlConnectionStringBuilder conexaoBanco ()
        {
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "lojaderoupas";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";
            return conexaoBD;
        }

        private void btneditar_Click(object sender, EventArgs e)
        {

            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "lojaderoupas";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";
            MySqlConnection realizaconexaoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaconexaoBD.Open();

                MySqlCommand comandoMySql = realizaconexaoBD.CreateCommand();
                comandoMySql.CommandText = "Update fabricante SET nomeFabricante = '" + textBox2.Text + "',  " +
                    "idadeFabricante = '" + textBox1.Text + "',  " +
                    "nacionalidadeFabricante = '" + textBox3.Text + "' WHERE idFabricante = " + textBox4.Text + "";
                comandoMySql.ExecuteNonQuery();

                realizaconexaoBD.Close();
                MessageBox.Show("Atualizado com Sucesso!");
                atualizarGrid();
                limparCampos();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnlimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["ColumnNome"].FormattedValue.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["ColumnIdade"].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["ColumnNacionalidade"].FormattedValue.ToString();
            }
        }

        private void btndeletar_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "lojaderoupas";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";
            MySqlConnection realizaconexaoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaconexaoBD.Open();

                MySqlCommand comandoMySql = realizaconexaoBD.CreateCommand();
                comandoMySql.CommandText = "UPDATE fabricante SET ativoFabricante = 1  WHERE idFabricante =" + textBox4.Text + "";
                comandoMySql.ExecuteNonQuery();

                realizaconexaoBD.Close();
                MessageBox.Show("Deletado com Sucesso!");
                atualizarGrid();
                limparCampos();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

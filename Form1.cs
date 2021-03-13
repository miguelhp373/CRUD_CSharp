using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRUD_CreateReadUpdateDelete
{
    public partial class Form1 : Form
    {
        SqlConnection ConnectionDB;
        SqlCommand CommandDB;
        SqlDataAdapter AdapterDB;
        SqlDataReader ReaderDB;

        String CommandsSQL;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnnew_Click(object sender, EventArgs e)
        {

            try
            {
                ConnectionDB = new SqlConnection(//faz a conexão com o db
                    @"
                Server=MIGUELHENRIQUE\SQLEXPRESS; 
                Database=CadastroClientes; 
                Trusted_Connection=True;
                ");

                CommandsSQL = "INSERT INTO tbcadusuarios (nome,telefone) VALUES (@nome,@telefone)";//instancia um comando sql
                CommandDB = new SqlCommand(CommandsSQL, ConnectionDB);//cria o comando instanciado acima
                CommandDB.Parameters.AddWithValue("@nome", txtnome.Text);//adiciona os valores para a instancia do comando sql
                CommandDB.Parameters.AddWithValue("@telefone", txtfone.Text);//adiciona os valores para a instancia do comando sql

                ConnectionDB.Open();//executa a conexão com o servidor do db
                CommandDB.ExecuteNonQuery();//executa a query do CommandsSQL
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//passa a mensagem caso o erro ocorra
            }
            finally
            {
                ConnectionDB.Close();//fecha a conexão com o db
                ConnectionDB = null;//define null para poder instanciar novamente
                CommandDB = null;//define null para poder instanciar novamente
            }
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionDB = new SqlConnection(//faz a conexão com o db
                @"
                Server=MIGUELHENRIQUE\SQLEXPRESS; 
                Database=CadastroClientes; 
                Trusted_Connection=True;
                ");

                CommandsSQL = "SELECT * FROM tbcadusuarios";//instancia um comando sql
                CommandDB = new SqlCommand(CommandsSQL, ConnectionDB);//cria o comando instanciado acima

                DataSet ds = new DataSet();//cria um novo dataset, para mostrar a tabela

                AdapterDB = new SqlDataAdapter(CommandsSQL,ConnectionDB);//recupera os dados

                ConnectionDB.Open();//executa a conexão com o servidor do db
                                 
                AdapterDB.Fill(ds);//popula o dataset
                viewData.DataSource = ds.Tables[0];//exibi os dados da tabela
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//passa a mensagem caso o erro ocorra
            }
            finally
            {
                ConnectionDB.Close();//fecha a conexão com o db
                ConnectionDB = null;//define null para poder instanciar novamente
                CommandDB = null;//define null para poder instanciar novamente
            }
        }

        private void btnconsult_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionDB = new SqlConnection(//faz a conexão com o db
                    @"
                Server=MIGUELHENRIQUE\SQLEXPRESS; 
                Database=CadastroClientes; 
                Trusted_Connection=True;
                ");

                CommandsSQL = "SELECT * FROM tbcadusuarios Where id = @id ";//instancia um comando sql
                CommandDB = new SqlCommand(CommandsSQL, ConnectionDB);//cria o comando instanciado acima
                CommandDB.Parameters.AddWithValue("@id", txtid.Text);//adiciona os valores para a instancia do comando sql
              
                ConnectionDB.Open();//executa a conexão com o servidor do db
                ReaderDB = CommandDB.ExecuteReader();//executa a query do CommandsSQL

                while (ReaderDB.Read())
                {
                    txtnome.Text = Convert.ToString(ReaderDB["nome"]);
                    txtfone.Text = Convert.ToString(ReaderDB["telefone"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//passa a mensagem caso o erro ocorra
            }
            finally
            {
                ConnectionDB.Close();//fecha a conexão com o db
                ConnectionDB = null;//define null para poder instanciar novamente
                CommandDB = null;//define null para poder instanciar novamente
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionDB = new SqlConnection(//faz a conexão com o db
                @"
                Server=MIGUELHENRIQUE\SQLEXPRESS; 
                Database=CadastroClientes; 
                Trusted_Connection=True;
                ");

                CommandsSQL = "UPDATE tbcadusuarios SET nome = @nome, telefone = @telefone WHERE id = @id";//instancia um comando sql

                CommandDB = new SqlCommand(CommandsSQL, ConnectionDB);//cria o comando instanciado acima

                CommandDB.Parameters.AddWithValue("@id", txtid.Text);//adiciona os valores para a instancia do comando sql
                CommandDB.Parameters.AddWithValue("@nome", txtnome.Text);//adiciona os valores para a instancia do comando sql
                CommandDB.Parameters.AddWithValue("@telefone", txtfone.Text);//adiciona os valores para a instancia do comando sql

                ConnectionDB.Open();//executa a conexão com o servidor do db
                CommandDB.ExecuteNonQuery();//executa a query do CommandsSQL
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//passa a mensagem caso o erro ocorra
            }
            finally
            {
                ConnectionDB.Close();//fecha a conexão com o db
                ConnectionDB = null;//define null para poder instanciar novamente
                CommandDB = null;//define null para poder instanciar novamente
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionDB = new SqlConnection(//faz a conexão com o db
                @"
                Server=MIGUELHENRIQUE\SQLEXPRESS; 
                Database=CadastroClientes; 
                Trusted_Connection=True;
                ");

                CommandsSQL = "DELETE tbcadusuarios Where id = @id";//instancia um comando sql

                CommandDB = new SqlCommand(CommandsSQL, ConnectionDB);//cria o comando instanciado acima

                CommandDB.Parameters.AddWithValue("@id", txtid.Text);//adiciona os valores para a instancia do comando sql


                ConnectionDB.Open();//executa a conexão com o servidor do db
                CommandDB.ExecuteNonQuery();//executa a query do CommandsSQL
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//passa a mensagem caso o erro ocorra
            }
            finally
            {
                ConnectionDB.Close();//fecha a conexão com o db
                ConnectionDB = null;//define null para poder instanciar novamente
                CommandDB = null;//define null para poder instanciar novamente
            }
        }
    }
}

using System;
using System.Data.SqlClient;
using System.Data; 
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library1
{
    public class ClsBancoDeDados 
    {
        //Classe destinada a resolver as requisições ao banco de dados.
        //Essa classe irá retornar leitor de dados genéricos no Namespace System.Data: DataTables, DataTablesReaders


        //Declarações de variaveis:

       string mstrStringConexao;            
       string strerro_banco = "";
       string mstrStatusConexao = "Não conectado";
       string mstrDescricaoErro = "";
       private SqlConnection moCon = new SqlConnection();


        //Variaveis de modulo:

       private string mstrMensagemUltimoComando = ""; //Variavel para armazenar mensagens de erros sobre o ultimo comando executado.
       private bool mboolResultadoUltimoComando; //Armazena true ou false de acordo com o sucesso de execução do comando.

       public string MensagemUltimoComando
       {
            get {return mstrMensagemUltimoComando;}    
       }

        public bool ResultadoUltimoComando
        {
            get{return mboolResultadoUltimoComando;}
        }
         


      #region "Método Construtor"
      public ClsBancoDeDados()
      {
            try
            {
                mstrStringConexao = @"Server = RODRIGO-PC\SQLEXPRESS; Database = SistemaReservas; Integrated Security = SSPI;";

                
                ConectaDB(mstrStringConexao);
            }
            catch
            {
                strerro_banco = "Erro ao tentar se conectar";
            }
        }
       #endregion

      #region "Metodos"
      private void ConectaDB(string strconecta)
      {

          try
          {
              moCon.ConnectionString = strconecta;
              moCon.Open();
              mstrStatusConexao = moCon.State.ToString();
          }
          catch 
          {
              strerro_banco = "erro ao se conectar";
          }
      }

      public void DesconectaDB()
      {
          try
          {
              if (moCon.State.ToString() == "Open")
              {
                  moCon.Close();
                  mstrStatusConexao = moCon.State.ToString();
              }
          }

          catch
          {
              strerro_banco = "erro ao tentar se desconectar";
          }
      }

        /// <summary>
        /// Esse método retorna um ResultSet(comando select) a partir do comando enviado. Caso o comando não tenha resultados, será retornado valor NULL.
        /// </summary>
        /// <param name="pstrQuery">Procedure ou query. </param>
        /// <returns>Um resultset do tipo DatatableReader</returns>

        

        public DataTableReader NewReader(string pstrQuery)
        {
            try
            {
                SqlCommand oComando = new SqlCommand(pstrQuery, moCon);

                DataTable dtResultado = new DataTable();

                SqlDataAdapter daAdaptador = new SqlDataAdapter(oComando);

                daAdaptador.Fill(dtResultado);

                mstrMensagemUltimoComando = "OK";
                //mbooResultadoUltimoComando = true;

                if (dtResultado.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                   return dtResultado.CreateDataReader();
                   
                }
            }
            catch
            {
                mstrMensagemUltimoComando = "Erro";
                strerro_banco = "erro ao executar comando";
                return null;
            }
        }


        /// <summary>
        /// Esse método retorna um DataSet(comando select) a partir do comando enviado. Caso o comando não tenha resultados, será retornado valor NULL.
        /// </summary>
        /// <param name="pstrQuery">Procedure ou query. </param>
        /// <returns>Um resultset do tipo DataSet</returns>


        public DataSet NewDataSet(string strDSQL)
        {
            try
            {
                
                //declara o dataset
                DataSet ds = new DataSet();

                //declara o sql data adapter
                using (SqlDataAdapter sdaAdapter = new SqlDataAdapter(strDSQL, this.moCon))
                {
                    //Preenche o DataAdpater:
                    sdaAdapter.Fill(ds);
                }

                return ds;
               
            }

            catch
            {
                mstrMensagemUltimoComando = "Erro";
                //mstrDescricaoErro = "Erro na execução do script";
                return null;

            }

        }


        /// <summary>
        /// Realiza comandos, não query's(update,delete), no banco. Retorna o número de linhas afetadas. Em caso de erro será retornado -1.
        /// A quantide de linhas afetadas leva em consideração as linhas alteradas por triggers, caso exista uma na tabela em questão.
        /// </summary>
        /// <param name="pstrQuery">Comando a ser executado no banco.</param>
        /// <returns></returns>

        public int Execute(string pstrQuery)
        {
           
            try
            {
                SqlCommand oComando = new SqlCommand(pstrQuery, moCon);                       
                int intQtdeReg = oComando.ExecuteNonQuery();

                mstrMensagemUltimoComando = "OK";
                mboolResultadoUltimoComando = true;
                return intQtdeReg;
            }
            catch
            {
                
                mstrMensagemUltimoComando = "Erro";
                mboolResultadoUltimoComando = false;
                strerro_banco = "erro ao executar algum comando";
                return -1;
            }
        }

        /// <summary>
        /// Realiza comandos, não query's, no banco. Não retorna o número de linhas afetadas. Em caso de erro será retornado -1.
        /// /// </summary>
        /// <param name="pstrQuery">Comando a ser executado no banco.</param>
        /// <returns>Esse método não retorna a quantidade de registros afetados.</returns>


        public void ExecuteSemRetorno(string pstrQuery)
        {
            try
            {
                SqlCommand oComando = new SqlCommand(pstrQuery, moCon);

                mstrMensagemUltimoComando = "OK";
                mboolResultadoUltimoComando = true;

                int intQtdeReg = oComando.ExecuteNonQuery();

                mstrMensagemUltimoComando = "OK";
                mboolResultadoUltimoComando = true;
                
            }
            catch 
            {
                mstrMensagemUltimoComando = "Erro";
                mboolResultadoUltimoComando = false;
                strerro_banco = "erro ao executar algum comando";
                
            }
        }
    
                 
    }

        #endregion

}


using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Library1
{
    
    public class Tratamento_Erros
    {
        string strexcecao_erro_msg;
        int intretorna_excecao_id_erro;
        string SQL;
        //string CGC;
        //string matricula;
        //string retorno;
        int id_retorno;

    

        ClsBancoDeDados oDB = new ClsBancoDeDados();

        /// <summary>
        ///Metodo da "Library1", namespace "Libray1", Classe "Tratamento_Erros", aplica tratamentos de excecao para operações de banco
        /// </summary> 
        public int Grava_Excecao(string cgc,string matricula,string retorno,string query,string pagina)
        {
            string retorno_erro;
            string retorno_query;
            string retorno_final;

            retorno_erro = retorno.Replace("'", "");
            retorno_erro = retorno_erro.Replace(",", "");

            retorno_query = query.Replace("'", "");
            //retorno_query = retorno_query.Replace(",", "");

            retorno_final = "Erro: erro processamento string SQL; Query: " + retorno_query + "; Página: " +pagina;

            SQL = "exec SP_INS_TB_Grava_Retorno_Excecao '" + cgc + "','" + matricula + "','" + retorno_final + "'";
            DataTableReader ds_retorno = oDB.NewReader(SQL);
            //--registrar eof:
            if (ds_retorno != null)
            {
                while (ds_retorno.Read())
                {
                    id_retorno = int.Parse(ds_retorno["Id_Erro"].ToString());
                    ds_retorno.Close();
                    oDB.DesconectaDB();
                    return id_retorno;
                }
            }

       
            oDB.DesconectaDB();
             return id_retorno;
        }
         

    }
}

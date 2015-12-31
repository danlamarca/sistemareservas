using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using Library1;

namespace Library1.BO
{
    public class Cliente  
    {
        #region Campos
        private int CODCLIENTE=0;
        private string CPF="";
        private string NOME="";
        private string ENDERECO="";

        StringBuilder sql = new StringBuilder();
        Tratamento_Erros Tr_Error = new Tratamento_Erros();
        Valicoes_num Val_Num_int = new Valicoes_num();
        string strSQL;
        int retorna_erro;
        int cesta_ok;
        #endregion 

        #region Propriedades
        public int _CODCLIENTE
        {
            get {return CODCLIENTE; }
            set { CODCLIENTE = value; }
        }

        public string _CPF
        {
            get { return CPF; }
            set { CPF = value; }
        }

        public string _NOME
        {
            get { return NOME; }
            set { NOME = value; }
        }

        public string _ENDERECO
        {
            get { return ENDERECO; }
            set { ENDERECO = value; }
        }
        #endregion

        #region Construtores
        public Cliente()
        {}  
        public Cliente(int CODCLIENTE,string CPF,string NOME,string ENDERECO)
        {
            this._CODCLIENTE = CODCLIENTE;
            this._NOME = NOME;
            this._CPF = CPF;
            this._ENDERECO = ENDERECO;
        }
        #endregion

        #region Metodos
        public void Salvar()    
        {
            //efetua gravação:
            sql.Append("INSERT INTO TB_CLIENTE(NOME,CPF,ENDERECO) VALUES('@NOME','@CPF','@END') ");
                    
            sql.Replace("@NOME", this._NOME);
            sql.Replace("@CPF", this._CPF);
            sql.Replace("@END", this._ENDERECO);

            ClsBancoDeDados oDB = new ClsBancoDeDados();
            oDB.ExecuteSemRetorno(sql.ToString());
            if (oDB.MensagemUltimoComando.ToString() == "Erro")
            {
                string retorno_xml = oDB.MensagemUltimoComando.ToString();
                string pagina = "BO_cliente.cs";
                retorna_erro = Tr_Error.Grava_Excecao("user1", "user1", retorno_xml, strSQL, pagina);
            }           
            oDB.DesconectaDB();
        }

        public void Deletar()  
        {
            sql.Append("DELETE FROM TB_CLIENTE ");

            if (this.CODCLIENTE > 0)
            {
                sql.Append("WHERE CODCLIENTE=@CODCLIENTE");
                sql.Replace("@CODCLIENTE", CODCLIENTE.ToString());
            }                      

            ClsBancoDeDados oDB = new ClsBancoDeDados();
            oDB.ExecuteSemRetorno(sql.ToString());
            if (oDB.MensagemUltimoComando.ToString() == "Erro")
            {
                string retorno_xml = oDB.MensagemUltimoComando.ToString();
                string pagina = "BO_cliente.cs";
                retorna_erro = Tr_Error.Grava_Excecao("user1", "user1", retorno_xml, strSQL, pagina);
            }
            oDB.DesconectaDB();
        }
        public void Verifica()
        { }
        #endregion        
    }
}

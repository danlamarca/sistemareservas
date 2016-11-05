using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using Library1;

namespace Library1.BO
{
    public class Cliente_Todos : List<Cliente>
    {
        #region Campos
        private int CODCLIENTE = 0;
        private string CPF = "0";      
        private TipoPesquisaCliente tipopesq = TipoPesquisaCliente.Todos;

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
            get { return CODCLIENTE; }
            set { CODCLIENTE = value; }
        }

        public string _CPF
        {
            get { return CPF; }
            set { CPF = value; }
        }
        #endregion

        #region Construtores
        public Cliente_Todos()
        { }
                
        public Cliente_Todos(int codigo)
        {           
            this._CODCLIENTE = codigo;
            tipopesq = TipoPesquisaCliente.porCodigo;
            Carrega();  
        }

        public Cliente_Todos(string CPF)
        {            
            this._CPF = CPF;
            tipopesq = TipoPesquisaCliente.porCPF;
            Carrega();
        }

        public Cliente_Todos(TipoPesquisaCliente tipopes, int codigo, string CPF)
        {
            tipopesq = tipopes;
            this._CODCLIENTE = codigo;
            this._CPF = CPF;
            Carrega();           
        }
        #endregion

        #region Metodos
        private void Carrega()
        {           
            sql.Append("Select CODCLIENTE,CPF,NOME,ENDERECO from TB_CLIENTE with(nolock) ");

            if (tipopesq == TipoPesquisaCliente.porCodigo)
            {
                sql.Append("where CODCLIENTE=@CODCLIENTE ");

                sql.Replace("@CODCLIENTE", CODCLIENTE.ToString());
            }
            else if (tipopesq == TipoPesquisaCliente.porCPF)
            {
                sql.Append("where CPF=@CPF ");

                sql.Replace("@CPF", CPF.ToString());
            }

            ClsBancoDeDados oDB = new ClsBancoDeDados();
            DataTableReader ds_usuario = oDB.NewReader(sql.ToString());                
            if (oDB.MensagemUltimoComando.ToString() == "Erro")
            {
                string retorno_xml = oDB.MensagemUltimoComando.ToString();
                string pagina = "BO_cliente_todos.cs";
                retorna_erro = Tr_Error.Grava_Excecao("user1", "user1", retorno_xml, strSQL, pagina);
            }                

            if (ds_usuario != null)
            {
                while (ds_usuario.Read())
                {
                    //Inicializo o objeto Usuario e populo a lista Usuario_Todos com ele.
                    Cliente usu = new Cliente(int.Parse(ds_usuario["CODCLIENTE"].ToString()), ds_usuario["CPF"].ToString(), ds_usuario["NOME"].ToString(), ds_usuario["ENDERECO"].ToString());
                    //populando este próprio objeto
                    this.Add(usu);
                }
                ds_usuario.Close(); 
            } 
            oDB.DesconectaDB();           
        }
        #endregion


        public enum TipoPesquisaCliente
        {
            porCodigo,          
            porCPF,
            Todos
        }
    }
}

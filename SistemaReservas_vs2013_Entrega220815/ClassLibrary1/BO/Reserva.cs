using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using Library1;

namespace Library1.BO
{
    public class Reserva
    {
        #region Campos
        private int CODRESERVA=0;
        private int CODSALA=0;
        private int CODUSUARIO=0;
        private DateTime DATAINICIO=Convert.ToDateTime("1800/01/01");
        private DateTime DATAFIM = Convert.ToDateTime("1800/01/01");
        private string DESCRICAO="";
        private int CODACOMPANHAMENTOITEM=0;
        private Cliente_Todos CLIENTE;

        StringBuilder sql = new StringBuilder();
        Tratamento_Erros Tr_Error = new Tratamento_Erros();
        Valicoes_num Val_Num_int = new Valicoes_num();
        string strSQL;
        int retorna_erro;
        int cesta_ok;
        #endregion

        #region Propriedades
        public int _CODRESERVA
        {
            get { return CODRESERVA; }
            set { CODRESERVA = value; }
        }
        public int _CODSALA
        {
            get { return CODSALA; }
            set { CODSALA = value; }
        }
        public int _CODUSUARIO
        {
            get { return CODUSUARIO; }
            set { CODUSUARIO = value; }
        }
        public DateTime _DATAINICIO
        {
            get { return DATAINICIO; }
            set { DATAINICIO = value; }
        }
        public DateTime _DATAFIM
        {
            get { return DATAFIM; }
            set { DATAFIM = value; }
        }
        public string _DESCRICAO
        {
            get { return DESCRICAO; }
            set { DESCRICAO = value; }
        }
        public int _CODACOMPANHAMENTOITEM
        {
            get { return CODACOMPANHAMENTOITEM; }
            set { CODACOMPANHAMENTOITEM = value; }
        }
        public Cliente_Todos _CLIENTE
        {
            get { return CLIENTE; }
            set { CLIENTE = value; }
        }
        #endregion

        #region Construtores
        public Reserva()
        {}

        public Reserva(int CODRESERVA, int CODSALA, int CODUSUARIO, DateTime DATAINICIO, DateTime DATAFIM, string DESCRICAO, int CODACOMPANHAMENTOITEM, int Cliente)
        { 
            this.CODRESERVA = CODRESERVA;
            this.CODSALA = CODSALA;
            this.CODUSUARIO = CODUSUARIO;
            this.DATAINICIO = DATAINICIO;
            this.DATAFIM=DATAFIM;
            this.DESCRICAO = DESCRICAO;
            this.CODACOMPANHAMENTOITEM = CODACOMPANHAMENTOITEM;            
            this._CLIENTE = new Cliente_Todos(Cliente);
        }
        #endregion

        #region Métodos
        public void Salvar()
        {
            //efetua gravação:
            sql.Append("INSERT INTO TB_RESERVA(CODSALA,CODUSUARIO, DATAINICIO,DATAFIM,DESCRICAO,CODACOMPANHAMENTOITEM,Cliente) ");
            sql.Append("VALUES(@CODSALA,@CODUSUARIO,@DATAINICIO,@DATAFIM,@DESCRICAO,@CODACOMPANHAMENTOITEM,@Cliente) ");
                        
            sql.Replace("@CODSALA", this.CODSALA.ToString());
            sql.Replace("@CODUSUARIO", this.CODUSUARIO.ToString());
            sql.Replace("@DATAINICIO", this.DATAINICIO.ToString());
            sql.Replace("@DATAFIM", this.DATAFIM.ToString());
            sql.Replace("@DESCRICAO", this.DESCRICAO.ToString());
            sql.Replace("@CODACOMPANHAMENTOITEM", this.CODACOMPANHAMENTOITEM.ToString());
            sql.Replace("@Cliente", this.CLIENTE._CODCLIENTE.ToString());

            ClsBancoDeDados oDB = new ClsBancoDeDados();
            oDB.ExecuteSemRetorno(sql.ToString());
            if (oDB.MensagemUltimoComando.ToString() == "Erro")
            {
                string retorno_xml = oDB.MensagemUltimoComando.ToString();
                string pagina = "BO_reserva.cs";
                retorna_erro = Tr_Error.Grava_Excecao("user1", "user1", retorno_xml, strSQL, pagina);
            }
            oDB.DesconectaDB();            
        }

        public void Deletar()
        {
            sql.Append("DELETE FROM TB_RESERVA ");

            if (this.CODRESERVA > 0)
            {
                sql.Append("WHERE CODRESERVA=@CODRESERVA");
                sql.Replace("@CODRESERVA", CODRESERVA.ToString());
            }

            ClsBancoDeDados oDB = new ClsBancoDeDados();
            oDB.ExecuteSemRetorno(sql.ToString());
            if (oDB.MensagemUltimoComando.ToString() == "Erro")
            {
                string retorno_xml = oDB.MensagemUltimoComando.ToString();
                string pagina = "BO_RESERVA.cs";
                retorna_erro = Tr_Error.Grava_Excecao("user1", "user1", retorno_xml, strSQL, pagina);
            }
            oDB.DesconectaDB();
        }
        #endregion

         
    }
}

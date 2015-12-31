using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using Library1;

namespace Library1.BO
{
    public class Reserva_Todos : List<Reserva>
    {
        #region Campos
        private int CODRESERVA = 0;
        private Cliente CLIENTE;
        private int CODSALA = 0;
        private int CODUSUARIO = 0;
        private TipoPesquisaReserva TIPOPESQ = TipoPesquisaReserva.porTodos;  

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
        public Cliente _CLIENTE
        {
            get { return CLIENTE; }
            set { CLIENTE = value; }
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
        public TipoPesquisaReserva _TIPOPESQ
        {
            get { return TIPOPESQ; }
            set { TIPOPESQ = value; }
        }
        #endregion

        #region Construtores
        public Reserva_Todos()
        { }

        public Reserva_Todos(int CODRESERVA)
        {
            this._CODRESERVA = CODRESERVA;
            TIPOPESQ = TipoPesquisaReserva.porReserva;
            Carrega();
        }

        public Reserva_Todos(Cliente CLIENTE)
        {
            this._CLIENTE = CLIENTE;
            TIPOPESQ = TipoPesquisaReserva.porCliente;
            Carrega();
        }

        public Reserva_Todos(int CODSALA, int CODUSUARIO, TipoPesquisaReserva TIPOPESQ)
        {
            this._CODSALA = CODSALA;
            this._CODUSUARIO = CODUSUARIO;
            this._TIPOPESQ = TIPOPESQ;
            Carrega();
        }
        #endregion

        #region Métodos
        private void Carrega()
        {
            sql.Append("Select CODRESERVA,CODSALA,CODUSUARIO,DATAINICIO,DATAFIM,DESCRICAO,CODACOMPANHAMENTOITEM,CLIENTE ");
            sql.Append("from TB_RESERVA with(nolock) ");

            if (TIPOPESQ == TipoPesquisaReserva.porReserva)
            {
                sql.Append("where CODRESERVA=@CODRESERVA ");

                sql.Replace("@CODRESERVA", CODRESERVA.ToString());
            }
            else if (TIPOPESQ == TipoPesquisaReserva.porCliente)
            {
                sql.Append("where CLIENTE=@CLIENTE ");

                sql.Replace("@CLIENTE", CLIENTE._CODCLIENTE.ToString());
            }
            else if (TIPOPESQ == TipoPesquisaReserva.porSala)
            {
                sql.Append("where CODSALA=@CODSALA ");

                sql.Replace("@CODSALA", CODSALA.ToString());
            }
            else if (TIPOPESQ == TipoPesquisaReserva.porUsuario)
            {
                sql.Append("where CODUSUARIO=@CODUSUARIO ");

                sql.Replace("@CODUSUARIO", CODUSUARIO.ToString());
            }
            ClsBancoDeDados oDB = new ClsBancoDeDados();
            DataTableReader ds_reserva= oDB.NewReader(sql.ToString());
            if (oDB.MensagemUltimoComando.ToString() == "Erro")
            {
                string retorno_xml = oDB.MensagemUltimoComando.ToString();
                string pagina = "BO_RESERVA_TODOS.cs";
                retorna_erro = Tr_Error.Grava_Excecao("user1", "user1", retorno_xml, strSQL, pagina);
            }

            if (ds_reserva != null)
            {
                while (ds_reserva.Read())
                {
                    //Inicializo o objeto reserva e populo a lista reserva_Todos com ele.
                    Reserva reserv = new Reserva(int.Parse(ds_reserva["CODRESERVA"].ToString()), int.Parse(ds_reserva["CODSALA"].ToString()), int.Parse(ds_reserva["CODUSUARIO"].ToString()), Convert.ToDateTime(ds_reserva["DATAINICIO"]), Convert.ToDateTime(ds_reserva["DATAFIM"]), ds_reserva["DESCRICAO"].ToString(), int.Parse(ds_reserva["CODACOMPANHAMENTOITEM"].ToString()),int.Parse(ds_reserva["CLIENTE"].ToString()));
                    //populando este próprio objeto
                    this.Add(reserv);
                }
                ds_reserva.Close();
            }
            oDB.DesconectaDB();              
        }
        #endregion


        public enum TipoPesquisaReserva
        {
            porReserva,
            porCliente,
            porSala,
            porUsuario,
            porTodos  
        }
    }
}

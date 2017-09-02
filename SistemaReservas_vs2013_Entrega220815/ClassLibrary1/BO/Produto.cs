using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library1.BO
{
    public class Produto
    {
        public Produto()
        { }//id,nome,descricao,valor

        private int _ID_PRODUTO = 0;
        private string _NOME = "";
        private string _DESCRICAO = "";
        private decimal _VALOR = 0;
       
        public int ID_PRODUTO
        {
            get { return _ID_PRODUTO; }
            set { _ID_PRODUTO = value; }
        }

        public string NOME
        {
            get { return _NOME; }
            set { _NOME = value; }
        }

        public string DESCRICAO 
        {
            get { return _DESCRICAO; }
            set { _DESCRICAO = value; }
        }

        public decimal VALOR 
        {
            get { return _VALOR; }
            set { _VALOR = value; }
        }
    }
}

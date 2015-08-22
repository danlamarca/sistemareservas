using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library1;
using System.Text.RegularExpressions;

namespace Library1
{

    //declaração de armazenamento especial de valores, enxergadas apenas pelo namespace VerificaForcaSenha 
    public enum ForcaSenha
    {
        Inaceitavel,
        Fraca,
        Aceitavel,
        Forte,
        Segura
    }

    public class ChecaForcaSenha
    {
        public int geraPontosSenha(string senha)
        {
            int PontosPorTamanho = GetPontoPorTamanho(senha);
            int PontosPorMinuscula = GetPontoPorMinuscula(senha);
            int PontosPorMaiuscula = GetPontoPorMaiuscula(senha);
            int PontosPorDigito = GetPontosPorDigito(senha);
            int PontosPorSimbolo = GetPontosPorSimbolo(senha);
            int PontosPorRepeticao = GetPontosPorRepeticao(senha);
            //RETORNA PONTUAÇÃO POR SENHA DIGITADA:
            //       60ptos             10ptos                10ptos                 10ptos            10ptos          30ptos
            int resultado = PontosPorTamanho + PontosPorMinuscula + PontosPorMaiuscula + PontosPorDigito + PontosPorSimbolo - PontosPorRepeticao;
            return resultado;
        }

        //60 pontos //private int GetPontoPorTamanho(string senha)  
        private int GetPontoPorTamanho(string senha)
        {
            /*A função Mat.Min retorna o minino entre 2 valores. Neste caso
              retornará o tamanho do campo com no maximo de uma pontuaçao de 60 pontos(demonstrando a força pelo tamanho)    
            */
            return Math.Min(10, senha.Length) * 6;
        }

        //10 pontos //private int GetPontoPorMinusculas(string senha) 
        private int GetPontoPorMinuscula(string senha)
        {
            //contabiliza as letras minusculas digitadas
            int contabiliza = senha.Length - Regex.Replace(senha, "[a-z]", "").Length;
            //Totaliza um maximo de 10 pontos:
            return Math.Min(2, contabiliza) * 5;
        }

        //10 pontos //private int GetPontoPorMaiusculas(string senha) 
        private int GetPontoPorMaiuscula(string senha)
        {
            //a funcao "Regex.Replace().Lenght" efetua o replace e implicitamente faz o Lenght do campo 
            int contabiliza = senha.Length - Regex.Replace(senha, "[A-Z]", "").Length;
            return Math.Min(2, contabiliza) * 5;
        }

        private int GetPontosPorDigito(string senha)
        {
            //contabiliza digitos digitados
            int contabiliza = senha.Length - Regex.Replace(senha, "[0-9]", "").Length;
            return Math.Min(2, contabiliza) * 5;
        }

        private int GetPontosPorSimbolo(string senha)
        {
            //contabiliza simbolos digitados 
            int contabiliza = senha.Length - Regex.Replace(senha, "[a-zA-Z0-9]", "").Length; //implicitamento conto o resultado do replace
            return Math.Min(2, contabiliza) * 5;
        }

        private int GetPontosPorRepeticao(string senha)
        {
            //contabiliza repetições
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(\w)*.*\1");
            //Se houver alguma repetição registrado pelo metodo abaixo é retirado da pontuacao total no retorno da classe
            bool repete = regex.IsMatch(senha);
            if (repete)
            {
                return 30;
            }
            else
            {
                return 0;
            }
        }

        public ForcaSenha GetForcaSenha(string senha)
        {
            int placar = geraPontosSenha(senha);
            if (placar < 50)
            {
                return ForcaSenha.Inaceitavel;
            }
            else if (placar < 60)
            {
                return ForcaSenha.Fraca;
            }
            else if (placar < 80)
            {
                return ForcaSenha.Aceitavel;
            }
            else if (placar < 100)
            {
                return ForcaSenha.Forte;
            }
            else
            {
                return ForcaSenha.Segura;
            }

        }

    }

    public class Valicoes_num
    {
        /// <summary>
        ///Metodo da "Library1", namespace "Validacoes", Classe "Valicoes_num_inteiros", efetua as validações de moeda/data/numeral
        /// </summary>   
        
        //Usado para validação de moeda    
        public bool IsDouble(string Valor) 
        {
            double result;
            return double.TryParse(Valor, out result);
            //return int.TryParse(Valor, out result);
        }

        //Usado para validação de numeral
        public bool IsInt(string Valor)
        {
            int result;
            return int.TryParse(Valor, out result);
        }

        //Usado validação de data
        public bool IsDate(string Valor)
        {
            DateTime result;
            return DateTime.TryParse(Valor, out result);
        }
    }

}
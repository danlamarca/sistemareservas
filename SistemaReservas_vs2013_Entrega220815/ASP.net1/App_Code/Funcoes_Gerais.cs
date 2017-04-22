using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;

/// <summary>
/// Summary description for Funcoes_Gerais
/// </summary>
public class Funcoes_Gerais
{
	public Funcoes_Gerais()
	{
		
	}

    //Classe responsável por dar ordens ao compilador C#:(mais em baixo nivel)
    public Double ProcessarExpressoesMatematicas(string comando)
    {//Namespace using System.CodeDom.Compiler -- dá ordens o compilador, utilizando elementos sintáticos e comandos.

        double retorno = 0;

        //Cria um provedor de Código C#:
        CSharpCodeProvider CodeProvider = new CSharpCodeProvider();
        //Cria os parametros para a compilação da origem:
        CompilerParameters cp = new CompilerParameters();

        //setando o objeto
        cp.GenerateExecutable = false; //Não precisa criar um arquivo EXE
        cp.GenerateInMemory = true; //Cria um na memória
        cp.OutputAssembly = "TempModule"; // Isso não é necessário, no entanto, se usado repetidamente, faz com que o CLR não precisa carregar uma novo assembly cada vez que a função é executada.

        // A string abaixo é basicamente a casca do programa C #, que não faz nada, mas contém um método Avaliar() para o uso desta função:
        string TempModuleSource = "namespace ns{" +
                                      "using System;" +
                                      "class class1{" +
                                      "public static double Evaluate(){return " + comando + ";}}} ";  //Calcula a expressão

        //DANDO ORDENS AO COMPILADOR:
        CompilerResults cr = CodeProvider.CompileAssemblyFromSource(cp, TempModuleSource);
        if (cr.Errors.Count > 0)
        {
            throw new ArgumentException("A expressão não pode ser avaliada, utiliza uma expressão válida...");
        }
        else
        {
            MethodInfo Methinfo = cr.CompiledAssembly.GetType("ns.class1").GetMethod("Evaluate");
            retorno = (double)Methinfo.Invoke(null, null);
        }

        return retorno;
    }
}
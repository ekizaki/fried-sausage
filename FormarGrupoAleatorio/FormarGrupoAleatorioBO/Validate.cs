using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FormarGrupoAleatorioBO
{
    public class Validate
    {
        private static string _mensagemErroFormato;
        public static string MensagemErroFormato
        {
            get { return _mensagemErroFormato; }
        }
        private static string _mensagemErroString;
        public static string MensagemErroString
        {
            get { return _mensagemErroString; }
        }
        private static string _mensagemIncompatibilidadeAlunoGrupo;
        public static string MensagemIncompatibilidadeAlunoGrupo
        {
            get { return _mensagemIncompatibilidadeAlunoGrupo; }
        }

        /// <summary>
        /// Valida se o valor recebido é de um formato passível de ser convertido para o tipo "inteiro".
        /// </summary>
        /// <param name="entrada">Recebe o valor a ter o formato validado.</param>
        /// <returns>Retorna "true" para o caso de o valor recebido não ser passível de conversão para
        /// um dado do tipo "double", e retorna um valor "false" para o caso de ser possível.</returns>
        public static bool ValidarFormato(string entrada)
        {
            int valor;            
            try
            {
                valor = int.Parse(entrada);
            }
            catch (FormatException ex)
            {
                _mensagemErroFormato = string.Format("DIGITE UM FORMATO DE VALOR VÁLIDO. {0}", ex.Message);
                return true;
            }
            return false;                     
               
        }

        /// <summary>
        /// Valida se o valor recebido é apenas composto por caracteres alfabéticos.
        /// </summary>
        /// <param name="EntradaString">Recebe o valor a ter o seu conteúdo validado</param>
        /// <returns>Retorna "true" para o caso de o valor recebido não ser composto apenas de
        /// caracteres alfabéticos e "false" para o caso de ser.</returns>
        public static bool ValidarFormatoString(string EntradaString)
        {
            Regex regex = new Regex(@"[A-Za-z][a-z]+");
            Match comparador = regex.Match(EntradaString);

            if (comparador.Success==false)
            {
                _mensagemErroString = "DIGITE UM NOME VÁLIDO. APENAS CARACTERES ALFABÉTICOS (A-Z/a-z).";
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Valida se o número de alunos adicionados é maior do que a quantidade de grupos a serem formados.
        /// </summary>
        /// <param name="qntAluno">Recebe a quantidade de alunos adicionados.</param>
        /// <param name="qntGrupo">Recebe a quantidade de grupos a serem formados.</param>
        /// <returns>Retorna "true" para o caso de a quantidade de alunos ser menor do que a quantidade
        /// de grupos a serem formados e "false" para o contrário.</returns>
        public static bool ValidarCompatibilidadeAlunoGrupo(int qntAluno, int qntGrupo)
        {
            if (qntAluno < qntGrupo)
            {
                _mensagemIncompatibilidadeAlunoGrupo = ("O número de alunos adicionados em relação a quantidade" +
                    " de grupos não é compatível. Favor refazer o processo.");
                return true;
            }
            else
                return false;
        }
    }
}

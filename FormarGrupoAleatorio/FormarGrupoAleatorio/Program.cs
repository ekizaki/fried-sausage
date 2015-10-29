using System;
using System.Collections.Generic;
using FormarGrupoAleatorioBO;

namespace FormarGrupoAleatorio
{
    class Program
    {
        static void Main(string[] args)
        {
            int qntGrupo = 0;
            string entradaQntGrupo;
            string opcao = "";
            string entradaNomeAluno;


        NumeroGrupo:
            Console.WriteLine("GERADOR DE GRUPOS ALEATÓRIOS");
            Console.WriteLine("Digite a quantidade de grupos que deverão ser formados.");
            entradaQntGrupo = Console.ReadLine();
            if (Validate.ValidarFormato(entradaQntGrupo))
            {
                Console.WriteLine(Validate.MensagemErroFormato);
                Console.WriteLine("===============================================================================");
                goto NumeroGrupo;
            }
            qntGrupo = int.Parse(entradaQntGrupo);

        NomeAluno:
            Console.WriteLine("Digite o nome do(a) aluno(a) a ser inserido(a): ");
            entradaNomeAluno = Console.ReadLine();
            if (Validate.ValidarFormatoString(entradaNomeAluno))
            {
                Console.WriteLine(Validate.MensagemErroString);
                Console.WriteLine("===============================================================================");
                goto NomeAluno;
            }
            AlunoOperation.AdicionarAluno(new Aluno() { Nome = entradaNomeAluno });
            Console.WriteLine("Deseja adicionar mais algum(a) aluno(a)? <S/N>");
            opcao = Console.ReadLine().ToUpper();
            if (opcao == "S")
            {
                goto NomeAluno;
            }
            if (Validate.ValidarCompatibilidadeAlunoGrupo(AlunoOperation.RelacaoAluno.Count, qntGrupo))
            {
                Console.Write("O número de alunos adicionados em relação a quantidade" +
                    " de grupos não é compatível. Favor refazer o processo.");
                goto NumeroGrupo;
            }
            Console.Clear();
            Console.WriteLine("===============================================================================");
            Aluno[] alunosRandomizados = AlunoOperation.RandomizarAlunos();
            List<Aluno>[] lista = CriarInicializarLista(qntGrupo);
            DistribuirAlunos(qntGrupo, alunosRandomizados, lista);
            ExibirResultado(qntGrupo, lista);

            Console.WriteLine("===============================================================================");
            Console.ReadLine();
        }

        /// <summary>
        /// Criar e inicializa "List<Aluno>" com base no número de listas que devem ser criadas.
        /// </summary>
        /// <param name="qntGrupo">Recebe a quantidade de listas a serem criadas.</param>
        /// <returns></returns>
        private static List<Aluno>[] CriarInicializarLista(int qntGrupo)
        {
            List<Aluno>[] lista = new List<Aluno>[qntGrupo];
            for (int j = 0; j < qntGrupo; j++)
            {
                lista[j] = new List<Aluno>();
            }

            return lista;
        }

        /// <summary>
        /// Distribui os alunos contidos no array "Aluno[] alunosRandomizados" nas listas
        /// contidas no array de "List<Aluno> lista".
        /// </summary>
        /// <param name="qntGrupo">Recebe a quantidade de listas existentes.</param>
        /// <param name="alunosRandomizados">Recebe um array contendo os alunos randomizados pelo 
        /// método "AlunoOperation.RandomizarAlunos".</param>
        /// <param name="lista">Recebe o array de listas de alunos para distribuição dos alunos
        /// contidos em "alunosRandomizados".</param>
        private static void DistribuirAlunos(int qntGrupo, Aluno[] alunosRandomizados, List<Aluno>[] lista)
        {
            int count = 0;
            foreach (Aluno termo in alunosRandomizados)
            {
                lista[count].Add(termo);
                count++;
                if (count == qntGrupo)
                {
                    count = 0;
                }
            }
        }

        /// <summary>
        /// Exibe os alunos contidos em cada uma das listas de "List<Aluno>[] lista", classificando cada
        /// um como um grupo.
        /// </summary>
        /// <param name="qntGrupo">Recebe a quantidade de listas existentes.</param>
        /// <param name="lista">Recebe o array de listas de alunos, para exibir os alunos contidos
        /// em cada uma dessas listas.</param>
        private static void ExibirResultado(int qntGrupo, List<Aluno>[] lista)
        {
            for (int i = 0; i < qntGrupo; i++)
            {
                Console.WriteLine("\nGrupo {0}", i + 1);
                foreach (Aluno aluno in lista[i])
                {
                    Console.WriteLine(aluno.Nome);
                }
            }
        }
    }
}

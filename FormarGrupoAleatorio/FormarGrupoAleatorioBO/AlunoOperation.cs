using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormarGrupoAleatorioBO
{
    public static class AlunoOperation
    {
        public static List<Aluno> RelacaoAluno { get; set; }

        /// <summary>
        /// O construtor está instanciando um objeto do tipo List<Aluno>
        /// </summary>
        static AlunoOperation()
        {
            RelacaoAluno = new List<Aluno>();
        }

        /// <summary>
        /// Realiza a adição de um objeto "Aluno" à lista "List<Aluno>"
        /// </summary>
        /// <param name="aluno">Recebe o objeto do tipo "Aluno"</param>
        public static void AdicionarAluno(Aluno aluno)
        {
            RelacaoAluno.Add(aluno);
        }

        /// <summary>
        /// Realiza a "randomização" dos alunos inseridos pelo método "AdicionarAluno()".
        /// </summary>
        /// <returns>Retorna um array com os termos da lista de alunos "RelacaoAluno" randomizados. </returns>
        public static Aluno[] RandomizarAlunos()
        {
            int count=0;
            int verificador;
            Random rdm = new Random();
            Aluno[] AlunosNaoRepetidos = new Aluno[RelacaoAluno.Count];
            while (count < RelacaoAluno.Count)
            {
                verificador = rdm.Next(RelacaoAluno.Count);
                if (AlunosNaoRepetidos.Contains(RelacaoAluno[verificador]) == false)
                {
                    AlunosNaoRepetidos[count] = RelacaoAluno[verificador];
                    count++;
                }
            }
            return (AlunosNaoRepetidos);
        }
    }
}

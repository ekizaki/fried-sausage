using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1_Trainee.ManipulacaoString
{
    public class ManipulacaoString
    {
        public string Testar()//Possibilidade de colocar valores de acordo com os argumentos colocados
            //"{0} e {1}
        {
            string valor1 = "Programa";
            string valor2 = "Trainee";
            string frase = string.Format("O {0} {1}", valor1, valor2);

            return (frase);
        }
        public static string Testar2()
        {

            //<SPLIT>
            string frase = "O Programa Trainee 2015, é bom";
            //O Split realiza a divisão das palavras com sabe no caracter apontado no ('<caracter>')
            string[] palavras = frase.Split(' ');//Nesse caso divide as palavras tendo como base o 
            //<espaço vazio>

            //<JOIN>
            //Realiza a junção de vários termos de uma array de string, tendo a possibilidade de 
            //definir um separador para a junção
            string[] coisas = new string[4];
            coisas[0] = "O";
            coisas[1] = "Programa";
            coisas[2] = "Trainee";
            coisas[3] = "2015";
            coisas[4] = "bom";

            //Nessa situação o JOIN irá fazer a junção de todos os termos da array "coisas" e utilizar
            //como separador dos termos o caracter "," <vírgula> entre eles.
            string novaCoisa = String.Join(", ", coisas);

            //<REPLACE>
            //O Replace faz a troca do caracter inserido no primeiro <','> pelo caracter inserido no
            //segundo <' '>
            string FraseSemVirgula = frase.Replace(',', ' ');//Nesse caso o Replace substitui as <','>
            //vírgulas pelo <' '> espaço em branco.
            
            //<SUBSTRING>
            //De acordo com a posição do caracter, é possível apenas pegar o string apenas desta posição
            frase.Substring(28);//ou frase.Substring(frase.Length - 3).
            //O Substring acima tem a função de apenas pegar a palavra "bom" da frase "frase".
            //Sendo que existe a possibilidade de também declarar a posição do caracter inicial e 
            //quantas posições a frente dessa posição gostaria de pegar.

            //<INDEXOF>
            //Irá passar a posição <int> da primeira ocorrência do termo inserido como argumento.
            int index = frase.IndexOf ("programa");//Nesse caso irá retornar o valor da posição em que
            //o argumento "programa" foi encontrado.

            //<IsNullOrEmpty>
            string palavra = "";
            //Nesse caso ela retorna um dado do tipo bool se a variável "palavra" estiver nula ou vazia.
            if (string.IsNullOrEmpty(palavra))
            {

            }

            //<PADLEFT/PADRIGHT>
            //Realiza a inserção de um caracter pré definido, em uma quantidade pré definida, em uma
            //string, preenchendo os campos que eventualmente estiverem faltando para completar a 
            //quantidade pré definida.
            string digito = "123";
            string resultado = digito.PadLeft(5, '0');//exibição <00000123> 8 caracteres
            string resultado2 = digito.PadRight(5, '0');//exibição <12300000>
            //Se eventualmente o valor de "digito" fosse "12345", o PADLEFT/PAFRIGHT iria exibir 
            //o seguinte valor <00012345> ou <12345000>

            //<TRIM>
            //Retira os espaços iniciais e finais de uma string, sendo que para uma situação em que 
            //o usuário digite o valor "123  " - com dois espaços, ao utilizar o TRIM, o valor string
            //passado será "123", sem os espaços.

            //<TOSTRING>
            //Faz a transformação de um objeto de qualquer tipo de dados em uma string.
            int i = 24;
            i.ToString();//o valor <int> de "i" passou a ser uma string.
                        
            return index.ToString();            
        }
    }
}

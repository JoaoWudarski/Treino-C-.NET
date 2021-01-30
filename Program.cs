using System;

namespace revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int i = 0;
            String option;
            do 
            {
                Console.WriteLine("Informe a opção desejada:");
                Console.WriteLine("[1] Inserir novo aluno");
                Console.WriteLine("[2] Listar alunos");
                Console.WriteLine("[3] Calcular média geral");
                Console.WriteLine("[X] Sair\n");
                
                option = Console.ReadLine().ToUpper();

            
                switch(option)
                {
                    case "1":
                        Console.WriteLine("Qual o nome do Aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.nome = Console.ReadLine();
                        
                        Console.WriteLine("Informe a nota do aluno:");

                        if(decimal.TryParse(Console.ReadLine(), out decimal nota))
                            aluno.nota = nota;
                        else
                            throw new ArgumentException("Nota inválida! Numero decimal esperado");
                        
                        alunos[i] = aluno;
                        i++;
                        
                        break;
                    case "2":
                    
                    foreach(Aluno al in alunos)
                    {
                        if(al.nome != null)
                            Console.WriteLine($"Aluno {al.nome} tirou {al.nota}");
                        
                    }                        

                        break;
                    case "3":
                        ConceitoEnum cg;
                        decimal media = gerarMedia(alunos);
                        
                        if(media >= 0 && media < 3)
                            cg = ConceitoEnum.E;
                        else if(media >=3 && media < 5)
                            cg = ConceitoEnum.D;
                        else if(media >= 5 && media < 7)
                            cg = ConceitoEnum.C;
                        else if(media >= 7 && media < 9)
                            cg = ConceitoEnum.B;
                        else
                            cg = ConceitoEnum.A;

                        Console.WriteLine($"A media da nota dos alunos é {media}, conceito {cg}");                 

                        break;
                    case "X":
                        break;        
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            } while(option != "X");

        }

        private static decimal gerarMedia(Aluno[] alunos)
        {
            decimal soma = 0;
            int alns = 0;
            foreach(Aluno aluno in alunos)
            {
                if(aluno.nome != null)
                {
                    soma += aluno.nota;
                    alns++;
                }
            }

            return soma/alns;
        }
 
    }
}

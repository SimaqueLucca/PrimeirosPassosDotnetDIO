using System;

namespace PrimeirosPassosDotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];

            int IndiceAluno = 0;

            string opcaoEscolhida = ObterOpcaoUsuario();

            while (opcaoEscolhida != "4")
            {
                switch (opcaoEscolhida)
                {
                    case "1":
                        System.Console.Write("Informe o nome do aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        System.Console.Write("Informe a nota: ");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }

                        alunos[IndiceAluno] = aluno;
                        IndiceAluno++;

                        break;

                    case "2":
                        foreach (var item in alunos)
                        {
                            if (item.Nome is not null) //!string.IsNullOrEmpty(item.Nome)
                            {
                                System.Console.WriteLine($"Aluno: {item.Nome} - Nota: {item.Nota}");
                            }
                        };
                        break;
                    case "3":

                        decimal notaTotal = 0;
                        int nrAlunos = 0;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (alunos[i].Nome is not null)
                            {
                                notaTotal += alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        decimal mediaGeral = notaTotal / nrAlunos;
                        ConceitoEnum conceitoGeral;

                        if (mediaGeral <= 2)
                        {
                            conceitoGeral = ConceitoEnum.E;
                        }
                        else if (mediaGeral <= 4)
                        {
                            conceitoGeral = ConceitoEnum.D;
                        }
                        else if (mediaGeral <= 6)
                        {
                            conceitoGeral = ConceitoEnum.C;
                        }
                        else if (mediaGeral <= 8)
                        {
                            conceitoGeral = ConceitoEnum.B;
                        }
                        else
                        {
                            conceitoGeral = ConceitoEnum.A;
                        }

                        System.Console.WriteLine($"Média geral: {mediaGeral} - Conceito: {conceitoGeral}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoEscolhida = ObterOpcaoUsuario();
            }

        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Informe a opção desejada: ");
            System.Console.WriteLine("1- Inserir novo aluno");
            System.Console.WriteLine("2- Listar alunos");
            System.Console.WriteLine("3- Calcular média geral");
            System.Console.WriteLine("4- Sair");
            System.Console.WriteLine();

            string opcaoEscolhida = Console.ReadLine();
            System.Console.WriteLine();
            return opcaoEscolhida;
        }
    }
}

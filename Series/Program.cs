using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Series.Classes;


namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {

            string opcaoUsuario = Menu();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine();
                        ListarSeries();
                        break;
                    case "2":
                        Console.WriteLine();
                        InserirSerie();
                        break;

                    case "3":
                        Console.WriteLine();
                        AtualizarSerie();
                        break;

                    case "4":
                        Console.WriteLine();
                        ExcluirSerie();                   
                        break;

                    case "5":
                        Console.WriteLine();
                        VisualizarSerie();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = Menu();
            }   
            
        }

        private static void ListarSeries()
        {
            
            Console.WriteLine("Listar séries");
            Console.WriteLine();

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Nenhuma série cadastrada.");
                Console.WriteLine();
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                if(!excluido)
                {
                    Console.WriteLine("#ID {0}:  {1}", serie.RetornaId(), serie.RetornaTitulo());
                }

                
            }
                

        }

        private static void InserirSerie()
        {
            Console.WriteLine();
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                
            }
            Console.WriteLine();
            Console.Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();


            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            repositorio.Insere(novaSerie);

                
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine();
            Console.Write("Digite o id da série:");
            int indiceSerie = int.Parse(Console.ReadLine());

            
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine();
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));

            }

            Console.WriteLine();
            Console.Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();


            Serie atualizaSerie = new Serie(id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);

        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }





        private static string Menu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Programa de Séries");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            Console.WriteLine();


            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}

using Locadora.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Leitura
    {
        public static IList()
        {
            var path = @"/PROJETOS/MinhaLocadora/Reader/Filmes.csv";
            var reader = new StreamReader(File.OpenRead(path));
            var line = reader.ReadLine();
            var coluns = line.Split(";");
            (dynamic indexId, dynamic indexTitulo, dynamic indexClassificacaoIndicativa, dynamic indexLancamento) = SetColunsIndex(coluns);
            var movies = BuildMovieList(reader, indexId, indexTitulo, indexClassificacaoIndicativa, indexLancamento);

            foreach (var movie in movies)
            {
                return($"ID: {movie.Id}, Titulo: {movie.Titulo}, Indicação: {movie.ClassificacaoIndicativa}, Lançamento: {movie.Lancamento} ");

            }
            return movies;
        }



        private static (int, int, int, int) SetColunsIndex(string[] coluns)
        {
            int indexId = -1;
            int indexTitulo = -1;
            int indexClassificacaoIndicativa = -1;
            int indexLancamento = -1;

            for (int i = 0; i < coluns.Length; i++)
            {
                if (string.IsNullOrEmpty(coluns[i]))
                    continue;

                if (coluns[i].ToLower() == "id")
                {
                    indexId = i;
                }

                if (coluns[i].ToLower() == "titulo")
                {
                    indexTitulo = i;
                }

                if (coluns[i].ToLower() == "classificacaoindicativa")
                {
                    indexClassificacaoIndicativa = i;
                }

                if (coluns[i].ToLower() == "lancamento")
                {
                    indexLancamento = i;
                }

            }
            return (indexId, indexTitulo, indexClassificacaoIndicativa, indexLancamento);
        }

        private static List<CreateFilmeViewModel> BuildMovieList(StreamReader reader, int indexId, int indexTitulo, int indexClassificacaoIndicativa, int indexLancamento)
        {
            Console.WriteLine("Montando lista de Filmes");
            string line;
            var movies = new List<CreateFilmeViewModel>();
            CreateFilmeViewModel readerModel;
            while ((line = reader.ReadLine()) != null)
            {
                var values = line.Split(';');
                readerModel = new CreateFilmeViewModel();

                if (indexId != -1)
                {
                    dynamic v = values[indexId];
                    readerModel.Id = v;
                }

                if (indexTitulo != -1)
                {
                    dynamic v = values[indexTitulo];
                    readerModel.Titulo = v;
                }

                if (indexClassificacaoIndicativa != -1)
                {
                    dynamic v = values[indexClassificacaoIndicativa];
                    readerModel.ClassificacaoIndicativa = v;
                }

                if (indexLancamento != -1)
                {
                    dynamic v = values[indexLancamento];
                    readerModel.Lancamento = v;
                }

                movies.Add(readerModel);
            }
            return (movies);
        }
    }



}

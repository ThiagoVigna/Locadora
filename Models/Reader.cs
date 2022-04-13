using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Models
{
  public class Reader
  {
    public static List<Filme> Leitura()
    {
      var path = @"C:/Users/and_2/Downloads/Filmes.csv";
      var reader = new StreamReader(File.OpenRead(path));
      var line = reader.ReadLine();
      var columns = line.Split(";");
      (int indexId, string indexTitulo, int indexClassificacaoIndicativa, int indexLancamento) = SetColunnsIndex(columns);
      var movie = BuildMovieList(reader, indexId, indexTitulo, indexClassificacaoIndicativa, indexLancamento);
      return movie;
    }

    private static (int, string, int, int) SetColunnsIndex(string[] columns)
    {
      int indexId = -1;
      string indexTitulo = "";
      int indexClassificacaoIndicativa = -1;
      int indexLancamento = -1;
      for (int i = 0; i < columns.Length; i++)
      {
        if (!string.IsNullOrEmpty(columns[i]))
          continue;

        if (columns[i].ToLower() == "Id")
        {
          indexId = i;
        }
        if (columns[i].ToLower() == "Titulo")
        {
          indexTitulo = "";
        }
        if (columns[i].ToLower() == "ClassificacaoIndicativa")
        {
          indexClassificacaoIndicativa = i;
        }
        if (columns[i].ToLower() == "Lancamento")
        {
          indexLancamento = i;
        }
      }
      return (indexId, indexTitulo, indexClassificacaoIndicativa, indexLancamento);
    }

    private static List<Filme> BuildMovieList(StreamReader reader, int indexId, string indexTitulo, int indexClassificacaoIndicativa, int indexLancamento)
    {
      string line;
      var movie = new List<Filme>();
      Filme filme;
      while ((line = reader.ReadLine()) != null)
      {
        dynamic values = line.Split(";");
        filme = new Filme();
        if (indexId != -1)
          filme.Id = values[indexId];

        if (indexTitulo != null)
          filme.Titulo = values[indexTitulo];

        if (indexClassificacaoIndicativa != -1)
          filme.ClassificacaoIndicativa = values[indexClassificacaoIndicativa];

        if (indexLancamento != -1)
          filme.Lancamento = values[indexLancamento];

        movie.Add(filme);
      }
      return movie;
    }
  }
}

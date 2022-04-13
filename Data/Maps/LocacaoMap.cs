using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Data.Maps
{
  public class LocacaoMap : IEntityTypeConfiguration<Locacao>
  {
    public void Configure(EntityTypeBuilder<Locacao> builder)
    {
      builder.HasKey(t => t.Id);

      builder.Property(t => t.Id_Cliente)
        .IsRequired();

      builder.Property(t => t.Id_Filme)
        .IsRequired();

      builder.Property(t => t.DataLocacao)
        .IsRequired();

      builder.Property(t => t.DataDevolucao)
        .IsRequired();

      builder.ToTable("Locacao");
    }
  }
}

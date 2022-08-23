using Entra21.CSharp.ClinicaVeterinaria.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entra21.CSharp.ClinicaVeterinaria.Repositorio.Mapeamentos
{
    //DB First : Criar uma aplicação onde o bandco de dados já existe
    //Code First: Criar um banco de dados apartir de uma aplicação existente
    //Seed: Alimentar o banco de dados com registros
    //Migration: Representação do mapeamento que será aplicado no banco de dados
    //Mapeamento: Representação da entodade em tabelas, colunas, indices...
    internal class RacaMapeamentos : IEntityTypeConfiguration<Raca>
    {
        public void Configure(EntityTypeBuilder<Raca> builder)
        {
            builder.ToTable("racas");

            builder.HasKey(x => x.Id).HasName("id");

            builder.Property(x => x.Especie)
                .HasColumnName("VARCHAR")
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("especie"); //NOT NULL

            builder.Property(x => x.Nome)
                .HasColumnName("VARCHAR")
                .HasMaxLength(30)
                .IsRequired()
                .HasColumnName("nome");

            builder.HasData(new Raca
            {
                Id = 1,
                Nome = "Frajola",
                Especie = "Gato"
            },
             new Raca
             {
                 Id=2,
                 Nome = "Piupiu",
                 Especie = "Capivara"
             });
        }
    }
}

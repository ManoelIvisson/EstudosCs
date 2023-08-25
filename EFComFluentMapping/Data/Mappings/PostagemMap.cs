using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings {
    public class PostagemMap : IEntityTypeConfiguration<Postagem> {
        public void Configure(EntityTypeBuilder<Postagem> builder) {
            builder.ToTable("Postagem");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.Titulo);
            builder.Property(x => x.Resumo);
            builder.Property(x => x.Corpo);
            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);
            
            builder.Property(x => x.DataCriacao)
                .IsRequired()
                .HasColumnName("DataCriacao")
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValueSql("GETDATE()");
                // .HasDefaultValue(DateTime.Now.ToUniversalTime());
            
            builder.Property(x => x.DataUltimaAtualizacao)
                .IsRequired()
                .HasColumnName("DataUltimaAtualizacao")
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(x => x.Autor)
                .WithMany(x => x.Postagens)
                .HasConstraintName("FK_Postagem_Autor")
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(x => x.Categoria)
                .WithMany(x => x.Postagens)
                .HasConstraintName("FK_Postagem_Categoria")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Tags)
                .WithMany(x => x.Postagens)
                .UsingEntity<Dictionary<string, object>>(
                    "PostagemTag",
                    postagem => postagem.HasOne<Tag>()
                        .WithMany()
                        .HasForeignKey("PostagemId")
                        .HasConstraintName("FK_PostagemTag_PostagemId")
                        .OnDelete(DeleteBehavior.Cascade),
                    tag => tag.HasOne<Postagem>()
                        .WithMany()
                        .HasForeignKey("TagId")
                        .HasConstraintName("FK_PostagemTag_TagId")
                        .OnDelete(DeleteBehavior.Cascade));
        }
    }
}
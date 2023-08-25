using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings {
    public class UsuarioMap : IEntityTypeConfiguration<Usuario> {
        public void Configure(EntityTypeBuilder<Usuario> builder) {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Email);
            builder.Property(x => x.SenhaHash);
            builder.Property(x => x.Bio);
            builder.Property(x => x.Imagem);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);
            
            builder.HasIndex(x => x.Email, "IX_Usuario_Email").IsUnique();
            builder.HasIndex(x => x.Slug, "IX_Usuario_Slug").IsUnique();

            builder.HasMany(x => x.Perfis)
                .WithMany(x => x.Usuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioPerfil",
                    usuario => usuario.HasOne<Perfil>()
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK_UsuarioPerfil_UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade),
                    perfil => perfil.HasOne<Usuario>()
                        .WithMany()
                        .HasForeignKey("PerfilId")
                        .HasConstraintName("FK_UsuarioPerfil_PerfilId"));
        }
    }
}
﻿// <auto-generated />
using LoginApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LoginApi.Migrations
{
    [DbContext(typeof(ApplicatioDbContext))]
    [Migration("20230523195727_animesfavoritos")]
    partial class animesfavoritos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LoginApi.Models.AnimesFavoritos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdAnime")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("AnimesFavoritos");
                });

            modelBuilder.Entity("LoginApi.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApellidoMaterno")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("ApellidoPaterno")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("LoginApi.Models.AnimesFavoritos", b =>
                {
                    b.HasOne("LoginApi.Models.Usuario", "Usuario")
                        .WithMany("AnimesFavoritos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LoginApi.Models.Usuario", b =>
                {
                    b.Navigation("AnimesFavoritos");
                });
#pragma warning restore 612, 618
        }
    }
}

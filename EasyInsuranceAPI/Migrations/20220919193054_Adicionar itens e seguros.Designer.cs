﻿// <auto-generated />
using System;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EasyInsuranceAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220919193054_Adicionar itens e seguros")]
    partial class Adicionaritenseseguros
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataAquisicaoItem")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("ValorEstimado")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Itens");
                });

            modelBuilder.Entity("Domain.Entities.Perfil", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TipoPerfil")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioAtualizou")
                        .HasColumnType("longtext");

                    b.Property<string>("UsuarioCriou")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Perfis");
                });

            modelBuilder.Entity("Domain.Entities.PerfilUsuario", b =>
                {
                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PerfilId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UsuarioAtualizou")
                        .HasColumnType("longtext");

                    b.Property<string>("UsuarioCriou")
                        .HasColumnType("longtext");

                    b.HasKey("UsuarioId", "PerfilId");

                    b.HasIndex("PerfilId");

                    b.ToTable("PerfisUsuarios");
                });

            modelBuilder.Entity("Domain.Entities.Seguro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("QuantidadeParcelas")
                        .HasColumnType("decimal(65,30)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("ValorParcela")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Seguros");
                });

            modelBuilder.Entity("Domain.Entities.TokenUsuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ExpiraEm")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TokensUsuarios");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Foto")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UsuarioAtualizou")
                        .HasColumnType("longtext");

                    b.Property<string>("UsuarioCriou")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Domain.Entities.Item", b =>
                {
                    b.HasOne("Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.PerfilUsuario", b =>
                {
                    b.HasOne("Domain.Entities.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Usuario", "Usuario")
                        .WithMany("PerfisUsuarios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.Seguro", b =>
                {
                    b.HasOne("Domain.Entities.Item", "Item")
                        .WithMany("Seguros")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.TokenUsuario", b =>
                {
                    b.HasOne("Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.Item", b =>
                {
                    b.Navigation("Seguros");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Navigation("PerfisUsuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
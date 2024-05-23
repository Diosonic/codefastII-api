﻿// <auto-generated />
using System;
using Codefast.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Codefast.Migrations
{
    [DbContext(typeof(CodefastContext))]
    partial class CodefastContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Codefast.Models.ControleEliminatoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EquipeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Pontuacao")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StatusValidacao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Tempo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EquipeId")
                        .IsUnique();

                    b.ToTable("ControleEliminatorias");
                });

            modelBuilder.Entity("Codefast.Models.ControleMataMata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DisputaTerceiroLugar")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EquipeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StatusValidacao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EquipeId")
                        .IsUnique();

                    b.ToTable("ControleMataMatas");
                });

            modelBuilder.Entity("Codefast.Models.Equipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCredenciado")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDesclassificado")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeParticipantes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TorneioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TorneioId");

                    b.ToTable("Equipes");
                });

            modelBuilder.Entity("Codefast.Models.Rodada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TorneioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TorneioId");

                    b.ToTable("Rodadas");
                });

            modelBuilder.Entity("Codefast.Models.SementeRodada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("RodadaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RodadaId");

                    b.ToTable("SementeRodadas");
                });

            modelBuilder.Entity("Codefast.Models.Torneio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("Tempo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("isTempoCorrendo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Torneios");
                });

            modelBuilder.Entity("EquipeSementeRodada", b =>
                {
                    b.Property<int>("EquipesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SementeRodadasId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EquipesId", "SementeRodadasId");

                    b.HasIndex("SementeRodadasId");

                    b.ToTable("EquipeSementeRodada");
                });

            modelBuilder.Entity("Codefast.Models.ControleEliminatoria", b =>
                {
                    b.HasOne("Codefast.Models.Equipe", "Equipe")
                        .WithOne("ControleEliminatoria")
                        .HasForeignKey("Codefast.Models.ControleEliminatoria", "EquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipe");
                });

            modelBuilder.Entity("Codefast.Models.ControleMataMata", b =>
                {
                    b.HasOne("Codefast.Models.Equipe", "Equipe")
                        .WithOne("ControleMataMata")
                        .HasForeignKey("Codefast.Models.ControleMataMata", "EquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipe");
                });

            modelBuilder.Entity("Codefast.Models.Equipe", b =>
                {
                    b.HasOne("Codefast.Models.Torneio", "Torneio")
                        .WithMany("Equipes")
                        .HasForeignKey("TorneioId");

                    b.Navigation("Torneio");
                });

            modelBuilder.Entity("Codefast.Models.Rodada", b =>
                {
                    b.HasOne("Codefast.Models.Torneio", "Torneio")
                        .WithMany()
                        .HasForeignKey("TorneioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Torneio");
                });

            modelBuilder.Entity("Codefast.Models.SementeRodada", b =>
                {
                    b.HasOne("Codefast.Models.Rodada", "Rodada")
                        .WithMany("SementeRodadas")
                        .HasForeignKey("RodadaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rodada");
                });

            modelBuilder.Entity("EquipeSementeRodada", b =>
                {
                    b.HasOne("Codefast.Models.Equipe", null)
                        .WithMany()
                        .HasForeignKey("EquipesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Codefast.Models.SementeRodada", null)
                        .WithMany()
                        .HasForeignKey("SementeRodadasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Codefast.Models.Equipe", b =>
                {
                    b.Navigation("ControleEliminatoria");

                    b.Navigation("ControleMataMata");
                });

            modelBuilder.Entity("Codefast.Models.Rodada", b =>
                {
                    b.Navigation("SementeRodadas");
                });

            modelBuilder.Entity("Codefast.Models.Torneio", b =>
                {
                    b.Navigation("Equipes");
                });
#pragma warning restore 612, 618
        }
    }
}

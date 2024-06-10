﻿// <auto-generated />
using System;
using CampMultigames.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CampMultigames.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240610170805_foto")]
    partial class foto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.20");

            modelBuilder.Entity("CampMultigames.Domain.Models.Confronto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Data")
                        .HasColumnType("TEXT");

                    b.Property<int>("JogoTabelaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PontosCasa")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PontosFora")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TimeCasaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TimeForaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("JogoTabelaId");

                    b.HasIndex("TimeForaId");

                    b.HasIndex("TimeCasaId", "TimeForaId", "JogoTabelaId")
                        .IsUnique();

                    b.ToTable("Confrontos");
                });

            modelBuilder.Entity("CampMultigames.Domain.Models.JogoBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Jogos");

                    b.HasDiscriminator<string>("Discriminator").HasValue("JogoBase");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CampMultigames.Domain.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TimeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TimeId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("CampMultigames.Domain.Models.TabelaGeral", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Derrotas")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Jogos")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Pontos")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TimeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Vitorias")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TimeId");

                    b.ToTable("TabelasGerais");
                });

            modelBuilder.Entity("CampMultigames.Domain.Models.TabelaPorJogoTabela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Derrotas")
                        .HasColumnType("INTEGER");

                    b.Property<int>("JogoTabelaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Jogos")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Pontos")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TimeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Vitorias")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("JogoTabelaId");

                    b.HasIndex("TimeId");

                    b.ToTable("TabelasPorJogoTabela");
                });

            modelBuilder.Entity("CampMultigames.Domain.Models.Time", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Times");
                });

            modelBuilder.Entity("CampMultigames.Domain.Models.JogoTabela", b =>
                {
                    b.HasBaseType("CampMultigames.Domain.Models.JogoBase");

                    b.Property<int>("pontosPorGame")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("JogoTabela");
                });

            modelBuilder.Entity("CampMultigames.Domain.Models.Confronto", b =>
                {
                    b.HasOne("CampMultigames.Domain.Models.JogoTabela", "JogoTabela")
                        .WithMany()
                        .HasForeignKey("JogoTabelaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampMultigames.Domain.Models.Time", "TimeCasa")
                        .WithMany()
                        .HasForeignKey("TimeCasaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampMultigames.Domain.Models.Time", "TimeFora")
                        .WithMany()
                        .HasForeignKey("TimeForaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JogoTabela");

                    b.Navigation("TimeCasa");

                    b.Navigation("TimeFora");
                });

            modelBuilder.Entity("CampMultigames.Domain.Models.Player", b =>
                {
                    b.HasOne("CampMultigames.Domain.Models.Time", "Time")
                        .WithMany("Players")
                        .HasForeignKey("TimeId");

                    b.Navigation("Time");
                });

            modelBuilder.Entity("CampMultigames.Domain.Models.TabelaGeral", b =>
                {
                    b.HasOne("CampMultigames.Domain.Models.Time", "Time")
                        .WithMany()
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Time");
                });

            modelBuilder.Entity("CampMultigames.Domain.Models.TabelaPorJogoTabela", b =>
                {
                    b.HasOne("CampMultigames.Domain.Models.JogoTabela", "JogoTabela")
                        .WithMany()
                        .HasForeignKey("JogoTabelaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampMultigames.Domain.Models.Time", "Time")
                        .WithMany()
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JogoTabela");

                    b.Navigation("Time");
                });

            modelBuilder.Entity("CampMultigames.Domain.Models.Time", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}

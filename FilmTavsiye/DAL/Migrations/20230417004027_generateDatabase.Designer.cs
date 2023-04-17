﻿// <auto-generated />
using System.Collections.Generic;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230417004027_generateDatabase")]
    partial class generateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CORE.Movie", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<bool>("adult")
                        .HasColumnType("boolean");

                    b.Property<string>("backdrop_path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<int>>("genre_ids")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<string>("original_language")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("original_title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("overview")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("popularity")
                        .HasColumnType("double precision");

                    b.Property<string>("poster_path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("release_date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("video")
                        .HasColumnType("boolean");

                    b.Property<double>("vote_average")
                        .HasColumnType("double precision");

                    b.Property<int>("vote_count")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}

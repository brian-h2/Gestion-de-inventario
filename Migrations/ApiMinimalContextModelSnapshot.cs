﻿// <auto-generated />
using System;
using ApiMinimal.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiMinimal.Migrations
{
    [DbContext(typeof(ApiMinimalContext))]
    partial class ApiMinimalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiMinimal.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Wheight")
                        .HasColumnType("int");

                    b.HasKey("CategoryID");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryID = new Guid("f4dd7e80-b991-4992-8207-fdf90ac21b8b"),
                            Name = "Limpieza",
                            Wheight = 20
                        },
                        new
                        {
                            CategoryID = new Guid("f4dd7e80-b991-4992-8207-fdf90ac21b02"),
                            Name = "Trabajo",
                            Wheight = 40
                        });
                });

            modelBuilder.Entity("ApiMinimal.Models.Tasks", b =>
                {
                    b.Property<Guid>("IdTask")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("DurationTask")
                        .HasColumnType("int");

                    b.Property<int>("PriorityTask")
                        .HasColumnType("int");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IdTask");

                    b.HasIndex("CategoryID");

                    b.ToTable("Tareas", (string)null);

                    b.HasData(
                        new
                        {
                            IdTask = new Guid("f5601b55-2076-4b30-91d0-ecbb6648d0af"),
                            CategoryID = new Guid("f4dd7e80-b991-4992-8207-fdf90ac21b8b"),
                            DateCreation = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DurationTask = 0,
                            PriorityTask = 0,
                            TaskName = "Limpiar la casa"
                        },
                        new
                        {
                            IdTask = new Guid("f5601b55-2076-4b30-91d0-ecbb6648d099"),
                            CategoryID = new Guid("f4dd7e80-b991-4992-8207-fdf90ac21b02"),
                            DateCreation = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DurationTask = 0,
                            PriorityTask = 2,
                            TaskName = "Arreglar bug en azure"
                        });
                });

            modelBuilder.Entity("ApiMinimal.Models.Tasks", b =>
                {
                    b.HasOne("ApiMinimal.Models.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ApiMinimal.Models.Category", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}

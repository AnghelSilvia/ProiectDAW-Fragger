// <auto-generated />
using System;
using Fragger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fragger.Migrations
{
    [DbContext(typeof(FraggerContext))]
    [Migration("20220605202529_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.16");

            modelBuilder.Entity("Fragger.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EstablishDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Fragger.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrandRef")
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .HasColumnType("TEXT");

                    b.Property<string>("phone")
                        .HasColumnType("TEXT");

                    b.HasKey("ContactId");

                    b.HasIndex("BrandRef")
                        .IsUnique();

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Fragger.Models.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("NoteId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Fragger.Models.Perfume", b =>
                {
                    b.Property<int>("PerfumeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BrandId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.HasKey("PerfumeId");

                    b.HasIndex("BrandId");

                    b.ToTable("Perfumes");
                });

            modelBuilder.Entity("Fragger.Models.PerfumeNote", b =>
                {
                    b.Property<int>("PerfumeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NoteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PerfumeId", "NoteId");

                    b.HasIndex("NoteId");

                    b.ToTable("PerfumeNotes");
                });

            modelBuilder.Entity("Fragger.Models.Contact", b =>
                {
                    b.HasOne("Fragger.Models.Brand", "Brand")
                        .WithOne("Contact")
                        .HasForeignKey("Fragger.Models.Contact", "BrandRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Fragger.Models.Perfume", b =>
                {
                    b.HasOne("Fragger.Models.Brand", "Brand")
                        .WithMany("Perfumes")
                        .HasForeignKey("BrandId");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Fragger.Models.PerfumeNote", b =>
                {
                    b.HasOne("Fragger.Models.Note", "Note")
                        .WithMany("PerfumeNotes")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fragger.Models.Perfume", "Perfume")
                        .WithMany("PerfumeNotes")
                        .HasForeignKey("PerfumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Note");

                    b.Navigation("Perfume");
                });

            modelBuilder.Entity("Fragger.Models.Brand", b =>
                {
                    b.Navigation("Contact");

                    b.Navigation("Perfumes");
                });

            modelBuilder.Entity("Fragger.Models.Note", b =>
                {
                    b.Navigation("PerfumeNotes");
                });

            modelBuilder.Entity("Fragger.Models.Perfume", b =>
                {
                    b.Navigation("PerfumeNotes");
                });
#pragma warning restore 612, 618
        }
    }
}

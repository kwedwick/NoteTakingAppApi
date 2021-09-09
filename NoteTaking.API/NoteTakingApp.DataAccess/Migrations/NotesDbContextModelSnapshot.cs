﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoteTakingApp.DataAccess.Entities;

namespace NoteTakingApp.DataAccess.Migrations
{
    [DbContext(typeof(NotesDbContext))]
    partial class NotesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("NoteTakingApp.DataAccess.Entities.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("NoteTakingApp.DataAccess.Entities.NoteTag", b =>
                {
                    b.Property<int>("NoteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("NoteId", "Name")
                        .HasName("PK__NoteTags__8DF96D108293576C");

                    b.HasIndex("Name");

                    b.ToTable("NoteTags");
                });

            modelBuilder.Entity("NoteTakingApp.DataAccess.Entities.Tag", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Name")
                        .HasName("PK__Tags__737584F72B9DE1A0");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("NoteTakingApp.DataAccess.Entities.NoteTag", b =>
                {
                    b.HasOne("NoteTakingApp.DataAccess.Entities.Tag", "NameNavigation")
                        .WithMany("NoteTags")
                        .HasForeignKey("Name")
                        .HasConstraintName("FK__NoteTags__Name__60A75C0F")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NoteTakingApp.DataAccess.Entities.Note", "Note")
                        .WithMany("NoteTags")
                        .HasForeignKey("NoteId")
                        .HasConstraintName("FK__NoteTags__NoteId__5FB337D6")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NameNavigation");

                    b.Navigation("Note");
                });

            modelBuilder.Entity("NoteTakingApp.DataAccess.Entities.Note", b =>
                {
                    b.Navigation("NoteTags");
                });

            modelBuilder.Entity("NoteTakingApp.DataAccess.Entities.Tag", b =>
                {
                    b.Navigation("NoteTags");
                });
#pragma warning restore 612, 618
        }
    }
}

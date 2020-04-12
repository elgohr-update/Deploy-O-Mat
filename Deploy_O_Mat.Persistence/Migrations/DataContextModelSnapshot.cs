﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using com.b_velop.Deploy_O_Mat.Data.Context;

namespace com.b_velop.Deploy_O_Mat.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("com.b_velop.Deploy_O_Mat.Domain.Models.Badge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("DockerImageId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DockerImageId");

                    b.ToTable("Badge");
                });

            modelBuilder.Entity("com.b_velop.Deploy_O_Mat.Domain.Models.DockerImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BuildId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Dockerfile")
                        .HasColumnType("text");

                    b.Property<string>("FullDescription")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsOfficial")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Namespace")
                        .HasColumnType("text");

                    b.Property<string>("Owner")
                        .HasColumnType("text");

                    b.Property<string>("Pusher")
                        .HasColumnType("text");

                    b.Property<string>("RepoName")
                        .HasColumnType("text");

                    b.Property<string>("RepoUrl")
                        .HasColumnType("text");

                    b.Property<int>("Stars")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("Tag")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("DockerImages");
                });

            modelBuilder.Entity("com.b_velop.Deploy_O_Mat.Domain.Models.DockerStackService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("DockerImageId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("MachineName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("DockerImageId");

                    b.ToTable("DockerStackServices");
                });

            modelBuilder.Entity("com.b_velop.Deploy_O_Mat.Domain.Models.RequestLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Body")
                        .HasColumnType("text");

                    b.Property<string>("ContentType")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("Duration")
                        .HasColumnType("bigint");

                    b.Property<string>("Header")
                        .HasColumnType("text");

                    b.Property<bool>("IsHttps")
                        .HasColumnType("boolean");

                    b.Property<string>("Method")
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.Property<string>("PathBase")
                        .HasColumnType("text");

                    b.Property<string>("Protocol")
                        .HasColumnType("text");

                    b.Property<string>("Query")
                        .HasColumnType("text");

                    b.Property<string>("RemoteIp")
                        .HasColumnType("text");

                    b.Property<int>("RemotePort")
                        .HasColumnType("integer");

                    b.Property<int>("ResponseStatusCode")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Created");

                    b.ToTable("RequestLogs");
                });

            modelBuilder.Entity("com.b_velop.Deploy_O_Mat.Domain.Models.Badge", b =>
                {
                    b.HasOne("com.b_velop.Deploy_O_Mat.Domain.Models.DockerImage", "DockerImage")
                        .WithMany("Badges")
                        .HasForeignKey("DockerImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("com.b_velop.Deploy_O_Mat.Domain.Models.DockerStackService", b =>
                {
                    b.HasOne("com.b_velop.Deploy_O_Mat.Domain.Models.DockerImage", "DockerImage")
                        .WithMany("DockerStackServices")
                        .HasForeignKey("DockerImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

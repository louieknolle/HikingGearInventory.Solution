// <auto-generated />
using HikingGear.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HikingGear.Migrations
{
    [DbContext(typeof(HikingGearContext))]
    [Migration("20220807230532_NewGearColumnName")]
    partial class NewGearColumnName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HikingGear.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("HikingGear.Models.CategoryGear", b =>
                {
                    b.Property<int>("CategoryGearId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("GearId")
                        .HasColumnType("int");

                    b.HasKey("CategoryGearId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("GearId");

                    b.ToTable("CategoryGear");
                });

            modelBuilder.Entity("HikingGear.Models.Gear", b =>
                {
                    b.Property<int>("GearId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PurchaseYear")
                        .HasColumnType("int");

                    b.HasKey("GearId");

                    b.ToTable("Gears");
                });

            modelBuilder.Entity("HikingGear.Models.CategoryGear", b =>
                {
                    b.HasOne("HikingGear.Models.Category", "Category")
                        .WithMany("JoinEntities")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HikingGear.Models.Gear", "Gear")
                        .WithMany("JoinEntities")
                        .HasForeignKey("GearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Gear");
                });

            modelBuilder.Entity("HikingGear.Models.Category", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("HikingGear.Models.Gear", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}

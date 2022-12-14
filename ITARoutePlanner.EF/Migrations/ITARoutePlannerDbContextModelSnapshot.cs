// <auto-generated />
using ITARoutePlanner.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ITARoutePlanner.EF.Migrations
{
    [DbContext(typeof(ITARoutePlannerDbContext))]
    partial class ITARoutePlannerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ITARoutePlanner.Domain.Models.Planet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AverageTemperature")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Diameter")
                        .HasColumnType("REAL");

                    b.Property<double>("DistanceFromEarth")
                        .HasColumnType("REAL");

                    b.Property<bool>("Habitable")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDwarf")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("PositionIndex")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Planetes");
                });

            modelBuilder.Entity("ITARoutePlanner.Domain.Models.Spacecraft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AsteroidDeflector")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("GravityGenerator")
                        .HasColumnType("INTEGER");

                    b.Property<double>("MaxTravelDistance")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Spacecrafts");
                });
#pragma warning restore 612, 618
        }
    }
}

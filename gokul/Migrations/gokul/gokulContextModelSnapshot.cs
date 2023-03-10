// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gokul.Data;

#nullable disable

namespace gokul.Migrations.gokul
{
    [DbContext(typeof(gokulContext))]
    partial class gokulContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("gokul.Models.customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ToAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.HasIndex("OrderTypeId");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("gokul.Models.executive", b =>
                {
                    b.Property<int>("ExecutiveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExecutiveId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ExecutiveName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderTypeId")
                        .HasColumnType("int");

                    b.Property<int>("PhnNo")
                        .HasColumnType("int");

                    b.HasKey("ExecutiveId");

                    b.HasIndex("OrderTypeId");

                    b.ToTable("executive");
                });

            modelBuilder.Entity("gokul.Models.order", b =>
                {
                    b.Property<int>("OrderTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderTypeId"));

                    b.Property<string>("OrderType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderTypeId");

                    b.ToTable("order");
                });

            modelBuilder.Entity("gokul.Models.customer", b =>
                {
                    b.HasOne("gokul.Models.order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("gokul.Models.executive", b =>
                {
                    b.HasOne("gokul.Models.order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}

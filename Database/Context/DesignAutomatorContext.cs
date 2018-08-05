using Microsoft.EntityFrameworkCore;
using Model.Models;
using Model.Models.Help;

namespace Infrastructure.Database.Context
{
    public partial class DesignAutomatorContext : DbContext
    {
        public DesignAutomatorContext(DbContextOptions<DesignAutomatorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssignedProduct> AssignedProduct { get; set; }
        public virtual DbSet<BaseType> BaseType { get; set; }
        public virtual DbSet<BasicData> BasicData { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<Discipline> Discipline { get; set; }
        public virtual DbSet<Dna> Dna { get; set; }
        public virtual DbSet<DnaClient> Dnaclient { get; set; }
        public virtual DbSet<DnaClientAuthorizationLevel> DnaclientAuthorizationLevel { get; set; }
        public virtual DbSet<DoorComponentMap> DoorComponentMap { get; set; }
        public virtual DbSet<ErrorCheckMapping> ErrorCheckMapping { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<FunctionLog> FunctionLog { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<LibraryConst> LibraryConst { get; set; }
        public virtual DbSet<Main> Main { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<PhoenixObject> Object { get; set; }
        public virtual DbSet<ProductData> ProductData { get; set; }
        public virtual DbSet<ProductHeader> ProductHeader { get; set; }
        public virtual DbSet<ProductLibDnaclient> ProductLibDnaclient { get; set; }
        public virtual DbSet<ProductLibrary> ProductLibrary { get; set; }
        public virtual DbSet<ProductLibraryHeader> ProductLibraryHeader { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Model.Models.Section> Section { get; set; }
        public virtual DbSet<SectionDisciplineMap> SectionDisciplineMap { get; set; }
        public virtual DbSet<ServerInfo> ServerInfo { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<TempDeviceSortTable> TempDeviceSortTable { get; set; }
        public virtual DbSet<TemplateParameter> TemplateParameter { get; set; }
        public virtual DbSet<TypeDisciplineMap> TypeDisciplineMap { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<TypeTagMap> TypeTagMap { get; set; }
        public virtual DbSet<UserDnaClient> UserDnaclient { get; set; }
        public virtual DbSet<User> User { get; set; }

        //Help
        public virtual DbSet<Model.Models.Help.Section> Sections { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.ToTable("Users");

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Password)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Username)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            modelBuilder.Entity<AssignedProduct>(entity =>
            {
                entity.ToTable("AssignedProduct", "Automation");

                entity.Property(e => e.DnaclientId).HasColumnName("DNAClientId");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.AssignedProduct)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AssignedProduct_Devices");

                entity.HasOne(d => d.Dnaclient)
                    .WithMany(p => p.AssignedProduct)
                    .HasForeignKey(d => d.DnaclientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AssignedProduct_DNAClient");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.AssignedProduct)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AssignedProduct_Products");
            });

            modelBuilder.Entity<BaseType>(entity =>
            {
                entity.ToTable("BaseType", "Automation");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.BaseType)
                    .HasForeignKey(d => d.SectionId)
                    .HasConstraintName("FK_BaseType_Section");
            });

            modelBuilder.Entity<BasicData>(entity =>
            {
                entity.HasKey(e => e.Sequence);

                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Destination).HasMaxLength(255);

                entity.Property(e => e.FolderPath).HasMaxLength(255);

                entity.Property(e => e.Program).HasMaxLength(50);

                entity.Property(e => e.ProjectNumber).HasMaxLength(10);

                entity.Property(e => e.ProjectPath).HasMaxLength(255);

                entity.Property(e => e.RelativeFolderPath).HasMaxLength(255);

                entity.Property(e => e.RequestDate)
                    .IsRequired()
                    .HasMaxLength(19)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(20)))");

                entity.Property(e => e.Reserved)
                    .HasColumnName("reserved")
                    .HasMaxLength(50);

                entity.Property(e => e.SplistId)
                    .HasColumnName("SPListId")
                    .HasMaxLength(50);

                entity.Property(e => e.SplistItemId)
                    .HasColumnName("SPListItemId")
                    .HasColumnType("decimal(8, 0)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255);

                entity.Property(e => e.Url).HasMaxLength(510);

                entity.Property(e => e.Useremail)
                    .HasColumnName("useremail")
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(255);

                entity.Property(e => e.WindowsIdentity).HasMaxLength(255);

                entity.Property(e => e.Xref).HasColumnName("XREF");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Address1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Address2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fax)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PostCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Prefix)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId)
                    .HasColumnType("decimal(1, 0)")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("Devices", "Automation");

                entity.Property(e => e.Active)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TypeId).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Devices_Types");
            });

            modelBuilder.Entity<Discipline>(entity =>
            {
                entity.ToTable("Disciplines", "Automation");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dna>(entity =>
            {
                entity.ToTable("DNA", "Automation");

                entity.Property(e => e.DnaclientId)
                    .HasColumnName("DNAClientId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TypeTagId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Value)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Dnaclient)
                    .WithMany(p => p.Dna)
                    .HasForeignKey(d => d.DnaclientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_DNA_DNAClient");

                entity.HasOne(d => d.TypeTag)
                    .WithMany(p => p.Dna)
                    .HasForeignKey(d => d.TypeTagId)
                    .HasConstraintName("FK_DNA_TypeTagMap");
            });

            modelBuilder.Entity<DnaClient>(entity =>
            {
                entity.ToTable("DNAClient", "Automation");

                entity.Property(e => e.ClientAddress1)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ClientAddress2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ClientCountry)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ClientId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ClientName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ClientPostCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Colour1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Colour2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Colour3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Colour4)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Colour5)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dnalogo)
                    .HasColumnName("DNALogo")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Naming)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Uname)
                    .HasColumnName("UName")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.DnaClient)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_DNAClient_Clients");
            });

            modelBuilder.Entity<DnaClientAuthorizationLevel>(entity =>
            {
                entity.ToTable("DNAClientAuthorizationLevels");

                entity.Property(e => e.AuthorizationLevel)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DoorComponentMap>(entity =>
            {
                entity.ToTable("DoorComponentMap", "Automation");

                entity.Property(e => e.DnaclientId).HasColumnName("DNAClientId");

                entity.HasOne(d => d.Dnaclient)
                    .WithMany(p => p.DoorComponentMap)
                    .HasForeignKey(d => d.DnaclientId)
                    .HasConstraintName("FK_DoorComponentMap_DNAClient");
            });

            modelBuilder.Entity<ErrorCheckMapping>(entity =>
            {
                entity.HasKey(e => e.ErrorCheckId);

                entity.Property(e => e.ErrorCheckId).HasColumnName("error_check_id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorDrawingPathwithname)
                    .HasColumnName("error_drawing_pathwithname")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorImagePathwithname)
                    .HasColumnName("error_image_pathwithname")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorInsertPriority).HasColumnName("error_insert_priority");

                entity.Property(e => e.ErrorType)
                    .IsRequired()
                    .HasColumnName("error_type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SpColumnName)
                    .IsRequired()
                    .HasColumnName("sp_column_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SpName)
                    .IsRequired()
                    .HasColumnName("sp_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.ToTable("Files", "Phoenix");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Calculated)
                    .HasColumnName("calculated")
                    .HasColumnType("datetime");

                entity.Property(e => e.Corrupted).HasColumnName("corrupted");

                entity.Property(e => e.DataUpdated)
                    .HasColumnName("dataUpdated")
                    .HasColumnType("datetime");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime");

                entity.Property(e => e.Unit)
                    .HasColumnName("unit")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(510)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FunctionLog>(entity =>
            {
                entity.Property(e => e.Discipline)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Errors).IsUnicode(false);

                entity.Property(e => e.InputFiles).IsUnicode(false);

                entity.Property(e => e.LogDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedAttribute)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OriginalAttribute)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OriginalValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OutputFiles).IsUnicode(false);

                entity.Property(e => e.Product)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Program)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Items", "Menu");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.EnabledExtensions)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.FileCount)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Icon)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NavigateUrl)
                    .HasColumnName("NavigateURL")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Params)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LibraryConst>(entity =>
            {
                entity.ToTable("LibraryConst", "Phoenix");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Main>(entity =>
            {
                entity.ToTable("Main", "Menu");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.Icon)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NavigateUrl)
                    .HasColumnName("NavigateURL")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Text)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("Manufacturer", "Automation");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PhoenixObject>(entity =>
            {
                entity.HasKey(e => e.BlckId);

                entity.ToTable("Objects", "Phoenix");

                entity.Property(e => e.BlckId)
                    .HasColumnName("blckID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BlckType)
                    .IsRequired()
                    .HasColumnName("blckType")
                    .HasMaxLength(50);

                entity.Property(e => e.Handle)
                    .IsRequired()
                    .HasColumnName("handle")
                    .HasMaxLength(10);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Layer)
                    .HasColumnName("layer")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Spc)
                    .HasColumnName("spc")
                    .HasMaxLength(1);

                entity.Property(e => e.Unit)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Xfn)
                    .HasColumnName("XFn")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.XscaleFactor).HasColumnName("XScaleFactor");

                entity.Property(e => e.Xst)
                    .HasColumnName("XSt")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Yfn)
                    .HasColumnName("YFn")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Yst)
                    .HasColumnName("YSt")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Zfn)
                    .HasColumnName("ZFn")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Zst)
                    .HasColumnName("ZSt")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Objects)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK_Objects_Files");
            });

            modelBuilder.Entity<ProductData>(entity =>
            {
                entity.ToTable("ProductData", "Automation");

                entity.Property(e => e.DnaclientId).HasColumnName("DNAClientId");

                entity.Property(e => e.Header)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Value)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.ProductData)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ProductData_Devices");

                entity.HasOne(d => d.Dnaclient)
                    .WithMany(p => p.ProductData)
                    .HasForeignKey(d => d.DnaclientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ProductData_DNAClient");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductData)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ProductData_Products");
            });

            modelBuilder.Entity<ProductHeader>(entity =>
            {
                entity.ToTable("ProductHeaders", "Automation");

                entity.Property(e => e.Header)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Value)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductHeaders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ProductHeader_Products");
            });

            modelBuilder.Entity<ProductLibDnaclient>(entity =>
            {
                entity.ToTable("ProductLibDNAClient", "Automation");

                entity.Property(e => e.DnaclientId).HasColumnName("DNAClientId");

                entity.HasOne(d => d.Dnaclient)
                    .WithMany(p => p.ProductLibDnaclient)
                    .HasForeignKey(d => d.DnaclientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ProductLibDNAClient_DNAClient");

                entity.HasOne(d => d.ProductLib)
                    .WithMany(p => p.ProductLibDnaclient)
                    .HasForeignKey(d => d.ProductLibId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ProductLibDNAClient_ProductLibrary");
            });

            modelBuilder.Entity<ProductLibrary>(entity =>
            {
                entity.ToTable("ProductLibrary", "Automation");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.ProductLibrary)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ProductLibrary_Manufacturer");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.ProductLibrary)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ProductLibrary_Types");
            });

            modelBuilder.Entity<ProductLibraryHeader>(entity =>
            {
                entity.ToTable("ProductLibraryHeaders", "Automation");

                entity.Property(e => e.Header)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Value)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProductLib)
                    .WithMany(p => p.ProductLibraryHeaders)
                    .HasForeignKey(d => d.ProductLibId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ProductDataHeaders_ProductLibrary");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products", "Automation");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.ProductLib)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductLibId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Products_ProductLibrary");
            });

            modelBuilder.Entity<Model.Models.Section>(entity =>
            {
                entity.ToTable("Section", "Automation");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<SectionDisciplineMap>(entity =>
            {
                entity.ToTable("SectionDisciplineMap", "Automation");

                entity.HasOne(d => d.Discipline)
                    .WithMany(p => p.SectionDisciplineMap)
                    .HasForeignKey(d => d.DisciplineId)
                    .HasConstraintName("FK_SectionDisciplineMap_Disciplines");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.SectionDisciplineMap)
                    .HasForeignKey(d => d.SectionId)
                    .HasConstraintName("FK_SectionDisciplineMap_Section");
            });

            modelBuilder.Entity<ServerInfo>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoenixServerName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoenixSharedFolder)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ServerType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpserverName)
                    .IsRequired()
                    .HasColumnName("SPServerName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SpsiteHostName)
                    .IsRequired()
                    .HasColumnName("SPSiteHostName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SqlconnectionString)
                    .IsRequired()
                    .HasColumnName("SQLConnectionString")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SqlreplaceString)
                    .IsRequired()
                    .HasColumnName("SQLReplaceString")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SqlserverName)
                    .IsRequired()
                    .HasColumnName("SQLServerName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WcfserviceUrl)
                    .IsRequired()
                    .HasColumnName("WCFServiceUrl")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tags", "Automation");

                entity.Property(e => e.DataType)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultValue).IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(1250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TempDeviceSortTable>(entity =>
            {
                entity.ToTable("TempDeviceSortTable", "Automation");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DoorName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LongDoorName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NickName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Priority)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Secure).HasDefaultValueSql("((0))");

                entity.Property(e => e.SequenceNum).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubPri)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TypeNm)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TemplateParameter>(entity =>
            {
                entity.ToTable("TemplateParameters", "Automation");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PanelType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReaderType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SystemType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Value).IsUnicode(false);

                entity.Property(e => e.ValueComment).IsUnicode(false);
            });

            modelBuilder.Entity<TypeDisciplineMap>(entity =>
            {
                entity.ToTable("TypeDisciplineMap", "Automation");

                entity.HasOne(d => d.Discipline)
                    .WithMany(p => p.TypeDisciplineMap)
                    .HasForeignKey(d => d.DisciplineId)
                    .HasConstraintName("FK_TypeDisciplineMap_Disciplines");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TypeDisciplineMap)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_TypeDisciplineMap_Types");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("Types", "Automation");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.BaseType)
                    .WithMany(p => p.Types)
                    .HasForeignKey(d => d.BaseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Types_BaseType");
            });

            modelBuilder.Entity<TypeTagMap>(entity =>
            {
                entity.ToTable("TypeTagMap", "Automation");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.TypeTagMap)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK_TypeTagMap_Tags");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TypeTagMap)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_TypeTagMap_Types");
            });

            modelBuilder.Entity<UserDnaClient>(entity =>
            {
                entity.ToTable("UserDNAClients");

                entity.Property(e => e.DnaAuthorizationLevelId).HasColumnName("DNAAuthorizationLevelId");

                entity.Property(e => e.DnaClientId).HasColumnName("DNAClientId");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.DnaAuthorizationLevel)
                    .WithMany(p => p.UserDnaclients)
                    .HasForeignKey(d => d.DnaAuthorizationLevelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UserDNAClients_DNAClientAuthorizationLevels");

                entity.HasOne(d => d.DnaClient)
                    .WithMany(p => p.UserDnaclient)
                    .HasForeignKey(d => d.DnaClientId)
                    .HasConstraintName("FK_UserDNAClients_DNAClient");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDnaclients)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UserDNAClients_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.Property(e => e.Dnamanager).HasColumnName("DNAManager");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsSqlauthentication).HasColumnName("IsSQLAuthentication");

                entity.Property(e => e.LockedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePicture)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('burakuytun.jpg')");

                entity.Property(e => e.Role).HasDefaultValueSql("((1))");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Users_Clients");
            });

            modelBuilder.Entity<Model.Models.Help.Section>(entity =>
            {
                entity.ToTable("Sections",schema:"help");
                entity.Property(e => e.Title).IsRequired().HasMaxLength(255);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Questions", schema: "help");
                
                entity.Property(e => e.Title).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Answer).IsRequired().HasMaxLength(255);
            });
        }
    }
}

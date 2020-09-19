using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PhoneStore.Data
{
    public partial class PhoneStoreDBContext : DbContext
    {
        public PhoneStoreDBContext()
        {
        }

        public PhoneStoreDBContext(DbContextOptions<PhoneStoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccBasket> AccBasket { get; set; }
        public virtual DbSet<AccRole> AccRole { get; set; }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AddressCity> AddressCity { get; set; }
        public virtual DbSet<AddressDistrict> AddressDistrict { get; set; }
        public virtual DbSet<AddressWard> AddressWard { get; set; }
        public virtual DbSet<BrandGroup> BrandGroup { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public virtual DbSet<ProBrand> ProBrand { get; set; }
        public virtual DbSet<ProGroup> ProGroup { get; set; }
        public virtual DbSet<ProSpecification> ProSpecification { get; set; }
        public virtual DbSet<ProType> ProType { get; set; }
        public virtual DbSet<ProVariant> ProVariant { get; set; }
        public virtual DbSet<ProView> ProView { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Specification> Specification { get; set; }
        public virtual DbSet<VarImages> VarImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
   }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccBasket>(entity =>
            {
                entity.HasKey(e => e.BasketId)
                    .HasName("PK__acc_bask__65E4F9F099F1E19E");

                entity.ToTable("acc_basket");

                entity.Property(e => e.BasketId).HasColumnName("basket_id");

                entity.Property(e => e.AccId).HasColumnName("acc_id");

                entity.Property(e => e.ProId).HasColumnName("pro_id");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.VarId).HasColumnName("var_id");

                entity.HasOne(d => d.Acc)
                    .WithMany(p => p.AccBasket)
                    .HasForeignKey(d => d.AccId)
                    .HasConstraintName("fk_cus_basket_acc_id");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.AccBasket)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("fk_cus_basket_pro_id");

                entity.HasOne(d => d.Var)
                    .WithMany(p => p.AccBasket)
                    .HasForeignKey(d => d.VarId)
                    .HasConstraintName("fk_cus_basket_var_id");
            });

            modelBuilder.Entity<AccRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__acc_role__760965CC1A5AC8C7");

                entity.ToTable("acc_role");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .HasColumnName("role_name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccId)
                    .HasName("PK__account__9A20D554ADB66FC6");

                entity.ToTable("account");

                entity.Property(e => e.AccId).HasColumnName("acc_id");

                entity.Property(e => e.AccAddressNumber)
                    .HasColumnName("acc_address_number")
                    .HasMaxLength(100);

                entity.Property(e => e.AccBirthday)
                    .HasColumnName("acc_birthday")
                    .HasColumnType("date");

                entity.Property(e => e.AccCityId).HasColumnName("acc_city_id");

                entity.Property(e => e.AccDistrictId).HasColumnName("acc_district_id");

                entity.Property(e => e.AccEmail)
                    .HasColumnName("acc_email")
                    .HasMaxLength(50);

                entity.Property(e => e.AccName)
                    .HasColumnName("acc_name")
                    .HasMaxLength(50);

                entity.Property(e => e.AccNote)
                    .HasColumnName("acc_note")
                    .HasMaxLength(500);

                entity.Property(e => e.AccPass)
                    .HasColumnName("acc_pass")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.AccPhone)
                    .HasColumnName("acc_phone")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AccRoleId).HasColumnName("acc_role_id");

                entity.Property(e => e.AccSalt)
                    .HasColumnName("acc_salt")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.AccStatus).HasColumnName("acc_status");

                entity.Property(e => e.AccWardId).HasColumnName("acc_ward_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.AccCity)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.AccCityId)
                    .HasConstraintName("fk_account_city_id");

                entity.HasOne(d => d.AccDistrict)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.AccDistrictId)
                    .HasConstraintName("fk_account_district_id");

                entity.HasOne(d => d.AccRole)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.AccRoleId)
                    .HasConstraintName("fk_account_role_id");

                entity.HasOne(d => d.AccWard)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.AccWardId)
                    .HasConstraintName("fk_account_ward_id");
            });

            modelBuilder.Entity<AddressCity>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .HasName("PK__address___031491A8585F1C92");

                entity.ToTable("address_city");

                entity.Property(e => e.CityId)
                    .HasColumnName("city_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CityName)
                    .HasColumnName("city_name")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<AddressDistrict>(entity =>
            {
                entity.HasKey(e => e.DistrictId)
                    .HasName("PK__address___2521322B054DEA5F");

                entity.ToTable("address_district");

                entity.Property(e => e.DistrictId)
                    .HasColumnName("district_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.DistrictName)
                    .HasColumnName("district_name")
                    .HasMaxLength(30);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.AddressDistrict)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("fk_address_district_city_id");
            });

            modelBuilder.Entity<AddressWard>(entity =>
            {
                entity.HasKey(e => e.WardId)
                    .HasName("PK__address___396B899D243CE4D6");

                entity.ToTable("address_ward");

                entity.Property(e => e.WardId)
                    .HasColumnName("ward_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DistrictId).HasColumnName("district_id");

                entity.Property(e => e.WardName)
                    .HasColumnName("ward_name")
                    .HasMaxLength(30);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.AddressWard)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("fk_address_ward_district_id");
            });

            modelBuilder.Entity<BrandGroup>(entity =>
            {
                entity.ToTable("brand_group");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.BrandGroup)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("fk_brand_group_group_id");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.BrandGroup)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("fk_brand_group_type_id");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.ComId)
                    .HasName("PK__comment__5066738C7723028A");

                entity.ToTable("comment");

                entity.Property(e => e.ComId).HasColumnName("com_id");

                entity.Property(e => e.ComAccId).HasColumnName("com_acc_id");

                entity.Property(e => e.ComCusPhone)
                    .HasColumnName("com_cus_phone")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ComStatus).HasColumnName("com_status");

                entity.Property(e => e.ComText)
                    .HasColumnName("com_text")
                    .HasMaxLength(1000);

                entity.Property(e => e.ComTime)
                    .HasColumnName("com_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConCusName)
                    .HasColumnName("con_cus_name")
                    .HasMaxLength(50);

                entity.Property(e => e.ConNote)
                    .HasColumnName("con_note")
                    .HasMaxLength(50);

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.ProId).HasColumnName("pro_id");

                entity.HasOne(d => d.ComAcc)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.ComAccId)
                    .HasConstraintName("fk_comment_acc_id");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("fk_comment_parent_id");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("fk_comment_pro_id");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.InvId)
                    .HasName("PK__invoice__A8749C297CC2AE10");

                entity.ToTable("invoice");

                entity.Property(e => e.InvId).HasColumnName("inv_id");

                entity.Property(e => e.CusId).HasColumnName("cus_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmId).HasColumnName("em_id");

                entity.Property(e => e.InvAddress)
                    .HasColumnName("inv_address")
                    .HasMaxLength(100);

                entity.Property(e => e.InvCityId).HasColumnName("inv_city_id");

                entity.Property(e => e.InvCusEmail)
                    .HasColumnName("inv_cus_email")
                    .HasMaxLength(50);

                entity.Property(e => e.InvCusName)
                    .HasColumnName("inv_cus_name")
                    .HasMaxLength(50);

                entity.Property(e => e.InvCusPhone)
                    .HasColumnName("inv_cus_phone")
                    .HasMaxLength(10);

                entity.Property(e => e.InvDate)
                    .HasColumnName("inv_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvDeliveryMethod).HasColumnName("inv_delivery_method");

                entity.Property(e => e.InvDistrictId).HasColumnName("inv_district_id");

                entity.Property(e => e.InvNote)
                    .HasColumnName("inv_note")
                    .HasMaxLength(200);

                entity.Property(e => e.InvPaymentMethod).HasColumnName("inv_payment_method");

                entity.Property(e => e.InvStatus)
                    .HasColumnName("inv_status")
                    .HasMaxLength(40);

                entity.Property(e => e.InvWardId).HasColumnName("inv_ward_id");

                entity.HasOne(d => d.Cus)
                    .WithMany(p => p.InvoiceCus)
                    .HasForeignKey(d => d.CusId)
                    .HasConstraintName("fk_invoice_cus_id");

                entity.HasOne(d => d.Em)
                    .WithMany(p => p.InvoiceEm)
                    .HasForeignKey(d => d.EmId)
                    .HasConstraintName("fk_invoice_em_id");

                entity.HasOne(d => d.InvCity)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.InvCityId)
                    .HasConstraintName("fk_invoice_city_id");

                entity.HasOne(d => d.InvDistrict)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.InvDistrictId)
                    .HasConstraintName("fk_invoice_district_id");

                entity.HasOne(d => d.InvWard)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.InvWardId)
                    .HasConstraintName("fk_invoice_ward_id");
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.HasKey(e => e.InvDetailId)
                    .HasName("PK__invoice___5506AA2C630539D4");

                entity.ToTable("invoice_detail");

                entity.Property(e => e.InvDetailId).HasColumnName("inv_detail_id");

                entity.Property(e => e.InvId).HasColumnName("inv_id");

                entity.Property(e => e.ProId).HasColumnName("pro_id");

                entity.Property(e => e.ProPrice).HasColumnName("pro_price");

                entity.Property(e => e.ProQty).HasColumnName("pro_qty");

                entity.Property(e => e.VarId).HasColumnName("var_id");

                entity.HasOne(d => d.Inv)
                    .WithMany(p => p.InvoiceDetail)
                    .HasForeignKey(d => d.InvId)
                    .HasConstraintName("fk_invoice_detail_inv_id");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.InvoiceDetail)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("fk_invoice_detail_pro_id");

                entity.HasOne(d => d.Var)
                    .WithMany(p => p.InvoiceDetail)
                    .HasForeignKey(d => d.VarId)
                    .HasConstraintName("fk_invoice_detail_vari_id");
            });

            modelBuilder.Entity<ProBrand>(entity =>
            {
                entity.HasKey(e => e.BrandId)
                    .HasName("PK__pro_bran__5E5A8E2719E7F75D");

                entity.ToTable("pro_brand");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.BrandLogo)
                    .HasColumnName("brand_logo")
                    .HasMaxLength(100);

                entity.Property(e => e.BrandName)
                    .HasColumnName("brand_name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ProGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("PK__pro_grou__D57795A086758C17");

                entity.ToTable("pro_group");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.GroupName)
                    .HasColumnName("group_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ProSpecification>(entity =>
            {
                entity.ToTable("pro_specification");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProId).HasColumnName("pro_id");

                entity.Property(e => e.SpecId).HasColumnName("spec_id");

                entity.Property(e => e.SpecValue)
                    .HasColumnName("spec_value")
                    .HasMaxLength(200);

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.ProSpecification)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("fk_pro_specification_pro_id");

                entity.HasOne(d => d.Spec)
                    .WithMany(p => p.ProSpecification)
                    .HasForeignKey(d => d.SpecId)
                    .HasConstraintName("fk_pro_specification_spec_id");
            });

            modelBuilder.Entity<ProType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__pro_type__2C00059890CD92FF");

                entity.ToTable("pro_type");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.TypeName)
                    .HasColumnName("type_name")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.ProType)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("fk_pro_type_group_id");
            });

            modelBuilder.Entity<ProVariant>(entity =>
            {
                entity.HasKey(e => e.VarId)
                    .HasName("PK__pro_vari__0586E27E39E05C33");

                entity.ToTable("pro_variant");

                entity.Property(e => e.VarId).HasColumnName("var_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProId).HasColumnName("pro_id");

                entity.Property(e => e.VarColor)
                    .HasColumnName("var_color")
                    .HasMaxLength(20);

                entity.Property(e => e.VarColorIcon)
                    .HasColumnName("var_color_icon")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VarQty).HasColumnName("var_qty");

                entity.Property(e => e.VarStatus).HasColumnName("var_status");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.ProVariant)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("fk_pro_variant_pro_id");
            });

            modelBuilder.Entity<ProView>(entity =>
            {
                entity.ToTable("pro_view");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DateViewed)
                    .HasColumnName("date_viewed")
                    .HasColumnType("datetime");

                entity.Property(e => e.IpAddress)
                    .HasColumnName("ip_address")
                    .HasMaxLength(20);

                entity.Property(e => e.ProId).HasColumnName("pro_id");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.ProView)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("fk_pro_view_pro_id");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProId)
                    .HasName("PK__product__335E4CA6F73AC91C");

                entity.ToTable("product");

                entity.Property(e => e.ProId).HasColumnName("pro_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProBrandId).HasColumnName("pro_brand_id");

                entity.Property(e => e.ProDescription).HasColumnName("pro_description");

                entity.Property(e => e.ProGroupId).HasColumnName("pro_group_id");

                entity.Property(e => e.ProImage)
                    .HasColumnName("pro_image")
                    .HasMaxLength(300);

                entity.Property(e => e.ProName)
                    .HasColumnName("pro_name")
                    .HasMaxLength(100);

                entity.Property(e => e.ProRetailPrice).HasColumnName("pro_retail_price");

                entity.Property(e => e.ProSalePrice).HasColumnName("pro_sale_price");

                entity.Property(e => e.ProStatus).HasColumnName("pro_status");

                entity.Property(e => e.ProTypeId).HasColumnName("pro_type_id");

                entity.HasOne(d => d.ProBrand)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProBrandId)
                    .HasConstraintName("fk_product_brand");

                entity.HasOne(d => d.ProGroup)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProGroupId)
                    .HasConstraintName("fk_product_group");

                entity.HasOne(d => d.ProType)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProTypeId)
                    .HasConstraintName("fk_product_type");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => e.RaId)
                    .HasName("PK__rating__1ADCB59F99335D74");

                entity.ToTable("rating");

                entity.Property(e => e.RaId).HasColumnName("ra_id");

                entity.Property(e => e.ProId).HasColumnName("pro_id");

                entity.Property(e => e.RaAccId).HasColumnName("ra_acc_id");

                entity.Property(e => e.RaCusName)
                    .HasColumnName("ra_cus_name")
                    .HasMaxLength(50);

                entity.Property(e => e.RaCusPhone)
                    .HasColumnName("ra_cus_phone")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RaPoint).HasColumnName("ra_point");

                entity.Property(e => e.RaText)
                    .HasColumnName("ra_text")
                    .HasMaxLength(1000);

                entity.Property(e => e.RaTime)
                    .HasColumnName("ra_time")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("fk_cus_rating_pro_id");

                entity.HasOne(d => d.RaAcc)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.RaAccId)
                    .HasConstraintName("fk_rating_acc_id");
            });

            modelBuilder.Entity<Specification>(entity =>
            {
                entity.HasKey(e => e.SpecId)
                    .HasName("PK__specific__F670C5672DE6227A");

                entity.ToTable("specification");

                entity.Property(e => e.SpecId).HasColumnName("spec_id");

                entity.Property(e => e.SpecName)
                    .HasColumnName("spec_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VarImages>(entity =>
            {
                entity.HasKey(e => e.ImgId)
                    .HasName("PK__var_imag__6F16A71C5933A444");

                entity.ToTable("var_images");

                entity.Property(e => e.ImgId).HasColumnName("img_id");

                entity.Property(e => e.ImgPath)
                    .HasColumnName("img_path")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Index).HasColumnName("index");

                entity.Property(e => e.VarId).HasColumnName("var_id");

                entity.HasOne(d => d.Var)
                    .WithMany(p => p.VarImages)
                    .HasForeignKey(d => d.VarId)
                    .HasConstraintName("fk_var_images_var_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Flight.Models
{
    public partial class ModelDbContext : DbContext
    {
        public ModelDbContext()
            : base("name=ModelDbContext")
        {
        }

        public virtual DbSet<CHITIETCHUYENBAY> CHITIETCHUYENBAYs { get; set; }
        public virtual DbSet<CHUYENBAY> CHUYENBAYs { get; set; }
        public virtual DbSet<DOANHTHUNAM> DOANHTHUNAMs { get; set; }
        public virtual DbSet<DOANHTHUTHANG> DOANHTHUTHANGs { get; set; }
        public virtual DbSet<DONGIA> DONGIAs { get; set; }
        public virtual DbSet<HANGVE> HANGVEs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<MAYBAY> MAYBAYs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<PHIEUDATCHO> PHIEUDATCHOes { get; set; }
        public virtual DbSet<SANBAY> SANBAYs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TUYENBAY> TUYENBAYs { get; set; }
        public virtual DbSet<VECHUYENBAY> VECHUYENBAYs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETCHUYENBAY>()
                .HasOptional(e => e.CHUYENBAY)
                .WithRequired(e => e.CHITIETCHUYENBAY);

            modelBuilder.Entity<HANGVE>()
                .HasMany(e => e.PHIEUDATCHOes)
                .WithMany(e => e.HANGVEs)
                .Map(m => m.ToTable("PHIEUDAT_HANGVE").MapLeftKey("MaHangVe").MapRightKey("MaPhieuDatCho"));

            modelBuilder.Entity<SANBAY>()
                .HasMany(e => e.TUYENBAYs)
                .WithMany(e => e.SANBAYs)
                .Map(m => m.ToTable("TUYENBAY_SANBAY").MapLeftKey("MaSanBay").MapRightKey("MaTuyenBay"));
        }
    }
}

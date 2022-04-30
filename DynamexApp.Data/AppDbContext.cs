using DynamexApp.Core.Entities;
using DynamexApp.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryBrand> CountryBrands { get; set; }
        public DbSet<DeliveryPrice> DeliveryPrices { get; set; }
        public DbSet<DeliveryType> DeliveryTypes { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsSection> NewsSections { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Video> Videos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new DeliveryPriceConfiguration());
            modelBuilder.ApplyConfiguration(new DeliveryTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
            modelBuilder.ApplyConfiguration(new NewsSectionConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new SliderConfiguration());
            modelBuilder.ApplyConfiguration(new VideoConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

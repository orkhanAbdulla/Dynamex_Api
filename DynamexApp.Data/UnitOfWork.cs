using DynamexApp.Core;
using DynamexApp.Core.Entities;
using DynamexApp.Core.Repositories;
using DynamexApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IBrandRepository _brand;
        private ICountryRepository _country;
        private IDeliveryPriceRepository _deliveryPrice;
        private IDeliveryTypeRepository _deliveryType;
        private ILanguageRepository _language;
        private INewsRepository _news;
        private INewsSectionRepository _neswSection;
        private IServiceRepository _service;
        private ISliderRepository _slider;
        private IVideoRepository _video;
       
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IBrandRepository BrandRepository => _brand = _brand ?? new BrandRepository(_context);

        public ICountryRepository CountryRepository => _country= _country?? new CountryRepository(_context);

        public IDeliveryPriceRepository DeliveryPriceRepository => _deliveryPrice = _deliveryPrice ?? new DeliveryPriceRepository(_context);

        public IDeliveryTypeRepository DeliveryTypeRepository => _deliveryType = _deliveryType ?? new DeliveryTypeRepository(_context);

        public ILanguageRepository LanguageRepository => _language =_language ?? new LanguageRepository(_context);

        public INewsRepository NewsRepository => _news = _news ?? new NewsRepository(_context);

        public INewsSectionRepository NewsSectionRepository => _neswSection= _neswSection ?? new NewsSectionRepository(_context);

        public IServiceRepository ServiceRepository => _service = _service ?? new ServiceRepository(_context);

        public ISliderRepository SliderRepository => _slider = _slider ?? new SliderRepository(_context) ;

        public IVideoRepository VideoRepository => _video = _video ?? new VideoRepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

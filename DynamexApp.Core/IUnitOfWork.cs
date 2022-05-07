using DynamexApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Core
{
    public interface IUnitOfWork
    {
        public IBrandRepository BrandRepository { get; }
        public ICountryRepository CountryRepository { get; }
        public ITariffRepository DeliveryPriceRepository { get; }
        public IDeliveryTypeRepository DeliveryTypeRepository { get; }
        public ILanguageRepository LanguageRepository { get; }
        public INewsRepository NewsRepository { get; }
        public INewsSectionRepository NewsSectionRepository { get; }
        public IServiceRepository ServiceRepository { get; }
        public ISliderRepository SliderRepository { get; }
        public IVideoRepository VideoRepository { get; }
        public ICountryBrandRepository ContryBrandRepository { get; }
        Task CommitAsync();
    }
}

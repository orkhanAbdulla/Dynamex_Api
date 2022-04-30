using DynamexApp.Core.Entities;
using DynamexApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Data.Repositories
{
    class DeliveryPriceRepository:Repository<DeliveryPrice>,IDeliveryPriceRepository
    {
        private readonly AppDbContext _context;
        public DeliveryPriceRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

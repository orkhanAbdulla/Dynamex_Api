using DynamexApp.Core.Entities;
using DynamexApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Data.Repositories
{
    class TariffRepository:Repository<Tariff>,ITariffRepository
    {
        private readonly AppDbContext _context;
        public TariffRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

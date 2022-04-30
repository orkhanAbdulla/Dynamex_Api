using DynamexApp.Core.Entities;
using DynamexApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Data.Repositories
{
    class SliderRepository:Repository<Slider>,ISliderRepository
    {
        private readonly AppDbContext _context;
        public SliderRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

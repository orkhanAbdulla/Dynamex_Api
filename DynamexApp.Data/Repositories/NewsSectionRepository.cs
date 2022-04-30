using DynamexApp.Core.Entities;
using DynamexApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Data.Repositories
{

    class NewsSectionRepository:Repository<NewsSection>,INewsSectionRepository
    {
        private readonly AppDbContext _context;
        public NewsSectionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

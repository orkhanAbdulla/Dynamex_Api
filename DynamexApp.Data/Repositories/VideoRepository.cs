using DynamexApp.Core.Entities;
using DynamexApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Data.Repositories
{
    class VideoRepository : Repository<Video>, IVideoRepository
    {
        private readonly AppDbContext _context;
        public VideoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

    }
    
}

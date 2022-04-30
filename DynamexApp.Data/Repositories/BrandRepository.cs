﻿using DynamexApp.Core.Entities;
using DynamexApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Data.Repositories
{
    public class BrandRepository:Repository<Brand>, IBrandRepository
    {
        private readonly AppDbContext _context;

        public BrandRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
    }
}

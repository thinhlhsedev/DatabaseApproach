﻿using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repository.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DBApproach.Infrastructure.Repositories
{
    public class ComponentRepository: Repository<Component>, IComponentRepository 
    {
        public ComponentRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }        
    }
}

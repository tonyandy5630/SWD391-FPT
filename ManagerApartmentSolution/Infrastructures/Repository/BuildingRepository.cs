﻿using Application.IRepository;
using Infrastructures.Repository.Generic;
using ManagerApartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repository
{
    public class BuildingRepository : GenericRepository<Building> ,IBuildingRepository
    {
        public BuildingRepository(Manager_ApartmentContext context) : base(context) { }
    }
}

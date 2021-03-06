﻿using PhDSystem.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories.Interfaces
{
    public interface IFormOfEducationRepository
    {
        Task<IEnumerable<FormOfEducation>> GetFormsOfEducation();
    }
}

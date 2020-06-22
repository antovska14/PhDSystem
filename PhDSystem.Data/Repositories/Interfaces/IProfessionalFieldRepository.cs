﻿using PhDSystem.Data.Entities;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories.Interfaces
{
    public interface IProfessionalFieldRepository
    {
        Task AddProfessionalField(ProfessionalField professionalField);

        Task DeleteProfessionalField(int professionalFieldId);

        Task GetProfessionalFields();
    }
}

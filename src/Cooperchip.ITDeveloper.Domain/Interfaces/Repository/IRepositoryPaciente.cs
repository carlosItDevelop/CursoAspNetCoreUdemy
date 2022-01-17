using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.DomainCore.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Domain.Interfaces.Repository
{
    public interface IRepositoryPaciente : IGerenicRepository<Paciente, Guid>
    {

    }
}
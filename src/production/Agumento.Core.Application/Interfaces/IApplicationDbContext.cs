using Agumento.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agumento.Core.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Account> Accounts { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<CandidateProfile> CandidateProfiles { get; set; }
        DbSet<OpenPosition> OpenPositions { get; set; }
        Task<int> SaveChanges();
    }
}

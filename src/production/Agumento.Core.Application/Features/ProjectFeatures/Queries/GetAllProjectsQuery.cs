using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agumento.Core.Application.Features.ProjectFeatures.Queries
{
    public class GetAllProjectsQuery : IRequest<IEnumerable<Project>>
    {
        public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, IEnumerable<Project>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllProjectsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Project>> Handle(GetAllProjectsQuery query, CancellationToken cancellationToken)
            {
                var projectList = await _context.Projects.ToListAsync();

                if (projectList == null)
                {
                    return null;
                }
                return projectList.AsReadOnly();
            }
        }
    }
}

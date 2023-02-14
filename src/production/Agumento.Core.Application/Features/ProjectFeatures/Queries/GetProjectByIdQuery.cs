using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agumento.Core.Application.Features.ProjectFeatures.Queries
{
    public class GetProjectByIdQuery : IRequest<Project>
    {
        public Guid Id { get; set; }
        public class GetAccountByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Project>
        {
            private readonly IApplicationDbContext _context;
            public GetAccountByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Project> Handle(GetProjectByIdQuery query, CancellationToken cancellationToken)
            {
                var project = _context.Projects.Where(a => a.Id == query.Id).FirstOrDefault();

                if (project == null) return null;
                return project;
            }
        }
    }
}

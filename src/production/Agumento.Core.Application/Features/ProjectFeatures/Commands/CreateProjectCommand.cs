using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agumento.Core.Application.Features.ProjectFeatures.Commands
{
    public class CreateProjectCommand : IRequest<Guid>
    { 
        public string? ProjectName { get; set; }
        public string? ProjectDetails { get; set; }        
        public string? ProjectManager { get; set; }        
        public virtual Guid AccountId { get; set; }        
        public virtual Account Account { get; set; }

        public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public CreateProjectCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
            {
                Project project = _mapper.Map<Project>(request);

                //account.AccountId = request.AccountId;
                //account.AccountName = request.AccountName;
                //account.AccountDetails = request.AccountDetails;
                //account.AccountManager = request.AccountManager;

                _context.Projects.Add(project);
                await _context.SaveChanges();

                return project.Id;
            }


        }

    }
}

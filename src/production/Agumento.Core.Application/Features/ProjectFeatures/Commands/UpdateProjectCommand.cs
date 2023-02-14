using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using AutoMapper;
using MediatR;

namespace Agumento.Core.Application.Features.ProjectFeatures.Commands
{
    public class UpdateProjectCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectDetails { get; set; }
        public string? ProjectManager { get; set; }
        public virtual Guid AccountId { get; set; }
        public virtual Account Account { get; set; }

        public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public UpdateProjectCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Guid> Handle(UpdateProjectCommand command, CancellationToken cancellationToken)
            {
                var project = _context.Projects.Where(a => a.Id == command.Id).FirstOrDefault();

                if (project == null)
                {
                    return default;
                }
                else
                {
                    project.Id = command.Id;

                    project.ProjectName = command.ProjectName;

                    project.ProjectDetails = command.ProjectDetails;

                    project.ProjectManager = command.ProjectManager;

                    project.AccountId = command.AccountId;

                    project.Account = command.Account;

                    _context.Projects.Add(project);
                    await _context.SaveChanges();

                    return project.Id;
                }
            }
        }
    }
}

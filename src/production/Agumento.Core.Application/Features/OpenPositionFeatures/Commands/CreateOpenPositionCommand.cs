using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using AutoMapper;
using MediatR;

namespace Agumento.Core.Application.Features.OpenPositionFeatures.Commands
{
    public class CreateOpenPositionCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string JobId { get; set; }
        public string JobTitle { get; set; }
        public virtual Guid AccountId { get; set; }
        // public virtual Account Account { get; set; }
        public virtual Guid ProjectId { get; set; }
        // public virtual Project Project { get; set; }

        public string SkillSet { get; set; }

        public Decimal YearOfExp { get; set; }

        public string? Qualification { get; set; }

        public string JobDescription { get; set; }


        public int NoOfPositions { get; set; }
        public string Budget { get; set; }


        public string? Location { get; set; }


        public class CreateOpenPositionCommandHandler : IRequestHandler<CreateOpenPositionCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public CreateOpenPositionCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Guid> Handle(CreateOpenPositionCommand request, CancellationToken cancellationToken)
            {
                //OpenPosition openPosition = _mapper.Map<OpenPosition>(request);
                var openPosition = new OpenPosition();

                openPosition.JobId = request.JobId;
                openPosition.JobTitle = request.JobTitle;
                openPosition.AccountId = request.AccountId;
                openPosition.ProjectId = request.ProjectId;
                openPosition.Budget = request.Budget;
                openPosition.Location = request.Location;
                openPosition.Qualification = request.Qualification;
                openPosition.NoOfPositions = request.NoOfPositions;
                openPosition.SkillSet = request.SkillSet;
                openPosition.JobDescription = request.JobDescription;
                openPosition.YearOfExp = request.YearOfExp;
                openPosition.CreatedOn = DateTime.UtcNow;
                _context.OpenPositions.Add(openPosition);

                await _context.SaveChanges();

                return openPosition.Id;
            }


        }
    }
}


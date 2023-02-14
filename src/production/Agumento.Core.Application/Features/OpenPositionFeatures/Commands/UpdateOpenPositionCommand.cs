using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using AutoMapper;
using MediatR;

namespace Agumento.Core.Application.Features.OpenPositionFeatures.Commands
{
    public class UpdateOpenPositionCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public long JobId { get; set; }
        public string JobTitle { get; set; }
        public virtual Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
        public virtual Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public string SkillSet { get; set; }
        public string YearOfExp { get; set; }
        public string? Qualification { get; set; }
        public string JobDescription { get; set; }
        public int NoOfPositions { get; set; }
        public string? Location { get; set; }

        public class UpdateOpenPositionCommandHandler : IRequestHandler<UpdateOpenPositionCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public UpdateOpenPositionCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Guid> Handle(UpdateOpenPositionCommand command, CancellationToken cancellationToken)
            {
                var openPosition = _context.OpenPositions.Where(a => a.Id == command.Id).FirstOrDefault();

                if (openPosition == null)
                {
                    return default;
                }
                else
                {
                    //Need to add mapper
                    //openPosition.Id = command.Id;
                    //openPosition.AccountId = command.AccountId;
                    //openPosition.AccountName = command.AccountName;
                    //openPosition.AccountDetails = command.AccountDetails;
                    //openPosition.AccountManager = command.AccountManager;

                    _context.OpenPositions.Add(openPosition);
                    await _context.SaveChanges();

                    return openPosition.Id;
                }
            }
        }
    }
}

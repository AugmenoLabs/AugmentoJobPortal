using Agumento.Core.Application.Interfaces;
using Agumento.Core.Application.ResponseObject;
using Agumento.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Agumento.Core.Application.Features.OpenPositionFeatures.Queries
{
    public class GetOpenPositionWorkflowDetailsQuery : IRequest<ResponseObject.Workflow>
    {
        public Guid OpenPositionId { get; set; }

        public class GetOpenPositionWorkflowDetailsQueryHandler : IRequestHandler<GetOpenPositionWorkflowDetailsQuery, ResponseObject.Workflow>
        {
            private readonly IApplicationDbContext _context;
            public GetOpenPositionWorkflowDetailsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Workflow> Handle(GetOpenPositionWorkflowDetailsQuery request, CancellationToken cancellationToken)
            {
                var res = await GetOpenPositionWorkflowDetails(request);
                return res;
            }

            private async Task<Workflow> GetOpenPositionWorkflowDetails(GetOpenPositionWorkflowDetailsQuery request)
            {
                var result = await _context.OpenPositions
                            .Join(_context.CandidateProfiles, op => op.Id, cp => cp.OpenPositionId, (op, cp) => new { OpenPosition = op, CandidateProfile = cp })
                            .Join(_context.CandidateInterviews, cp => cp.CandidateProfile.Id, ci => ci.CandidateId, (cp, ci) => new { OpenPosition = cp.OpenPosition, CandidateProfile = cp.CandidateProfile, CandidateInterview = ci })
                            .Where(x => x.OpenPosition.Id == request.OpenPositionId)
                            .GroupBy(x => x.CandidateProfile.OpenPositionId)
                            .Select(g => new Workflow
                            {
                                Screening = new WorkflowLevels
                                {
                                    Selected = g.Count(x => x.CandidateInterview.IsSelected && x.CandidateInterview.Level == "Screening"),
                                    Rejected = g.Count(x => x.CandidateInterview.IsSelected == false && x.CandidateInterview.Level == "Screening"),
                                    Completed = g.Count(x => x.CandidateInterview.Level == "Screening")
                                },
                                L1 = new WorkflowLevels
                                {
                                    Scheduled = g.Count(x => x.CandidateInterview.Level == "L1"),
                                    Selected = g.Count(x => x.CandidateInterview.Level == "L1" && x.CandidateInterview.IsCompleted),
                                    Rejected = g.Count(x => x.CandidateInterview.Level == "L1" && !x.CandidateInterview.IsCompleted),
                                    Completed = g.Count(x => (x.CandidateInterview.IsCompleted || !x.CandidateInterview.IsCompleted) && x.CandidateInterview.Level == "L1")
                                },
                                L2 = new WorkflowLevels 
                                { 
                                    Scheduled = g.Count(x => x.CandidateInterview.Level == "L2"),
                                    Selected = g.Count(x => x.CandidateInterview.Level == "L2" && x.CandidateInterview.IsCompleted),
                                    Rejected = g.Count(x => x.CandidateInterview.Level == "L2" && !x.CandidateInterview.IsCompleted),
                                    Completed = g.Count(x => (x.CandidateInterview.IsCompleted || !x.CandidateInterview.IsCompleted) && x.CandidateInterview.Level == "L2")
                                },
                                Managerial = new WorkflowLevels 
                                { 
                                    Scheduled = g.Count(x => x.CandidateInterview.Level == "Managerial"),
                                    Selected = g.Count(x => x.CandidateInterview.Level == "Managerial" && x.CandidateInterview.IsCompleted),
                                    Rejected = g.Count(x => x.CandidateInterview.Level == "Managerial" && !x.CandidateInterview.IsCompleted),
                                    Completed = g.Count(x => (x.CandidateInterview.IsCompleted || !x.CandidateInterview.IsCompleted) && x.CandidateInterview.Level == "Managerial2")
                                },
                                HR = new WorkflowLevels 
                                {
                                    Scheduled = g.Count(x => x.CandidateInterview.Level == "HR"),
                                    Selected = g.Count(x => x.CandidateInterview.Level == "HR" && x.CandidateInterview.IsCompleted),
                                    Rejected = g.Count(x => x.CandidateInterview.Level == "HR" && !x.CandidateInterview.IsCompleted),
                                    Completed = g.Count(x => (x.CandidateInterview.IsCompleted || !x.CandidateInterview.IsCompleted) && x.CandidateInterview.Level == "HR")
                                },
                                Hired = new WorkflowLevels
                                {
                                    Scheduled = g.Count(x => x.CandidateInterview.Level == "Hired"),
                                    Selected = g.Count(x => x.CandidateInterview.Level == "Hired" && x.CandidateInterview.IsCompleted),
                                    Rejected = g.Count(x => x.CandidateInterview.Level == "Hired" && !x.CandidateInterview.IsCompleted),
                                    Completed = g.Count(x => (x.CandidateInterview.IsCompleted || !x.CandidateInterview.IsCompleted) && x.CandidateInterview.Level == "Hired")
                                }
                            }).FirstOrDefaultAsync();

                return result;
            }
        }

    }
}

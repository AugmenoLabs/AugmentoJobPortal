﻿using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agumento.Core.Application.Features.CandidateProfileFeatures.Queries
{
    public class GetAllCandidateProfileQuery : IRequest<IEnumerable<CandidateProfile>>
    {
        public class GetAllAccountsQueryHandler : IRequestHandler<GetAllCandidateProfileQuery, IEnumerable<CandidateProfile>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllAccountsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<CandidateProfile>> Handle(GetAllCandidateProfileQuery query, CancellationToken cancellationToken)
            {
                var candidateProfileList = await _context.CandidateProfiles.ToListAsync();

                if (candidateProfileList == null)
                {
                    return null;
                }
                return candidateProfileList.AsReadOnly();
            }

        }
    }
}


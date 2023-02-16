﻿using Agumento.Core.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agumento.Core.Application.Features.ProjectFeatures.Commands
{
    public class DeleteProjectByIdCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public class DeleteProjectIdCommandHandler : IRequestHandler<DeleteProjectByIdCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public DeleteProjectIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(DeleteProjectByIdCommand command, CancellationToken cancellationToken)
            {
                var project = await _context.Projects.Where(a => a.Id == command.Id).FirstOrDefaultAsync();

                if (project == null) return default;
                // _context.Projects.Remove(project);
                project.IsDeleted = true;
                _context.Projects.Update(project);

                await _context.SaveChanges();
                return project.Id;
            }
        }
    }
}

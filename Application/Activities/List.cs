using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<Result<List<Activity>>> { }

        public class Handler : IRequestHandler<Query, Result<List<Activity>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            // Because return Task so we need a async
            public async Task<Result<List<Activity>>> Handle(Query request, CancellationToken token)
            {
                return Result<List<Activity>>.Success(await _context.Activities.ToListAsync(token));
            }
        }
    }
}
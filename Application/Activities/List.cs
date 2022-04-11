using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        //Create a query class that will implement the Mediatr.IRequest interface
        //to return a list of Activities
        public class Query : IRequest<List<Activity>> {}

        //Create a handler to handle our Querys
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;

            //injecting DataContext into constructor
            public Handler(DataContext context)
            {
                //assign the datacontext to the readonly one we defined above
                _context = context;
            }

            //Generate the task and make it async
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Activities.ToListAsync(cancellationToken);
            }
        }
    }
}
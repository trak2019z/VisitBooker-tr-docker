using System.Threading;
using System.Threading.Tasks;
using Domain.Core.Command;
using Domain.Entities;
using MediatR;
using Persistance.Context;

namespace Application.Visits.Commands
{
    public class AddNewVisitCommandHandler : ICommandHandler<AddNewVisitCommand>
    {
        private readonly VisitBookerDbContext _context;
        public AddNewVisitCommandHandler(VisitBookerDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(AddNewVisitCommand request, CancellationToken cancellationToken)
        {
            var entity = new Visit(request.Username, request.VisitDate, request.VisitTypeId);

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

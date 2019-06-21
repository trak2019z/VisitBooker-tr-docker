using Domain.Core.Command;
using System;

namespace Application.Visits.Commands
{
    public class AddNewVisitCommand : ICommand
    {
        public string Username { get; set; }
        public DateTime VisitDate { get; set; }
        public int VisitTypeId { get; set; }
    }
}

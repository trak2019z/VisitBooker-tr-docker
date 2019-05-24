using Domain.Enums;
using Domain.Security;
using System;

namespace Domain.Entities
{
    public class Visit
    {
        public Visit(string userName, DateTime date)
        {
            UserName = userName;
            VisitDate = date;
            Status = VisitStatus.Generated;
        }

        public DateTime VisitDate { get;  protected set; }
        public VisitStatus Status { get; protected set; }
        public string UserName { get; protected set; }
        public virtual ApplicationUser User { get; protected set; }
    }
}

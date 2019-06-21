using Domain.Common;
using Domain.Enums;
using Domain.Security;
using System;

namespace Domain.Entities
{
    public class Visit : SoftDeleteEntityBase
    {
        public Visit(string userName, DateTime date, int visitTypeId)
        {
            UserName = userName;
            VisitDate = date;
            VisitTypeId = visitTypeId;
            Status = VisitStatus.Generated;
        }
        protected Visit() { }

        public DateTime VisitDate { get;  protected set; }
        public VisitStatus Status { get; protected set; }
        public int VisitTypeId { get; protected set; }
        public virtual VisitType VisitType { get; protected set; }
        public string UserName { get; protected set; }
        public virtual ApplicationUser User { get; protected set; }
    }
}

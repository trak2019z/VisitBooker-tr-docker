using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class VisitType : SoftDeleteEntityBase
    {
        public VisitType(string name, string description, string price, string duration)
        {
            Name = name;
            Description = description;
            DefaultPrice = price;
            DefaultDuration = duration;
            Visits = new HashSet<Visit>();
        }
        protected VisitType() { }


        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string DefaultPrice { get; protected set; }
        public string DefaultDuration { get; protected set; }
        public virtual ICollection<Visit> Visits { get; protected set; }
    }
}

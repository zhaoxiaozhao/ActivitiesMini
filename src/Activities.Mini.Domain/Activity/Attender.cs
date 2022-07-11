using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Activities.Mini.Activity
{
    public class Attender : Entity
    {
        public long AttenderId { get; set; }
        public string AttenderName { get; set; }
        public int Gender { get; set; }
        public int Age { get; set; }
        protected Attender() { }
        public Attender(long attenderId)
        {
            AttenderId = attenderId;
        }
        public override object[] GetKeys()
        {
            throw new NotImplementedException();
        }
    }
}

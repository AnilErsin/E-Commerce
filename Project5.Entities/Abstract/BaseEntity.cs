using Project5.Entities.Enum;
using Project5.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5.Entities.Entity
{
    public class BaseEntity : IEntity
    {
        public int ID { get ; set ; }
        public DateTime? CreatedDate { get ; set ; }
        public DateTime? ModifiedDate { get ; set ; }
        public DateTime? DeletedDate { get ; set ; }
        public DataStatus Status { get ; set ; }
        public bool Discontinued { get ; set ; }
    }
}

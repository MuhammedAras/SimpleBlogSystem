using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTest.Data.Model
{
    public class Article : ModelBase
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        //relations
        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
    }
}

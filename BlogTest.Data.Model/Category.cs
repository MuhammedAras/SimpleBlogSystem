using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTest.Data.Model
{
    public class Category : ModelBase
    {
        public Category()
        {
            this.Articles = new List<Article>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}

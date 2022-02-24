using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string description { get; set; }
        public string picture { get; set; }

    }
}

using Cart.Core;
using System;
using System.Collections.Generic;

namespace Cart.Entities
{
    public partial class Cart : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        public int Quentity { get; set; }      
    }
}

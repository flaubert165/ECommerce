﻿using System;

namespace ECommerce.Domain.Entities
{
    public class Entity
    {
        public int Id {get; set;}
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassIn.Infrastructure.Entities
{
    public class Event  
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public int Maximun_Attendees { get; set; }
     }
}

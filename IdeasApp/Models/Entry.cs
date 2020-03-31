﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeasApp.Models {
    class Entry {
        // Stores table values for particular columns listed below
        public string Category { get; set; }
        public string TaskName { get; set; }
        public string Deadline { get; set; }
        public string Priority { get; set; }
        public decimal EstimatedTime { get; set; }
        
    }
}

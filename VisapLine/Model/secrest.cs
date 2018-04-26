﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VisapLine.Model
{
    class secrest
    {
        public string id { get; set; }
        public string name { get; set; }
        public string service { get; set; }
        public string caller_id { get; set; }
        public string password { get; set; }
        public string profile { get; set; }
        public string local_address { get; set; }
        public string remote_address { get; set; }
        public string rutes { get; set; }
        public string limit_bytes_in { get; set; }
        public string limit_bytes_out { get; set; }
        public string last_logges_out { get; set; }
        public bool disable { get; set; }
    }
}

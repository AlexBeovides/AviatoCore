﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.DTOs
{
    public class LoginResult
    {
        public string Token { get; set; }
        public string Role { get; set; }
        public int AirportId { get; set; }
    }
}

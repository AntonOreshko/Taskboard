﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dto
{
    public class UserEditDto
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Exceptions
{
    public class DuplicateAuthorNameException: Exception
    {

        public DuplicateAuthorNameException() : base("\"Author Name cannot be duplicate \"") { }

     

    }
}

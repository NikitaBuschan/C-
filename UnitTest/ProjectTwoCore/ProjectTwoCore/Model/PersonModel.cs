﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTwoCore.Model
{
    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{ FirstName } { LastName }";
            }
        }
    }
}

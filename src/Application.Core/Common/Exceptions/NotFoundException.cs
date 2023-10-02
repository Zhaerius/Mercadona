﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Impossible de trouver l'entité")
        {
        }
    }
}

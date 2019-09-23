﻿using System;

namespace OSIRIS.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {

        }

        public NotFoundException(string message) : base($"{message} not found.")
        {

        }
    }
}

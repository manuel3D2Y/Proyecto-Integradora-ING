using System;
using System.Collections.Generic;
using CrudEntityFramework.response;

namespace CrudEntityFramework.Excepciones
{
    public class DomainValidationsException : Exception
    {
        public IList<Validation> Validations { get; private set; }

        public DomainValidationsException(IList<Validation> validations)
        {
            Validations = validations;
        }
    }
}

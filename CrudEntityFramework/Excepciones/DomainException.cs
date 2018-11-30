using System;

namespace CrudEntityFramework.Excepciones
{
    public class DomainException : Exception
    {
        public string Mensaje { get; }
        public Exception ErrorOrigen { get; }

        public DomainException(string mensaje)
        {
            Mensaje = mensaje;
        }

        public DomainException(string mensaje, Exception exception)
        {
            ErrorOrigen = exception;
            Mensaje = mensaje;
        }
    
    }
}

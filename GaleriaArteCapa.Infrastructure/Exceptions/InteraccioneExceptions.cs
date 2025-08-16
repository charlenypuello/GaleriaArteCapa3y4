using System;

namespace GaleriaArteCapa.Infrastructure.Exceptions
{
    public class InteraccioneNotFoundException : Exception
    {
        public InteraccioneNotFoundException() : base($"Interaccione no encontrado")
        {
        }
        
        public InteraccioneNotFoundException(int id) : base($"Interaccione con ID {id} no encontrado")
        {
        }
        
        public InteraccioneNotFoundException(string message) : base(message)
        {
        }
        
        public InteraccioneNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    
    public class InteraccioneValidationException : Exception
    {
        public InteraccioneValidationException(string message) : base(message)
        {
        }
        
        public InteraccioneValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
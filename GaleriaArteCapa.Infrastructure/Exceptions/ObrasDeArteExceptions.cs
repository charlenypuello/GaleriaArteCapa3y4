using System;

namespace GaleriaArteCapa.Infrastructure.Exceptions
{
    public class ObrasDeArteNotFoundException : Exception
    {
        public ObrasDeArteNotFoundException() : base($"ObrasDeArte no encontrado")
        {
        }
        
        public ObrasDeArteNotFoundException(int id) : base($"ObrasDeArte con ID {id} no encontrado")
        {
        }
        
        public ObrasDeArteNotFoundException(string message) : base(message)
        {
        }
        
        public ObrasDeArteNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    
    public class ObrasDeArteValidationException : Exception
    {
        public ObrasDeArteValidationException(string message) : base(message)
        {
        }
        
        public ObrasDeArteValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
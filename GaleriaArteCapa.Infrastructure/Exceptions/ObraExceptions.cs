using System;

namespace GaleriaArteCapa.Infrastructure.Exceptions
{
    public class ObraNotFoundException : Exception
    {
        public ObraNotFoundException() : base($"Obra no encontrado")
        {
        }
        
        public ObraNotFoundException(int id) : base($"Obra con ID {id} no encontrado")
        {
        }
        
        public ObraNotFoundException(string message) : base(message)
        {
        }
        
        public ObraNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    
    public class ObraValidationException : Exception
    {
        public ObraValidationException(string message) : base(message)
        {
        }
        
        public ObraValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
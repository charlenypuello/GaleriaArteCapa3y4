using System;

namespace GaleriaArteCapa.Infrastructure.Exceptions
{
    public class UsuarioNotFoundException : Exception
    {
        public UsuarioNotFoundException() : base($"Usuario no encontrado")
        {
        }
        
        public UsuarioNotFoundException(int id) : base($"Usuario con ID {id} no encontrado")
        {
        }
        
        public UsuarioNotFoundException(string message) : base(message)
        {
        }
        
        public UsuarioNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    
    public class UsuarioValidationException : Exception
    {
        public UsuarioValidationException(string message) : base(message)
        {
        }
        
        public UsuarioValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
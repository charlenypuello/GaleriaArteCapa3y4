using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleriaArteCapa.Application.DTOs
{
    internal class ObraReadDTO
    {
            public int Id { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public string Categoria { get; set; }
            public string UrlImagen { get; set; }
            public DateTime FechaRegistro { get; set; }

        
            public UsuarioReadDto Usuario { get; set; }

            // Interacciones de esa obra
            public List<InteraccioneReadDto> Interacciones { get; set; }
        }
    }

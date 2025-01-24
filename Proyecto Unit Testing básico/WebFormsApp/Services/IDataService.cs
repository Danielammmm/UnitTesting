using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFormsApp.Services
{
    /// <summary>
    /// Representa un servicio externo para validar datos.
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Valida un nombre mediante una lógica externa.
        /// </summary>
        /// <param name="name">El nombre a validar.</param>
        /// <returns>True si el nombre es válido, False si no.</returns>
        bool ValidateName(string name);

        /// <summary>
        /// Obtiene la edad mínima requerida desde una lógica externa.
        /// </summary>
        /// <returns>La edad mínima como entero.</returns>
        int GetMinimumAge();
    }
}

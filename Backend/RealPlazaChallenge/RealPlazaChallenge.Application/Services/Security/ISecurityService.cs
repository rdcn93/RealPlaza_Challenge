using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RealPlazaChallenge.Application.Services.Security
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "ISecurityService" en el código y en el archivo de configuración a la vez.
    public interface ISecurityService
    {
        string Hash(string password);
        bool Check(string hash, string password);
    }
}


using AdapterLayer.Models;

namespace AdapterLayer.DTOs
{
    public class UserMapper
    {
        public UserMapper() { }

        public UserModel ToModel(UserRequest request)
        {
            return new UserModel
            {
                nombre = request.nombre,
                apellidos = request.apellidos,
                email = request.email,
                telefonoFijo = request.telefonoFijo,
                telefonoMovil = request.telefonoMovil,
                telefonoInstitucional = request.telefonoInstitucional,
                clave = request.clave,
                rol = request.rol,
                esResponsable = request.esResponsable,
                esAutorizante = request.esAutorizante
            };
        }
    }
}

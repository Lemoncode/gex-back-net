
namespace AdapterLayer.DTOs
{
    public class UserRequest
    {
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string telefonoFijo { get; set; }
        public string telefonoMovil { get; set; }
        public string telefonoInstitucional { get; set; }
        public string clave { get; set; }
        public string rol { get; set; }
        public bool esResponsable { get; set; }
        public bool esAutorizante { get; set; }
    }
}

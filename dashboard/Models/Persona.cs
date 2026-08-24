namespace dashboard.Models
{
    public class Persona
    {
        public int Idpersonas { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;

        public string EstadoTexto => Activo ? "Activo" : "Inactivo";
        public string NombreCompleto => $"{Nombres} {Apellidos}".Trim();
    }
}

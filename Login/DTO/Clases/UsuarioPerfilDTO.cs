namespace DTO
{
    public class UsuarioPerfilDTO
    {
        public int id { get; set; }
        public int id_perfil { get; set; }
        public int id_usuario { get; set; }
        public bool vigente { get; set; }
        public UsuarioDTO usuario { get; set; }
        public PerfilDTO perfil { get; set; }

        public UsuarioPerfilDTO()
        {
            usuario = new UsuarioDTO();
            perfil = new PerfilDTO();
        }
    }
}

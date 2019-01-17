namespace Upds.Sistemas.ProgWeb2.Tintoreria.Core
{
    public class Usuario
    {
        #region Atributos

        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string Password  { get; set; }
        public bool EsAdmin { get; set; }

        #endregion
    }
}

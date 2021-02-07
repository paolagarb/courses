namespace CursosMVC.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Plataforma { get; set; }
        public bool TemCertificado { get; set; }
        public bool CertificadoGratuito { get; set; }
        public byte[] Dados { get; set; }
        public string ContentType { get; set; }
        public Curso()
        {

        }
    }
}

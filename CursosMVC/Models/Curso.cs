using System.ComponentModel.DataAnnotations;

namespace CursosMVC.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Plataforma { get; set; }

        [Display(Name = "Possui certificado")]
        public bool TemCertificado { get; set; }

        [Display(Name = "Certificado gratuito")]
        public bool CertificadoGratuito { get; set; }

        public byte[] Dados { get; set; }
        public string ContentType { get; set; }

        [Display(Name = "URL do curso")]
        public string Link { get; set; }
        public Curso()
        {

        }
    }
}

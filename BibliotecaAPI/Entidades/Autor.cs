using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Entidades
{
    public class Autor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

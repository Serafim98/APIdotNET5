using System.ComponentModel.DataAnnotations;

namespace FilmeAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Gênero é obrigatório")]
        [StringLength(30, ErrorMessage = "O Gênero não pode ter mais de 30 caracteres")]
        public string Genero { get; set; }
        public string Diretor { get; set; }
        [Range(1, 600, ErrorMessage = "A duração dever estar entre 1 e 600 minutos")]
        public int Duracao { get; set; }
    }
}

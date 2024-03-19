using System.ComponentModel.DataAnnotations;

namespace StarStore.Models
{
    public class LoginModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo login é obrigatório.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O E-mail informado é inválido!")]
        public string Email { get; set; }

    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Toolbox.ASPMVC.ValidationAttributes;

namespace Demo_ASP.Models
{
    public class UserCreateForm
    {
        [Required(ErrorMessage = "Le nom de famille est obligatoire.")]
        [MinLength(2)]
        [MaxLength(32)]
        [DisplayName("Nom de famille :")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        [MinLength(2)]
        [MaxLength(32)]
        [DisplayName("Prénom :")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Le pseudo est obligatoire.")]
        [MinLength(2)]
        [MaxLength(32)] 
        [DisplayName("Pseudo :")]
        public string Pseudo { get; set; }
        [Required(ErrorMessage = "Le date de naissance est obligatoire.")]
        [DisplayName("Date de naissance :")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "L'adresse email est obligatoire.")]
        [MinLength(5)]
        [MaxLength(255)] 
        [DisplayName("Adresse e-mail :")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [MinLength(8)]
        [MaxLength(32)] 
        [DisplayName("Mot de passe :")]
        [DataType(DataType.Password)]
        [NeedLowerCase(5)]
        //[RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\-\.=+*@?]).*$", ErrorMessage ="Le format est trop simple pour la sécurité.")]
        public string Password { get; set; }
        [DisplayName("Veuillez confirmer votre mot de passe :")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string SecondPassword { get; set; }

    }
}

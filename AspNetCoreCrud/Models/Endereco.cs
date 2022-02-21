using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCrud.Models
{
	public class Endereco : Entity
	{
		public Guid MotoristaId { get; set; }

		[Required(ErrorMessage = "Campo {0} é obrigatório!")]
		[StringLength(100, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 4)]
		public string NomeRua { get; set; }

		[Required(ErrorMessage = "Campo {0} é obrigatório!")]
		[StringLength(50, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
		public string Numero { get; set; }

		public string Complemento { get; set; }

		[Required(ErrorMessage = "Campo {0} é obrigatório!")]
		[StringLength(8, ErrorMessage = "O Campo {0} precisa ter {1} caracteres", MinimumLength = 8)]
		public string Cep { get; set; }

		[Required(ErrorMessage = "Campo {0} é obrigatório!")]
		[StringLength(50, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
		public string Bairro { get; set; }

		[Required(ErrorMessage = "Campo {0} é obrigatório!")]
		[StringLength(50, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
		public string Cidade { get; set; }

		[Required(ErrorMessage = "Campo {0} é obrigatório!")]
		[StringLength(2, ErrorMessage = "O Campo {0} precisa {1} caracteres", MinimumLength = 2)]
		public string Estado { get; set; }

		public Motorista Motorista { get; set; }

	}
}

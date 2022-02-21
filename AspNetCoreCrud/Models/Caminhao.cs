using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCrud.Models
{
	public class Caminhao: Entity
	{

		public Guid MotoristaId { get; set; }

		[Required(ErrorMessage = "Campo {0} é obrigatório!")]
		[StringLength(100, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
		public string Marca { get; set; }

		[Required(ErrorMessage = "Campo {0} é obrigatório!")]
		[StringLength(100, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
		public string Modelo { get; set; }

		[Required(ErrorMessage = "Campo {0} é obrigatório!")]
		[StringLength(7, ErrorMessage = "O Campo {0} precisa ter {1} caracteres", MinimumLength = 7)]
		public string Placa { get; set; }

		[Required(ErrorMessage = "Campo {0} é obrigatório!")]
		[StringLength(100, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
		public string Eixo { get; set; }

		public Motorista Motorista { get; set; }

	}
}

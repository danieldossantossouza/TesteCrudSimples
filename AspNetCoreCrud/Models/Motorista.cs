using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreCrud.Models
{
	public class Motorista : Entity
	{
		

		
		[Required(ErrorMessage = "Campo {0} é obrigatório!")]
		[StringLength(50, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 4)]
		public string PrimeiroNome { get; set; }


		[Required(ErrorMessage = "Campo {0} é obrigatório!")]
		[StringLength(50, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 4)]
		public string  SegundoNome { get; set; }

	

		public CadastroViagem CadastroViagem { get; set; }

		public Endereco Endereco { get; set; }

		public Caminhao Caminhao { get; set; }



	}
}

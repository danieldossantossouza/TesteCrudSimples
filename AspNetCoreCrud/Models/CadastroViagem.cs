using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreCrud.Models
{
	public class CadastroViagem : Entity
	{
		public Guid MotoristaId { get; set; }

		[Required(ErrorMessage = "Campo Data é obrigatório!")]
		public DateTime DataHora { get; set; }


		[Required(ErrorMessage ="Campo Peso da Carga é obrigatório!")]
		public double PesoCarga { get; set; }


		[Required(ErrorMessage = "Campo Local da Entrega é obrigatório!")]
		public string LocaEntrega { get; set; }


		[Required(ErrorMessage = "Campo local da saida é obrigatório!")]
		public string LocaSaida { get; set; }

		[Required(ErrorMessage = "Total de quilometragem é obrigatório!")]
		public decimal KmTotal { get; set; }

		public Motorista Motorista { get; set; }


	}
}

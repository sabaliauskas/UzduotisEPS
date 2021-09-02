using System;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
	public class DiscountCode
	{
		public DiscountCode(string code)
		{
			Code = code;
		}

		[Required]
		[Key]
		public int Id { get; set; }

		[Required]
		[MinLength(7)]
		[MaxLength(8)]
		public string Code { get; set; }

		[Required]
		public DateTime CreatedAt { get; set; }

		public DateTime? UsedAt { get; set; }
	}
}
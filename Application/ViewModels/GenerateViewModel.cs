using System;

namespace Application.ViewModels
{
	public class GenerateViewModel : BaseViewModel
	{
		public ushort Count { get; set; }
		public byte Length { get; set; }

		public override void ValidateModel()
		{
			if (Count < 999 || Count > 2000)
				throw new Exception(_codeCountErrorMessage);

			if (Length != 7 && Length != 8)
				throw new Exception(_discountErrorMessage);
		}
	}
}
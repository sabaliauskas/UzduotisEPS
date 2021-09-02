using System;

namespace Application.ViewModels
{
	public class UseCodeViewModel : BaseViewModel
	{
		public string Code { get; set; }

		public override void ValidateModel()
		{
			if (Code.Length != 7 && Code.Length != 8)
				throw new Exception(_discountErrorMessage);
		}
	}
}
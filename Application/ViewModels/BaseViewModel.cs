namespace Application.ViewModels
{
	public abstract class BaseViewModel
	{
		internal const string _discountErrorMessage = "Discount code length error. Required code length is : 7 or 8";
		internal const string _codeCountErrorMessage = "Invalid number of codes to generate. Choose between 1000 and 2000";

		public abstract void ValidateModel();
	}
}
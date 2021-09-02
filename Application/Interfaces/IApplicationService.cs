using Application.ViewModels;

namespace Application.Interfaces
{
	public interface IApplicationService
	{
		bool Generate(GenerateViewModel viewModel);

		bool UseCode(UseCodeViewModel viewModel);
	}
}
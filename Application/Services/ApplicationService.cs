using Application.Interfaces;
using Application.ViewModels;
using Database.Interfaces;
using System.Collections.Generic;

namespace Application.Services
{
	public class ApplicationService : IApplicationService
	{
		private readonly IDiscountCodeRepository _rep;
		private readonly ICodeGeneratorService _codeGen;

		public ApplicationService(IDiscountCodeRepository discountCodeRepository, ICodeGeneratorService codeGeneratorService)
		{
			_rep = discountCodeRepository;
			_codeGen = codeGeneratorService;
		}

		public bool Generate(GenerateViewModel viewModel)
		{
			viewModel.ValidateModel();

			return GenerateCodes(viewModel.Length, viewModel.Count);
		}

		public bool UseCode(UseCodeViewModel viewModel)
		{
			viewModel.ValidateModel();

			return _rep.TryUseCode(viewModel.Code);
		}

		internal bool GenerateCodes(byte lenght, ushort count)
		{
			var codeList = _codeGen.GenerateList(lenght, count);

			(bool, List<string>) result = _rep.SaveCodes(codeList);

			//if all codes saved
			if (result.Item1) return true; 
			else return TryFixFailed(lenght, codeList, result.Item2);
		}

		private bool TryFixFailed(byte codeLength, List<string> initialCodes, List<string> failedCodes)
		{
			if (failedCodes?.Count > 0)
			{
				var attempt = 0;
				var maxAttempts = failedCodes.Count + 20;
				List<string> newCodes;

				while (failedCodes?.Count > 0 && attempt < maxAttempts)
				{
					newCodes = _codeGen.GenerateList(codeLength, (ushort)failedCodes.Count);

					(bool, List<string>) result = _rep.SaveCodes(newCodes);

					failedCodes = result.Item2;

					attempt++;

					if (attempt == maxAttempts)
					{
						_rep.RemoveFailedCodes(initialCodes);
						return false;
					}
				}
			}

			return true;
		}
	}
}
using System.Collections.Generic;

namespace Database.Interfaces
{
	public interface IDiscountCodeRepository
	{
		bool TryUseCode(string code);

		(bool, List<string>) SaveCodes(List<string> generatedStrings);

		void RemoveFailedCodes(List<string> codes);
	}
}
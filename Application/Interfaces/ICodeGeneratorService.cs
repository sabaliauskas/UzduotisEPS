using System.Collections.Generic;

namespace Application.Interfaces
{
	public interface ICodeGeneratorService
	{
		List<string> GenerateList(byte length, ushort count);
	}
}
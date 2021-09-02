using Application.Helpers;
using Application.Interfaces;
using System.Collections.Generic;

namespace Application.Services
{
	public class CodeGeneratorService : ICodeGeneratorService
	{
		public List<string> GenerateList(byte lenght, ushort count)
		{
			return RandomStringGenerator.ListOfStrings(lenght, count);
		}
	}
}
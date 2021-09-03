using Database.Contexts;
using Database.Interfaces;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Database.Repositories
{
	public class DiscountCodeRepository : IDiscountCodeRepository
	{
		private readonly DiscountCodeContext _context;

		public DiscountCodeRepository(DiscountCodeContext context)
		{
			_context = context;
		}

		public (bool, List<string>) SaveCodes(List<string> generatedStrings)
		{
			var failedCodes = new List<string>();

			foreach (var item in generatedStrings)
			{
				var dbObject = TryGetByCode(item);

				if (dbObject == null)
				{
					Create(new DiscountCode(item));
				}
				else
					failedCodes.Add(item);
			}

			if (failedCodes.Count > 0)
				return (false, failedCodes);

			return (true, null);
		}

		public void RemoveFailedCodes(List<string> generatedStrings)
		{
			foreach (var code in generatedStrings)
				RemoveByCode(code);
		}

		public bool TryUseCode(string code)
		{
			var dbObject = TryGetByCode(code);

			if (dbObject != null && !dbObject.UsedAt.HasValue)
			{
				dbObject.UsedAt = DateTime.Now;

				_context.SaveChanges();

				return true;
			}

			return false;
		}

		internal void Create(DiscountCode dbObject)
		{
			dbObject.CreatedAt = DateTime.Now;
			_context.DiscountCodes.Add(dbObject);
			_context.SaveChanges();
		}

		internal void RemoveByCode(string code)
		{
			var itemToRemove = _context.DiscountCodes.Where(x => x.Code == code).FirstOrDefault();

			if (itemToRemove != null)
				_context.DiscountCodes.Remove(itemToRemove);
		}


		internal DiscountCode TryGetByCode(string code)
		{
			return _context.DiscountCodes.FirstOrDefault(p => p.Code == code);
		}

		
	}
}
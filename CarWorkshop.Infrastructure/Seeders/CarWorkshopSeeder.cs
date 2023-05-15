using CarWorkshop.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Seeders
{
	public class CarWorkshopSeeder
	{
		private readonly CarWorkshopDbContext _dbContext;
		public CarWorkshopSeeder(CarWorkshopDbContext dbContext) 
		{ 
			_dbContext = dbContext;
		}

		public async Task Seed()
		{
			if( await _dbContext.Database.CanConnectAsync())
			{
				if (!_dbContext.CarWorkshops.Any())
				{
					var maxdaAso = new Domain.Entities.CarWorkshop()
					{
						Name = "Mazda ASO",
						Description = "Autoryzowany serwis Mazda",
						ConcactDetails = new()
						{
							City = "Kraków",
							Street = "Fabryczna 2",
							PostalCode = "30-001",
							PhoneNumber = "+48555666777"
						}
					};
					maxdaAso.EncodeName();

					_dbContext.CarWorkshops.Add(maxdaAso);
					await _dbContext.SaveChangesAsync();
				}
			}
		}
	}
}

using System.Collections.Generic;

namespace Cities.Models
{
    public class MemoryRepository : IRepository
    {
        private List<City> cities = new List<City>
        {
            new City { Name = "London", Country = "UK", Population = 8539000},
            new City { Name = "New York", Country = "USA", Population = 8406000 },
            new City { Name = "San Jose", Country = "USA", Population = 998537 },
            new City { Name = "Paris", Country = "France", Population = 2244000 }
        };

        public IEnumerable<City> Cities
        {
            get
            {
                return cities;
            }
        }

        public void AddCity(City newCity)
        {
            cities.Add(newCity);
        }
    }
}
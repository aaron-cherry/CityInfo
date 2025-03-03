using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public CitiesDataStore() 
        {        
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "Seattle",
                    Description = "Home of MLS losers",
                    PointsOfInterest = new List<PointsOfInterestDto>()
                    {
                        new PointsOfInterestDto()
                        {
                            Id = 1,
                            Name = "Space Needle",
                            Description = "A testament to our origins"
                        },
                        new PointsOfInterestDto()
                        {
                            Id = 2,
                            Name = "Duke's",
                            Description = "Some of the best food in town"
                        }

                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "St. Louis",
                    Description = "Future MLS Champions",
                    PointsOfInterest = new List<PointsOfInterestDto>()
                    {
                        new PointsOfInterestDto()
                        {
                            Id = 1,
                            Name = "The Arch",
                            Description = "Humanity's Greatest Achievement"
                        },
                        new PointsOfInterestDto()
                        {
                            Id = 2,
                            Name = "O'Fallon Sports Park",
                            Description = "I scored many goals here"
                        }

                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Portland",
                    Description = "Like a real life COD Zombies map",
                    PointsOfInterest = new List<PointsOfInterestDto>()
                    {
                        new PointsOfInterestDto()
                        {
                            Id = 1,
                            Name = "Port Of Portland",
                            Description = "Real creative with the name guys"
                        },
                        new PointsOfInterestDto()
                        {
                            Id = 2,
                            Name = "Washington Park ig",
                            Description = "One of portland's least heroin riddled parks"
                        }

                    }
                }
            };
        }
    }
}

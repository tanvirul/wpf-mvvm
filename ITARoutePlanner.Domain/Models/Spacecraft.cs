using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITARoutePlanner.Domain.Models
{
    public class Spacecraft : DomainObject
    {
        //"name": "Spectrum XIII",
        //    "type": "Light Spacecruiser",
        //    "capacity": 4,
        //    "gravityGenerator": false,
        //    "maxTravelDistance": 5620,
        //    "asteroidDeflector": false
        public string Name { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public bool GravityGenerator { get; set; }
        public double MaxTravelDistance { get; set; }
        public bool AsteroidDeflector { get; set; }

        public double AvailableMaxTravelDistance(int numOfPassengers)
        {
            double maxLoss = this.MaxTravelDistance - (this.MaxTravelDistance * 30 / 100);
            return this.Capacity * numOfPassengers / maxLoss;
        }
        public double[,] PlanetDistanceMatrix()
        {
            List<Planet> PlanetList = new List<Planet>();
            PlanetList = PlanetList.OrderBy(x => x.PositionIndex).ToList();

            double[,] distanceMatrix = new double[PlanetList.Count + 1, PlanetList.Count + 1];

            int totalPlanet = PlanetList.Count;
            for (int i = 1; i <= totalPlanet; i++)
            {
                for (int j = 1; j <= totalPlanet; j++)
                {
                    double distance = Math.Abs(PlanetList[i].DistanceFromEarth - PlanetList[j].DistanceFromEarth);
                    distanceMatrix[PlanetList[i].PositionIndex, PlanetList[j].PositionIndex] = distance;
                }
            }

            return distanceMatrix;
        }
        public bool ValidateRoute(Queue<Planet> route, Spacecraft spacecraft, int numOfPassenger)
        {
            double totalTraveledDistance = 0;
            int count = 0;
            int previousPlanetIndex = 3; // earth
            double[,] planetDistanceMatrix = this.PlanetDistanceMatrix();
            while (route.Count > 0)
            {
                Planet planet = route.Dequeue();
                double traveledDistance = planetDistanceMatrix[previousPlanetIndex, planet.PositionIndex];
                totalTraveledDistance = totalTraveledDistance + traveledDistance;
                previousPlanetIndex = planet.PositionIndex;
            }
            totalTraveledDistance = totalTraveledDistance + planetDistanceMatrix[previousPlanetIndex, 3];

            return this.AvailableMaxTravelDistance(numOfPassenger) >= totalTraveledDistance;
        }
    }
}

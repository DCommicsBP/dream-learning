using DreamLearning.Models;
using DreamLearning.Dto; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device.Location;

namespace DreamLearning.Util
{
    public class Utils
    {
        public List<GeolocationPoint> FilterGeolocation(List<GeolocationPoint> geolocations, Coordinate coordinate)
        {

            foreach(GeolocationPoint point in geolocations)
            {
                List<GeolocationPoint> geolocationPoints = new List<GeolocationPoint>(); 
                if(point.Latitude.Equals("0.0") && point.Latitude.Equals("0.0"))
                {
                    geolocationPoints.Add(point);
                }
                else
                {
                    double latA = global::System.Single.Parse(point.Latitude.Replace(".", ","));
                    double longA = global::System.Single.Parse(point.Longitude.Replace(".", ","));
                    double latB = global::System.Single.Parse(coordinate.lat.Replace(".", ","));
                    double longB = global::System.Single.Parse(coordinate.lng.Replace(".", ","));

                    var locA = new GeoCoordinate(latA, longA);
                    var locB = new GeoCoordinate(latB, longB);
                    double distance = locA.GetDistanceTo(locB);
                    point.Distance = distance;

                }

            }
            return geolocations.OrderBy(x => x.Distance).ToList(); 
        }
    }
}
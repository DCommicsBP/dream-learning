var adrdresses = [], points = [], placesRecive=[], schools = [], subArrayAddresses = [], subArrayPoints = [], subArraySchools = [], pointMarkers = [], markers = [], places = [];
var newPoint = {};
var center = { lat: -30.030194684981844, lng: -51.22252230705834 };

var map;

function initialize() {
    var directionsService = new google.maps.DirectionsService();
    var directionsRenderer = new google.maps.DirectionsRenderer();
 
    var mapProp = {
        center: { lat: -30.030194684981844, lng: -51.22252230705834 },
        zoom: 16,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById('map'), mapProp);
};

var input = document.getElementById("inputSearch");

var defaultBounds = new google.maps.LatLngBounds(new google.maps.LatLng(-30.030194684981844, -51.22252230705834))
var searchBox = new google.maps.places.SearchBox(input, { bounds: defaultBounds });

var placesService = new google.maps.places.PlacesService(map);

places.forEach(function (place) {
    if (!place.geometry) {
        console.log("Returned place contains no geometry");
        return;
    }

    var buttonSend = function (e) {

        document.getElementById('btn-search').onclick = function () {
            var input = document.getElementById('inputSearch');
            input.focus();
            google.maps.event.trigger(input, 'keydown', { keyCode: 13 });
        };
    }
});

searchBox.addListener('places_changed', function () {
    var places = searchBox.getPlaces();

    if (places.length == 0) {
        return;
    }

    markers.forEach(function (marker) {
        marker.setMap(null);
    });

    newPoint = { lat: places[0].geometry.location.lat(), lng: places[0].geometry.location.lng() }

    console.log(newPoint)
    map.setCenter({ lat: places[0].geometry.location.lat(), lng: places[0].geometry.location.lng() }, 13)

    getData(places[0], { lat: places[0].geometry.location.lat(), lng: places[0].geometry.location.lng() });
});

var makeMarkers = function (subArrayPoints) {

    markers = []; 
    subArrayPoints.forEach(element => {
        let filterAdresses = addresses.filter(x => x.Inep === element.Inep);
        let filterSchool = schools.filter(x => x.Inep === element.Inep);
        
        cardAdress(filterAdresses[0], filterSchool[0].Nome);

        var marker = new google.maps.Marker({
            position: new google.maps.LatLng(parseFloat(element.Latitude), parseFloat(element.Longitude)),
            map: map,
            title: ``
        });
        

        var infowindow = new google.maps.InfoWindow({
            content: cardSchool(filterSchool[0], filterAdresses[0])
        });

        marker.addListener('click', function () {
            infowindow.open(map, marker);
        });

        markers.push(marker);

    });

    map.setCenter({ lat: subArrayPoints[subArrayPoints.length - 1].Latitude, lng: subArrayPoints[subArrayPoints.length - 1].Longitude }, 13)
       
    markers.forEach(function (marker) {

        marker.setMap(marker);

    });
};

initialize()

    directionsRenderer.addListener('directions_changed', function() {
        computeTotalDistance(directionsRenderer.getDirections());
      });
    
      displayRoute('Perth, WA', 'Sydney, NSW', directionsService,
          directionsRenderer);
    
    
    function displayRoute(origin, destination, service, display) {
      service.route({
        origin: origin,
        destination: destination,
        waypoints: [{location: 'Adelaide, SA'}, {location: 'Broken Hill, NSW'}],
        travelMode: 'DRIVING',
        avoidTolls: true
      }, function(response, status) {
        if (status === 'OK') {
          display.setDirections(response);
        } else {
          alert('Could not display directions due to: ' + status);
        }
      });
    }
    
    function computeTotalDistance(result) {
      var total = 0;
      var myroute = result.routes[0];
      for (var i = 0; i < myroute.legs.length; i++) {
        total += myroute.legs[i].distance.value;
      }
      total = total / 1000;
      document.getElementById('total').innerHTML = total + ' km';
    }



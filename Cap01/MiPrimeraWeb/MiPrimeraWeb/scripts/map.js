(function (cibertec) {
    window.cibertec.geoLocation = function () {
        console.log("Verificado Geolocalizacion");

        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(showPosition);
        } else {
            console.log("No se Admite Geolocalizacion");
        }
    }
    function showPosition(position) {
        var location = {
            lat: position.coords.latitude,
            lng: position.coords.longitude,
        }

        var map = new google.maps.Map(document.getElementById("googleMap"), { zoom: 15, canter: location });

        var marker = new google.maps.Marker({ position: location, map: map, title: "Cibertec" });
    }
})(window.cibertec = window.cibertec || {});
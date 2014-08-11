function showMap(myMap) {
    var coordStr = $('#Location').val(),
             center,
             myPlacemark;

    try {
        var coordPaths = coordStr.match(/\d+\.\d+/g),
            coordFloat = [parseFloat(coordPaths[0]), parseFloat(coordPaths[1])];
        center = [coordFloat[1], coordFloat[0]];
        myPlacemark = new ymaps.Placemark(center);

    } catch (e) {
        center = [59.829825, 30.377274];
    }

    myMap = new ymaps.Map("yMap", {
        center: center,
        zoom: 17
    });

    myMap.cursors.push('arrow');

    if (myPlacemark) {
        myMap.geoObjects.add(myPlacemark);
    }
    return myMap;
}

function clickHandler(e, myMap) {
    var coords = e.get('coords');
    var latitude = coords[0].toPrecision(6),
        longitude = coords[1].toPrecision(6);

    //SRID=4326;POINT (30.3739 59.8305)
    $('#Location').val("SRID=4326;POINT (" + longitude + " " + latitude + ")");

    myMap.geoObjects.removeAll();

    var myPlacemark = new ymaps.Placemark([latitude, longitude]);
    myMap.geoObjects.add(myPlacemark);
}
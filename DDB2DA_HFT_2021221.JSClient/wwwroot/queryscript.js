let items = [];




async function getdata() {
    let endpoint = document.getElementById(`querytype`).value;
    await fetch('http://localhost:21304/query/' + endpoint)
        .then(x => x.json())
        .then(y => {
            items = y;
            console.log(items);
            if (endpoint == "GetDriversFromTeam") { driverdisplay(); }
            else if (endpoint == "GetDriverRaces") { gpdisplay(); }
            else { teamdisplay(); }
        });
}

function driverdisplay() {
    document.getElementById(`resulttopics`).innerHTML = "<th>ID</th> <th>Short Name</th> <th>Name</th> <th>Nationality</th>";
    document.getElementById(`resultarea`).innerHTML = "";
    items.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.shortName + "</td><td>" + t.firstName + " " +
            t.lastName + "</td><td>" + t.nationality + "</td></tr>";
    });
}

function teamdisplay() {
    document.getElementById(`resulttopics`).innerHTML = "<th>ID</th> <th>Name</th> <th>Points</th>";
    document.getElementById(`resultarea`).innerHTML = "";
    items.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.name + "</td><td>" + t.points + "</td></tr>";
    });

}

function gpdisplay() {
    document.getElementById(`resulttopics`).innerHTML = "<th>ID</th> <th>Name</th> <th>Track</th> <th>Date</th>";
    document.getElementById(`resultarea`).innerHTML = "";
    items.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.name + "</td><td>" +
            t.track + "</td><td>" + t.date.toString().split("T")[0] + "</td></tr>";
    });
}
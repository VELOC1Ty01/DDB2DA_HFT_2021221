let drivers = [];
let connection = null;

let driverIdToUpdate = -1;

setupSignalR();

getdata();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:21304/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("DriverCreated", (user, message) => {
        getdata();
    });

    connection.on("DriverDeleted", (user, message) => {
        getdata();
    });

    connection.on("DriverUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();



}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};



async function getdata() {
    await fetch('http://localhost:21304/driver')
        .then(x => x.json())
        .then(y => {
            drivers = y;
            console.log(drivers);
            display();
        });
}


fetch('http://localhost:21304/driver')
    .then(x => x.json())
    .then(y => {
        drivers = y;
        console.log(drivers);
        display();
    });


function display() {
    document.getElementById(`resultarea`).innerHTML = "";
    drivers.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.firstName + " " + t.lastName + "</td><td>" +
            `<Button type="button" onclick="remove(${t.id})">Delete</Button>` +
            `<Button type="button" onclick="showupdate(${t.id})">Update</Button>` +
            "</td></tr>";
        //console.log(t.lastName);
    });
}

function showupdate(id) {
    document.getElementById('firstNameUp').value = drivers.find(t => t[`id`] == id)[`firstName`];
    document.getElementById('lastNameUp').value = drivers.find(t => t[`id`] == id)[`lastName`];
    document.getElementById('shortNameUp').value = drivers.find(t => t[`id`] == id)[`shortName`];
    document.getElementById('nationalityUp').value = drivers.find(t => t[`id`] == id)[`nationality`];
    document.getElementById('teamUp').value = drivers.find(t => t[`id`] == id)[`teamId`];

    document.getElementById('updateformdiv').style.display = 'flex';
    driverIdToUpdate = id;

}

function create() {
    let firstName = document.getElementById(`firstName`).value;
    let lastName = document.getElementById(`lastName`).value;
    let shortName = document.getElementById(`shortName`).value;
    let nationality = document.getElementById(`nationality`).value;
    let teamId = document.getElementById(`team`).value;

    fetch('http://localhost:21304/driver', {
        method: 'POST',
        headers: { 'Content-Type': `application/json`, },
        body: JSON.stringify(
            {
                firstName: firstName, lastName: lastName,
                shortName: shortName, nationality: nationality,
                teamId:teamId
            })
    })
        .then(response => response)
        .then(data =>
        {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';

    let firstName = document.getElementById(`firstNameUp`).value;
    let lastName = document.getElementById(`lastNameUp`).value;
    let shortName = document.getElementById(`shortNameUp`).value;
    let nationality = document.getElementById(`nationalityUp`).value;
    let teamId = document.getElementById(`teamUp`).value;

    fetch('http://localhost:21304/driver', {
        method: 'PUT',
        headers: { 'Content-Type': `application/json`, },
        body: JSON.stringify(
            {
                firstName: firstName, lastName: lastName,
                shortName: shortName, nationality: nationality,
                teamId: teamId, id: driverIdToUpdate
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}



function remove(id) {
    fetch('http://localhost:21304/driver/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}
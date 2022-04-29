let products = [];
let connection = null;

let productIdToUpdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:27588/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ProductCreated", (user, message) => {
        getdata();
    });
    connection.on("ProductDeleted", (user, message) => {
        getdata();
    });
    connection.on("ProductUpdated", (user, message) => {
        getdata();
    });

    connection.onclose
        (async () => {
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
    await fetch('http://localhost:27588/product')
        .then(x => x.json())
        .then(y => {
            products = y;
            //console.log(products);
            display();
        });
}





function display() {
    document.getElementById('resultarea').innerHTML = "";
    products.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
        "<tr><td>" + t.productId + "</td><td>"
            + t.productName + "</td><td>"
            + t.color + "</td><td>"
            + t.size + "</td><td>"
            + t.price + "</td><td>"
        + `<button type="button" onclick="remove(${t.productId})">Delete</button>`
        + `<button type="button" onclick="showupdate(${t.productId})">Update</button>`  + "</td></tr>"
    });
}

function create() {
    let name = document.getElementById('productName').value;
    let color = document.getElementById('color').value;
    let size = document.getElementById('size').value;
    let price = document.getElementById('price').value;
    fetch('http://localhost:27588/product/', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { productName: name, color: color, size: size, price: price }),
    })
        .then(response => response)
        .then(data => { console.log('Success:', data); getdata();})
        .catch(error => { console.error('Error:', error); });
}

function remove(productId){
    fetch('http://localhost:27588/product/' + productId, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => { console.log('Success:', data); getdata(); })
        .catch(error => { console.error('Error:', error); });
}

function showupdate(productId) {
    document.getElementById('productNameToUpdate').value = products.find(t => t['productId'] == productId)['productName']
    document.getElementById('colorToUpdate').value = products.find(t => t['productId'] == productId)['color']
    document.getElementById('sizeToUpdate').value = products.find(t => t['productId'] == productId)['size']
    document.getElementById('priceToUpdate').value = products.find(t => t['productId'] == productId)['price']
    document.getElementById('updateformdiv').style.display = 'flex';
    productIdToUpdate = productId;
}

function update() {
    let id = productIdToUpdate;
    let name = document.getElementById('productNameToUpdate').value;
    let color = document.getElementById('colorToUpdate').value;
    let size = document.getElementById('sizeToUpdate').value;
    let price = document.getElementById('priceToUpdate').value;
    fetch('http://localhost:27588/product/', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { productId: id, productName: name, color: color, size: size, price: price }),
    })
        .then(response => response)
        .then(data => { console.log('Success:', data); getdata(); })
        .catch(error => { console.error('Error:', error); });
    document.getElementById('updateformdiv').style.display = 'none';
}
let products = [];

getdata();

async function getdata() {
    await fetch('http://localhost:27588/product')
        .then(x => x.json())
        .then(y => {
            products = y;
            console.log(products);
            display();
        });
}





function display() {
    products.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
        "<tr><td>" + t.productId + "</td><td>"
            + t.productName + "</td><td>"
            + t.color + "</td><td>"
            + t.size + "</td><td>"
            + t.price + "</td></tr>"
    });
}

function create() {
    let name = document.getElementById('productName').value;
    let color = document.getElementById('color').value;
    let size = document.getElementById('size').value;
    let price = document.getElementById('price').value;
    fetch('http://localhost:27588/product', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { productName: name, color: color, size: size, price: price }),
    })
        .then(response => response)
        .then(data => { console.log('Success:', data); })
        .catch(error => { console.error('Error', error); });
    getdata();

}
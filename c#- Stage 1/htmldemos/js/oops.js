// class Product{
//     qty=1;
//     constructor(name, price){
//         this.name=name;
//         this.price=price;
//     }

//     display(){
//         console.log(this.name, this.price, this.qty);
//     }
// }

// let p = new Product("lays",15);
// p.display()
// Product.prototype.subtitle = function(){
//     console.log("This is a subtitle function."+ this.discount)
// }
// Product.prototype.discount=100;
// p.subtitle();
// console.log(p.discount);

// delete Product.discount;   //to delete the function or variable
// console.log(p.discount);




// // making of a new object withiur object

// let p2 = new Object()  // blank new object
// p2.name='kurkure';
// p2.price=20;
// p2.qty=1;
// Object.prototype.display = function(){
//     console.log(this.name, this.price , this.qty);
// }
// p2.display()


// //Inheritance

// class Item extends Product{

// }

// new Item.display();

// --------------------------------------------
//Implement Object from function
//advantage :implicit constructor

function Products(name,qty,price){
    this.display=()=>{console.log(name)}
}

let pr = new Products('namkeen',1,133);
pr.display();
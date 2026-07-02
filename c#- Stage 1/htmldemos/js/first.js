function sum(){
    console.log(arguments[0]+arguments[1])
}

sum(1,2);
sum(1,2,3,2);
sum(1);
sum();

const sub = (a,b)=>{
    console.log(b-a);
}

sub(2,1);
sub(1,2);
sub(1,2,3);
sub(1);

for(let x of "hello"){
    console.log(x);
}

for(let x in "hello"){
    console.log(x);
}

print(6);

function print(n){
    for(let i=0;i<n;i++){
        row=""
        for(let j=0;j<n-i;j++){
            row+=" "
        }
        for(let k=1;k<i;k++){
            row+="* "
        }
        console.log(row);
    }
}

marks=[1,2,3,4,5,6]
countries=['india','israel','usa','oman','srilanka']

for(let m of marks){
    console.log(m);
}

marks.forEach((m)=>{
    console.log(m);
})

let upCoun = countries.map((m)=>{
    return m.toUpperCase();
})

console.log(upCoun);
console.log(countries);

console.log(marks.map(m=>m*m))
console.log(marks.reduce((a,c)=>a*c))

var res = countries.reduce((a,c)=>a+" "+c, "countries:")
console.log(res)

countries.filter((c)=>c.length>5).forEach((c)=>{console.log(c)})

console.log(typeof(nan))
console.log(typeof(null))
console.log(typeof(object))
console.log(typeof(undefined))
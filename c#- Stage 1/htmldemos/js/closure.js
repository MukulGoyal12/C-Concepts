function generateSequence(){
    var count=0;
    return (()=>{
        console.log(++count);
    })
}

let result = generateSequence();
result()
result()
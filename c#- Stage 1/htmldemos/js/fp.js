// functional programming

// function func1(){
//     setTimeout(()=>{
//         console.log("hello");
//     },1000)
// }

// function func2(){
//     func1();
//     console.log("over");
// }

// func2();


// ------------------------------------

async function myFunc() {
    // console.log("async func begins");
    // return 10;             //return promise bcoz async
    // -------
    return new Promise((success,failure)=>{
        console.log("async func begins");
        if(true) success(333)
        else failed(200)
    })
}


function callfunc() {
    let res = myFunc();
    // res.then(successCallback, failureCallback)
    res.then((success) => {
        console.log("successfully completion with:" + success);
    }, (failed) => {
        console.log("failure completion with:" + failed);
    }).catch(err => {
        console.log("found err:" + err)
    })
    console.log("over");
}

callfunc()


// async function callfunc(){
//     await myFunc();                        //blocking , it will block the code after this.
//     console.log("after completion");
//     console.log("over");
// }


// ---------------------------------------------------------------------- 


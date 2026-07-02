# DOTNET



It is name of initiative from Microsoft to solve difficulties of n tier application development. 1998.



.net framework

.net languages -- Vb.next , c#.net, F#.net . Follow CLS(Common language Specification) and CTS(Common type Specification)

.net runtime



Assembly(deployable unit of .net project. Contains meta data + msil . Not contain runtime so independent of runtime environment.): single file assembly , multi file assembly , strong named assembly ,  global assembly cache,





### c#:

C# is pure object oriented programing language means everything must be inside class. Stand alone functions not allow

To create new project( dotnet new console -n projectname)

Object oriented programing language.

Identify data, process , object. object is collection of related data and functions. Can implement with class, record and struct. Need .net sdk



#### Types of MEMORY:



Stack Memory: Limited size. To load function to store functions and variables.

Heap Memory: Can be extended. If stack mem is full we use heap memory.

Base Memory: fastest but limited size.

Cache Memory: Frequently used data inside.



Dynamic Memory Allocation: We have to use pointers.

Stand Alone Functions: functions which are outside class which do not access the global data.







\[ <access specifier> <modifier>] class <classname>

&#x09;public		static

&#x09;internal	abstract

&#x09;protected

&#x09;private

&#x09;protected internal

&#x09;private protected

&#x09;file



&#x09;{

&#x09;   member variable / fields (private by default)

&#x09;   member function(){}

&#x09;   member event

&#x09;}



variables

==============

\[<access specifier> <modifier>] <datatype> <variablename>

int area;              		     |

&#x09;			     |

&#x09;			     v

&#x09;		bool,byte(0-255),sbyte(-128-127),short(-32768,32767),ushort(0-65536),

&#x09;		int(4 byte/ -2^31-2^31-1),uint,long(8 bytes, 2^63-2^63-1),ulong(8 bytes/0-2^63),

&#x09;		float(4 bytes),double(8 bytes),decimal(16 bytes),char(2 bytes)



Reference var size is always 4 bytes weather it is any datatype.





member functions

================

\[<access specifier> <modifier>] <returntype> <function name>(\[parameters]){

&#x09;\[statements]    |

} 			|

void display(){}	|

&#x20;      		        v

&#x20;		   abstract, static

&#x09;	   sealed, virtual







ONLY DECLARATION IS ALLOWED INSIDE CLASS.

INSTANCE DECLARATION AND MEMBER VARIABLE DECLARATION. WE CAN NOT ASSIGN VALUE;



class dummy{

&#x20;   	int age;

&#x09;age=10;                              //wrong , can not assign

&#x09;function void display(){

&#x09;	Console.Write(age);

&#x09;}

}





new dummy().display();   //error





sdk8: top-level statements

Only one file in whole project where we run statements without class. we have to encapsulate everything inside a class in every file except only one file.

And top level statements by default encapsulate inside Program class.





\*\* Member variables are provate so how to acess them outside class , best practive is not to make them public or private but to use special method----Property functions.



accessSpecifier  datatype  propertyName{get{};set{}}



internal int Name{

&#x09;get{};

&#x09;set{};

}





We declare keywords using var and dynamic also.

Variables declare with var must be initialize because datatype is needed.



Abstract class is use to hold the common properties of kind of classes.



BASE CLASS REFERENCE VARIABLE HOLDS ADDRESS OF CHILD CLASS INSTANCE.



Binding is process of associating func to the class. compiler do during compilation time , if compiler not able to do then runtime.







##### Four Pillars:



Encapsulation : TO wrap up related data in single unit. Class,Struct,Record

Abstraction: Provides what end user needs from user perspective.   Abstraction level -- class - properties,fields,methods,events etc. -- use access modifiers . Class is only public , protected , file.

Polymorphism : Ability of an object to behave differently in different situation.                                                                        class --> function --> Overloading/Overriding

Inheritance: It help to avoid code redundancy.





We can pass address also in functions. Call by Reference

&#x20;

Main(){

&#x20;int x=100, int y=300;

&#x20;swap(ref x, ref y);

&#x20;//x=300 y=100                                       //ref use krne se reference pass hua or variables ki value bhi change ho gyi.

}



swap(ref int a , ref int b){

&#x20;int c=a;

&#x20;a=b;

&#x20;b=c;

&#x20;//a=300 b=100

}





* ##### **Struct**

**It will not support inheritance.** struct use to implement class and it support encapsulation.As struct varuables store in stack its acess time is less and fast. only interfaces can be interited. All struct implicitly are child of object class.





* **Member variable can be readonly but not property.**



public const int code=10;                  // initialize only one while declaration

public readonly int code=10;              // initialize while declaration and in constructor.

public int code {get;set;}               // not applicable

public int code {get;init;}=90            // now it is readonly, we can initialize only while declaration once.





* ##### **Record**

Record Product(int Id, string Name, float Price);

Product p= new Product(1,"lays",44)





**Is Equivalent to:**



class Product{

&#x09;public int Id{get;init;}

&#x09;public int Name{get;init;}

&#x09;public int Price{get;init;}

}







##### **ARRAYS:**



Collection of variable

of same datatype --heterogenous

of different datatypes-heterogenous

array-> single dimension and multidimension

&#x20;

syntax: **Single dimensional array**

datatype \[]<arrayname>=new <datatype>\[size];

eg:	byte \[] marks =new byte\[10];

&#x09;marks\[0]=10;

&#x09;marks\[9]=90;





syntax: **multi dimensional array: Rectangular Array and jagged array**



**Rectangular Array:**

int\[,] data = new int\[5,5]    2-D

data\[0,0]=0;



**Jagged Array:**

int\[]\[] count= new int\[5]\[];      //No value to 2nd one because can be dynamic;

count\[0]= new int\[5];

count\[1]= new int\[8];





#### Enhanced SWITCH EXPRESSION:



string grade= Console.ReadLine();

string res= grade switch{

&#x09;"A" or "B" => "excellent",

&#x09;"C" => "good",

&#x09;"D"=> "ok",

&#x09;\_ => "fail"

}





Console.WriteLine("Enter marks");

if(int.TryParse(ReadLine(), out int marks)){

&#x09;int res= marks switch{

&#x09;	>80 => "excellent",

&#x09;	>60 => "good",

&#x09;	>50 => "ok",

&#x09;	\_ => "fail"

&#x09;}

}





#### Interface:



Future Referencing -> want to use a method/property which will implemented in future.

It is an object contains contract declarations - method, event, property.

They are created and used in library developement.

USED FOR:

1. Future Referencing (delegates)
2. Dynamic Binding
3. Dependency Injection



Delegates are same as function pointer.

1. declare the degelate type
2. instantiate delegate variable
3. store address of cuntion
4. use delegate to call function.





###### 5 Features to call a class -> COMPONENT Class:



1. Customization
2. Introspection





###### INTERFACE- Top down Approach:



generic types <class,record,struct> 8-12 version





#### **Collections:**

Group of value of same or different type.

array-object - heterogeneous

int\[] - homogeneous  -- static data structure - the shape is fixed.

Shape of data in memory is called data structure.

elastic data structure -- linked list , stack , queue , graph , queue etc -- Shape is not fix.


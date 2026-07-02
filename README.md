STAGE 1:SQL

To make db of our own size and location:

create database mukul
on
(name='mukuldata',filename='C:\data\mukuldata.mdf',size=10,filegrowth=1,maxsize=20)
log on (name='nandilog',filename='C:\data\nandilog.ldf',size=10,filegrowth=1,maxsize=20)
go
sp_helpdb mukul
go

System databases:

master : do not make anything in this

model  : model for other databases
use model
create table dummy(id int , int varchar(30))           // now this dummy table is replicated to every database.

tempdb: temporary , will be remove at end(when u shut down the system)

msdb

---
data integrity: correctness of data. to ensure this we have constraints
unique
not null
check  -- pattern domain range
primary key
foreign key

create table employees(id int primary key,
name varchar(30),
designation varchar(30),
salary float,
dob datetime,
managerId int references employees(id),
gender char(1) check(gender in ('f','m','F','M'))
insert in employees values(1,'janakiram','ceo',300000,null,'m')

SYNTAX FOR CONSTRAINT:

constraint <constraintName> constraintType
alter table employees drop constraint gchek
Normalization: Reducing complex table structure into a simple structure without loss of data to reduce redundancy.

A table can have only one Primary Key because a Primary Key automatically creates a clustered index, and a table can have only one clustered index.
A clustered index defines the physical sort order of the table.
If multiple Primary Keys were allowed, multiple clustered indexes would be needed — and a table cannot be physically sorted in more than one way.

If more than 2% of rows are written, then indexing is not useful.



Database Object(Anything which occupies space in database):

table , index, views , rules, defaults, trigger, procedure, function, type etc.


RULES:

if a constraint is to add in many tables we create rule.
create rule pincoderule as
@x='[6][0-9][0-9][0-9][0-9][0-9]'
sp_bindrule pincoderule 'mukul.dbo.products.pincode'  //To bind rule
sp_unbindrule 'mukul.dbo.products.pincode'         //To unbind any rule.


=======================================================================================================================================================

Stage 1:DOTNET

It is name of initiative from Microsoft to solve difficulties of n tier application development. 1998.

.net framework
.net languages -- Vb.next , c#.net, F#.net . Follow CLS(Common language Specification) and CTS(Common type Specification)
.net runtime

Assembly(deployable unit of .net project. Contains meta data + msil . Not contain runtime so independent of runtime environment.): single file assembly , multi file assembly , strong named assembly ,  global assembly cache,

=============================================================================================================================================


c#:
C# is pure object oriented programing language means everything must be inside class. Stand alone functions not allow
To create new project( dotnet new console -n projectname)
Object oriented programing language.
Identify data, process , object. object is collection of related data and functions. Can implement with class, record and struct. Need .net sdk

Types of MEMORY:

Stack Memory: Limited size. To load function to store functions and variables.
Heap Memory: Can be extended. If stack mem is full we use heap memory.
Base Memory: fastest but limited size.
Cache Memory: Frequently used data inside.

Dynamic Memory Allocation: We have to use pointers.
Stand Alone Functions: functions which are outside class which do not access the global data.



[ <access specifier> <modifier>] class <classname>
	public		static
	internal	abstract
	protected
	private
	protected internal
	private protected
	file

	{
	   member variable / fields (private by default)
	   member function(){}
	   member event
	}

variables
==============
[<access specifier> <modifier>] <datatype> <variablename>
int area;              		     |
				     |
				     v
			bool,byte(0-255),sbyte(-128-127),short(-32768,32767),ushort(0-65536),
			int(4 byte/ -2^31-2^31-1),uint,long(8 bytes, 2^63-2^63-1),ulong(8 bytes/0-2^63),
			float(4 bytes),double(8 bytes),decimal(16 bytes),char(2 bytes)

Reference var size is always 4 bytes weather it is any datatype.


member functions
================
[<access specifier> <modifier>] <returntype> <function name>([parameters]){
	[statements]    |
} 			|
void display(){}	|
       		        v
 		   abstract, static
		   sealed, virtual



ONLY DECLARATION IS ALLOWED INSIDE CLASS.
INSTANCE DECLARATION AND MEMBER VARIABLE DECLARATION. WE CAN NOT ASSIGN VALUE;

class dummy{
    	int age;
	age=10;                              //wrong , can not assign
	function void display(){
		Console.Write(age);
	}
}


new dummy().display();   //error


==========================================================================================================================================



Memory & Variables (The "Inside" Story)
Stack: Fast access, limited size. Yahan Value Types (int, struct) aur function calls store hote hain.

Heap: Flexible size. Yahan Objects store hote hain.

Reference Var: Size hamesha 4 or 8 bytes (system architecture ke hisaab se) hota hai, chahe data kitna bhi bada ho, kyunki ye sirf Address hold karta hai.

Top-Level Statements (SDK 8): Pure project mein sirf ek file aisi ho sakti hai jahan bina class ke direct code likho. Internally wo Program class mein hi wrap hota hai.


sdk8: top-level statements
Only one file in whole project where we run statements without class. we have to encapsulate everything inside a class in every file except only one file.
And top level statements by default encapsulate inside Program class.


** Member variables are private so how to acess them outside class , best practice is not to make them public or private but to use special method----Property functions.

accessSpecifier  datatype  propertyName{get{};set{}}

internal int Name{
	get{};
	set{};
}


We declare keywords using var and dynamic also.
Variables declare with var must be initialize because datatype is needed.

Abstract class is use to hold the common properties of kind of classes.

BASE CLASS REFERENCE VARIABLE HOLDS ADDRESS OF CHILD CLASS INSTANCE.

Binding is process of associating func to the class. compiler do during compilation time , if compiler not able to do then runtime.


=============================================================================================================================================


Four Pillars:

Encapsulation : TO wrap up related data in single unit. Class,Struct,Record
Abstraction: Provides what end user needs from user perspective.   Abstraction level -- class - properties,fields,methods,events etc. -- use access modifiers . Class is only public , protected , file.
Polymorphism : Ability of an object to behave differently in different situation.                                                                        class --> function --> Overloading/Overriding
Inheritance: It help to avoid code redundancy.


We can pass address also in functions. Call by Reference
 
Main(){
 int x=100, int y=300;
 swap(ref x, ref y);
 //x=300 y=100                                       //ref use krne se reference pass hua or variables ki value bhi change ho gyi.
}

swap(ref int a , ref int b){
 int c=a;
 a=b;
 b=c;
 //a=300 b=100
}


=============================================================================================================================================


Struct
It will not support inheritance. struct use to implement class and it support encapsulation. As struct variables store in stack its acess time is less and fast. only interfaces can be interited. All struct implicitly are child of object class.


# STRUCT – SIMPLE & CLEAR NOTES (Hinglish + Technical Terms)

1️⃣ Struct kya hota hai? (Definition)

struct ek value type hota hai
Value type ka matlab: data copy hota hai, reference nahi
Usually small & simple data store karne ke liye use hota hai
struct Student
{
    public int Id;
    public string Name;
}


📌 Jab Student s2 = s1; likhenge → pura data copy hoga


2️⃣ Memory Concept (Important)

Struct mostly stack memory me store hota hai
Isliye fast hota hai
But large data ke liye unsafe


3️⃣ Struct vs Class (Basic Difference)

Struct → Value Type
Class → Reference Type
Student s1 = new Student();
Student s2 = s1; // copy


Class me hota:
Student c2 = c1; // reference


4️⃣ Struct ke IMPORTANT RULES

Struct kisi class ko inherit nahi kar sakta
Struct interface implement kar sakta hai
Struct me parameterless constructor allowed nahi
Sab fields ko initialize karna zaroori


5️⃣ const keyword
Meaning:

const = compile-time constant
Value compile hone ke time fix ho jaati hai
Automatic static hota hai
struct Demo
{
    public const int MaxLimit = 100;
}


📌 const value kabhi change nahi ho sakti


6️⃣ readonly keyword
Meaning:

readonly = value sirf constructor me set hoti hai
Runtime pe value decide hoti hai
struct Employee
{
    public readonly int Id;

    public Employee(int id)
    {
        Id = id;
    }
}


📌 Constructor ke baad value change nahi kar sakte


7️⃣ const vs readonly (Samajhne Layak)

const → compile time fix
readonly → runtime fix
const simple values ke liye
readonly flexible hota hai


8️⃣ init keyword
Meaning:

Property sirf object banate time set hoti hai
Uske baad read-only behave karti hai
struct User
{
    public string Name { get; init; }
}

var u = new User { Name = "Mukul" };


📌 Baad me u.Name = "ABC" ❌ error


9️⃣ readonly struct
Meaning:

Poora struct immutable ho jaata hai
Koi bhi field change nahi ho sakti
readonly struct Money
{
    public int Amount { get; }

    public Money(int amount)
    {
        Amount = amount;
    }
}


✅ Data safe ✅ Performance better


🔟 Struct & Inheritance
❌ Struct class inherit nahi kar sakta
✅ Struct interface implement kar sakta hai
interface IPrint
{
    void Print();
}

struct Report : IPrint
{
    public void Print()
    {
        Console.WriteLine("Print");
    }
}




1️⃣1️⃣ Kab struct use kare?
✅ Small data (Point, Money, Date) ✅ Immutable data ✅ Performance important ho
❌ Large objects ❌ Inheritance heavy design


✅ EXAM / INTERVIEW SHORT POINTS

Struct is value type
Struct stack memory use karta hai
Struct class inherit nahi karta
const compile-time hota hai
readonly constructor ke baad change nahi hota
init initialization ke time set hota hai

=============================================================================================================================================

Member variable can be readonly but not property.

public const int code=10;                  // initialize only once while declaration
public readonly int code=10;              // initialize while declaration and in constructor.
public int code {get;set;}               // not applicable
public int code {get;init;}=90            // now it is readonly, we can initialize only while declaration , in constructor and while object creation.


Record
Record Product(int Id, string Name, float Price);
Product p= new Product(1,"lays",44)


Is Equivalent to:

class Product{
	public int Id{get;init;}
	public int Name{get;init;}
	public int Price{get;init;}
}


=============================================================================================================================================



ARRAYS:

Collection of variable
of same datatype --heterogenous
of different datatypes-heterogenous
array-> single dimension and multidimension
 
syntax: Single dimensional array
datatype []<arrayname>=new <datatype>[size];
eg:	byte [] marks =new byte[10];
	marks[0]=10;
	marks[9]=90;


syntax: multi dimensional array: Rectangular Array and jagged array

Rectangular Array:
int[,] data = new int[5,5]    2-D
data[0,0]=0;

Jagged Array:
int[][] count= new int[5][];      //No value to 2nd one because can be dynamic;
count[0]= new int[5];
count[1]= new int[8];


=============================================================================================================================================



Enhanced SWITCH EXPRESSION:

string grade= Console.ReadLine();
string res= grade switch{
	"A" or "B" => "excellent",
	"C" => "good",
	"D"=> "ok",
	_ => "fail"
}


Console.WriteLine("Enter marks");
if(int.TryParse(ReadLine(), out int marks)){
	int res= marks switch{
		>80 => "excellent",
		>60 => "good",
		>50 => "ok",
		_ => "fail"
	}
}


=============================================================================================================================================



Interface:

Future Referencing -> want to use a method/property which will implemented in future.
It is an object contains contract declarations - method, event, property.
They are created and used in library developement.
USED FOR:
Future Referencing (delegates)
Dynamic Binding
Dependency Injection

Delegates are same as function pointer.
declare the delegate type
instantiate delegate variable
store address of function
use delegate to call function.


5 Features to call a class -> COMPONENT Class:

Customization
Introspection


INTERFACE- Top down Approach:

generic types <class,record,struct> 8-12 version


=============================================================================================================================================



Collections:
Group of value of same or different type.
array-object - heterogeneous
int[] - homogeneous  -- static data structure - the shape is fixed.
Shape of data in memory is called data structure.
elastic data structure -- linked list , stack , queue , graph , queue etc -- Shape is not fix.

================================================================================================================================================

📘 DateTime in C# – General Notes (Save & Revise)

1️⃣ DateTime kya hota hai?
DateTime C# ka built‑in value type (struct) hai jo:

Date (day / month / year)
Time (hours / minutes / seconds)
Day of week
Comparison & calculation
sab handle karta hai.

C#DateTime dt;Show more lines
➡ Default value:
C#DateTime.MinValue   // 01/01/0001 00:00:00Show more lines

2️⃣ Current Date & Time
C#DateTime now = DateTime.Now;      // Current date + timeDateTime today = DateTime.Today;  // Date only, time = 00:00:00Show more lines
Difference:

Now → Time ke saath
Today → Sirf date


3️⃣ DateTime ko initialize karna
Constructor use karke:
C#DateTime dt = new DateTime(2025, 4, 11);DateTime dt2 = new DateTime(2025, 4, 11, 10, 30, 0);Show more lines
Format:
(year, month, day, hour, minute, second)


4️⃣ String → DateTime conversion
✅ ParseExact (Recommended)
C#DateTime dt = DateTime.ParseExact(    "05/25/2023",    "MM/dd/yyyy",    CultureInfo.InvariantCulture);Show more lines
✔ Format exact same hona chahiye
❌ Galat format → exception

✅ TryParseExact (Safe)
C#bool isValid = DateTime.TryParseExact(    input,    "MM/dd/yyyy",    CultureInfo.InvariantCulture,    DateTimeStyles.None,    out DateTime dt);``Show more lines
✔ Error nahi aata
✔ Success/failure bool me milta hai

FormatMeaningMMMonthddDayyyyyYearHH24‑hourmmMinutesssSeconds
Example:
Plain TextMM/dd/yyyy → 05/25/2023Show more lines

6️⃣ DateTime Properties
C#dt.Yeardt.Monthdt.Daydt.Hourdt.Minutedt.SecondShow more lines
Day name:
C#dt.DayOfWeek    //Show more lines

7️⃣ DateTime comparison
C#if (date1 < date2)Show more lines
Allowed operators:

< earlier
> later
== same date
!= not same

✔ Direct comparison allowed

8️⃣ Date difference / calculations
C#TimeSpan diff = date2 - date1;int days = diff.Days;Show more lines
Shortcut:
C#int days = (date2 - date1).Days;Show more lines

Add / Subtract days
C#dt.AddDays(5);dt.AddMonths(2);dt.AddYears(1);Show more lines
Original DateTime change nahi hota, new value milti hai.

9️⃣ DateTime formatting (Output ke liye)
C#string s = dt.ToString("MM/dd/yyyy");string s2 = dt.ToString("dddd"); // Day name``Show more lines
Examples:
Saturday
25-05-2023


🔟 DateTime Kind (Basic idea)
C#dt.KindShow more lines
Possible values:

Local
Utc
Unspecified


11️⃣ Important Points (Exam / Interview)

Date comparison string me nahi, DateTime me hoti hai
DateTime immutable hai (value type)
TryParseExact safer hota hai
DayOfWeek enum return karta hai


❌ Common Mistakes
❌ Date directly string me compare karna
❌ Format mismatch (MM vs mm)
❌ Time diya hi nahi aur "HH:mm:ss" use karna
❌ Original DateTime change ho jayega sochna (immutable hai)

✅ One‑Line Summary (Must Remember)

C# me DateTime ka use date parse, compare, calculate aur format karne ke liye hota hai.



================================================================================================

READ WRITE OPERATIONS:

TO WRITE:
---------

StreamWriter writer= new StreamWriter(@path);
writer.Write(data);
writer.Flush()
writer.Close()

OR

JsonSerializerOptions options = new JsonSerializerOptions()
{
    WriteIndented = true
};
string data = JsonSerializer.Serialize(products,options)              // products is ArrayList of products.
File.WriteAllText(@path,Data);


TO READ:
-------

StreamReader reader = new StreamReader(@path);
string data = reader.ReadToEnd();
Console.WriteLine(data);

OR

string data = File.ReadAllText(@"c:\json.txt");
List<Product> products = JsonSerializer.Deserialize<List<Product>>(data);
foreach(Product product in products)
{
    WriteLine(product);
}


=========================================================================================================================================================

ADO.NET:
ADO - Activex data objects
Specification created by Microsoft to develop data centric classes
Connected -- Disconnected

Connection , Command , DataReader
Microsoft  - SQLConnection , SQLCommand , SQLDataReader
Oracle     - OracleConnection , OracleCommand , OracleDataReader
PostgreSQL - PgSqlConnection , PgSqlCommand , PgSqlDataReader


ADO Disconnected architecture.


class DataSet{
  DataTable[] tables = new();
}


class DataTable{
   DataRow[] rows = new DataRow[10];
}

class DataRow{
   DataColumns[] ItemArray = new DataColumn[10];
}


DataTable dt = new DataTable();
dt.rows[1].ItemArray[0];



---------------------------------------------------

CONNECTED ARCHITECTURE :
-----------------------------------

Connected means crud operations are performed with database through an active connection.
Establish Connection
Execute Statement
Cross Connection

 static void Main(string[] args)
 {
     SqlConnection connection = null;
     try
     {
         string connstring = @"server=.\sqlexpress;initial catalog=cognizant;integrated security=true;trustservercertificate=true;";
         connection = new SqlConnection(connstring);
         SqlCommand cmd = new SqlCommand();
         cmd.Connection = connection;
         cmd.CommandText = "insert into products values(2,'lays',22)";
         connection.Open();
         cmd.ExecuteNonQuery();  //for dml - Insert Update Delete


         //In case Select Query
         //cmd.CommandText = "select * from products";
         //reader = cmd.ExecuteReader();
         //while (reader.read())                   //ref is before first row and read() moves it to next row and it return boolean
         //{
	
         //}
     }
     catch (SqlException e) { Console.WriteLine(e.ToString()); }
     finally
     {
         if (connection.State == ConnectionState.Open)
             connection.Close();
     }
 }




ExecuteScalar():

Ye tab use hota hai jab tumhe sirf ek single value chahiye (jaise count, max, min).

Example:
-------
 
cmd.CommandText = "select count(*) from products";
int count = (int)cmd.ExecuteScalar();
Console.WriteLine($"Total products: {count}");

==========================================================================================================

MultiThread Programming:

Thread - is process/function in execution
VLC Media - mp4 - audio data(o/p on speaker) and video data(o/p on monitor)
		  PlayAudio()                    ShowVideo()

Main(){                              //Here Pehle video chal jaegi phir audio aegi to idhr chahie parallel processing, yani ek time pr dono.
  ShowVideo(); - time sharing -- 1 nanosec to this
  PlayAudio(); 		     and 1 nanosec
}

Steps to implement multithreading:
runtime
Create an object of Thread Class
Pass the function you want to execute parallely
3. Start the thread
 
System.Threading

class{
void main(){
  Thread video= new Thread(showVideo);
  Thread audio= new Thread(playAudio);
  video.start();
  audio.start();
}

void showVideo()
void playAudio()
}



TASK:
Highlevel abstraction over threads



=======================================================================================================================================================

Stage 2:


17-04-2026


SOLID PRINCIPLES:

S - Single Responsibility  -- A class/object should follow/perform one and only one action. High Cohesion and Loose Coupling
O - Open Close Principles  -- A class should be open for extension but close for modification
L - Liskov substitutions   -- Sub classes should be substitutable for their base classes.
I - Intereface Segregation -- Many client specific interface are better than single Interface. Client should not implement methods they do not need.
D - Depenedency Inversion  -- A High level module should not depend on a low level module, rather both depend on Abstraction;


Single Responsibility:

A class should have only one reason to change and it should do only one thing.

class me sirf related methods and variables honge , na ki kuch bhi.

Example: product me price and name hai
Shopping cart me me CalculatePrice() , PrintInvoice(), SaveToDb() sb daldu to single resposnsibility violate hogi kyuki kuch change Karna hoga to bar bar class ko change krna pdega, islie alag alag classes bnaenge , like
ShoppingCart -- CalcTotalPrice()
CartInvoicePrinter -- PrintInvoice()
CartDBStorage -- SaveToDB()
.........................................................................................................................................................

Open Close Principle:

Me kisi existing class ke andr kuch add krne ke bajae , ek base interface bnaunga and baki classes me vo inherit krke function ko body dunga, let say SaveToDb() class thi ab mujhe SaveToMongo bhi krna hai or SaveToFile bhi , to me kya krunga uss SaveToDB class me change to krunga nahi , ek DBPersistence krke interface bnaunga or baki classes me use inherit krunga.

.........................................................................................................................................................

Liskov Substitution Principle:

Interface Account{
Deposit(),WithDraw()
}

CurrentAccount:Account{
Deposit(){};WithDraw(){}
}

SavingsAccount:Account{
Deposit(){};WithDraw(){}
}


FixedAccount:Account{       Mujhe iss account me bs deposit krvana hai but withdraw nahi but Account ko kia h inherit to dono krvana pdega
Deposit(){}; 		    but mujhe withdraw nahi chahie , to me kya kr skta hu main impolementation me check krlu fixed hai to mt kro call
WithDraw(){}		    but use OPEN CLOSE break hoga , aage bhi koi class add krni hoi aisi to kya krunga uss case me neeche vala kaam krenge
}

__________________

Interface NonWithdrawableAccount{
Deposit()
}

Interface WithdrawableAccount:NonWithdrawableAccount{
WithDraw()
}


CurrentAccount:WithdrawableAccount{
Deposit(){};WithDraw(){}
}

SavingsAccount:WithdrawableAccount{
Deposit(){};WithDraw(){}
}


FixedAccount:NonWithdrawableAccount{
Deposit(){};
}

NewTypeAccount:NonWithdrawableAccount{
Deposit();
}

.........................................................................................................................................................

Interface Segregation:

Interface 2DShape{
Area();
}

Interface 3DShape{
Area();
Volume();
}


Square:2DShape{
Area(){}
}

Rectangle:2DShape{
Area(){}
}

Cube:3DShape{
Area(){}
Volume(){}
}

.........................................................................................................................................................

Dependency Inversion Principle (DIP):
It states that high-level modules should not depend on low-level modules; both should depend on abstractions, promoting loose coupling and enhancing code maintainability.
without dip:-
public class LightBulb
{
    public void TurnOn() { /* implementation */ }
    public void TurnOff() { /* implementation */ }
}
public class Switch
{
    private LightBulb bulb;
    public Switch(LightBulb bulb)
    {
        this.bulb = bulb;
    }
    public void Toggle()
    {
        if (bulb.IsOn)
            bulb.TurnOff();
        else
            bulb.TurnOn();
    }
}
with dip:
public interface ISwitchable
{
    void TurnOn();
    void TurnOff();
}
public class LightBulb : ISwitchable
{
    // implementation
}
class WashingMachine:ISwitchable{
{
 
}
public class Switch
{
    private ISwitchable device;
    public Switch(ISwitchable device)
    {
        this.device = device;
    }
    public void Toggle()
    {
        if (device.IsOn)
            device.TurnOff();
        else
            device.TurnOn();
    }
}



=====================================================================================================

20-04-2026
 
Some common Interfaces : IDisposable, IComparable, IComparer

Object Oriented Analysis(OOA)

Design Patterns:
Creational Design Patterns : Decide how to create instance if a class. Factory,Builder,Singleton
Behavorial Design Patterns :
Structural Design Patterns

------------------------------------------------------------------------------------------------------------


ADVANCE SQL:
_____________________

Batches, Views , Procedures , Functions , Triggers etc

create schema mukul
create table mukul.products(id int)     // agr simple krta to dbo ke under bnti, dbo.products
_____________

VIEW:
_________

A view is a database object that encapsulate a select command..
create view <viewName> as <select command>
The table which is reference in view table is called base table.
Purpose of view is to store complex select statements.

VIEWS:
Simple Views
Complex Views

#Simple Views :
_____________

view will act like a table means you can perform DML and Select operations.

select * from HumanResources.Employee
create view Employees as select * from HumanResources.Employee
select * from Employees         -- Employees here is not a table but views


#Complex Views :
_______________

DML Operations are not possible on this.

create view EmpDetails as
select e.BusinessEntityID , e.JobTitle , e.Gender, e.HireDate ,e.SalariedFlag , p.FirstName
from HumanResources.Employee e join
Person.Person p
on (e.BusinessEntityID=p.BusinessEntityID)

select * from EmpDetails

Ab itni badi command ko bar bar chalane se behtar hai ek view bnalo or bar bar itna bada nahi likhna pdega seedhe view ke naam se call kr skte hai.

==========================================================================================================

21-04-2026
----------

Batches/Scripts , procedures, functions:

Batch: is series sql statements executed as a unit. A batch contain programming constructs (i.e if else , switch case , variables etc).
TQSL : Transact SQL Language

begin
.
.
.
end
Iske beech kuch bhi likhdo ek sang chlega.

begin
 create table sample
 insert into sample values() // not allow
end

# Declare variable like this..

begin
declare @num int
set @num=1
print @num
end


begin
declare @num int
select @num=id from products          //Last Value aa jaegi.
insert into productcopy values( @num , '',44)
print @num
end


to create copy of a table:
select * into <copytablename> from <sourcetablename>

....................................................................................................................................................

if u want to execute a batch frequently you have 2 solutions:
Save the batch in a .sql file of the local machine and this will lead to batches may lead to network congestion and server overhead.
Batch can be store in server also inside a Procedure is a database object (Procedure is a database object that store batches).


PROCEDURES:
_________________

sp_helptext <procedureName> to see whole code.

SYNTAX:

create procedure <procedureName>
as
begin
.
.
.
end

exec <procedureName>      //Not do network congestion kyuki 100 Bande 100 line ka batch bheje to dikkat hogi pr ab ek line reh gyi.

.........................................................................................................................

# Table of 5:

create procedure printTable
as
begin
	declare @num int=1
	while @num<=10
	begin
		print '5 * '+ cast(@num as char(3)) + ' = '+ cast(@num*5 as char(2))
		set @num=@num+1
	end
end

exec printable

sp_helptext printable     // this is use to get code

...............................................................................................................

create procedure printNewTable(@count int)
as
begin
	declare @num int=1
	while @num<=10
	begin
		print cast(@count as char(3)) + ' * '+ cast(@num as char(3)) + ' = '+ cast(@num*@count as char(2))
		set @num=@num+1
	end
end

exec printNewTable 4

.............................................................................................................................

Exersice : create a procedure to accept name and price of product as params and insert a new row to products table with values. and Id should be last id+1;

create or alter procedure InsertInTable(@name varchar(10), @price int)
as
begin
declare @id int
select @id = Max(id) from products
set @id=@id+1
insert into products values(@id,@name,@price)
end

exec InsertInTable 'bingo',5

select * from products

.............................................................................

//IN CASE RETURN VALUE
_______________________


create procedure addNum(@num1 int , @num2 int)
as
begin
return @num1+@num2
end

begin
declare @result int
exec @result = addNum 10,20
print @result
end

............................................................................

create or alter procedure addNum(@num1 int , @num2 int , @res int out)
as
begin
set @res = @num1+@num2
end

begin
declare @sum int
exec addNum 10,20,@sum out
print @sum
end

...................................................................................

create or alter procedure addNum(@num1 int , @num2 int , @res int out)
as
begin
set  @res = @num1+@num2
return 69
end

begin
declare @result int
declare @sum int
exec @result = addNum 10,20,@sum out
print @sum
print @result
end

...................................................................................

CASE IN SQL
___________

select EMPID, name,
case designation
when 'CEO' then 'Chief Election Officer'
when 'COO' then 'Chief Operating Officer'
else 'No Designation'
end as designation, salary
from EmployeesPay

...........................................................................................

SQL FUNCTIONS : are small programs which accept zero or more input as params and returns a single value as output.


create or alter function exptax(@ctc int)
returns float
as
begin
	declare @tax float
	if @ctc between 3100000 and 3500000
		set @tax = @ctc*0.5
	else
		if @ctc between 3500001 and 4500000
			set @tax = @ctc*1.0
	return @tax
end

begin
declare @tax float
exec @tax=exptax 3600000
print @tax
end

........................................................................................................................

create or alter function emptax(@ctc float)
returns float
as
begin
	declare @tax float
	if @ctc between 3100000 and 3500000
		set @tax = @ctc*0.5
	else
		if @ctc between 3500001 and 4500000
			set @tax = @ctc*1.0
	return @tax
end

select dbo.emptax(4000000)
select dbo.emptax(salary) as tax from EmployeesPay

_____________________________________________________________________________________________________________________________________________________

22-04-2026
___________


TRIGGERS:

Trigger is a database object like procedure and function called automatically :
Triggers are use for automation , ensuring data integrity.

.....................................................................................................
 
DML Triggers: execute automatically when a dml operation happen on a table or view.
DDL Triggers
Database Triggers

SYNTAX:
________

create or alter trigger <triggerName>
on <tableName/viewName>
after <DML Operation>
as
begin
<statements>
end


EXAMPLE
________

select * from products
select * from productcopytable

create or alter trigger trgCopyProduct
on products
after insert
as
begin
print 'Enty ni peru'
end

insert into products values(9,'peru',10)

select * from productcopytable

--------------------------------------------------------------------------

create or alter trigger trgCopyProduct
on products
after insert
as
begin
declare @id int
declare @name varchar(20)
declare @price int
select @id=id, @name=name, @price=price from inserted
insert into productcopytable values( @id , @name, @price)
end

select * from productcopytable

In this insert is magic table, means products pr triger kaam kr rha h neeche vale code me to jaise hi products me insert hoga uski last row
inserted magic table me aa jaegi and hm seedhe insert hone pr copy vali table me dal skte hai.


Primary Key check using Trigger

create table Associate(id int , name varchar(10),gender varchar(7))

insert into Associate values(null,'123','monkey')
insert into Associate values(2,'123','monkey')

select * from Associate

create or alter trigger trgPKAssociateId
on Associate
instead of insert,update
as
begin
declare @id int
select @id=id from inserted
declare @count int
select @count=count(*) from Associate where id=@id
if(@count>0 or @id is null)
	raiserror('Duplicate or Null Ids can not be inserted',12,12)
else
	insert into Associate values(@id, (select name from inserted),(select gender from inserted))
end

After ki bajae hmne instead of use kia hai, kyuki after me Pehle insert ho rha tha uske bad check hua to error aega hi aega but isme Pehle trigger chala phir check hua to chal gya.

.....................................................................................................................................................

UNPIVOT:
_________

To convert columns to rows, called unpivot.

syntax:
________

SELECT <static_columns>, <unpivoted_column_name>, <value_column_name>
FROM <table_name>
UNPIVOT (
<value_column_name> FOR <unpivoted_column_name> IN (<col1>, <col2>, <col3>, ...)
) AS unpvt;
 
eg:
USE [cognizant]
GO
 
/****** Object:  Table [dbo].[pvt]    Script Date: 22/04/2026 17:43:38 ******/
SET ANSI_NULLS ON
GO
 
SET QUOTED_IDENTIFIER ON
GO
 
CREATE TABLE [dbo].[pvt](
	[VendorID] [int] NULL,
	[Emp1] [int] NULL,
	[Emp2] [int] NULL,
	[Emp3] [int] NULL,
	[Emp4] [int] NULL,
	[Emp5] [int] NULL
) ON [PRIMARY]
GO
 
USE [cognizant]
GO
 
INSERT INTO [dbo].[pvt]
     VALUES(1,4,5,3,2,6),VALUES(2,5,3,2,6,2),VALUES(3,6,5,3,2,6)
GO
 
 
-- static column(vendorid),unpivoted colum(employee),valuecolumn(orders)
select vendorid,employee,orders from (
select vendorid,emp1,emp2,emp3,emp4,emp5 from pvt
) p
unpivot(orders for employee in
(
emp1,emp2,emp3,emp4,emp5
)
)as unpvt;
 
..............................................................................................................

Pivot:
________

converts rows to column

syntax:
 
SELECT <non-pivoted column>,
       [FirstPivotColumn], [SecondPivotColumn], ...
FROM
(
<SELECT query that produces the data>
) AS SourceTable
PIVOT
(
<aggregation_function>(<values column>)
    FOR <column to pivot> IN ([FirstPivotColumn], [SecondPivotColumn], ...)
) AS PivotTable;
eg:
select * from (select category,productid from productcategory) t
pivot(
count(productid)
for category in(
[Accessories],[Bikes],[Clothing],[Components]
)
) as pivottable

.....................................................................................................................................................

Table valued function :
___________________________


Table valued function returns a table as output.

There are two types of table valued function:

1.Inline table valued function
  	Returns a table directly from a single SELECT statement.
	No BEGIN...END block is used.
	Best for simple queries and better performance
  eg:
	create or alter function fnCategory(@category varchar(30))
	returns table
	as
	return (select * from ProductCategory where category=@category)
      usage:-select * from dbo.fnCategory('Bike')


2.Multi Statement Table Valued Function
	Allows multiple statements inside the function.
	You define a table variable, insert data into it, and return it.
	Useful for complex logic.
  eg:
	create or alter function fnGetPerson()
	returns @data table(
	id int,
	fullname varchar(100),
	designation varchar(50)
	)
	as
	begin
  		insert into @data
    		select p.businessentityid as id,
    		concat(p.firstname,p.middlename,p.lastname)as fullname,
    		e.JobTitle as designation
    		from Person.Person p join HumanResources.Employee e
    		on(p.BusinessEntityID=e.BusinessEntityID)
    	    return
	end


_____________________________________________________________________________________________________________________________________________

24-04-2026

Automatically Executed Triggers:
insert,update,delete
sp_help
sp_settriggerorder
fngetdetails
FIRST
Insert -- Trigger fire when insert and update operation.
	DML Timimgs:
	for,after,instead of


OLTP: Online transaction processing, table used by applications directly.
Warehouse : old data.
ex: Amazon me cart system hota h to cart ki ek table hogi database me , usme kitna data store krega to assume new data and previous data store kr lia OLTP me and baki data warehouse bhej dia.
AuditTrail : To monitor kisne kya add kia kb add kia.

example:

................................................................................................................

select * from products
select * into productlog from products

alter table productlog add done_by varchar(30) , tim_of_op datetime, operation varchar(10)

create or alter trigger auditProducts
on products
after insert, update, delete
as
begin
	declare @id int
	declare @name varchar(30)
	declare @price float
	if ((select count(*) from inserted)>0)
	begin
		select @id=id , @name=name, @price=price from inserted
		insert into productlog values (@id,@name,@price,user,GETDATE(),'Inserted')
	end

	if ((select count(*) from deleted)>0)
	begin
		select @id=id , @name=name, @price=price from deleted
		insert into productlog values (@id,@name,@price,(Select SUSER_SNAME() as currentLogin) ,GETDATE(),'Deleted')

	end
end

update products set price=50 where id=4
	select * from productlog
delete from products where id=3

................................................................................................................


trigger to stop dml operation outside office hours

create trigger stopop
on products
after insert,update,delete
as
begin
if(datepart(hh,getdate()) between 18 and 23)
  begin
    raiseerror('un authorized',15,2)
    rollback
  end
end

................................................................................................................

setcommand - union,unionall, -- data warehouse
unionn-- remove duplicate
unionall - keep duplicate
 
 
UNION
select category,subcategory,sum(listprice)as totalprice from productcategory
 
group by category,subcategory
 
union
 
select category,null,sum(listprice)as totalprice from productcategory
 
group by category
 
union
 
select null,subcategory,sum(listprice)as totalprice from productcategory
 
group by subcategory

 
**groupingset:-
select category,subcategory,sum(listprice)as totalprice from productcategory
group by grouping sets (
	(category,subcategory),
	(category),
	(subcategory))


select category,subcategory,sum(listprice)as totalprice from productcategory
group by category,subcategory
union
select category,null,sum(listprice)as totalprice from productcategory
group by category
union
select null,subcategory,sum(listprice)as totalprice from productcategory
group by subcategory

			| |
			| |

select category,subcategory,sum(listprice)as totalprice from productcategory
group by grouping sets ((category,subcategory),(category),(subcategory))


--------------------------------------------------------------------------------


Testing , NUnit, GroupingSets:

Testing -- Quality

Quality: Conformance Requirements.
Factors affecting Quality :
Affordability
Maintainability
Usability
Durability
Reliability

QA : Quality Assurance - is process which ensure that a quality product is produced at the end of the process.

To ensure Quality :
Quality System
Quality Process
Quality People

_____________________________________________________________________________________________________________________________________________

27-04-2026

CURSOR:

Cursor is a variable that store output of a select statement.

Declare Cursor   --  declare <cursorName> cursor for a <SelectCommand>
Open the cursor  --  open <cursorName>
Fetch and process from cursor  -- fetch <cursorName> into <VariableList>
Close Cursor
Deallocate
...............................................................

Mene 3 baar likha fetch vala, ab me 3 dafa run krunga to teeno time 1-1 table milegi next next hokr.
Pehle run me pehli table doosre me doosri teesre me teesri.

select * from Products

begin
declare @id int
declare @price float
declare @slno int
declare @name varchar(30)
declare pcursor cursor for select * from products
open pcursor
fetch pcursor into @id,@name,@price,@slno
fetch pcursor into @id,@name,@price,@slno
fetch pcursor into @id,@name,@price,@slno
select @id,@name,@price,@slno
close pcursor
deallocate pcursor
end

|||||||||||||||||

Ek hi run me sb aa gya.

select * from products

begin
declare @id int
declare @price float
declare @slno int
declare @name varchar(30)
declare pcursor cursor for select * from products
open pcursor
fetch pcursor into @id,@name,@price,@slno
while @@FETCH_STATUS = 0
	begin
		select concat(@id,'		',@name,'	 ',@price,'		 ',@slno)
		fetch pcursor into @id,@name,@price,@slno
	end
close pcursor
deallocate pcursor
end

............................................................................................................................................

MOQ:
_____

It is a library use to create dummy or proxy objects.

Model : Classes which contain only properties.
Repository: Classes contins code to perform CRUD Operations.
Services: Classes contain BusinessLogic, Validation , Transformation

____________________________________________________________________________________________________________________________________________________

28-04-2026

DAPPER:
______

It is a micro ORM Framework and provides a set of extention method.

namespace EntensionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string surname = new string("Goyal");
            Console.WriteLine(surname.Mukul());
        }
    }

    public static class MyExtentions
    {
        public static string Mukul(this string s)
        {
            return "Mukul " + s;
        }
    }
}

ORM: Object Relational Mapping -- Creating a table in the database of same structure of an existing class.
Migration: Process of converting objects to database table or vice versa.

.......................................................................................................................................................

29-04-2026

IDbConnetion --> SqlConnection

program.cs

main(){
	IDbConnection con = new SqlConnection(connstring)
	con.Execute("insert into products values(..,..,..);
	con.Dispose();
}

SqlConnection ek disposable class hai means classes jo Idispose ko inherit krti h , ye kya hai ab dekho ki kaii baar hme unmanage code smjho cpp ka likhna h memory issue krne ke lie jaise pointers to hm use (unsafe) ke neeche likhenge ab kaam hone ke bad mujhe jo unmanage code yani memory ko bhi release krna hai to me destructor ka use krke krunga( cons ka ulta , jo jb kaam krega jb class garbage collector me chali jaegi), ye to end me hoga but mujhe khudse krna hai to me dispose method ka use kr lunga jaisa upr kia but agr me using ke andr krunga to vo apne app hi Dispose kr dega.

			OR

main(){
	using(IDbConnection con = new SqlConnection(connstring)){            //Disposing
		con.Execute("insert into products values(..,..,..);
	}    //Automatically dispose will be called
}

Disposing is the process of releasing memory hold objects - Garbage Collector - runtime
GC.Collect() -> Will inform garbage collector to start disposing process.

Managed Code -- Code excuted by dotnet runtime
Unmanaged Code -- Code excuted by native runtime

.................................................................................................................................

ENTITY FRAMEWORK :
-------------------------

Build on top of ADO.NET Disconnected.

(OR MAPPING)
Model - Class - Mapped to table means table ke column ke name and class ke properties same hogi. Isme ye sb automatically hoga apne app table bnegi in sbse hme khud nahi krna hoga and this is called Migration.

DbContext - Class - All context classes must be derived from DbContext

Migration : Process of converting objects/classes to equivalent table.
Tools>Nugget package Manager > Console
Package-Entity framework tools and design
add-migration <migration Name>


__________________________________________________________________________________________________________________________________________________

30-04-2026

DbFirst Migration --> add-migration --> up and down functions
		      update-database --> call up function --> code to create table
		      drop-database --> call down method --> code to drop table
		      remove-migration --> Remove migration folder

It is opposite to codeFirst Migration , It generate model and context class from existing tables but CFM create table from Models and Classes.
Automatic code generation process is called SCAFFOLD

This command in tools>Pacakage manager console and table se sab uthkr mere models me class bankr aa jaega

scaffold-dbcontext "server=.\sqlexpress;initial catalog=ecommerce;integrated security=true;trustservercertificate=true"      Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

----------------------------------------------------------------------------------

Web Applications;
----------------

Appilcations deployed on web server and installed with middleware.

Traditional ->
	 Include client part and server part. Java, C#, Python . Client_server Side Script both in single project
	 .net framework - WebForms, MVC
	 dotnet 8 - RazorPages, MVC
 

Controller classes contains Action Methods and these methods are called when a request is being sent from client browser to server. These action methods may receive a Model class object as parameter or returns one or collection of model class objects as output.

Modern ->  Client server Side Script both in separate project

 
Model (classes that represent forms),Views(html pages),controller - business logic

Scaffolding:process of generating the code automatically
____________________________________________________________________________________________________________________________

06-05-2026
----------

LINQ ki jgh agr directly sql query bhejni h to --

_context.Database.ExecuteSqlRaw("Select * from items where id=1");
_context.Database.ExecuteSql($"Select * from items where id={id}");

----------------------------------------------------------------------

Lazy LOADING

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    //optionsBuilder.UseSqlServer(connstring);
    optionsBuilder
        .UseLazyLoadingProxies()    //Enable Lazy Loading. Child tables use krni h to krna pdega
        .UseSqlServer(@"server=.\sqlexpress;initial catalog=tomato;integrated security=true;trustservercertificate=true");
}

 CustomerRepository customerRepository = new CustomerRepository();
 customerRepository.GetCustomers().ToList().ForEach(customer =>
 {
     Console.WriteLine(customer.Name+" "+customer.Email) ;
     Console.WriteLine("orders of Customer "+ customer.Name);
     foreach (Order o in customer.Orders)
     {
         Console.WriteLine(o.GrossAmount);
     }
 });

Jb chahie tbhi milega data.
________________________________________________________________________________________________________________

EAGER LOADING

public List<Customer> GetCustomers()
{
    return _context.Customers.Include(cc=>cc.Orders).ToList();
}


If more than one icollection is present in Customer

return _context.Customers.Include(cc=>cc.Orders).ThenInclude(p=>p.payroll).ToList();

Ek sang hi sara data le aoo.
___________________________________________________________________________________________________________________

EXPLICIT LOADING

public List<Customer> GetCustomers()
{
    var customers = _context.Customers.ToList();
    foreach(Customer cust in customer){
	_context.Entry(cust).Collection(c=>c.Orders).Load();
    }
    return customers;
}


Jab mera man krega tbhi me ata load krunga.
___________________________________________________________________________________________________________________________________________________________

07-05-2026
----------

Net(8) sdk, language version12
After compilation msl code and assembly is there
 
Msilcode    >---Just in time compiler---->  native code --> runtime cpu execute it
AOT(Ahead Of Time):-
..net framework 1,4.8 --- windows
WCF:- windows communication foundation (Predecessor of REST API)
WPF:- Windows desktop application (RIA) Rich Internet Application , XAML (Extensible Application markup language),
Console,
Windows,
Xamarin :-  Used to build mobile apps (Android + iOS) using C#
Blazer:- Blazer web Assembly :- whole machine download in client machine and then run on client machine
, blazer Server
 
SSR (Server-Side Rendering):- Rendering the web page on the server first, and then sending the fully prepared HTML to the browser.
PWA (Progressive Web Application):- is a web application that behaves like a mobile app.
A PWA is a website that can install on your device, work offline, and feel like a real app
Dependency Injection
Providing (injecting) the required dependencies of a class from the outside instead of creating them inside the class.
 
ASP.net Runtime:- is the execution engine that runs ASP.NET web applications.
 
When Request is made and goes to server, the ASP.NET Runtime creates the Controller object automatically.
 
(Delegation of responsibly) :- Assigning a task or responsibility to another class/object instead of doing it yourself.
 
public class HomeController : Controller
{
   private readonly IService _service;
   public HomeController(IService service)
   {
       _service = service;
   }
}
 
In Program .cs
builder.Services.AddScoped<IService, Service>()>  // Delegated Responsibility

-----------------------------------------------------------------------------------------------
MODERN WEBAPP :- Front End -- backend
MVC -- return JSON-XML -- WEBAPI
 
API - is collection of function that perform operations

Distributed method :-
"A distributed method is a function that executes on a remote system and is accessed over a network instead of running locally."
 
Distributed Components (Contains Distributed Component) means:
Remoting:- uses client side proxies and ssp ,and both application must be in same language
Application parts are spread across multiple machines/servers
UI → Server → Database (different systems)
 
Web Services are used to connect distributed components
Frontend (Client)
        ↓
   Web Service (API)
        ↓
Backend (Server / Database)
 
Client-Side Proxy:-
A proxy that runs on the client application (browser or frontend app) to forward requests to another server.
Browser → CSP → Web Service → Server
 
Server-Side Proxy:-
An intermediate server that forwards requests from a client to another server and returns the response.
Client → Server Proxy → Web Service → Backend System
 
 
WebServies :-

WEBAPI:- req will be in form of http URL --- http://123.34.63.435/customer/create
REST API:- is kind of web API --- http://123.34.63.435/customer (ie no method will be mention in url)

 
DCOM(Distributed Component Object Nmodel)
CORBA (Common request Broken Architecture)
 
 
"REST API is an architectural style that allows communication between systems over HTTP using standard methods like GET, POST, PUT, and DELETE, and typically returns data in JSON format."
 
 
Rest handler call the function
Rest handler identify the which function to call from httpverb / httpmethod -- post ,put ,delete, patch, get, head etc.
Middleware receive req
 
REST API – Method Identification (Short Note)

REST API identifies which function to call using:
1. URL (Route)
2. HTTP Method (GET, POST, PUT, DELETE)
Rule:
Same URL + Different HTTP Method → Different Function

Example:
URL: /api/users
GET  /api/users  → calls GetUsers()
POST /api/users   → calls CreateUser()

In Controller:
[HttpGet]
GetUsers(){}
[HttpPost]
CreateUser(){}
Conclusion:
REST uses URL + HTTP verb to decide which method to execute.
 
Minimal
 
Npointname :- used to indetify the resource
To send post request to server we use api testing tool ex, postman
Quality :-Conformance to Requirements
QA:- is process to ensure quality product is deliver after devlopment'
 


___________________________________________________________________________________________________________________________________________________________

08-05-2026
----------
 
Web API kya hai?

Web API ek framework hai jiske zariye do softwares internet (HTTP) par ek dusre se baat kar sakte hain. Ye zaroori nahi ki wo sirf browser ke liye ho, ye mobile apps ya dusre servers ke liye bhi ho sakti hai.

Format: Ye XML, JSON, ya kisi bhi format mein data bhej sakti hai.

Protocol: Ye sirf HTTP/HTTPS protocol use karti hai.

-------------------

REST API kya hai?

REST (Representational State Transfer) koi protocol nahi, balki ek Architectural Style (design karne ka tarika) hai. Agar koi Web API kuch rules (constraints) follow kare, toh use hum RESTful API kehte hain.

Stateless: Har request apne aap mein complete hoti hai, server ko purani request yaad rakhne ki zaroorat nahi padti.

Methods: Ye standard HTTP verbs use karti hai:

GET (Data lene ke liye)

POST (Naya data create karne ke liye)

PUT (Data update karne ke liye)

DELETE (Data delete karne ke liye)

-----------------------

Minimal API Kya Hai?

Traditional APIs mein aapko Controllers, Actions, aur alag-alag folders ki zaroorat hoti thi. Minimal APIs mein aap seedha Program.cs file ke andar endpoints likh sakte hain. Ye un developers ke liye perfect hai jo Node.js (Express) ya Python (FastAPI) se C# mein aa rahe hain.


or agr isme apko controller bnana hai MVC type bnani hai to Main me

builder.Services.AddControllers();
app.MapControllers();         //Middleware Method

lgana pdega

----------------------

Client send request and that request go to middleware and then it pass to rest handler and then RH will pass it to the application and it goes to Main method first.
It work 2 times request coming and going.
___________________________________________________________________________________________________________________________________________________________

11-05-2026
----------

Ways to make Distributed Methods.

Java			Microsoft
RMI			Remoting   -- Client and component should be on same language
EJB			DCOM
WebService		WebService

WebAPI -- Action Methods -- Controllers -- http url -- Customer/...
RestAPI -- Action Methods -- Controllers  -- http url -- Customer      method is not needed that will be identified using http method like get put patch
grpc --

Rest API project -- Minimal and Controller based
Minimal API Project contains collection of remote distributed methods.
and we get app object and define routes.

app.MapGet("/Customer", ()=>{});
app.MapPost("/Customer", ()=>{});

Rest API is collection of distributed methods which is called by client apps by sending a http request and methods are identified by request type.


=======================================================================================================================================================

Stage 3:

11-05-2026
----------

Web Application -- Application is full fletch application that developer develope and users use. User send request.
Web API -- Used by developer to make application, Develper send request.

Both are stored into server.


DTO:
------

namespace AuctionAPI.Models
{
    public class Advertisement
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double BasePrice { get; set; }
        public string Description { get; set; }
        public string ItemImage { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public virtual ICollection<Bid>? Bids { get; set; }
    }
}



Mujhe user se sb kuch nahi lena input me but bhejna sb kuch hai to me ek dto class banaunga or usme bs vo sb lunga jo mujhe chahie...



namespace AuctionAPI.Models
{
    public class AdvertisementDto
    {
        public string ProductName { get; set; }
        public double BasePrice { get; set; }
        public string Description { get; set; }
        public string ItemImage { get; set; }
    }
}

Or controller me post me ye krunga

 public async Task<ActionResult<Advertisement>> PostAdvertisement(AdvertisementDto dto)
 {
     var advertisement = new Advertisement
     {
         ProductName = dto.ProductName,
         BasePrice = dto.BasePrice,
         Description = dto.Description,
         ItemImage = dto.ItemImage,
         CreateDate = DateTime.Now, // Server ka time, client se nahi lenge
         Bids = new List<Bid>()      // Empty list se initialize kiya taaki EF exception na de
     };

     try
     {
         // 3. Database me add aur save karna
         _context.Advertisements.Add(advertisement);
         await _context.SaveChangesAsync();

         // 4. Response bhejna (CreatedAtAction status code 201 deta hai)
         return CreatedAtAction(nameof(GetAdvertisement), new { id = advertisement.Id }, advertisement);
     }
     catch (DbUpdateException ex)
     {
         // Database level errors ko catch karne ke liye
         // Aap yahan logging bhi add kar sakte hain: _logger.LogError(ex, "Error saving advertisement");
         return StatusCode(500, "Database me data save karte waqt internal error aayi hai.");
     }
 }

-------------------------------------------------------------------------

APNE APP SE DATA BHEJNE KE LIE AISA KRNA HOGA

 HttpClient client = new();
 public async Task<List<Advertisement>> Index()
 {
     client.BaseAddress = new Uri("http://localhost:5100/");
     var result = await client.GetAsync("api/advertisements");
     if (result.IsSuccessStatusCode)
     {
         return await result.Content.ReadFromJsonAsync<List<Advertisement>>();
     }
     return null;
 }

 client.PostAsync("api/advertisements");

 client.PutAsync("api/advertisements");

 client.DeleteAsync("api/advertisements");


===========================================================================================================================================================

12-05-2026
----------

When Client send request to frontend it send to server and their are many clients and many request , like 100 clients can send 1000 request at the time lead to OVERHEAD and it affects performance which we can avoid by using SCALING.

SCALING:

Vertical Scaling : Improve capacity of server.
Horizontal Scaling : Keep the application on multiple server.

Divide project in small small projects containing single controller and model called monolithic application. This architecture is called MICROSERVICES.
																	    --------------
Ab itni sari services hai to ar service ka alag ip address bhi hoga to uske lie ek or API bnaenge GATEWAY use ye hoga ki developer ko bs ek IP yaad rakhna pdega and u automatically request ko aage bhejta rhega.

Ab Pehle ek db hota tha ab db bhi multiple hai to foreign key relation nahi ban skta uss case me ek api doosri api ko request bhejegi use bolenge hm
INTER SERVICE COMMUNICATION:
EventGrid -- ServiceBus
EventBus
Kafka -- EventStreaming Services  ----- much faster than API calls

-------------------

Razor Syntax - cshtml
HTML Helpers -- View(List), ViewBag , Viewdata

===========================================================================================================================================================

13-05-2026
----------

 
Micro Service -- It is a design pattern which divide monolithic api into small units called services.

Rest Api me Rest Handler method type se call krta h but agr method same hai jaise 2 post ho gye to AMBIGUITY aa jaegi mtlb rest handler nahi smjh paega kise call krna hai .											   ---------
To solve it we use attribute based routing,

[HttpPost]
[Route("register")]
public void Post([FromBody] Staff staff){}

[HttpPost]
[Route("login")]
public void Validate([FromBody] LoginModel Login){}


JSON WEB TOKEN:
-------------------------

Token:User information in encrypted format.

{"header":{},"payload":{},"signature":{}};

After Encryption : dgdghhdslkjlwij.sjdgkdshkjnsdl.sdjgdsjjdj

Payload:
{
   "Name" : "Mukul",
   "Password" : 1232
}


if we make any function authorized function then rest handler will look for authorization key inside jwt in header



===========================================================================================================================================================

19-05-2026
----------

@{} razor syntax

polygot --- storing data according to user perspective


===========================================================================================================================================================

20-05-2026
----------

GATEWAYS:

Add empty web project.
Install ocelot package
add an json file (ocelot.json)
add upstream path names and downstream path in the json file.
donfigure thw ocelot in program.cs


===========================================================================================================================================================

21-05-2026
----------

views , strongly typed
html
html helpers
@HTML.TextBox("email","Enter your name") - <input type=text name=email placeholder="Your Name">
@HTML.TextBoxFor(m=>m.Password)

Custom Helper Method -> static methods returning HTML Elements -> Documentation
Assignment -> Create a custom helper method which return a login UI



DISCOVERY -- Gateway ocelot json file se uthata h IPs but agr time to time IPs change hongi to dikkt hogi to uss case me use hota h discovery.
Consul -- provides middleware function to perform discovery.
Provisioning needs to happen dynamically
Reflection: Code written to read and understand attribute and its value, class and its properties.


Aspect Oriented Programming:
---------------------------

Aspect -- Cross cutting concerns (Overlapping Requirements), developing these aspects as a seperate pluggable module is called Aspect Oriented Programming.
 	  ----------------------
mtlb ki jaise 2 controller hai unhe kya code repeat ho rha  kya common hai jaise exception handling.
Filters- A way to implement AOP , plug and remove anytime.
ActionFilters - class contain func to be executed vefore and after action methods.

class AssetActionFilter:IActionFilter{

}


===========================================================================================================================================================

22-05-2026
----------

Discovery Patterns:
------------------

Discovery Patterns -- micro services -- dynamic scaling -- Gateways

Consul application use in Discovery.


===========================================================================================================================================================

25-05-2026
----------
 
Docker,Azure
Logging in asp.net mvc, Introduction to typescript language.

=======================================================================================================================================================

Stage 4:


ANGULAR:
------------

Framework to develop frontend part of the modern web application.
javascript framework  helps to simplify the single page application. It allows developer to use html code for dom manipulation. Event handling code need written in typescript.
Some other similar frameworks
===========================
Vue --
Ionic
Ember
React - it is a library (javascript/typescript)
Typescript - object oriented, strongly typed, is an extension of javascript.
traspilation - converting typescript to javascript
install typescript transpiler- npm install -g typescript
to convert typescript to javascript
===============
tsc <filename.ts>
eg:tsc first.ts -> will generate first.js
and run
using:- node first.js


____________________________________________________________________________________________________________


26-05-26:
--------

interface Asset{
    name:string,
    type:string
}

interface PropertyAsset extends Asset{
    location:string
}

function readAsset(a:Asset):void{
    console.log(a.name);
}

readAsset({name:"Mukul",type:"Man"})

-------------------------------------------------

type Vehicle = {
    make:string,
    model:string,
    year:number
}

function showVehicle(v:Vehicle){
    console.log(`make:${v.make} model:${v.model} year:${v.year} `)
}

showVehicle({make:"Honda",
    model:"2024",
    year:2026})


We can use INTERFACE and TYPE as class in TYPESCRIPT.
and INTERFACE can be inherited.

___________________________________________________________________________________________

Type can't be inherited so we can extend like this , now Car has vehicles properties too

type Car = Vehicle & {
    doors:number
}

_____________________________________________________________________________________________________

class Patient{
    id?:number
    private name:string = 'Mukul'
    protected age?:number

    constructor(id:number,name:string,age:number){
        this.id=id
        this.name=name
        this.age=age
    }

    show(){
        console.log(`${this.id} ${this.name} ${this.age}`);
    }
}

let p1 = new Patient(1,'Mukul',45);
p1.show();

THIS IS EQUIVALENT TO |
		      v

class Rogi{
    constructor(private id :number, public name :string, public age :number){}

    show(){
        console.log(`${this.id} ${this.name} ${this.age}`);
    }
}

let p2= new Rogi(2,'Mukul',20);
p2.show();

_____________________________________________________________________________________________________

FRAMEWORK - Partial implementation of application.

To install Angular - npm install -g @angular/cli
To check installed - ng version
To make project - ng new <NameOfProject>
To run app - ng serve

____________________________________________________________________________________________________________


27-05-26:
--------

<app-root>  -- is a selector , behind selector a partial html,css,ts code is present.
selector - is an alias name to a component(partial html,css,ts)
 
an angular application is a collection components.
routing - loading components on demand/rendering component
to render a component in placeholder area - uses the selector name of the component
app component - <app-root>
custom components:- components created by the developer.
option1:create one typescript file which contains html,css,typescript(inline template)
option2: create separate html,css and typescript
to create a new component
ng generate component <name of the component>
eg: ng g c navigation
ng g c register --skip-tests - skip test file creation
@Component({
  selector: 'app-register',
  imports: [],
  template: `<p>register works!</p>`,
  styles: ``,
})
decorator - similar to attributes c#
services,components,directives,modules(optional)
 
event binding - associating eventhandler functions with html template
syntax (eventname)="eventhadler()"
databinding - associate data from typescript to template
property binding-
syntax- property={{data}} - {{}} -interpolation
eg: <input placeholder={{email}}/>
[property]="variable" -- property binding syntax


____________________________________________________________________________________________________________


27-05-26:
--------

Routing Steps:

Add a placeholder in the root component html - <router-outlet></router-outlet>
Create the route table and enable routing of components whereever needed. -- app.routes.ts
Use @angular/routing module to perform the routing.


=========
Services |
=========

Special types of classes that can be injected to other classes. (Dependency Injection). Normally these classes business logic of the application.

Marked with @Injectable() decorator

@Injectable()
export class Vehicles{}

ng g s <ServiceName>
ng g s services/Vehicle   services is folder name and Vehicle is service inside

Service class is use to share data between 2 components.

____________________________________________________________________________________________________________

29-05-26:
--------

services, routing

DIRECTIVES -- Programs that give instruction to Angular.

TYPES:

Attribute/Property Directive -- Make changes to property/attribute.
Structural Directive -- Changes structure of UI
Custome Directive -- *ngfor , *ngif , @for , @if


____________________________________________________________________________________________________________________________________________________________

01-06-26:
---------
 
agenda
--------
distributing apps  and deployment/installing of apps
basics virtualisation, containerization
------------------
Legacy ways- setup project , xcopy
Virtualisation -- is a way to distribute apps. in this  process of creating a virtual machine contains app+ bin+lib+os
and to run the virtual machine in the target client machine we need a hypervisor(eg:virtual box,VMWare)
hypervisor installs and run the virtualised application
types of hypervisors
---------------------
type1 - bare metal - directly interact with kernel and hardware
type2 - hosted  - interact with host os
disadvantage: occupies lot of memory and disk space hence slow down the application.
------------------
containerization  -- is a way to distribute application
================
Here the and app along with its bins/libs added to an image  called container image.
And containerization software provides os environment in the target machine so no os layer is needed in the image thus reduces size and improves performance.
 
Example of containerization software, Docker, OpenShift etc
 
Docker Hub: a Server where docker images of apps can be stored
----------
to containerise a dotnet web app
1. Add a Dockerfile  to the application root.
docker file contains docker commands(eg:copy,run,build,workdir,etc) to build the docker image of the application.
2.docker build - command to create the docker image
	syntax : docker build -t<tagname> <path of the docker file>
	docker build -t dotnetdockerwebapp  .
 
to run the containerized application
   command :- docker run -n <containername> <imagename>
     eg: docker run -n container1   dotnetdockerwebapp
 
copy of the docker image running in the memory is called container-
-----------------------------------------------------------------
to pull images from docker hub
docker pull <tagname/imagename>
eg: docker pull anilthirumala/itcdocker:ver1
to see how many containers are running
  c:\> docker ps
To stop a docker container
  c:\> docker stop <containername/id>
	eg: docker stop container1
To restart a docker container
   c:\> docker start <containername/id>
	eg:docker start container1
To remove the docker container from memory
   c:\> docker rm <containername/id>
	eg: docker rm container1
To remove a docker image from machine
	docker rmi <imagename>
eg: docker rmi dotnetdockerwebapp:ver1


DockerDesktop

____________________________________________________________________________________________________________________________________________________________

02-06-26:
---------

Distriubution  				---- 		Deployement

Provide app to the client.				Copying app into client's machine.
Floppy disk
CD Roms with setup project
virtualization (virtual machines)
Containerization


____________________________________________________________________________________________________________________________________________________________

11-06-26:
---------

AZURE Category of services:

Iaas -- Infrastructure as a service -- Virtual Machine
Saas -- Software as a service -- SQL Server, Office 365
Paas -- Platform(Pre Configured Machine) as a service -- App Service
Serverless


-------------------------------------------------------------------------------------

=======================================================================================================================================================

Things to remember during developing web API in dot Net8.0


appsettings.json

ADD Connection String:
  "ConnectionStrings": {
    "ServiceCenterDb": "Server=.\\sqlexpress;initial catalog=StaffDb;User Id=sa;Password=winner@123;trustservercertificate=true;"
  }

------------

Context class

public class ServiceCenterContext: DbContext
{
    public ServiceCenterContext(DbContextOptions<ServiceCenterContext> options) : base(options)
    {
    }
    public DbSet<ServiceCenter> ServiceCenters { get; set; }
}

----------------

program.cs

// Add your database
   builder.Services.AddDbContext<Models.ServiceCenterContext>((options) =>
      options.UseSqlServer(builder.Configuration.GetConnectionString("ServiceCenterDb"))
   );


---------------

Create API Controller and ServiceCenterServices inside Services folder and write business logic inside services and CRUD operations in controller
 





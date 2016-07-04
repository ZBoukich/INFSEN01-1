// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System

type Occupation = 
        |Student 
        |Docent 

type Calculate = 
        |Add 
        |Subtract 
        |Sum 
        |Divide 
        |Modulo 

type User ={
        Name:string;
        Age: int;
        Occupation: Occupation
        CalculationRequest : Calculate option
       }
       
// Functions to perform calculations
let sum (x:int, y:int)= x+y
let subtract (x:int, y:int)= x-y
let multiply (x:int, y:int)= x*y
let divide (x:int, y:int)= x/y

//Recursion call to calculate factorial of number
let rec factorial (num:int) (acc:int)=
    if num =1 then acc
    else factorial(num-1)(acc*num)

// Check whether it's a Student or Docent
let checkOccupation s : Occupation=
          match s with
          | "Student"->Occupation.Student
          | "Docent"-> Occupation.Docent

// Check which calculate have been requested, handle accordingly
//let checkCalculateRequest s : Calculate=
let checkCalculationRequest request (x,y) =
         match request with
         |"sum"-> sum (x,y)
         |"subtract"->subtract(x,y)
         |"multiply"->multiply(x,y)
         |"divide"->divide(x,y)
            
        
//Extract all even numbers and return the list
let rec getEvenNumbers (ls:List<'a>) (acc:List<'a>)=
        match ls with
        |[]-> List.rev acc
        |x::xs when x%2=0 -> getEvenNumbers xs (x::acc)
        |_::xs -> getEvenNumbers xs acc


//Extract all odd numbers and return the list
let rec getOddNumbers (ls:List<'a>) (acc:List<'a>)=
        match ls with
        |[]-> List.rev acc
        |x::xs when x%2=1 -> getOddNumbers xs (x::acc)
        |_::xs -> getOddNumbers xs acc


[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    let mutable loop = true
    while loop do
        printfn "Welcome, What's your name, age, occupation and calculationrequest?"
      
        printfn "Name: "
        let nameValue = Console.ReadLine()
        let name:string = string nameValue
        printfn "Age: "
        let ageValue = Console.ReadLine()
        let age : int = int32 ageValue
        printfn "Occupation? Student or Docent: "
        let occupationValue = Console.ReadLine()
        let oc : string = string occupationValue

        let occupation = checkOccupation oc

        // Create user with values entered
        let user = { Name= name; Age = age; Occupation= occupation;  CalculationRequest= None}
       
        printfn "Hi %s your age is (%i) and occupation %A ,a record have been created for you!" user.Name user.Age user.Occupation 

        //Choose a calculating request sum subtract multiply divide
        printfn "Perform a nice calculation of numbers. Choose to sum, subtract, divide or multiply "
        let calculateRequest = Console.ReadLine()
        let request : string = string calculateRequest

        printfn "you request the %s calculating" request

        printfn "Enter two numbers"
        printfn "first number: "
        let firstNumber = Console.ReadLine()
        let first:int = int32 firstNumber
        printfn "second number: "
        let secondNumber = Console.ReadLine()
        let second:int = int32 secondNumber

        printfn "Here we go"
        let value = checkCalculationRequest request (first, second)
        printfn "Result of calculation: %A "value

        //Recursive functie
        printfn "Demo for Recursion Call on list"
        printfn "Enter size of list"
        let sizeList = Console.ReadLine()
        let size:int = int32 sizeList
        let ls =[1..size]
        printfn "Here we go"
        printfn "filter elements by even numbers"
        let values = getEvenNumbers ls []
        printfn "value: %A "values
        printfn "filter elements by odd numbers"
        let values = getOddNumbers ls []
        printfn "value: %A "values
              
    //End
        printfn "Try again? 'y' or 'n' "
        let answer = Console.ReadLine()
        if answer = "n" 
            then
            loop <- false
     
    0 // return an integer exit code

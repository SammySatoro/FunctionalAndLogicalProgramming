open System

//Multiplying digits of number
//vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
let rec multDigitsUp (n:int) =
    if n = 0 then 1
    else (n % 10) * multDigitsUp(n / 10)    

let multDigitsDown (n:int) = 
    let rec subMultDigitsDown (n:int) curMult = 
        if n = 0 then curMult   
        else
            let nextN = n / 10
            let nextDigit = n % 10
            let nextMult = curMult * nextDigit
            subMultDigitsDown nextN nextMult
    subMultDigitsDown n 1
//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

//Finding max digit of number
//vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
let rec findMaxDigitUp (n:int) = 
    if n < 10 then n
    else 
        max (n % 10) (findMaxDigitUp (n / 10))

let findMaxDigitDown (n:int) = 
    let rec subFindMaxDigitDown (n:int) curMax =
        if n = 0 then curMax
        else
            let nextMax = 
                if n % 10 > curMax then n % 10 
                else curMax
            let nextN = n / 10
            subFindMaxDigitDown nextN nextMax
    subFindMaxDigitDown n (n % 10)
//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
  
//Finding min digit of number
//vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
let rec findMinDigitUp (n:int) =
    if n < 10 then n
    else
        min (n % 10) (findMinDigitUp (n / 10))

let findMinDigitDown (n:int) =
    let rec subFindMinDigitDown (n:int) curMin =
        if n = 0 then curMin
        else
            let nextMin = 
                if n % 10 < curMin then n % 10
                else curMin
            let nextN = n / 10
            subFindMinDigitDown nextN nextMin

    subFindMinDigitDown n (n % 10)
//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

[<EntryPoint>]
let main argv =    
    printf "Enter a number: "
    let n = Console.ReadLine() |> Int32.Parse
    printf "Product of digits (up): \t %A \n" (multDigitsUp n)
    printf "Product of digits (down): \t %A \n" (multDigitsDown n)
    printf "Maximal digit (up):     \t %A \n" (findMaxDigitUp n)
    printf "Maximal digit (down):   \t %A \n" (findMaxDigitDown n)
    printf "Minimal digit (up):     \t %A \n" (findMinDigitUp n)
    printf "Minimal digit (down):   \t %A \n" (findMinDigitDown n)
    0

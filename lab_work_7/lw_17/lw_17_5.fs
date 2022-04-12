module lw_17_5

let createList n = List.init(n) (fun i -> System.Console.ReadLine()|>System.Int32.Parse)

let isPrime n =
    let rec loop n div counter =
        if div <= 0 then counter = 2
        else if n = 1 then true
        else
            let nextCounter = counter + if n % div = 0 then 1 else 0
            let nextDiv = div - 1
            loop n nextDiv nextCounter
    loop n n 0
            
                
let findPrimes n = 
    let rec loop n div primesList =
        match div with       
        |div when div <> 0 ->
            let nextPrimesList = primesList @ [div]
            let nextDiv = div - 1
            if n % div = 0 && isPrime div then loop n nextDiv nextPrimesList
            else loop n nextDiv primesList
        |div -> primesList
    loop n n []


let buildStrangeList list =
    let listOflistsOfDivs = List.map (fun i -> findPrimes i) list
    let listOfListsOfContained = List.map (fun i -> List.map (fun j -> List.contains j list) i) listOflistsOfDivs
    List.map2 (fun i j -> if List.contains false i then [] else [j]) listOfListsOfContained list |> List.collect (fun i -> i)

let ForDemo17 = 
    printfn "%A" (buildStrangeList [52;2;1;34;100;71;7;14;25]) //[2; 1; 71; 7; 14] 

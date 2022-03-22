open System

let processAnswer  answer = 
    match answer with
        |"F#"|"Prolog"-> "Sycophant!"
        |other -> "You're goddamn psychopath!"
   
[<EntryPoint>]
let main argv =
    printf "Which programming language do you like the most?: " 
    let answer = Console.ReadLine()
    Console.WriteLine(processAnswer answer)
    0

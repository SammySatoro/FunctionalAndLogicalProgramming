open System

let processAnswer  answer = 
    if (answer = "F#" || answer = "Prolog") then "Sycophant!"
    else "You're goddamn right!"

[<EntryPoint>]
let main argv =
    printf "Which programming language do you like the most?: " 
    let answer = Console.ReadLine()
    Console.WriteLine(processAnswer answer)
    0

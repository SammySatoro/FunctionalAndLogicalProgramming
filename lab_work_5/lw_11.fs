open System

let processAnswer  answer = 
    match answer with
        |"F#"|"Prolog"-> "Sycophant!"
        |"C++"|"c++"|"Cxx"|"cxx"|"CXX"-> "Just don't talk to me anymore..."
        |"C#"-> "Already tried Unity?"
        |"JavaScript"|"javascript"-> "It ain't Java, you know that?"
        |"Java"-> "I've played Minecraft too"
        |"Python" -> "..."
        |other -> "You're goddamn psychopath!"
    
[<EntryPoint>]
let main argv =
    printf "Which programming language do you like the most?: " 
    let answer = Console.ReadLine()
    Console.WriteLine(processAnswer answer)
    0

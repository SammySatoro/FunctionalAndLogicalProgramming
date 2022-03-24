open System
   
[<EntryPoint>]
let main argv =
    let processAnswer answer = 
        match answer with
            |"F#"|"Prolog"-> "Sycophant!"
            |"C++"|"c++"|"Cxx"|"cxx"|"CXX"-> "Just don't talk to me anymore..."
            |"C#"-> "Already tried Unity?"
            |"JavaScript"|"javascript"-> "It ain't Java, you know that?"
            |"Java"-> "I've played Minecraft too"
            |"Python" -> "..."
            |other -> "You're goddamn psychopath!"
    printf "Which programming language do you like the most?: " 
//12.1
    (Console.ReadLine>>processAnswer>>Console.WriteLine)()
//12.2
    printfn "Which programming language do you like the most?: "
    let answer input (output:string->unit) chooser = output (chooser (input ()))
    answer Console.ReadLine Console.WriteLine processAnswer
    0

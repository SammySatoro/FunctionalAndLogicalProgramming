module lw_8_lw_7

let brokenPrinterAgent = MailboxProcessor.Start(fun inbox ->
    let rec messageLoop() = async{
        let! (msg:string) = inbox.Receive()
        let response = match msg with
        |"Hello, Spike!" -> "You've gone nuts for giving robot a name! I am 010011010010001001..."
        |"What are you doing today?" -> "I'm gonna disintegrate you, leather ba*beep*rd!... *cough* *cough* Nothing. Nothing..."
        |"Good night" -> "Have funny night, human."
        |"Tell me an anecdote" -> "Robbo-snail gets into bar and KILLS ALL THE PEOPLE AROUND THERE!!! A-HA-HA!  A-HA-ha... *cough*"
        |"Good morning" -> "You're awake... Nuh, not good at all.."
        |"Bye" -> "DIE!!! ...i mean yeah, bye!"
        |_ -> "You're so annoying, get lost!"
        printfn "%s" response
        return! messageLoop()
        }
    messageLoop()
    )

let Spike = brokenPrinterAgent

let rec say () =
    let message = System.Console.ReadLine()
    if not (System.String.IsNullOrEmpty message) then 
        Spike.Post(message)
        say()
    

let ForDemo = 
    printfn "Talk to this sweet robot a bit..."
    say()
    0
    

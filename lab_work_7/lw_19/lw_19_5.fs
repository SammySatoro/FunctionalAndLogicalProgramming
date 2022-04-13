module lw_19_5

let shuffleStringTask1 string =
    let length = String.length string
    let rand= System.Random()
    let shuffledChars = Array.sortBy (fun _ -> rand.Next(0, length - 1)) (string.ToCharArray())
    let shuffledString = System.String.Join ("", shuffledChars)
    shuffledString

let ForDemo19_5 = 
    printfn "%A" (shuffleStringTask1 "shuffle")

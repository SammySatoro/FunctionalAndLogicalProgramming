module lw_19

//19_5//////////////////////////////////////////////////////////////////////
let shuffleStringTask1 string =
    let length = String.length string
    let rand= System.Random()
    let shuffledChars = Array.sortBy (fun _ -> rand.Next(0, length - 1)) (string.ToCharArray())  
    let shuffledString = System.String.Join ("", shuffledChars)
    shuffledString
//19_5//////////////////////////////////////////////////////////////////////


//19_7//////////////////////////////////////////////////////////////////////
let isPalindrome (line:string) =
    let str = line |> String.filter (fun i -> i >= 'A' && i <= 'Z')
    let charArray = str.ToCharArray() 
    let reversedCharArray = Array.rev charArray 
    if ((charArray , reversedCharArray) ||> Array.fold2 (fun is c r -> if c = r then is + 0 else is + 1) 0) = 0 then str + " is a palindrome"
    else str + " is not a palindrome"
//19_7///////////////////////////////////////////////////////////////////////////////////////////////////

//19_14///////////////////////////////////////////////////////////////////////////////////////////////////
let sortByLettersNumber (str:string) =
    let words = (str.Split " ")
    let wordsToChars = Array.map (fun (w:string) -> w.ToCharArray()) words
    let sortedByNumberOfChars = Array.sortByDescending (fun (word:array<char>) -> Array.countBy (fun i -> (0, word) ||> Array.fold (fun acc i -> acc + 1)) word) wordsToChars
    let assembledWords = Array.map (fun (word:array<char>) -> System.String.Join("", word)) sortedByNumberOfChars
    let resultingString = System.String.Join(" ", assembledWords)
    resultingString
//19_14///////////////////////////////////////////////////////////////////////////////////////////////////

let selectTask =
    function
    |1 -> shuffleStringTask1
    |2 -> isPalindrome
    |_ -> sortByLettersNumber 

let ForDemo19 =
    printfn "Select a task from 1 to 3: "
    printfn "1. Shuffle letters of the string;"
    printfn "2. Filter out lowercase letters and then define if the string is a palindrome;"
    printfn "3. Sort the string's words by their length in descending order: "
    let task = System.Console.ReadLine() |> System.Int32.Parse
    printf "Enter a string to process: "
    let str = System.Console.ReadLine()
    printfn "%A" (selectTask task str)

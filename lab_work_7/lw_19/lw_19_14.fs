module lw_19_14

let sortByLettersNumber (str:string) =
    let words = (str.Split " ")
    let wordsToChars = Array.map (fun (w:string) -> w.ToCharArray()) words
    let sortedByNumberOfChars = Array.sortByDescending (fun (word:array<char>) -> Array.countBy (fun i -> (0, word) ||> Array.fold (fun acc i -> acc + 1)) word) wordsToChars
    let assembledWords = Array.map (fun (word:array<char>) -> System.String.Join("", word)) sortedByNumberOfChars
    let resultingString = System.String.Join(" ", assembledWords)
    resultingString
    

let ForDemo19_14 = 
    printfn "%A" (sortByLettersNumber "qwer tyuiopa sd fgh jklz xc c vbn m")
    

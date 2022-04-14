module lw_20_5

let ratingInAlphabet = [|8.17; 1.49; 2.78; 4.25; 12.7; 2.23; 2.02; 6.09; 6.97; 0.15; 0.77; 4.03; 2.41;                                           
                                      6.75; 7.51; 1.93; 0.1; 5.99; 6.33; 9.06; 2.76; 0.98; 2.36; 0.15; 1.97; 0.07|] 

let lines = [|"gg sh hjfsjgh fgh fsgh";
                    "afsag vxcz bhgf dhf dfgad";
                    "gg s gh hjffsdf";
                    "nvbxgf sh hjfsjghfds fgh fsa gh";
                    "fdg gg s hh hjhfh fsjg hfghh fgh fsgh";
                    "siuf sfsdnf sgaoidngu";
                    "qho fosdhfo igjgfgf oig";
                    "q pofipfsafgurgjg gdjg  fg d g";|]
  
let rateInAlpOfMostRatedLetter (char:char)= 
     if (System.Char.IsLower char) then ratingInAlphabet.[(int)char - 97]   
     else ratingInAlphabet.[(int)char- 65]

let findQuadraticDeviations (linesArray:array<string>) =
    let arrayOfArraysOfChars = linesArray |> Array.map (fun line -> line.ToCharArray())    
    let arrayOfNumbersOfTheMostRatedChars  =  
        arrayOfArraysOfChars 
        |> Array.map (fun line -> line |> Array.countBy (fun i -> i)  |> Array.sortByDescending snd) |> Array.map (fun pair -> Array.head pair)

    let arrayOfRatingsOfTheMostRatedInLines = 
        (arrayOfNumbersOfTheMostRatedChars, linesArray)
        ||> Array.map2 (fun (pair:char*int) (line:string) -> (float)(snd pair) / (float)(String.length line) * 100.0) 

    let arrayOfRatingsOfTheMostRatedInAlphabet =
        arrayOfNumbersOfTheMostRatedChars
        |> Array.map (fun pair -> rateInAlpOfMostRatedLetter (fst pair))

    let arrayOfQuadraticDeviations =
        (arrayOfRatingsOfTheMostRatedInAlphabet, arrayOfRatingsOfTheMostRatedInLines)
        ||> Array.map2 (fun rateAlph rateLine -> (rateAlph - rateLine)*(rateAlph - rateLine))

    arrayOfQuadraticDeviations
  
let sortByQuadraticDeviations strings =
    let pairsStringQD =
        (strings, findQuadraticDeviations strings)
        ||> Array.map2 (fun str qd -> (str, qd))
    Array.sortBy snd pairsStringQD |> Array.map (fun pair -> fst pair) 
 
let printStrings strings = 
    strings |> Array.map (fun str -> printfn "%A" str)
        
let ForDemo20_5 =
    printStrings(sortByQuadraticDeviations lines)

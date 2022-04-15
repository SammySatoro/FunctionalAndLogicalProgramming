module lw_20_5

let ratingInAlphabet = [|8.17; 1.49; 2.78; 4.25; 12.7; 2.23; 2.02; 6.09; 6.97; 0.15; 0.77; 4.03; 2.41;                                           
                                      6.75; 7.51; 1.93; 0.1; 5.97; 6.33; 9.06; 2.76; 0.98; 2.36; 0.15; 1.97; 0.07|] 

let lines = [|  "gg sh hjfsjgh fgh fsgh";
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

let findQuadraticDeviation (str:string) =
    let rec findMostRatedCharAndItsRate str id mostRatedChar max=
        if id = String.length str then (mostRatedChar, ((float)max / (float)(String.length str) * 100.0))
        else 
            let nextMax =  str |> String.filter (fun c -> str.[id] = c) |> String.length
            if nextMax > max then findMostRatedCharAndItsRate str (id + 1) (str.[id]) nextMax 
            else findMostRatedCharAndItsRate str (id + 1) mostRatedChar max
    let mostRatedChar, mostRatedCharRate = findMostRatedCharAndItsRate str 0 str.[0] 0
    let quadraticDeviation = ((rateInAlpOfMostRatedLetter mostRatedChar) - mostRatedCharRate)**2.0
    quadraticDeviation

let sortByQuadraticDeviation (linesArray:array<string>) = linesArray |> Array.sortBy (fun line -> findQuadraticDeviation line)
 
let printStrings strings = 
    strings |> Array.map (fun str -> printfn "%A" str)


let ForDemo20_5 =
    printStrings (sortByQuadraticDeviation lines)

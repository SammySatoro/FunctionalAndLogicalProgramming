module lw_20

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

let printStrings strings = 
    strings |> Array.map (fun str -> printfn "%A" str)
////First method/////////////////////////////////////////////////////////////////
let rateInAlpOfMostRatedLetter (char:char)= 
     if (System.Char.IsLower char) then ratingInAlphabet.[(int)char - 97]   
     else ratingInAlphabet.[(int)char- 65]

let findQuadraticDeviationMethod1 (str:string) =
    let rec findMostRatedCharAndItsRate str id mostRatedChar max=
        if id = String.length str then (mostRatedChar, ((float)max / (float)(String.length str) * 100.0))
        else 
            let nextMax =  str |> String.filter (fun c -> str.[id] = c) |> String.length
            if nextMax > max then findMostRatedCharAndItsRate str (id + 1) (str.[id]) nextMax 
            else findMostRatedCharAndItsRate str (id + 1) mostRatedChar max
    let mostRatedChar, mostRatedCharRate = findMostRatedCharAndItsRate str 0 str.[0] 0
    let quadraticDeviation = ((rateInAlpOfMostRatedLetter mostRatedChar) - mostRatedCharRate)**2.0
    quadraticDeviation
////First method/////////////////////////////////////////////////////////////////
////Second method/////////////////////////////////////////////////////////////////
let findAverageWeight (str:string) =
    (float)([|0 .. (String.length str) - 1|] 
    |> Array.map (fun ind -> (int)str.[ind]) 
    |> Array.sum) 
    / (float)(String.length str)

let findMaxAverageTriple (str:string) =
    (float)(([|0 .. (String.length str) - 3|], [|1 .. (String.length str) - 2|], [|2 .. (String.length str) - 1|]) 
    |||> Array.map3 (fun i1 i2 i3 ->  (int)(str.[i1]) + (int)(str.[i2]) + (int)(str.[i3]))
    |> Array.max)
    / (float)(String.length str)

let findQuadraticDeviationMethod2 (str:string) = (findAverageWeight str - findMaxAverageTriple str) ** 2.0
////Second method/////////////////////////////////////////////////////////////////
let qdSelection = 
    function
    |1 -> findQuadraticDeviationMethod1
    |_ -> findQuadraticDeviationMethod2

let sortByQuadraticDeviation (linesArray:array<string>) (choice:int) = 
    linesArray |> Array.sortBy (fun line -> qdSelection choice line)

let ForDemo20 =
    printf "Select the method you'd like to apply (1 or 2): "
    let choice =  System.Console.ReadLine() |> System.Int32.Parse
    let sortedLines = sortByQuadraticDeviation lines choice
    printStrings sortedLines

module lw_20_8

let lines = [|  "gg sh hjfsjgh fgh fsgh";
                    "afsag vxcz bhgf dhf dfgad";
                    "gg s gh hjffsdf";
                    "nvbxgf sh hjfsjghfds fgh fsa gh";
                    "fdg gg s hh hjhfh fsjg hfghh fgh fsgh";
                    "siuf sfsdnf sgaoidngu";
                    "qho fosdhfo igjgfgf oig";
                    "q pofipfsafgurgjg gdjg  fg d g";|]

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

let findQuadraticDeviation (str:string) = (findAverageWeight str - findMaxAverageTriple str) ** 2.0
    
let sortByQuadraticDeviation (linesArray:array<string>) = 
    linesArray |> Array.sortBy (fun line -> findQuadraticDeviation line)
 
let printStrings strings = 
    strings |> Array.map (fun str -> printfn "%A" str)
 
let ForDemo20_8 =
    printStrings (sortByQuadraticDeviation lines)

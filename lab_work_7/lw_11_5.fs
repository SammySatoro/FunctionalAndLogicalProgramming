module lw_11_5
open System

let rec createList n = List.init(n) (fun i -> Console.ReadLine()|>Int32.Parse)

let isGlobalMin list index=
    let minItem = List.min list
    let itemByIndex = List.item index list
    minItem = itemByIndex
        
let ForDemo11 = printfn "%A" (isGlobalMin (createList 10) 5)
    

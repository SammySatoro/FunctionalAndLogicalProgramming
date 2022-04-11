module lw_12_15
open System

let isLocalMin list index a b = 
    let localChunk = (List.skip (a + 1) list) |> List.take (b - a - 1)
    let localMin = List.min localChunk
    index = localMin

let ForDemo12 = printfn "%A"  (isLocalMin [0;1;2;3;4;5;6;7;5;2;3;5;56;7;8] 3 2 6) // true

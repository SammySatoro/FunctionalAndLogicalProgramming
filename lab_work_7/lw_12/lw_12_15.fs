module lw_12_15
open System

let isLocalMin list index = 
    let localChunk = (List.skip (index - 1) list) |> List.take (3)
    let localMin = List.min localChunk
    List.item index list = localMin

let ForDemo12 = printfn "%A"  (isLocalMin [2;1;1;3;4;5;1;7;5;2;3;5;56;7;8] 6) // [5;1;7] true

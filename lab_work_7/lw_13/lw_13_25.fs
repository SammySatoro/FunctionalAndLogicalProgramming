module lw_13_25

let maxBetween list a b = 
    let localChunk = (List.skip (a + 1) list) |> List.take (b - a - 1)
    List.max localChunk

let ForDemo13 = printfn "%A"  (maxBetween [2;1;1;3;4;5;1;7;5;2;3;5;56;7;8] 2 7) // [3;4;5;1]  5

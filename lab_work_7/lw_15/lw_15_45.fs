module lw_15_45

let sumBetween (list:List<int>) a b = (List.filter (fun i -> a < i && i < b) list) |> List.sum

let ForDemo15 = 
    printfn "%A" (sumBetween [1;6;2;7;3;7;2;6;1] 0 5) // 9

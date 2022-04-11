module lw_16_55

let sortByNumber list =
    let listOfPairs = list |> List.countBy id |> List.sortByDescending snd
    List.collect (fun pair -> List.filter (fun i -> (fst pair) = i) list) listOfPairs

let ForDemo16 = 
    printfn "%A" (sortByNumber [3;5;3;1;5;6;1;1;6;1;6;3;2;3;3;1;1;1]) //[1; 1; 1; 1; 1; 1; 1; 3; 3; 3; 3; 3; 6; 6; 6; 5; 5; 2]

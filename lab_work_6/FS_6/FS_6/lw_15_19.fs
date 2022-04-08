module lw_15_19

let len list = 
    let rec loop list length =
        match list with
        |head::tail ->
            let nextLength = length + 1
            loop tail nextLength
        |[] -> length
    loop list 0
    
let shiftToRight (list:List<int>) =
    let rec loop list shiftedList listLength = 
        match list with 
        |head::tail ->
            let nextList = if listLength > 0 then (shiftedList @ [head]) else head::shiftedList
            let nextListLength = listLength - 1
            loop tail nextList nextListLength
        |[] -> shiftedList
    loop list [] (len list - 1)

let ForDemo15_19 = 
    let list = [0;1;100;3;4;5;6;-50;8]
    printfn "%A" (shiftToRight list)
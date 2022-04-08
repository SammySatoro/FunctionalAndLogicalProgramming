module lw_17_29

let findMaxItemIndex list =
    let rec loop list max index maxIndex = 
        match list with
        |head::tail ->
            let nextMax = if max <= head then head else max
            let nextMaxIndex = if max <= head then index else maxIndex
            let nextIndex = index + 1
            loop tail nextMax nextIndex nextMaxIndex
        |[] -> maxIndex
    loop list list.Head 0 0

let containsMax list a b = 
    let max = findMaxItemIndex list
    if a <= max && max <= b then true
    else false

let ForDemo17_29 = 
    let list = [0;1;-50;-50;4;5;6;-50;5;-50]
    printfn "%A" (containsMax list 1 6)

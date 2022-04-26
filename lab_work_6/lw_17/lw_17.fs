module lw_17_29

let findMax list = 
    let rec loop list min = 
        match list with
        |head::tail ->
            let nextMin = if min <= head then head else min
            loop tail nextMin
        |[] -> min
    loop list list.Head

let findMinInds list a b= 
    let rec loop list indList index max =
        match list with
        |head::tail -> 
            let nextIndList = if head = max && a<= index && index <= b then (indList @ [index]) else indList @ []
            let nextIndex = index + 1
            loop tail nextIndList nextIndex max
        |[] -> indList
    loop list [] 0 (findMax list)

let containsMax list a b = 
    let maxs = findMinInds list a b
    match maxs with
    |[] -> false
    |_ -> true

let ForDemo17_29 = 
    let list = [0;1;-50;-50;4;3;5;-50;5;-50]
    printfn "%A" (containsMax list 1 6)

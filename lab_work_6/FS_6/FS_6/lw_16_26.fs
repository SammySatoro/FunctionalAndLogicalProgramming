module lw_16_26

let findMin list = 
    let rec loop list min = 
        match list with
        |head::tail ->
            let nextMin = if min >= head then head else min
            loop tail nextMin
        |[] -> min
    loop list list.Head

let findMinInds list = 
    let rec loop list indList index min =
        match list with
        |head::tail -> 
            let nextIndList = if head = min then (indList @ [index]) else indList @ []
            let nextIndex = index + 1
            loop tail nextIndList nextIndex min
        |[] -> indList
    loop list [] 0 (findMin list)

let countBetweenMins list = 
    let rec loop indList first item =
       match indList with
       |head::tail ->
            loop tail first head
       |[] -> item - first - 1
    let indList = findMinInds list 
    loop indList indList.Head indList.Head
            

let ForDemo16_26 = 
    let list = [0;1;-50;-50;4;5;6;-50;5;-50]
    printfn "%A" (countBetweenMins list)

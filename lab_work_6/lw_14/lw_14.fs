module lw_14_17

let findMinItemIndex list =
    let rec loop list min index minIndex = 
        match list with
        |head::tail ->       
            let nextMin = if min >= head then head else min
            let nextMinIndex = if min >= head then index else minIndex
            let nextIndex = index + 1
            loop tail nextMin nextIndex nextMinIndex
        |[] -> (minIndex, min)
    loop list list.Head 0 0
 
let findMaxItemIndex list =
    let rec loop list max index maxIndex = 
        match list with
        |head::tail ->
            let nextMax = if max <= head then head else max
            let nextMaxIndex = if max <= head then index else maxIndex
            let nextIndex = index + 1
            loop tail nextMax nextIndex nextMaxIndex
        |[] -> (maxIndex, max)
    loop list list.Head 0 0

let swapMinWithMax list =
    let rec loop list minInd maxInd index min max procList=
        match list with
        |head::tail ->
            let item = if index = minInd then max 
                       else if index = maxInd then min
                       else head
            let nextList = procList @ [item]   
            let nextIndex = index + 1            
            loop tail minInd maxInd nextIndex min max nextList
        |[] -> procList
    let minRes = findMinItemIndex list
    let maxRes = findMaxItemIndex list
    loop list (fst minRes) (fst maxRes) 0 (snd minRes) (snd maxRes) []
    
            

let ForDemo14_17 = 
    let list = [0;1;100;3;4;5;6;-50;8;1000]
    printfn "%A" (swapMinWithMax list)


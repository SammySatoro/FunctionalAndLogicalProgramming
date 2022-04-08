module lw_20_53

let findMax list = 
    let rec loop list max = 
        match list with
        |head::tail ->
            let nextMax = if max <= head then head else max
            loop tail nextMax
        |[] -> max
    loop list list.Head

let quantifyAverage list =
    let rec loop list sum count = 
        match list with
        |head::tail ->
            let nextSum = sum + (abs head)
            let nextCount = count + 1
            loop tail nextSum nextCount
        |[] -> (float)sum / (float)count
    loop list 0 0

let buildList list = 
    let rec loop list max avg resList=
        match list with
        |head::tail ->
            let nextResList = resList @ (if (float)head > avg && head < max then [head]
                                         else [])
            loop tail max avg nextResList
        |[] -> resList
    loop list (findMax list) (quantifyAverage list) []

let ForDemo20_53 = 
    let list = [1;2;3;4;5;6;7;8;9;1]
    printfn "%A" (buildList list)

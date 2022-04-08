module lw_13_12

let findMinItemIndex list =
    let rec loop list min index minIndex = 
        match list with
        |head::tail ->       
            let nextMin = if min >= head then head else min
            let nextMinIndex = if min >= head then index else minIndex
            let nextIndex = index + 1
            loop tail nextMin nextIndex nextMinIndex
        |[] -> minIndex
    loop list list.Head 0 0
 
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

let reposition list minItemInd maxItemInd=
    let rec loop list minInd maxInd repList index = 
        match list with
        |[] -> repList
        |head::tail ->
            if index <= minInd then
                let nextRepList = repList @ [head]
                let nextIndex = index + 1 
                loop tail minInd maxInd nextRepList nextIndex
            else 
                let rec subLoop section repSection upperEdge index indCounter =
                    match section with
                    |[] -> (repSection, indCounter)
                    |head::tail ->
                        if index < upperEdge then 
                            let nextRepSection = head::repSection
                            let nextIndex = index + 1
                            let nextIndCounter = indCounter + 1
                            subLoop tail nextRepSection upperEdge nextIndex nextIndCounter
                        else 
                            let nextRepSection = repSection @ [head]
                            let nextIndex = index + 1
                            let nextIndCounter = indCounter + 1
                            subLoop tail nextRepSection upperEdge nextIndex nextIndCounter  
                let subLoopRes = subLoop list [] maxInd index 0
                let endIndex = index + (snd subLoopRes)
                let nextRepList = repList @ (fst subLoopRes)
                loop [] minInd maxInd nextRepList endIndex
    loop list (min minItemInd maxItemInd) (max minItemInd maxItemInd) [] 0

let ForDemo13_12 = 
    let list = [0;1;100;3;4;5;6;-100;8]
    let minItemInd = findMinItemIndex list
    let maxItemInd = findMaxItemIndex list
    printfn "%A" (reposition list minItemInd maxItemInd)
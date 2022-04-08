module lw_12_5

let findMin list =
    let rec loop list min = 
        match list with
        |head::tail ->
            let nextMin = if min >= head then head else min
            loop tail nextMin
        |[] -> min
    loop list list.Head
 
let isGlobalMin list index = 
    let rec loop list index min is = 
        match list with
        |head::tail ->          
            if index <> 0 && index >= 0 && index < list.Length then 
                let nextIndex = index - 1
                loop tail nextIndex min is
            else
                if head = min then is = true
                else is = false          
        |[] -> is
    let min = findMin list
    loop list index min true

let ForDemo12_5 = printfn "%A" (isGlobalMin [7;4;9;4;-2;4;6] 4)
    

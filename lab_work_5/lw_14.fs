open System

let processDivisorsOfNumber n func initial =
    let rec subProcessDivisorsOfNumber n func initial curDiv = 
        if curDiv = 0 then initial
        else
            let nextInitial = 
                if n % curDiv = 0 then func initial curDiv
                else initial
            let nextDiv = curDiv - 1
            subProcessDivisorsOfNumber n func nextInitial nextDiv
    subProcessDivisorsOfNumber n func initial n

[<EntryPoint>]
let main argv =    
    printf "Sum of divisors: %A" (processDivisorsOfNumber 15 (fun x y -> x + y) 0)
    0

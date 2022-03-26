let rec findGCD x y = 
    if x = 0 || y = 0 then x + y
    else 
        let nextX = 
            if x > y then x % y
            else x
        let nextY = 
            if x <= y then y % x
            else y
        findGCD nextX nextY

let processDivisorsOfNumber n func initial =
    let rec loop n func initial curDiv = 
        if curDiv = 0 then initial
        else
            let nextInitial = 
                if n % curDiv = 0 then func initial curDiv
                else initial
            let nextDiv = curDiv - 1
            loop n func nextInitial nextDiv
    loop n func initial n

let roundPrime (n:int) func initial = 
    let rec loop n func initial exp =
        if exp <= 0 then initial
        else
            let nextInitial =
                if  findGCD n exp = 1 then func initial exp
                else initial
            let nextExp = exp - 1           
            loop n func nextInitial nextExp  
    loop n func initial n

// 17.1
let processDivisorsWithCondition (n:int) func cond initial =
        let subFunc initial div = 
            if cond div then func initial div
            else initial
        processDivisorsOfNumber n subFunc initial

// 17.2
let roundPrimesWithCondition (n:int) func cond initial = 
    let subFunc initial div = 
        if cond div then func initial div
        else initial
    roundPrime n subFunc initial

[<EntryPoint>]
let main argv =           
    printfn "17.1: %A" (processDivisorsWithCondition 9 (fun x y -> x + y) (fun d -> d > 5) 0)
    printf "17.2: %A" (roundPrimesWithCondition 9 (fun x y -> x + y) (fun d -> d % 2 = 1) 0)
    0 

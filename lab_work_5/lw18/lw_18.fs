//First method vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
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

let FirstMethod (n:int) func cond initial =
        let subFunc initial div = 
            if cond div then func initial div               
            else initial
        processDivisorsOfNumber n subFunc initial
//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

[<EntryPoint>]
let main argv =           
    let n = (FirstMethod 15 (fun x y -> x + 1) (fun d -> d % 3 <> 0) 0)
    printfn "Number of divisors not divisible by 3: %A" n // 1, 5 (2)
    0 

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

//Second Method vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
let secondMethod n cond = 
  let rec loop n cond curMin = 
    if n % 10 = 0 then curMin
    else 
      let nextMin = 
        if (curMin > (n % 10) && cond (n % 10)) then n % 10
        else curMin
      let nextN = n / 10
      loop nextN cond nextMin
  loop n cond n % 10
//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

[<EntryPoint>]
let main argv =           
    let n = (FirstMethod 15 (fun x y -> x + 1) (fun d -> d % 3 <> 0) 0)
    printfn "Number of divisors not divisible by 3: %A" n // 1, 5 (2)
    printfn "Minimal odd of number: %A" (secondMethod 515633454 (fun c -> c % 2 <> 0))// (1)
    0 

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

// Third Method vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
let findGCD x y =
  let rec loop x y =
    if x * y = 0 then x + y
    else
      let nextX = 
        if x > y then x % y
        else x
      let nextY =
        if x <= y then y % x
        else y
      loop nextX nextY
  loop x y

let processDigits n func oper= 
  let rec loop n func accum = 
    if n <= 0 then accum
    else 
      let nextAccum = func accum (n % 10)
      let nextN = n / 10
      loop nextN func nextAccum
  loop n func oper

let thirdMethod n =
  let rec loop n sum curDiv =
    if curDiv <= 0 then sum
    else 
      let nextSum = 
        sum + (if (n % curDiv = 0 && findGCD (processDigits n (fun x y -> x + y) 0) curDiv = 1 &&  findGCD (processDigits n (fun x y -> x * y) 1) curDiv <> 1) then curDiv else 0) 
      let nextDiv = curDiv - 1
      loop n nextSum nextDiv
  loop n 0 n
//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
[<EntryPoint>]
let main argv =           
//First method
    let n = (FirstMethod 15 (fun x y -> x + 1) (fun d -> d % 3 <> 0) 0)
    printfn "Number of divisors not divisible by 3: %A" n // 1, 5 (2)
 //Second method   
    printfn "Minimal odd of number: %A" (secondMethod 515633454 (fun c -> c % 2 <> 0))// (1)
//Third method
    printfn "Sum of divisors that are mutually prime with sum and not mutually prime with product of the number's digits: %A" (thirdMethod 14) // 14   1 2 7 14
    printfn "Sum of digits: %A" (processDigits 14 (fun x y -> x + y) 0) // 5    1 5
    printfn "Product of digits: %A" (processDigits 14 (fun x y -> x * y) 1) // 4    1 2 4
    0 

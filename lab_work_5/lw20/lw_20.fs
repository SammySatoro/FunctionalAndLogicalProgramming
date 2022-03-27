open System

let firstMethod n  =
    let rec loop n count curDiv = 
        if curDiv = 0 then count
        else
            let nextCount = 
                if n % curDiv = 0 && curDiv % 3 <> 0 then count + 1
                else count
            let nextDiv = curDiv - 1
            loop n nextCount nextDiv
    loop n 0 n


let secondMethod n = 
  let rec loop n curMin = 
    if n % 10 = 0 then curMin
    else 
      let nextMin = 
        if (curMin > (n % 10) && (n % 10) % 2 <> 0) then n % 10
        else curMin
      let nextN = n / 10
      loop nextN nextMin
  loop n n % 10


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

let multDigits n = 
  let rec loop n accum = 
    if n <= 0 then accum
    else 
      let nextAccum = accum * (n % 10)
      let nextN = n / 10
      loop nextN nextAccum
  loop n 1

let sumDigits n = 
  let rec loop n accum = 
    if n <= 0 then accum
    else 
      let nextAccum = accum + (n % 10)
      let nextN = n / 10
      loop nextN nextAccum
  loop n 0

let thirdMethod n =
  let rec loop n sum curDiv =
    if curDiv <= 0 then sum
    else 
      let nextSum = 
        sum + (if (n % curDiv = 0 && 
                    findGCD (sumDigits n) curDiv = 1 &&  
                    findGCD (multDigits n) curDiv <> 1) then curDiv 
                    else 0) 
      let nextDiv = curDiv - 1
      loop n nextSum nextDiv
  loop n 0 n


//20///////////
let chooseFunction =
    function
    |1 -> firstMethod
    |2 -> secondMethod
    |_ -> thirdMethod


[<EntryPoint>]
let main argv =
    printfn "Enter two numbers: function number and its argument: "
    let options = 
        (Console.ReadLine() |> Int32.Parse, 
         Console.ReadLine() |> Int32.Parse)
    printfn "%A" (chooseFunction (fst options) (snd options))
    0 

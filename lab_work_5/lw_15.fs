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
    

[<EntryPoint>]
let main argv =       
    printf "Sum of mutually prime numbers: %A" (roundPrime 9 (fun (x:int) (y:int) -> x + y) 0)
    0 

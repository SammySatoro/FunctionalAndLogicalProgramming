module lw_8_lw_5

type MyOption<'T> =
    |None
    |Some of 'T

let mapMyOption func value =
    match value with
    |Some T -> Some (func T)
    |None -> None

let (<*>) func value =
    match func, value with
    |Some f, Some v -> Some (f v)
    |_ -> None

let applyMyOption2 value func=
    match func, value with
    |Some f, Some v -> Some (f v)
    |_ -> None

let monadMyOption func opt =
    match opt with
    |Some x -> func x
    |None -> None

//let bind func opt =
//         match opt with
//         |Some x -> func x
//         |None -> None

let (>>=) x func = monadMyOption func x

let isPositive num =
    match num with
    |0 -> None
    |x -> Some (x > 0)
    
let ForDemo = 
    
    // 1. Functor is something that is mappable in elevated world
    // 2. Applicative something that can define apply and return
    // 3. Monad is somthing that can define bind and return
    // BIND is a function that takes a function that takes a "normal" value (int, float, etc) and return elevated value
    // 4. TO LIFT something means that something has been lifted to the elevated world 

    //    Для произвольно выбранного типа данных 
    //реализуйте функции функтора, аппликативного функтора, монады.
    //Проверьте для Вашей реализации справедливость соответствующих
    //законов для функтора и аппликативного функтора (тех законов, которые
    //можно проверить с использованием F#). Некоторые законы могут не
    //выполняться. Это означает что данный тип не является в полной мере
    //функтором, аппликативным функтором, монадой.

    // 1. Functor law. Lifting the function doesn't affect the result ((id -(map)> lifted id) = id )
    let id x = x 
    printfn "1. Functor law. Lifting id function doesn't affect the result: \n Lifted %A = NOT Lifted %A \n" (mapMyOption id (Some 5)) (id (Some 5))
    // 2. Functor law. Composition of lifted f and g functions is equivalent of lifted composition. 
    //----------------------------------------------------------------------------------------
    //    [lifted f] [lifted g] --compose-> [lifted h]                                                                                                                                                       
    //          ^            ^                                 ^                                                                                                                                                    
    //        map       map                            map       = Same function                                                                                                                                                          
    //           |             |                                  |                                                                                                                                                       
    //          [f]          [g]      --compose->     [h]
    //----------------------------------------------------------------------------------------
    printfn "2. Functor law: "
    let func_f x = x + 1
    let func_g x = x * 2
    let some_1 = mapMyOption func_f (Some 2)
    let some_2 = mapMyOption func_g (some_1)
    printfn "Composition of lifted f and g functions = %A" (some_2)
    let some_1_2 = mapMyOption (func_f >> func_g) (Some 2)
    printfn "Lifted composition = %A \n\n" (some_1_2)

    // Applicative contains RETURN function and APPLY function
    // RETURN lifts a value
    // APPLY applies lifted function to lifted value(s)
    // If data type meets following signature then the data type is APPLICATIVE
    //-----------------------------------------------------------------------------------
    // [E<a -> b>] --apply-> [E<a>] -> [E<b>]       [E<a>] -> [E<b>]
    //        ^                                                    =              ^
    //    return                                                              map
    //         |                                                                     |
    //    [a -> b]                                                          [a] -> [b]   
    //-----------------------------------------------------------------------------------
    // However, it's necessary that following 4 laws are fulfilled:
    // 1. Applicative law
    // Applying ID function to lifted value is equivalent to applying not lifted ID function to not lifted value.
    printfn "Applicative laws: "
    printfn "1."
    let law11 = id 1
    let law12 = (Some id) <*> (Some 1)
    printfn "BOTH NOT LIFTED = %A \nBOTH LIFTED = %A" (law11) (law12)
    // 2. Applicative law
    printfn "\n2."
    //If y=f(x), then lifting f function and x value and then applying to them APPLY function will lead to the same result as lifting y.
    let law2_f = fun x -> x + 1
    let law2_x = 9
    let law2_y = (Some (law2_f law2_x))
    let law2_y2 = (Some law2_f) <*> (Some law2_x)
    printfn "Lifted y = %A\nLifted y and x, then APPLIED = %A" (law2_y) (law2_y2)
    // 3. Applicative law
    printfn "\n3."
    //Arguments can be swapped:
    let law31 = (Some (fun x -> x * 2)) <*> (Some 4)
    //Cannot be swapped 'cause F# doesn't support that feature.
    //Therefore it's necessary to wrire another function "applyMyOption2"
    let law32 = applyMyOption2 (Some 4) (Some (fun x -> x * 2))     
    printfn "NOT SWAPPED = %A\nSWAPPED = %A" (law31) (law32)
    printfn "Since we were forced to create a new function to make it meet third law,\nthe law in fact is not fulfilled!"
    // 4. Applicative law
    // Composition of APPLY functions is associative.
    printfn "\n4."
    printfn "The fourth law cannot be fulfilled because the \"<*>\" operator doesn't support associative laws"
    printfn "\nJust for demonstration of monad (Some 5 >>= isPositive): %A" (Some 5 >>= isPositive)

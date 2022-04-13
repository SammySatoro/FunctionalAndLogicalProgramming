module lw_18_5

let createArrays2 n n2 =
    let arr1 = Array.filter (fun i -> i >= 0 && i <= 9) (Array.init(n) (fun i -> System.Console.ReadLine()|>System.Int32.Parse))
    let arr2 = Array.filter (fun i -> i >= 0 && i <= 9) (Array.init(n2) (fun i -> System.Console.ReadLine()|>System.Int32.Parse))
    arr1, arr2


let differenceOfArrays (arr1, arr2) = 
     let a = arr1 |> Array.rev |> Array.indexed |> Array.map (fun i -> (float)(snd i) * (10.0 ** (float)(fst i))) |> Array.sum |> int32
     let b = arr2 |> Array.rev |> Array.indexed |> Array.map (fun i -> (float)(snd i) * (10.0 ** (float)(fst i))) |> Array.sum |> int32
     a - b
    
let ForDemo18 =
    let arrays = createArrays2 4 2
    printfn "%A" (arrays)
    printfn "%A" (differenceOfArrays arrays)

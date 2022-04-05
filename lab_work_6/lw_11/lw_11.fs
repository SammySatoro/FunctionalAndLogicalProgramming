open System

let rec createList size = 
    if size <= 0 then []
    else 
        let head = Console.ReadLine() |> Int32.Parse
        let tail = createList (size - 1)
        head::tail

let rec writeList list = 
    match list with
    |head::tail ->
        printfn "%O" head
        writeList tail
    |[] -> ()

let foo11 list func = 
    let rec loop list func nextList = 
        match list with
        |item_0::tail ->
            let item_1 = if tail <> [] then tail.Head else 1
            let item_2 = if tail <> [] then (if tail.Tail <> [] then tail.Tail.Head else 1) else 1
            let applyFunc = func item_0 item_1 item_2
            let nextNextList = nextList @ [applyFunc]
            let shiftedList =  if tail <> [] then (if tail.Tail <> [] then tail.Tail.Tail else []) else []
            loop shiftedList func nextNextList
        |[] -> nextList
    loop list func []
[<EntryPoint>]
let main argv = 
    printfn "Enter the number of list elements and the elements: "
    let list = (foo11 (createList (Console.ReadLine() |> Int32.Parse)) (fun a b c -> a + b + c))
    writeList list     
    0

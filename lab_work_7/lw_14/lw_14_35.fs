module lw_14_35

let findClosest item list = 
    let differences = List.map (fun i -> abs (item - i)) list
    List.item (List.findIndex (fun i -> i = List.min differences) differences) list

let ForDemo14 =
    let R = 1.0
    printfn "%A" (findClosest R [1.4;-2.0;3.33;-4.0;0.7;4.0])
    

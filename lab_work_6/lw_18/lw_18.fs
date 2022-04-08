module lw_18_41

let quantifyAverage list =
    let rec loop list sum count = 
        match list with
        |head::tail ->
            let nextSum = sum + (abs head)
            let nextCount = count + 1
            loop tail nextSum nextCount
        |[] -> (float)sum / (float)count
    loop list 0 0

let ForDemo18_41 = 
    let list = [1;2;3;4;5;6;7;8;9;10]
    printfn "%A" (quantifyAverage list)

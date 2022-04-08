module lw_19_49

let isPrime item = 
    let rec loop item div count = 
        if div <= 0 then (count <= 2)
        else
            let nextDiv = div - 1
            if item % div = 0 then
                let nextCount = count + 1               
                loop item nextDiv nextCount
            else
                loop item nextDiv count
    loop item item 0

let findPrimes item =
    let rec loop item div list = 
        if div <= 0 then list
        else
            let nextDiv = div - 1
            if item % div = 0 && isPrime div then               
                loop item nextDiv (list @ [div])
            else 
                loop item nextDiv list
    loop item item []

let containsItem list item =
    let rec loop list item flag =
        match list with
        |head::tail -> 
            if head = item then 
                loop [] item true
            else 
                loop tail item flag
        |[] -> flag
    loop list item false

let buildList list = 
    let rec loop list uniqueList =
        match list with
        |head::tail ->            
            let rec subLoop localList tempList =
                match localList with
                |h::t ->
                    let nextTempList = if containsItem uniqueList h then tempList @ []
                                       else tempList @ [h]
                    subLoop t nextTempList
                |[] -> tempList
            let nextUniqueList = uniqueList @ subLoop (findPrimes head) []
            loop tail nextUniqueList 
        |[] -> uniqueList
    loop list []

let ForDemo19_49 =
    let list = [1;2;3;4;5;6;7;8;9;10;26;43;56]
    printfn "%A" (buildList list) // 1 2 3 5 7 13 43

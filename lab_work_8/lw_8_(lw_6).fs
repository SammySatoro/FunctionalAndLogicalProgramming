module lw_8_lw_6
open FParsec

//Разработайте программу, которая осуществляет разбор текста с
//использованием библиотеки FParsec. Результатом разбора должны быть
//значения алгебраического типа.

type Expr =
    |Num of float
    |Plus of Expr * Expr
    |Minus of Expr * Expr

let pstring_ws s = spaces >>. pstring s .>> spaces 
let float_ws  = spaces >>. pfloat .>> spaces

let parseExpression, implementation = createParserForwardedToRef<Expr, unit>()
let parsePlus = tuple2 (parseExpression .>> pstring_ws  "+" ) parseExpression |>> Plus
let parseMinus = tuple2 (parseExpression .>> pstring_ws  "-" ) parseExpression |>> Minus 
let parseOp = between (pstring_ws "(") (pstring_ws ")") (attempt parsePlus <|> parseMinus)
let parseNum = float_ws |>> Num
implementation := parseNum <|> parseOp

let rec EvalExpr(e:Expr):float =
    match e with
    | Num(a) -> a
    | Plus(a,b) | Minus(a,b) ->
        let right = 
            match b with
            | Num(num) -> num
            | Plus(_,_) | Minus(_,_) -> EvalExpr b
        let left = 
            match a with
            | Num(num) -> num
            | Plus(_,_) | Minus(_,_) -> EvalExpr a       
        match e with
        | Plus(_,_) -> left + right
        | Minus(_,_) -> left - right
        | _ -> EvalExpr(b)

let ForDemo = 
    let text = "((2 + 2) - 1)"
    let expr1Parser = run parseExpression text
    printfn "%A" (expr1Parser)
    match expr1Parser with
        | Success(result, _, _) ->
            let eval1 = EvalExpr(result)
            printfn "Result of computation: %f" eval1
        | Failure(errorMsg, _, _) -> printfn "Failure: %s" errorMsg

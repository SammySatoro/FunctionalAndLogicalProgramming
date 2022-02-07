open System

[<EntryPoint>]
let main argv =
    let a = Convert.ToDouble(Console.ReadLine())
    let b = Convert.ToDouble(Console.ReadLine())
    let c = Convert.ToDouble(Console.ReadLine())
    let d = b * b - 4.0 * a * c
    if (d = 0.0)
    then
        let x = -b/(2.0*a)
        Console.WriteLine(String.Concat("x1 = ", " ", -b/(2.0*a)))
    if (d > 0.0)
    then
        Console.WriteLine(String.Concat("x1=", (-b - Math.Sqrt d)/(2.0*a), " ", "x2=", (-b + Math.Sqrt d)/(2.0*a)))
    else
        Console.WriteLine("No solutions!");
    0

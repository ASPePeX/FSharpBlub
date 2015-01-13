// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv = 

    let n = 46

    let rec fib x = 
        if x <= 2 then 1
        else fib(x-1) + fib(x-2)
        
    let timeStart = System.DateTime.Now.TimeOfDay

    let fibs1 =
        [ for i in 0..n -> fib(i) ]

    let timeEnd1 = System.DateTime.Now.TimeOfDay

    let fibs2 =
        Async.Parallel [ for i in 0..n -> async { return fib(i) } ]
        |> Async.RunSynchronously

    let timeEnd2 = System.DateTime.Now.TimeOfDay

    0 // return an integer exit code

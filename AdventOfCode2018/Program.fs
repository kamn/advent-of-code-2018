// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System
module c1 =  Challenge1
[<EntryPoint>]
let main argv = 
    c1.solve ()
    printfn "Press Enter to exit"
    Console.ReadLine() |> ignore
    0 // return an integer exit code

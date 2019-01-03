// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System
module c1 =  Challenge1
[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    c1.solve ()
    Console.ReadLine()

    0 // return an integer exit code

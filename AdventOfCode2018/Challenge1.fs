module Challenge1

open System
open System.IO

let newlineChars = [|"\r\n"; "\n"; "\r"|]

let readFile fileName =
    let text = File.ReadAllText(Environment.CurrentDirectory + "\\" + fileName)
    let splitLines = text.Split(newlineChars, StringSplitOptions.RemoveEmptyEntries)
    splitLines

let listToInt = List.map int

let add a b = a + b

let solve () =
    let reduced = 
        "c1.txt"
        |> readFile
        |> Array.toList
        |> listToInt
        |> List.reduce add
    printfn "%A" reduced
module Challenge1

open System
open System.IO

let readFile fileName =
    let text = File.ReadAllText(Environment.CurrentDirectory + "\\" + fileName)
    let splitLines = text.Split([|"\r\n"; "\n"; "\r"|], StringSplitOptions.RemoveEmptyEntries)
    splitLines

let listToInt xs = 
    List.map int xs


let solve () =
    let strData = readFile "c1.txt"
    let intData = listToInt (strData |> Array.toList)
    let reduced = intData |> List.reduce (fun r x -> r + x)
    printf "%A" reduced
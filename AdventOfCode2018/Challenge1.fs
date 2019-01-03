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

let applyFreqChanges init changes =
    let reduced = 
        changes
        |> List.fold add init
    reduced

let rec recursiveSolve init changes (set : Set<int>) =
    let newFreq = init + List.head changes
    if set.Contains(newFreq) then
        newFreq
    else
        recursiveSolve newFreq ((List.tail changes) @ [(List.head changes)]) (set.Add(newFreq))

let solve () =
    let changes = 
        "c1.txt"
        |> readFile
        |> Array.toList
        |> listToInt
    recursiveSolve 0 changes Set.empty

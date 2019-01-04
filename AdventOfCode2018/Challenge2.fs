module Challenge2

open System
open System.IO

module b = Base


let listToInt = List.map int

type State = {
    doubles : int;
    triples : int;
}

let emptyState = {doubles = 0; triples = 0}

type DupCounter = {
    hasDoubles : bool;
    hasTriples : bool;
}

let emptyDupCounter = {hasDoubles = false; hasTriples = false}


let foldHelper dupCounter k v =
    match (Seq.length v) with
    | 2 -> {dupCounter with hasDoubles = true}
    | 3 -> {dupCounter with hasTriples = true}
    | _ -> dupCounter

let getLineStatus (str : String) =
    str
    |> Seq.groupBy (fun x -> x)
    |> Map.ofSeq
    |> Map.fold foldHelper emptyDupCounter


let updateState state dupCounter =
    let newDoubles = 
        if dupCounter.hasDoubles then
            state.doubles + 1
        else
            state.doubles
    let newTriples = 
        if dupCounter.hasTriples then
            state.triples + 1
        else
            state.triples
    {
        doubles = newDoubles;
        triples = newTriples;
    }

let rec recursiveSolve boxIds (state : State) =
    if List.isEmpty boxIds then
        state.doubles * state.triples
    else
        let newState = getLineStatus (List.head boxIds)
        let updatedState = updateState state newState
        recursiveSolve (List.tail boxIds) updatedState
 
let solve () =
    let boxIds = 
        "c2.txt"
        |> b.readFile
        |> Array.toList
    recursiveSolve boxIds emptyState

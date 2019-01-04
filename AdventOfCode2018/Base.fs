module Base

open System
open System.IO

let newlineChars = [|"\r\n"; "\n"; "\r"|]

let readFile fileName =
    let text = File.ReadAllText(Environment.CurrentDirectory + "\\" + fileName)
    let splitLines = text.Split(newlineChars, StringSplitOptions.RemoveEmptyEntries)
    splitLines
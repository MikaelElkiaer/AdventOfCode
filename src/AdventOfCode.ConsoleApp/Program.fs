// Learn more about F# at http://fsharp.org

open System

open AdventOfCode.Day3

[<EntryPoint>]
let main argv =
    System.IO.Path.Combine(Environment.CurrentDirectory, "input.txt")
        |> System.IO.File.ReadAllLines
        |> Array.toList
        // ["#1 @ 1,3: 4x4";"#2 @ 3,1: 4x4";"#3 @ 5,5: 2x2"]
        |> countSquareInches

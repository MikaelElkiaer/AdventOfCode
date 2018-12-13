namespace AdventOfCode

open System

module Day1 =
    let rec adjust frequency changes =
        match changes with
        | head :: tail -> adjust (frequency + head) tail
        | [] -> frequency

    let parseFile filePath =
        System.IO.File.ReadAllLines filePath
        |> Array.toList
        |> List.map Int32.Parse

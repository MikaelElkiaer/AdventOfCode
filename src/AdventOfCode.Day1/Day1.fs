namespace AdventOfCode

open System

module Day1 =
    let rec adjust frequency changes =
        match changes with
        | head :: tail -> adjust (frequency + head) tail
        | [] -> frequency

    let findFirstDuplicate frequency changes =
        let rec findFirstDuplicateRec frequency i seen =
            if Set.contains frequency seen
            then frequency
            else findFirstDuplicateRec (frequency + List.item (i % List.length changes) changes) (i + 1) (Set.add frequency seen)
        findFirstDuplicateRec frequency 0 Set.empty

    let parseFile filePath =
        System.IO.File.ReadAllLines filePath
        |> Array.toList
        |> List.map Int32.Parse

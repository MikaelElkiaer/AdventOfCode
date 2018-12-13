namespace AdventOfCode

open System

module Day1 =
    let rec adjust frequency changes =
        match changes with
        | head :: tail -> adjust (frequency + head) tail
        | [] -> frequency

    let findFirstDuplicate frequency changes =
        let infiniteChanges =
            Seq.initInfinite (fun i -> List.item (i % List.length changes) changes)
        let rec findFirstDuplicateRec frequency changes seen =
            if Set.contains frequency seen
            then frequency
            else findFirstDuplicateRec (frequency + Seq.head changes) (Seq.tail changes) (Set.add frequency seen)
        findFirstDuplicateRec frequency infiniteChanges Set.empty

    let parseFile filePath =
        System.IO.File.ReadAllLines filePath
        |> Array.toList
        |> List.map Int32.Parse

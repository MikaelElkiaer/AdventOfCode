namespace AdventOfCode

module Day2 =
    let makeChecksum strings =
        strings
        |> Seq.map (Seq.toList
            >> Seq.groupBy id
            >> Seq.map (fun (x, y) -> (x, Seq.length y))
            >> Seq.filter (fun (_, y) -> Seq.contains y [2;3])
            >> Seq.distinctBy (fun (_, y) -> y)
            >> Seq.sortBy (fun (_, y) -> y)
            >> Seq.toList
            >> (fun xs ->
                match xs with
                | [_;_] -> (1, 1)
                | [(_,2)] -> (1, 0)
                | [(_,3)] -> (0, 1)
                | _ -> (0, 0)
                ))
        |> Seq.fold (fun (x1,y1) (x2,y2) -> (x1 + x2, y1 + y2)) (0,0)
        |> (fun (x,y) -> x * y)

    let parseFile filePath =
        System.IO.File.ReadAllLines filePath
        |> Array.toList  

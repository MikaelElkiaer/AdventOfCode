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

    let extractCommonLetters s1 s2 =
        let s1cs = Seq.toList s1
        let s2cs = Seq.toList s2
        let diffs = Seq.map2 (fun x y -> if x = y then 0 else 1) s1cs s2cs
        if Seq.sum diffs <> 1
        then None
        else
            Seq.zip s1cs diffs
            |> Seq.filter (fun (x, y) -> y = 0)
            |> Seq.map (fun (x, y) -> x)
            |> Some

    let findCommonLetters strings =
        let rec findCommonLettersRec current remaining =
            let r = extractCommonLetters (Seq.head current) (Seq.head remaining)
            match r with
            | Some x -> x
            | None ->
                match remaining with
                | [_] -> findCommonLettersRec (Seq.tail current) strings
                | _::xs -> findCommonLettersRec current xs
        findCommonLettersRec strings strings
        |> Array.ofSeq
        |> System.String

    let parseFile filePath =
        System.IO.File.ReadAllLines filePath
        |> Array.toList  

namespace AdventOfCode

open System.Text.RegularExpressions

module Day3 =
    let flip f x y = f y x

    let (|Regex|_|) pattern input =
        let m = Regex.Match(input, pattern)
        if m.Success then Some (List.tail [ for g in m.Groups -> g.Value ])
        else None

    let parseInput string =
        match string with
        | Regex @"\#(\d+)\s\@\s(\d+)\,(\d+)\:\s(\d+)x(\d+)" [ id; left; top; width; height ]
            -> Some (int id, int left, int top, int width, int height)
        | _ -> None

    let pad squares oldWidth oldHeight newWidth newHeight =
        if oldWidth >= newWidth && oldHeight >= newHeight
        then squares
        else
            Seq.chunkBySize oldWidth squares
            |> Seq.map (fun x -> Array.toList x @ List.init (newWidth - oldWidth) (fun _ -> 0))
            |> Seq.reduce (@)
            |> flip (@) (List.init ((newHeight - oldHeight) * (max oldWidth newWidth)) (fun _ -> 0))
            |> List.toSeq
        
    let createFabricMap (id, left, top, width, height) =
        let w = left + width
        let h = top + height
        Seq.init (w * h) (fun x ->
            let b = x + 1 > top * w && (x % w) >= left
            if b
            then id
            else 0)
        |> Seq.toList

    let combine result maxWidth maxHeight fabric =
        let _, left, top, width, height = fabric
        let fabricMap = createFabricMap fabric
        let newMaxWidth = max maxWidth (left + width)
        let newMaxHeight = max maxHeight (height + top)
        let paddedResult = pad result maxWidth maxHeight newMaxWidth newMaxHeight
        let paddedFabric = pad fabricMap (left + width) (top + height) newMaxWidth newMaxHeight
        Seq.map2 (fun a b -> a + b) paddedResult paddedFabric
        |> (fun x -> (x, newMaxWidth, newMaxHeight))

    let rec countSquareInchesRec result maxWidth maxHeight fabrics =
        match fabrics with
        | [] -> result
        | x::xs ->
            let combination = combine result maxWidth maxHeight x
            let r, w, h = combination
            countSquareInchesRec r w h xs

    let countSquareInches strings =
        Seq.map parseInput strings
        |> Seq.filter (fun x -> x <> None)
        |> Seq.map Option.get
        |> Seq.toList
        |> countSquareInchesRec [0] 1 1
        |> Seq.filter (fun x -> x > 0)
        |> Seq.length
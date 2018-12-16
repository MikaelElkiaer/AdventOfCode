module AdventOfCode.Day2.Tests

open System
open System.IO
open Xunit
open AdventOfCode.Day2

[<Fact>]
let ``Day 2 - Example`` () =
    let expected = 12
    let actual =
        makeChecksum ["abcdef";"bababc";"abbcde";"abcccd";"aabcdd";"abcdee";"ababab"]
    Assert.Equal(expected, actual)

[<Fact>]
let ``Day 2 - Input`` () =
    let expected = 5658
    let actual =
        Path.Combine(Environment.CurrentDirectory, "input.txt")
        |> parseFile
        |> makeChecksum
    Assert.Equal(expected, actual)

[<Fact>]
let ``Day 2 Part 2 - Example`` () =
    let expected = "fgij"
    let actual =
        findCommonLetters ["abcde";"fghij";"klmno";"pqrst";"fguij";"axcye";"wvxyz"]
    Assert.Equal(expected, actual)    

[<Fact>]
let ``Day 2 Part 2 - Input`` () =
    let expected = "nmgyjkpruszlbaqwficavxneo"
    let actual =
        Path.Combine(Environment.CurrentDirectory, "input.txt")
        |> parseFile
        |> findCommonLetters
    Assert.Equal(expected, actual)
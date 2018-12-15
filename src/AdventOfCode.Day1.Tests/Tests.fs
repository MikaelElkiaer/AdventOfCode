module AdventOfCode.Day1.Tests

open System
open System.IO
open Xunit
open AdventOfCode.Day1

[<Fact>]
let ``Day1 - Example 1`` () =
    let expected = 3
    let actual =
        adjust 0 [1;-2;3;1]
    Assert.Equal(expected, actual)

[<Fact>]
let ``Day1 - Example 2`` () =
    let expected = 3
    let actual =
        adjust 0 [1;1;1]
    Assert.Equal(expected, actual)

[<Fact>]
let ``Day1 - Example 3`` () =
    let expected = 0
    let actual =
        adjust 0 [1;1;-2]
    Assert.Equal(expected, actual)

[<Fact>]
let ``Day1 - Example 4`` () =
    let expected = -6
    let actual =
        adjust 0 [-1;-2;-3]
    Assert.Equal(expected, actual)

[<Fact>]
let ``Day1 - input`` () =
    let expected = 580
    let actual =
        Path.Combine(Environment.CurrentDirectory, "inputs.txt")
        |> parseFile
        |> adjust 0
    Assert.Equal(expected, actual)

[<Fact>]
let ``Day1 Part2 - Example 1`` () =
    let expected = 2
    let actual =
        findFirstDuplicate 0 [1;-2;3;1;1;-2]
    Assert.Equal(expected, actual)    

[<Fact>]
let ``Day1 Part2 - Example 2`` () =
    let expected = 0
    let actual =
        findFirstDuplicate 0 [1;-1]
    Assert.Equal(expected, actual)    

[<Fact>]
let ``Day1 Part2 - Example 3`` () =
    let expected = 10
    let actual =
        findFirstDuplicate 0 [3;3;4;-2;-4]
    Assert.Equal(expected, actual)    

[<Fact>]
let ``Day1 Part2 - Example 4`` () =
    let expected = 5
    let actual =
        findFirstDuplicate 0 [-6;3;8;5;-6]
    Assert.Equal(expected, actual)

[<Fact>]
let ``Day1 Part2 - Example 5`` () =
    let expected = 14
    let actual =
        findFirstDuplicate 0 [7;7;-2;-7;-4]
    Assert.Equal(expected, actual)

[<Fact>]
let ``Day1 Part2 - Input`` () =
    let expected = 81972
    let actual =
        Path.Combine(Environment.CurrentDirectory, "inputs.txt")
        |> parseFile
        |> findFirstDuplicate 0
    Assert.Equal(expected, actual)
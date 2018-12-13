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
    let expected = 0
    let actual =
        Path.Combine(Environment.CurrentDirectory, "inputs.txt")
        |> parseFile
        |> adjust 0
    Assert.Equal(expected, actual)

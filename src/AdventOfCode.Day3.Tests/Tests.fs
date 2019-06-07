module Tests

open System
open Xunit
open AdventOfCode.Day3

[<Fact>]
let ``createFabricMap - Zero`` () =
    let expected = []
    let actual = createFabricMap (1,0,0,0,0)
    Assert.Equal<int list>(expected, actual)

[<Fact>]
let ``createFabricMap - 1x1`` () =
    let expected = [1]
    let actual = createFabricMap (1,0,0,1,1)
    Assert.Equal<int list>(expected, actual)

[<Fact>]
let ``createFabricMap - 1x1 with 1,1 offset`` () =
    let expected =
        [0;0;
         0;1]
    let actual = createFabricMap (1,1,1,1,1)
    Assert.Equal<int list>(expected, actual)

[<Fact>]
let ``createFabricMap - 2x2 with 1,1 offset`` () =
    let expected =
        [0;0;0;
         0;1;1;
         0;1;1]
    let actual = createFabricMap (1,1,1,2,2)
    Assert.Equal<int list>(expected, actual)
    
[<Fact>]
let ``countSquareInches - Example`` () =
    let expected = 4
    let actual = countSquareInches ["#1 @ 1,3: 4x4";"#2 @ 3,1: 4x4";"#3 @ 5,5: 2x2"]
    Assert.Equal<int>(expected, actual)

// [<Fact>]
// let ``countSquareInches - Input`` () =
//     let expected = 0
//     let actual =
//         System.IO.Path.Combine(Environment.CurrentDirectory, "input.txt")
//         |> System.IO.File.ReadAllLines
//         |> Array.toList
//         |> countSquareInches
//     Assert.Equal<int>(expected, actual)
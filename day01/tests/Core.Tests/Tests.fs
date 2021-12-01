module Tests

open System
open Xunit
open FsUnit

open Inputs

let Part1 depths =
    depths |> List.pairwise |> List.map (fun (a,b) -> b-a) |> List.filter (fun x -> x > 0) |> List.length

[<Fact>]
let ``My test part01`` () =
    Part1 [199;200;208;210;200;207;240;269;260;263] |> should equal 7

[<Fact>]
let ``Part 01`` () =
    Part1 measurements |> should equal 1233



let Part2 depths =
    let length = (depths |> List.length) - 2
    (depths |> List.take length, depths |> List.skip 1 |> List.take length, depths |> List.skip 2) |||> List.map3 (fun x y z -> x + y + z)
    |> Part1

[<Fact>]
let ``My test part02`` () =
    Part2 [199;200;208;210;200;207;240;269;260;263] |> should equal 5


[<Fact>]
let ``Part 02`` () =
    Part2 measurements |> should equal 1275


module Tests

open System
open Xunit
open FsUnit

open Inputs

let Part1 depths =
    depths |> List.pairwise |> List.map (fun (a,b) -> b-a) |> List.filter (fun x -> x > 0) |> List.length

[<Fact>]
let ``My test`` () =
    Part1 [199;200;208;210;200;207;240;269;260;263] |> should equal 7

[<Fact>]
let ``Part 01`` () =
    Part1 measurements |> should equal 7

module Tests

open System
open Xunit
open FsUnit

open Inputs

let add (x,y) (x1,y1) = (x+x1,y+y1)

let parse (str: string) =
    match str.Split ' ' with
    | [|"forward"; x|] -> (int x, 0)
    | [|"down"; x|] -> (0, int x)
    | [|"up"; x|] -> (0, -(int x))
    | _ -> (0,0)

let Part1 (cmd: string) =
    (cmd.Split '\n') |> Array.map parse |> Array.reduce add ||> (*)

let specialAdd (x, y, aim) (x1, y1) =
    (x+x1, y + x1*aim, aim+y1)

let Part2 (cmd: string) =
    let (x, y, _) = (cmd.Split '\n') |> Array.map parse |> Array.fold specialAdd (0,0,0)
    x*y

[<Fact>]
let ``Part 1 small test`` () =
    commandsSmall |> Part1 |> should equal 150

[<Fact>]
let ``Part 1 test`` () =
    commandsBig |> Part1 |> should equal 1962940

[<Fact>]
let ``Part 2 small test`` () =
    commandsSmall |> Part2 |> should equal 900

[<Fact>]
let ``Part 2 test`` () =
    commandsBig |> Part2 |> should equal 1813664422

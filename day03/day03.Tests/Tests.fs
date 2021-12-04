module Tests

open System
open Xunit
open FsUnit

open Inputs

let bitCalc (c:char) =
    match c with | '0' -> -1 | '1' -> 1 | _ -> 0

let calcPow n pow =
    if n <= 0 then 0
    else
        match pow with
            | 0 -> 1
            | _ -> pown 2 pow

let calcBit (bits: int list) mult =
    let rec f bits acc =
        match bits with
        | [] -> 0
        | x::rest -> calcPow (x * mult) acc + f rest (acc+1)
    f bits 0

let extractBits (str:string) =
    let res =
        str.Split '\n' |>
        Array.map (fun x -> Seq.toList x) |>
        Array.map (List.map bitCalc) |>
        Array.reduce (fun x y -> List.zip x y |> List.map (fun x  -> x||> (+))) |>
        List.rev
    let x = calcBit res 1
    let y = calcBit res -1
    (x,y)

let getPower str =
    extractBits str ||> (*)

[<Fact>]
let ``test bit calculator`` () =
    calcBit [-1;1;1;-1;1] 1 |> should equal 22

[<Fact>]
let ``part 1 bit extraction`` () =
    extractBits small |> should equal (22, 9)

[<Fact>]
let ``part 1 power`` () =
    getPower small |> should equal 198

[<Fact>]
let ``part 1 power big`` () =
    getPower big |> should equal 3549854

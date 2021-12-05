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

let part1 (str:string) =
    let res =
        str.Split '\n' |>
        Array.map (fun x -> Seq.toList x) |>
        Array.map (List.map bitCalc) |>
        Array.reduce (fun x y -> List.zip x y |> List.map (fun x  -> x||> (+))) |>
        List.rev
    let x = calcBit res 1
    let y = calcBit res -1
    (x,y)

let rec groupAndPickMax pos arr =
    match (Array.length arr, Array.head arr) with
    | (1, head) -> head
    | (_, head) when List.length head = pos -> head
    | _ ->
        let (_, x) = arr |> Array.groupBy (fun x -> List.item pos x) |> Array.sortBy (fun (x, _) -> x) |> Array.rev |> Array.maxBy (fun (_, x) -> Array.length x)
        groupAndPickMax (pos+1) x

let rec groupAndPickMin pos arr =
    match (Array.length arr, Array.head arr) with
    | (1, head) -> head
    | (_, head) when List.length head = pos -> head
    | _ ->
        let (_, x) = arr |> Array.groupBy (fun x -> List.item pos x) |> Array.sortBy (fun (x, _) -> x) |> Array.minBy (fun (_, x) -> Array.length x)
        groupAndPickMin (pos+1) x

let part2 (str:string) =
    let l = str.Split '\n' |> Array.map (fun x -> Seq.toList x)
    let res = l |> groupAndPickMax 0 |> List.map bitCalc |> List.rev
    let res2 = l |> groupAndPickMin 0 |> List.map bitCalc |> List.rev
    let x = calcBit res 1
    let y = calcBit res2 1
    (x,y)

let getPower str = part1 str ||> (*)
let getLifeSupport str = part2 str ||> (*)

[<Fact>]
let ``test bit calculator`` () =
    calcBit [-1;1;1;-1;1] 1 |> should equal 22

[<Fact>]
let ``part 1 bit extraction`` () =
    part1 small |> should equal (22, 9)

[<Fact>]
let ``part 1 power`` () =
    getPower small |> should equal 198

[<Fact>]
let ``part 1 power big`` () =
    getPower big |> should equal 3549854

[<Fact>]
let ``test bit calculator part 2`` () =
    calcBit (['1';'0';'1';'1';'1'] |> List.map bitCalc |> List.rev) 1 |> should equal 23

[<Fact>]
let ``test groupAndPickMax part 2`` () =
    small.Split '\n' |> Array.map (fun x -> Seq.toList x) |> groupAndPickMax 0 |> should equal ['1';'0';'1';'1';'1']

[<Fact>]
let ``part 2 bit extraction`` () =
    part2 small |> should equal (23, 10)

[<Fact>]
let ``part 2 power`` () =
    getLifeSupport small |> should equal 230

[<Fact>]
let ``part 2 power big`` () =
    getLifeSupport big |> should equal 3765399

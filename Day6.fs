module Day6

open System.IO

let input =
    File.ReadAllLines("./input/06")
    |> Array.item 0
    |> (fun x -> x.Split(','))
    |> Array.map int64
    |> Array.toList

let initialCount =
    List.replicate 9 0
    |> List.mapi
        (fun i _ ->
            input
            |> List.countBy id
            |> List.tryFind (fun (day, _) -> day = i)
            |> fun x ->
                match x with
                | Some (_, count) -> int64 count
                | None -> int64 0)

let rec countFishOverDays (days: int) (fishCount: int64 list) : int64 =
    if days = 0 then
        List.sum fishCount
    else
        fishCount.Tail @ [ fishCount.Head ]
        |> List.mapi (fun i x -> if i = 6 then x + fishCount.Head else x)
        |> countFishOverDays (days - 1)

let part1 = countFishOverDays 80 initialCount
let part2 = countFishOverDays 256 initialCount

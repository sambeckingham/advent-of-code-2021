open System.IO

let input =
    File.ReadAllLines("./input")
    |> Array.item 0
    |> (fun x -> x.Split(','))
    |> Array.map int64
    |> Array.toList

let mutable fishies: int64 list = [0;0;0;0;0;0;0;0;0]

for x in input do
    fishies <- fishies
        |>List.mapi (fun i n -> if int64 i = x then n + int64 1 else n)


let countFishiesOverDays (days: int) =
    for _ = 1 to days do
        let head :: tail = fishies
        fishies <- tail @ [head]
        fishies <- fishies
            |> List.mapi (fun i x -> if i = 6 then x + head else x) 

    List.sum fishies


printfn $"{countFishiesOverDays 80}"

fishies <- [0;0;0;0;0;0;0;0;0]

for x in input do
    fishies <- fishies
        |>List.mapi (fun i n -> if int64 i = x then n + int64 1 else n)

printfn $"{countFishiesOverDays 256}"
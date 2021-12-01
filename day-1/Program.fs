open System.IO

let input =
    File.ReadAllLines("./input") |> Array.map int

let countIncrements input =
    input
    |> Array.windowed 2
    |> Array.filter (fun [| a; b |] -> a < b)
    |> Array.length

// Part 1

printfn $"{input |> countIncrements}"

// Part 2

let slidingWindow input =
    input
    |> Array.windowed 3
    |> Array.map Array.sum
    |> countIncrements

printfn $"{slidingWindow input}"

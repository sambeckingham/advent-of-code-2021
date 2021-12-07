module Day1

open System.IO

let input =
    File.ReadAllLines("./input/01") |> Array.map int

let countIncrements input =
    let incrementalNumbers x =
        match x with
        | [| a; b |] -> a < b
        | _ -> false

    input
    |> Array.windowed 2
    |> Array.filter incrementalNumbers
    |> Array.length

// Part 1

let part1 = input |> countIncrements

// Part 2

let slidingWindow input =
    input
    |> Array.windowed 3
    |> Array.map Array.sum
    |> countIncrements

let part2 = slidingWindow input

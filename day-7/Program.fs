module Day7

open System.IO

let lines =
    File.ReadAllText("./input/07").Split(",")
    |> Array.map int

let upperBound = lines |> Array.max

let getTotalFuel endPosition initialPositions =
    initialPositions
    |> Array.map (fun x -> abs (endPosition - x))
    |> Array.sum

let part1 =
    [| 0 .. upperBound |]
    |> Array.map (fun x -> getTotalFuel x lines)
    |> Array.min

let sumOfConsecutiveNumbers n = n * (n + 1) / 2

let getTotalExpensiveFuel endPosition initialPositions =
    initialPositions
    |> Array.map (fun x -> abs (endPosition - x)) // Figure out differences (again)
    |> Array.map sumOfConsecutiveNumbers // Calculate sum of consecutive numbers to 0 for each
    |> Array.sum // 4. Profit

let part2 =
    [| 0 .. upperBound |]
    |> Array.map (fun x -> getTotalExpensiveFuel x lines)
    |> Array.min

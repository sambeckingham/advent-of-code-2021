
open System.IO

let lines =
    File.ReadAllText("input").Split(",")
    |> Array.map int
    
let upperBound =
    lines
    |> Array.max

let getTotalFuel endPosition initialPositions = 
    initialPositions
    |> Array.map (fun x -> abs (endPosition - x))
    |> Array.sum

[|0..upperBound|]
|> Array.map (fun x -> getTotalFuel x lines)
|> Array.min
|> fun x -> printfn $"Petrol: {x}"

let sumOfConsecutiveNumbers n =
    n * (n+1) / 2

let getTotalExpensiveFuel endPosition initialPositions = 
    initialPositions  
    |> Array.map (fun x -> abs (endPosition - x)) // Figure out differences (again)
    |> Array.map sumOfConsecutiveNumbers // Calculate sum of consecutive numbers to 0 for each
    |> Array.sum     // 4. Profit

[|0..upperBound|]
|> Array.map (fun x -> getTotalExpensiveFuel x lines)
|> Array.min
|> fun x -> printfn $"Diesel: {x}"
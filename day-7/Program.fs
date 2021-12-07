
open System.IO

let input =
    File.ReadAllText("input").Split(",")
    |> Array.map int
    
let upperBound =
    input
    |> Array.max

let getTotalFuel endPosition initialPositions = 
    initialPositions
    |> Array.map (fun x -> abs (endPosition - x))
    |> Array.sum

[|0..upperBound|]
|> Array.map (fun x -> getTotalFuel x input)
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
|> Array.map (fun x -> getTotalExpensiveFuel x input)
|> Array.min
|> fun x -> printfn $"Diesel: {x}"
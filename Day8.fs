module Day8

open System.IO

let input =
    File.ReadAllLines("./input/08")
    |> Array.map (fun x -> x.Split(" | "))
    |> Array.map (fun x -> (x[0], x[1]))

let part1 =
    input
    |> Array.map snd // Get the outputs
    |> Array.map (fun x -> x.Split(' ')) // Split em into an array
    |> Array.concat // Flatten into one Array of all outputs
    |> Array.filter (fun x -> // Count strings with unique lengths
        match x.Length with
        | 2 | 3 | 4 | 7 -> true
        | _ -> false)
    |> Array.length
    
let decode (input: string * string): int =
    let patterns =
        input
        |> fst
        |> fun x -> x.Split(" ")
        |> Array.sortBy (fun x -> x.Length)
        |> Array.map Set.ofSeq
    
    let output =
        input
        |> snd
        |> fun x -> x.Split(" ")
        |> Array.map Set.ofSeq
    
    output
    |> Array.map (fun digit ->
        match digit.Count with
        | x when x = patterns[0].Count -> 1 // We already know these 4
        | x when x = patterns[1].Count -> 7
        | x when x = patterns[2].Count -> 4
        | x when x = patterns[9].Count -> 8
        | x when x = 5 -> // 2, 3, 5 all contain 5 digits
           if (Set.difference patterns[0] digit).Count = 0 then // 1 can be used to deduce 3
                3
            else if (Set.difference patterns[2] digit).Count = 1 then // 4 can be used to deduce the others
                5
            else 2 // Otherwise it's 2
        | _ ->
            if (Set.difference patterns[0] digit).Count = 1 then // 1 can be used to deduce 6
                6
            else if (Set.difference patterns[2] digit).Count = 1 then // 4 can be used to deduce the others
                0
            else 9) // Otherwise it's 9
    |> Array.map string
    |> String.concat ""
    |> int
           
let part2 =
    input
    |> Array.map decode
    |> Array.sum
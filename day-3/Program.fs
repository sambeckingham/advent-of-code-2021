open System
open System.IO

let input: string[] = File.ReadAllLines("./input")

// Part 1

// Matrix rotation robbed from http://fssnip.net/7Wk
let rotateGridClockwise grid =
    let height, width = Array2D.length1 grid, Array2D.length2 grid
    Array2D.init width height (fun row column -> Array2D.get grid (height - column - 1) row)
    
let inputMatrix = Array2D.init input.Length input[0].Length (fun row column -> input[row].[column])

let rotatedMatrix = rotateGridClockwise inputMatrix

let mutable gammaBits = ""
for x in [0..Array2D.length1 rotatedMatrix - 1 ] do
    gammaBits <- rotatedMatrix[x, *]
        |> Array.countBy id
        |> Array.maxBy snd
        |> fst
        |> string 
        |> (+) gammaBits
        
let gamma = Convert.ToInt32(gammaBits, 2)
let deltaBits = gammaBits
                |> String.map (fun c -> if c = '1' then '0' else '1')
let delta = Convert.ToInt32(deltaBits, 2)

printfn $"Gamma: {gamma} * Delta: {delta} = {gamma * delta}"
// Gamma: 1337 * Delta: 2758 = 3687446

// Part 2 - Fuck functional programming

let mutable inputList = Array.toList input

let rec filterListByPosition (position: int) (input: string list) filterFn: string list =
    let mutable oneCount, zeroCount = 0, 0
    
    for j = 0 to input.Length-1 do
        if input[j][position] = '1' then
            oneCount <- oneCount + 1
        else
            zeroCount <- zeroCount + 1
            
    let filteredInput =
        if filterFn oneCount zeroCount then
            input |> List.filter (fun str -> str[position] = '1')
        else
            input |> List.filter (fun str -> str[position] = '0')
    
    printfn $"{filteredInput}"
    
    if filteredInput.Length = 1 then
        filteredInput
    else
        filterListByPosition (position+1) filteredInput filterFn
        
let oxygenBits= filterListByPosition 0 inputList (fun ones zeroes -> ones >= zeroes)
let CO2Bits = filterListByPosition 0 inputList (fun ones zeroes -> zeroes > ones)

let oxygen, CO2 = Convert.ToInt32(oxygenBits[0], 2), Convert.ToInt32(CO2Bits[0], 2)

printfn $"Oxy: {oxygen} * CO2: {CO2} = {oxygen * CO2}"
// Oxy: 1599 * CO2: 2756 = 4406844
module Day4

open System
open System.IO

let lines = File.ReadAllLines("./input/04")

let numbers = lines[ 0 ].Split ',' |> Array.map int

type BingoCard() =
    let mutable winningCombinations: int list list = []

    member this.WinningCombinations
        with get () = winningCombinations
        and set (wc) = winningCombinations <- wc

    member this.AddWinningCombination(wc: int list) =
        this.WinningCombinations <- wc :: this.WinningCombinations

    member this.MarkNumber(num: int) =
        this.WinningCombinations <-
            this.WinningCombinations
            |> List.map (fun wc -> wc |> List.filter (fun n -> n <> num))

    member this.CheckForWinner: bool =
        query {
            for wc in this.WinningCombinations do
                exists (wc.Length = 0)
        }

    member this.SumUnmarked: int =
        this.WinningCombinations
        |> List.concat
        |> Set.ofList
        |> Set.toList
        |> List.sum

let mutable bingoCards: BingoCard list = []

for card in 1 .. 6 .. lines.Length - 1 do
    let newCard = BingoCard()

    // Get rows
    for row = 1 to 5 do
        newCard.AddWinningCombination(
            lines[ card + row ].Split ' '
            |> Array.filter (fun x -> not (String.IsNullOrWhiteSpace(x)))
            |> Array.map int
            |> Array.toList
        )

    for column = 0 to 4 do
        let mutable columnCombination: int list = []

        for row = 1 to 5 do
            columnCombination <-
                (lines[ card + row ].Split ' '
                 |> Array.filter (fun x -> not (String.IsNullOrWhiteSpace(x)))
                 |> Array.map int
                 |> Array.toList)[ column ]
                :: columnCombination

        newCard.AddWinningCombination columnCombination

    bingoCards <- newCard :: bingoCards

let mutable firstWinner, lastWinner = 0, 0

for num in numbers do
    for card in bingoCards do
        card.MarkNumber num

        if card.CheckForWinner then
            if firstWinner = 0 then
                firstWinner <- card.SumUnmarked * num

            if bingoCards.Length = 1 then
                lastWinner <- card.SumUnmarked * num
                bingoCards <- bingoCards |> List.filter (fun bc -> bc <> card)
            else
                bingoCards <- bingoCards |> List.filter (fun bc -> bc <> card)

let part1, part2 = firstWinner, lastWinner

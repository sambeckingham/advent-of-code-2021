open System.IO
open System.Text.RegularExpressions


let input: string[] = File.ReadAllLines("./testinput")

type Point = int * int

type Field() =
    let mutable vents: (Point * Point) list = []

    member this.Vents
        with get () = vents
        and set (v) = vents <- v

    member this.AddVent point1 point2 =
        vents <- (point1, point2) :: vents

    member this.StraightLines: (Point * Point) list =
        let mutable straightLines = []
        for vent in vents do
            match vent with
            | (x1, y1), (x2, y2) when x1 = x2 || y1 = y2 -> 
                straightLines <- vent :: straightLines
            | _ -> ()

        straightLines

let field = Field()

for line in input do
    let pattern = "(\d+),(\d+) -> (\d+),(\d+)"
    let matched = Regex.Match(line, pattern)
    let point1: Point = (int matched.Groups[1].Value, int matched.Groups[2].Value)
    let point2: Point = (int matched.Groups[3].Value, int matched.Groups[4].Value)
    field.AddVent point1 point2

// TODO

// field.StraightLines
// |> 

printfn "%O" field.Vents
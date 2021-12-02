

open System.IO

let lines = File.ReadAllLines("./input")

// Part 1

let mutable position = (0, 0)

let parseCommand (cmd : string) =
    let cmds = cmd.Split(' ')
    
    match cmds[0] with
    | "forward" -> position <- (fst position + int cmds[1], snd position)
    | "up" -> position <- (fst position, snd position - int cmds[1])
    | "down" -> position <- (fst position, snd position + int cmds[1])
    | _ -> ()
    

lines
|> Array.map parseCommand
|> ignore

printfn $"{fst position * snd position}"

// Part 2

let mutable orientation = (0,0,0)
let parseCommandWithFeeling (cmd : string) =
    let cmds = cmd.Split(' ')
    
    let (x, depth, aim) = orientation
    
    match cmds[0] with
    | "forward" -> orientation <- (x + int cmds[1], depth + (aim * int cmds[1]), aim)
    | "up" -> orientation <- (x, depth, aim - int cmds[1])
    | "down" -> orientation <- (x, depth, aim + int cmds[1])
    | _ -> ()
    
lines
|> Array.map parseCommandWithFeeling
|> ignore

let (x, depth, _) = orientation
printfn $"{x * depth}"
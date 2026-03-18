open System
open System.IO

type Customer =
    { CustomerId: string
      Email: string
      IsEligible: string
      IsRegistered: string
      DateRegistered: string
      Discount: string }

type DataReader = string -> Result<string seq, exn>

let readFile path =
    try
        File.ReadLines path |> Ok
    with ex ->
        Error ex

let parseLine (line: string) : Customer option =
    match line.Split('|') with
    | [| customerId; email; eligible; registered; dateRegistered; discount |] ->
        Some
            { CustomerId = customerId
              Email = email
              IsEligible = eligible
              IsRegistered = registered
              DateRegistered = dateRegistered
              Discount = discount }
    | _ -> None


let parse (data: string seq) =
    data
    |> Seq.skip 1 // Ignore the header row
    |> Seq.choose parseLine

let output data =
    data |> Seq.iter (fun x -> printfn "%A" x)

let import (dataReader: DataReader) path =
    match path |> dataReader with
    | Ok data -> data |> parse |> output
    | Error ex -> printfn "Error: %A" ex.Message

let data =
    Path.Combine(__SOURCE_DIRECTORY__, "resources", "customers.csv")
    |> import readFile

open System

let tryParseDateTime (input: string) =
    let (success, value) = DateTime.TryParse input
    if success then Some value else None

let isDate = tryParseDateTime "2024-01-01" |> Option.isSome
let parsedDate = tryParseDateTime "2024-01-01" |> Option.get


let fromNullObject: string option = None
let setUnknownAsDefault = Option.defaultValue ""

let result = setUnknownAsDefault fromNullObject

open System

let tryDivide (x: int) (y: int) : Result<int, DivideByZeroException> =
    try
        Ok(x / y)
    with :? DivideByZeroException as ex ->
        Error(ex)

let badDivide = tryDivide 10 0
let goodDivide = tryDivide 10 2

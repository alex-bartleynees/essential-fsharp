namespace ComputationExpression

[<AutoOpen>]
module Option =
    type OptionBuilder() =
        member _.Bind(x, f) = Option.bind f x
        member _.Return(x) = Some(x)
        member _.ReturnFrom(x) = x

    let option = OptionBuilder()

module OptionDemo =

    let multiply x y = x * y

    let divide x y = // int -> int -> int option
        if y = 0 then None else Some(x / y)

    // The formula is: f x y = ((x / y) * x) / y
    // let calculate x y =
    //     divide x y
    //     |> fun result ->
    //         match result with
    //         | Some v -> multiply v x |> Some
    //         | None -> None
    //         |> fun result ->
    //             match result with
    //             | Some t -> divide t y
    //             | None -> None

    let calculate x y =
        option {
            let! v = divide x y
            let t = multiply v x
            return! divide t y
        }

    // test calculate and print result
    let result = calculate 10 2
    printfn "Result: %A" result


    let calculateWithBind x y =
        divide x y
        |> Option.map (fun v -> multiply v x)
        |> Option.bind (fun t -> divide t y)

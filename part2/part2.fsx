type RegisteredCustomer = { Id: string; IsEligible: bool }
type UnregisteredCustomer = { Id: string }

type Customer =
    | Registered of RegisteredCustomer
    | Guest of UnregisteredCustomer


let calculateTotal (customer: Customer) (spend: decimal) : decimal =
    let discount =
        match customer with
        | Registered regCustomer ->
            if regCustomer.IsEligible && spend >= 100.0M then
                spend * 0.1M
            else
                0.0M
        | Guest _ -> 0.0M

    let total = spend - discount
    total

let john = Registered { Id = "John"; IsEligible = true }

let mary = Registered { Id = "Mary"; IsEligible = true }

let richard = Registered { Id = "Richard"; IsEligible = false }

let sarah = Guest { Id = "Sarah" }

let assertJohn = calculateTotal john 100.0M = 90.0M
let assertMary = calculateTotal mary 100.0M = 100.0M
let assertRichard = calculateTotal richard 100.0M = 90.0M
let assertSarah = calculateTotal sarah 100.0M = 100.0M

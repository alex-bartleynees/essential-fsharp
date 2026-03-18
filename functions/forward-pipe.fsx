type Customer =
    { Id: string
      IsEligible: bool
      IsRegistered: bool }

let calculateTotal (customer: Customer) (spend: decimal) : decimal =
    let discount =
        if customer.IsEligible && spend >= 100.0M then
            spend * 0.1M
        else
            0.0M

    let total = spend - discount
    total

let john =
    { Id = "John"
      IsEligible = true
      IsRegistered = true }

let calculateTotalForJohn = calculateTotal john

let completeJohnTotal = 100.0M |> calculateTotalForJohn

let isEqualTo expected actual = expected = actual

let assertJohn = calculateTotal john 100.0M |> isEqualTo 90.0M
let x = 5
x = 6

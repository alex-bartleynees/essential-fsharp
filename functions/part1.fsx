type Customer =
    { Id: int
      IsVip: bool
      Credit: decimal }

// Customer -> (Customer * decimal)
let getPurchases customer =
    let purchases = if customer.Id % 2 = 0 then 120M else 80M
    (customer, purchases)

let tryPromoteToVip purchases =
    let (customer: Customer, amount) = purchases

    if amount > 100M then
        { customer with IsVip = true }
    else
        customer

let increaseCreditIfVip customer =
    let increase = if customer.IsVip then 100M else 50M

    { customer with
        Credit = customer.Credit + increase }

let now () = System.DateTime.UtcNow

now ()

let add = fun x y -> x + y
add 5 3

let apply f x y = f x y

let sum = apply add 5 3

let rnd =
    let rnd = System.Random()
    fun () -> rnd.Next(100)

List.init 50 (fun _ -> rnd ())

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

let completeJohnTotal = calculateTotalForJohn 100.0M

let assertJohn = completeJohnTotal = 90.0M

type LogLevel =
    | Info
    | Warning
    | Error

let log (level: LogLevel) message = printfn "[%A] %s" level message

let logInfo = log Info
let logWarning = log Warning
let logError = log Error

logInfo "This is an informational message."
logWarning "This is a warning message."
logError "This is an error message."

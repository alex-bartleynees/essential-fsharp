open System

let (|ValidDate|_|) (input: string) =
    match DateTime.TryParse(input) with
    | (true, date) -> Some(date)
    | _ -> None

let parse input =
    match input with
    | ValidDate dt -> printfn "%A" dt
    | _ -> printfn "Invalid date"


parse "2026-03-21T04:25:29Z"
parse "not-a-date"

let (|IsDivisibleBy|_|) divisors n =
    if divisors |> List.forall (fun div -> n % div = 0) then
        Some()
    else
        None

let calculateFizzBuzz i =
    match i with
    | IsDivisibleBy [ 3; 5 ] -> "FizzBuzz"
    | IsDivisibleBy [ 3 ] -> "Fizz"
    | IsDivisibleBy [ 5 ] -> "Buzz"
    | _ -> string i

for num in 1..100 do
    printfn "%s" (calculateFizzBuzz num)


// leap years
let (|IsDivisibleByYear|_|) divisor n =
    if n % divisor = 0 then Some() else None

let (|NotDivisibleBy|_|) divisor n =
    if n % divisor <> 0 then Some() else None

let isLeapYear year =
    match year with
    | IsDivisibleByYear 400 -> true
    | IsDivisibleByYear 4 & NotDivisibleBy 100 -> true
    | _ -> false


// Multi case active patterns
type Rank =
    | Ace
    | Two
    | Three
    | Four
    | Five
    | Six
    | Seven
    | Eight
    | Nine
    | Ten
    | Jack
    | Queen
    | King

type Suit =
    | Hearts
    | Diamonds
    | Clubs
    | Spades

type Card = Rank * Suit

let (|Red|Black|) (card: Card) =
    match card with
    | (_, Diamonds)
    | (_, Hearts) -> Red
    | (_, Clubs)
    | (_, Spades) -> Black

let describeColour card =
    match card with
    | Red -> "red"
    | Black -> "black"
    |> printfn "The card is %s"

describeColour (Two, Hearts)

// Single case active patterns
let (|CharacterCount|) (input: string) = input.Length

let (|ContainsANumber|) (input: string) =
    input |> Seq.filter Char.IsDigit |> Seq.length > 0

let (|IsValidPassword|) input =
    match input with
    | CharacterCount len when len < 8 -> (false, "Password must be at least 8 characters long")
    | ContainsANumber false -> (false, "Password must contain at least one number")
    | _ -> (true, "")

let setPassword input =
    match input with
    | IsValidPassword(true, _) as pwd -> Ok pwd
    | IsValidPassword(false, failureReason) -> Error $"Password not set: %s{failureReason}"

let badPassword = setPassword "password"
let goodPassword = setPassword "passw0rd"

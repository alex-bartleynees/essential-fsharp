let items =
    [ for x in 1..5 do
          x ]

let extendedItems = 6 :: items

let readList =
    match items with
    | head :: tail -> printfn "Head: %d, Tail: %A" head tail
    | [] -> printfn "Empty list"

let list1 = [ 1; 2; 3 ]
let list2 = [ 4; 5; 6 ]
let combinedList = list1 @ list2
let joinedList = List.concat [ list1; list2 ]

let filteredList = List.filter (fun x -> x % 2 = 0) combinedList
let summedList = List.sum combinedList

let triple items = List.map (fun x -> x * 3) items
let tripledList = triple combinedList

let print items =
    items |> List.iter (fun x -> printfn "Item: %d" x)

print combinedList

let tuplesList = [ (1, 0.25M); (2, 0.5M); (3, 0.75M) ]

let sumTuples items =
    items |> List.map (fun (x, y) -> x + int y) |> List.sum

let printSumOfTuples items =
    let sum = sumTuples items
    printfn "Sum of tuples: %d" sum

printSumOfTuples tuplesList

List.fold (fun acc x -> acc + x) 0 combinedList

let nums = [ 1..10 ]

nums
|> List.filter (fun v -> v % 2 = 1)
|> List.map (fun v -> v * v)
|> List.sum

nums |> List.choose (fun v -> if v % 2 = 1 then Some(v * v) else None)

nums |> List.fold (fun acc v -> acc + if v % 2 = 1 then (v * v) else 0) 0

nums |> List.sumBy (fun v -> if v % 2 = 1 then (v * v) else 0)

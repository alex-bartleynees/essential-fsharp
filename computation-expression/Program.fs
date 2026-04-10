open ComputationExpression.AsyncDemo
open System.IO

Path.Combine(__SOURCE_DIRECTORY__, "resources", "customers.csv")
|> getFileInformation
|> Async.RunSynchronously
|> fun file -> printfn "File: %s, Size: %d" file.Name file.Length

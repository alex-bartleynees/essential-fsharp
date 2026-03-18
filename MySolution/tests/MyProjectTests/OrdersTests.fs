namespace OrdersTests

open MyProject.Orders
open MyProject.Orders.Domain
open Xunit
open FsUnit

module ``Add item to order`` =
    [<Fact>]
    let ``when product does not exist in empty order`` () =
        let myEmptyOrder = { Id = 1; Items = [] }

        let expected =
            { Id = 1
              Items = [ { ProductId = 1; Quantity = 3 } ] }

        let actual = myEmptyOrder |> addItem { ProductId = 1; Quantity = 3 }
        actual |> should equal expected

    [<Fact>]
    let ``when product does not exist in non empty order`` () =
        let myOrder =
            { Id = 1
              Items = [ { ProductId = 1; Quantity = 2 } ] }

        let expected =
            { Id = 1
              Items = [ { ProductId = 1; Quantity = 2 }; { ProductId = 2; Quantity = 4 } ] }

        let actual = myOrder |> addItem { ProductId = 2; Quantity = 4 }
        actual |> should equal expected

    [<Fact>]
    let ``when product exists in order`` () =
        let myOrder =
            { Id = 1
              Items = [ { ProductId = 1; Quantity = 2 } ] }

        let expected =
            { Id = 1
              Items = [ { ProductId = 1; Quantity = 5 } ] }

        let actual = myOrder |> addItem { ProductId = 1; Quantity = 3 }
        actual |> should equal expected


module ``add multiple items to order`` =

    [<Fact>]
    let ``when adding multiple items to empty order`` () =
        let myEmptyOrder = { Id = 1; Items = [] }

        let expected =
            { Id = 1
              Items = [ { ProductId = 1; Quantity = 3 }; { ProductId = 2; Quantity = 4 } ] }

        let actual =
            myEmptyOrder
            |> addItems [ { ProductId = 1; Quantity = 3 }; { ProductId = 2; Quantity = 4 } ]

        actual |> should equal expected

    [<Fact>]
    let ``when adding multiple items to non-empty order`` () =
        let myOrder =
            { Id = 1
              Items = [ { ProductId = 1; Quantity = 2 } ] }

        let expected =
            { Id = 1
              Items =
                [ { ProductId = 1; Quantity = 2 }
                  { ProductId = 2; Quantity = 4 }
                  { ProductId = 3; Quantity = 5 } ] }

        let actual =
            myOrder
            |> addItems [ { ProductId = 2; Quantity = 4 }; { ProductId = 3; Quantity = 5 } ]

        actual |> should equal expected

    [<Fact>]
    let ``when removing product from order`` () =
        let myOrder =
            { Id = 1
              Items = [ { ProductId = 1; Quantity = 2 }; { ProductId = 2; Quantity = 4 } ] }

        let expected =
            { Id = 1
              Items = [ { ProductId = 2; Quantity = 4 } ] }

        let actual = myOrder |> removeProduct 1
        actual |> should equal expected

    [<Fact>]
    let ``when removing non-existent product from order`` () =
        let myOrder =
            { Id = 1
              Items = [ { ProductId = 1; Quantity = 2 }; { ProductId = 2; Quantity = 4 } ] }

        let expected =
            { Id = 1
              Items = [ { ProductId = 1; Quantity = 2 }; { ProductId = 2; Quantity = 4 } ] }

        let actual = myOrder |> removeProduct 3
        actual |> should equal expected

module ``Reduce item in order`` =
    [<Fact>]
    let ``when reducing item in order`` () =
        let myOrder =
            { Id = 1
              Items = [ { ProductId = 1; Quantity = 5 } ] }

        let expected =
            { Id = 1
              Items = [ { ProductId = 1; Quantity = 2 } ] }

        let actual = myOrder |> reduceItem 1 3
        actual |> should equal expected

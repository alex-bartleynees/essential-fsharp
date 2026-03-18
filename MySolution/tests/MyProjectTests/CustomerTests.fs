namespace MyProjectTests

open MyProject.Customer
open Xunit

module ``When upgrading a customer`` =
    let customerVIP = { Id = 1; IsVip = true; Credit = 0.0M }

    let customerSTD =
        { Id = 2
          IsVip = false
          Credit = 100.0M }

    [<Fact>]
    let ``should give VIP customer more credit`` () =
        let expected =
            { customerVIP with
                Credit = customerVIP.Credit + 100M }

        let actual = upgradeCustomer customerVIP
        Assert.Equal(expected, actual)

    [<Fact>]
    let ``should convert eligible STD customer to VIP`` () =
        let expected =
            { customerSTD with
                IsVip = true
                Credit = 200M }

        let actual = upgradeCustomer customerSTD
        Assert.Equal(expected, actual)

    [<Fact>]
    let ``should not upgrade ineligible STD customer`` () =
        let ineligibleCustomer = { customerSTD with Id = 3 }

        let expected =
            { ineligibleCustomer with
                Credit = ineligibleCustomer.Credit + 50M }

        let actual = upgradeCustomer ineligibleCustomer
        Assert.Equal(expected, actual)

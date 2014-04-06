namespace AppStoreCrawler.Tests

open System
open NUnit.Framework
open AppStoreCrawler

[<TestFixture>]
type ``Test crawling Windows Phone Store`` () =
    
    [<Test>]
    member x.``Apps should be found`` () =
        let apps = WindowsPhoneStore.searchAppStore "LEMA" "SK"
        Assert.IsNotNull(apps)
        Assert.IsNotEmpty(apps)
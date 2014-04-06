namespace AppStoreCrawler.Tests

open System
open NUnit.Framework
open AppStoreCrawler

[<TestFixture>]
type ``Test crawling AppStore`` () =
    
    [<Test>]
    member x.``Apps should be found`` () =
        let apps = AppStore.searchAppStore "LEMA" "SK"
        Assert.IsNotNull(apps)
        Assert.IsNotEmpty(apps)
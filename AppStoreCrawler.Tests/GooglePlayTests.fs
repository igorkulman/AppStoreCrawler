namespace AppStoreCrawler.Tests

open System
open NUnit.Framework
open AppStoreCrawler

[<TestFixture>]
type ``Test crawling Google Play`` () =
    
    [<Test>]
    member x.``Apps should be gound`` () =
        let apps = PlayStore.searchAppStore "LEMA"
        Assert.IsNotNull(apps)
        Assert.IsNotEmpty(apps)


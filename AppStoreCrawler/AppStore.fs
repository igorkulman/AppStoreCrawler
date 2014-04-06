namespace AppStoreCrawler

module AppStore =

    open Net
    open System.IO    
    open FSharp.Data
    open Types    

    type AppStoreData = JsonProvider<"http://itunes.apple.com/search?term=LEMA&entity=software&country=CZ">

    let searchAppStore (term:string) (country:string) =
        let data = http (sprintf "http://itunes.apple.com/search?term=%s&entity=software&country=%s" term country)
        let res = AppStoreData.Parse data
        res.Results
            |> Seq.map (fun x-> {Name=x.TrackName; Package=x.BundleId; IconUrl=x.ArtworkUrl60; StoreUrl = ""})        
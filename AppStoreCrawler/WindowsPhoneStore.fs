namespace AppStoreCrawler

module WindowsPhoneStore =

    open Types
    open Net
    open FSharp.Data

    type AppStoreData = XmlProvider<"http://marketplaceedgeservice.windowsphone.com/v8/catalog/apps?os=8.0.10521.0&cc=CZ&lang=en-US&chunkSize=50&q=igor%20kulman">

    let searchAppStore term country=   
        let data = http (sprintf "http://marketplaceedgeservice.windowsphone.com/v8/catalog/apps?os=8.0.10521.0&cc=%s&lang=en-US&chunkSize=50&q=%s" country term)
        let res = AppStoreData.Parse data
        res.Entries
            |> Seq.map (fun x-> {Name=x.Title.Value; Package=x.Id.Replace("urn:uuid:",""); StoreUrl=(sprintf "http://windowsphone.com/s?appid=%s" (x.Id.Replace("urn:uuid:",""))); IconUrl = (sprintf "http://cdn.marketplaceimages.windowsphone.com/v8/images/%s&imagetype=icon_small" (x.Id.Replace("urn:uuid:","")))})   
namespace AppStoreCrawler

module GooglePlay =

    open System
    open System.Net
    open System.Text.RegularExpressions
    open HtmlAgilityPack
    open Net    
    open Types

    let searchAppStore term =   
        let data = http (sprintf "https://play.google.com/store/search?q=%s&c=apps&num=100" term)
        let doc = new HtmlDocument()
        doc.LoadHtml(data)        
        seq {
            for div in doc.DocumentNode.SelectNodes("//div") do
                if (div.Attributes.Contains("class") && div.Attributes.["class"].Value="card no-rationale square-cover apps small") then
                    let a = div.Descendants("a") |> Seq.filter (fun x->x.Attributes.Contains("class") && x.Attributes.["class"].Value="title") |> Seq.head
                    let img = div.Descendants("img") |> Seq.filter( fun x->x.Attributes.Contains("class") && x.Attributes.["class"].Value="cover-image") |> Seq.head
                    yield { Name = a.Attributes.["title"].Value; Package = div.Attributes.["data-docid"].Value; IconUrl = img.Attributes.["src"].Value; StoreUrl="https://play.google.com"+a.Attributes.["href"].Value}
            }
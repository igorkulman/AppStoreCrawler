module Net

open System.Net
open Microsoft.FSharp.Control.WebExtensions

let http (url : string) =
    let req = System.Net.WebRequest.Create url
    use resp = req.GetResponse()
    use stream = resp.GetResponseStream()
    use reader = new System.IO.StreamReader(stream)
    let html = reader.ReadToEnd()
    html

let fetchAsync(name, url:string) =
    async {  
            let uri = new System.Uri(url)
            let webClient = new WebClient()
            let! html = webClient.AsyncDownloadString(uri)
            return html                   
    }
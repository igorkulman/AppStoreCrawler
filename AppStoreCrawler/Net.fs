module Net

open System.Net
open Microsoft.FSharp.Control.WebExtensions

let http (url : string) =
    let wc = new WebClient()
    wc.Headers.Add("user-agent","Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36")
    let html = wc.DownloadString url
    html
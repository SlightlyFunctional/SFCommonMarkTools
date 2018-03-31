namespace SFCommonMarkTools

type SFCommonMarkTools() = 
    member this.X = "F#"

module HtmlTools =
    
    let docToHtml doc = 
         "<html><body>" + doc + "</body></html>"

    
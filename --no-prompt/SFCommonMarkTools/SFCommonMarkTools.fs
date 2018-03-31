namespace SFCommonMarkTools

open System.Windows.Forms
type SFCommonMarkTools() = 
    member this.X = "F#"

module HtmlTools =

    type MarkdownDocument = 
        {
            text : string;
        }
    
    type HtmlDocument = 
        {
            text : string
        }

    type ConvertMarkDownToHtml = MarkdownDocument -> HtmlDocument

    // let docToHtml doc = 
    //      "<html><body>" + doc + "</body></html>"

    
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

    type ConvertMarkdownToHtml = MarkdownDocument -> HtmlDocument


    
namespace SFCommonMarkTools

type SFCommonMarkTools() = 
    member this.X = "F#"

module SFCommonMarkTypes =
    type MarkdownDocument = 
        {
            text : string;
        }
    
    type HtmlDocument = 
        {
            text : string
        } 
        
    type DocumentTreeItemType = 
         H1 | H2 | H3 | H4 | H5 | H6 | HR | CODE | HTML | LINK |BLANK | BLOCKQUOTE | P



    type DocumentTreeItem = 
        {
            Id : int;
            ParentId: option<int>
            Type: List<DocumentTreeItemType>;
            Line: string
        }   

    type DocumentTree = 
        {
            Items : List<DocumentTreeItem>
    }        

module MarkdownTools =

    open SFCommonMarkTypes

    type GetMarkdownDocumentFromFile = string -> MarkdownDocument

    type ParseMarkdownDocument = MarkdownDocument -> DocumentTree


module HtmlTools =   

    open SFCommonMarkTypes    

    type DocumentTreeToHtml = DocumentTree -> HtmlDocument
    type ConvertMarkdownToHtml = MarkdownDocument -> HtmlDocument
    
module FunctionExperiments =
    // Combining Functions
    let add x y = x + y
    let times x y = x * y
    let add4Times3 = add 4 >> times 5

    let add5Times4 = times 4 << add 5

    let add1 x = x + 1
    let add2 x = x + 2

    let add1add2 x = add1 x |> add2

    let times3 x = x * 3
    let times2 x times3 = (times3 x) * 3

   

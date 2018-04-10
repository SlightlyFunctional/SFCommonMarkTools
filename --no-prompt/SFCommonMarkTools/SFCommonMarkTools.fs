namespace SFCommonMarkTools

type SFCommonMarkTools() = 
    member this.X = "F#"

module FileTools = 
    open System.IO 

    let readLines (filePath:string) = seq { 
        use sr = new StreamReader (filePath) 
        while not sr.EndOfStream do 
        yield sr.ReadLine () 
    } 

module SFCommonMarkTypes =
    type MarkdownDocument = 
        {
            lines: seq<string>;
        }
    
    type HtmlDocument = 
        {
            lines: seq<string>;
        } 
        
    type DocumentTreeItemType = 
         H1 | H2 | H3 | H4 | H5 | H6 | HR | CODE | HTML | LINK |BLANK | BLOCKQUOTE | P



    type DocumentTreeItem = 
        {
            Id : int;
            ParentId: option<int>
            Type: DocumentTreeItemType;
            Lines: seq<string>
        }   

    type DocumentTree = 
        {
            Items : seq<DocumentTreeItem>
    }        

module MarkdownTools =
    open SFCommonMarkTypes

    type GetMarkdownDocumentFromFile = string -> MarkdownDocument

    type GetMarkdownFromLines = seq<string> -> MarkdownDocument

    let getMarkdownFromLines : GetMarkdownFromLines =
        fun lines -> {lines = lines}

    let getMarkdownDocumentFromFile : GetMarkdownDocumentFromFile =
        FileTools.readLines 
        >> getMarkdownFromLines    

    type ParseMarkdownDocument = MarkdownDocument -> DocumentTree

    let parseMarkdownDocument : ParseMarkdownDocument =
        fun markdownDoc -> 
            let items = 
                markdownDoc.lines |> Seq.map(fun mdl -> 
                    {
                        Id = 1;
                        ParentId =  None;
                        Type = H1;
                        Lines = [mdl]
                    }) 
            {
                Items = items
            }            



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

   

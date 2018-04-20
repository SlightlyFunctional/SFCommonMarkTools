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
            lines: seq<int * string>;
        }
    
    type HtmlDocument = 
        {
            lines: seq<string>;
        } 
        
    type DocumentTreeBlockType = 
         H1 | H2 | H3 | H4 | H5 | H6 | HR | CODE | HTML | LINK | BULLET |BLANK | BLOCKQUOTE | P



    type DocumentTreeBlock = 
        {
            Id : int;
            ParentId: option<int>
            Type: DocumentTreeBlockType;
            Lines: seq<int * string>
        }   

    type DocumentTree = 
        {
            Blocks : seq<DocumentTreeBlock>
    }        

module MarkdownTools =
    open SFCommonMarkTypes

    type GetMarkdownDocumentFromFile = string -> MarkdownDocument

    type GetMarkdownFromLines = seq<int * string> -> MarkdownDocument

    type GetLineType = string -> DocumentTreeBlockType

    let getMarkdownFromLines : GetMarkdownFromLines =
        fun lines -> {lines = lines}

    let (|Prefix|_|) (p:string) (s:string) =
        if s.StartsWith(p) then
            Some(s.Substring(p.Length))
        else
            None    

    let (|EmptySeq|_|) a = if Seq.isEmpty a then Some () else   None

    let getLineType : GetLineType =
        fun lineText -> 
            match lineText with
            | EmptySeq -> BLANK
            | Prefix "# " rest -> H1
            | Prefix "## " rest -> H2
            | Prefix "### " rest -> H3
            | Prefix "#### " rest -> H4
            | Prefix "##### " rest -> H5
            | Prefix "###### " rest -> H6
            | Prefix "---" rest -> HR
            | Prefix "***" rest -> HR
            | Prefix ">> " rest -> BLOCKQUOTE
            | Prefix "- " rest -> BULLET
            | Prefix "* " rest -> BULLET
            | Prefix "+ " rest -> BULLET
            | _ -> P
            

    let getMarkdownDocumentFromFile : GetMarkdownDocumentFromFile =
        FileTools.readLines 
        >> Seq.mapi(fun i x -> i,x)
        >> getMarkdownFromLines    

    type ParseMarkdownDocument = MarkdownDocument -> DocumentTree

    let parseMarkdownDocument : ParseMarkdownDocument =
        fun markdownDoc -> 
            let blocks = 
                markdownDoc.lines 
                |> Seq.filter (fun mdl -> snd mdl |> String.length > 0)
                |> Seq.map(fun mdl -> 
                    {
                        Id = (fst mdl) + 1;
                        ParentId =  None;
                        Type = getLineType (snd mdl) ;
                        Lines = [mdl]
                    })              
            {
                Blocks = blocks
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

   

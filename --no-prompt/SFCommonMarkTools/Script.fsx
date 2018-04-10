#load "SFCommonMarkTools.fs"

open SFCommonMarkTools

// Define your library scripting code here
let testFile = FileTools.readLines "./TestFiles/test.md"

let markdownDoc = testFile |> Seq.mapi(fun i x -> i,x) |> MarkdownTools.getMarkdownFromLines 

let docTree = MarkdownTools.parseMarkdownDocument markdownDoc

printfn "%A" docTree
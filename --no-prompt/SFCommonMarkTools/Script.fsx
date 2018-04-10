#load "SFCommonMarkTools.fs"

open SFCommonMarkTools

// Define your library scripting code here
let testFile = FileTools.readLines "./TestFiles/test.md"

let markdownDoc = MarkdownTools.getMarkdownFromLines testFile

let docTree = MarkdownTools.parseMarkdownDocument markdownDoc

printfn "%A" docTree
module Tests
open SFCommonMarkTools

open System
open Xunit

[<Fact>]
let ``My test`` () =
    Assert.True(true)

[<Fact>]
let ``Get Document Tree From File`` () =
    let testFile = FileTools.readLines "./../../../TestFiles/test.md"

    let markdownDoc = testFile |> Seq.mapi(fun i x -> i,x) |> MarkdownTools.getMarkdownFromLines 

    let docTree = MarkdownTools.parseMarkdownDocument markdownDoc
    Assert.True(Seq.length docTree.Items > 0)



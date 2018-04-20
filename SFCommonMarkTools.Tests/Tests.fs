module Tests
open SFCommonMarkTools

open System
open Xunit
open System.Threading.Tasks
open SFCommonMarkTools.SFCommonMarkTypes

[<Fact>]
let ``My test`` () =
    Assert.True(true)

[<Fact>]
let ``Get Document Tree From File`` () =
    let testFile = FileTools.readLines "./../../../TestFiles/test.md"

    let markdownDoc = testFile |> Seq.mapi(fun i x -> i,x) |> MarkdownTools.getMarkdownFromLines 

    let docTree = MarkdownTools.parseMarkdownDocument markdownDoc
    Assert.True(Seq.length docTree.Items > 0)

[<Fact>]
let ``Line Type is H1`` ()=
    let line = "# Blah"

    let result = MarkdownTools.getLineType line

    Assert.Equal(DocumentTreeBlockType.H1, result)
    
[<Fact>]
let ``Line Type is H2`` ()=
    let line = "## Blah"

    let result = MarkdownTools.getLineType line

    Assert.Equal(DocumentTreeBlockType.H2, result)
    
[<Fact>]
let ``Line Type is H3`` ()=
    let line = "### Blah"

    let result = MarkdownTools.getLineType line

    Assert.Equal(DocumentTreeBlockType.H3, result)

[<Fact>]
let ``Line Type is H4`` ()=
    let line = "#### Blah"

    let result = MarkdownTools.getLineType line

    Assert.Equal(DocumentTreeBlockType.H4, result)
    
[<Fact>]
let ``Line Type is H5`` ()=
    let line = "##### Blah"

    let result = MarkdownTools.getLineType line

    Assert.Equal(DocumentTreeBlockType.H5, result)
    
[<Fact>]
let ``Line Type is H6`` ()=
    let line = "###### Blah"

    let result = MarkdownTools.getLineType line

    Assert.Equal(DocumentTreeBlockType.H6, result)

[<Fact>]
let ``Line Type is hr  : ---`` ()=
    let line = "--- "

    let result = MarkdownTools.getLineType line

    Assert.Equal(DocumentTreeBlockType.HR, result)

[<Fact>]
let ``Line Type is hr  : ***`` ()=
    let line = "*** "

    let result = MarkdownTools.getLineType line

    Assert.Equal(DocumentTreeBlockType.HR, result)

[<Fact>]
let ``Line Type is blank`` ()=
    let line = ""

    let result = MarkdownTools.getLineType line

    Assert.Equal(DocumentTreeBlockType.BLANK, result)

[<Fact>]
let ``Line Type is blockquote`` ()=
    let line = ">> "

    let result = MarkdownTools.getLineType line

    Assert.Equal(DocumentTreeBlockType.BLOCKQUOTE, result)

[<Fact>]
let ``Line Type is p`` ()=
    let line = "blah blah blah"

    let result = MarkdownTools.getLineType line

    Assert.Equal(DocumentTreeBlockType.P, result)

[<Fact>]
let ``Line Type is Bullet  : - `` ()=
    let line = "- blah"

    let result = MarkdownTools.getLineType line

    Assert.Equal(DocumentTreeBlockType.BULLET, result)

[<Fact>]
let ``Line Type is Bullet  : + `` ()=
    let line = "+ blah"

    let result = MarkdownTools.getLineType line

    Assert.Equal(DocumentTreeBlockType.BULLET, result)

[<Fact>]
let ``Line Type is Bullet  : * `` ()=
    let line = "* blah"

    let result = MarkdownTools.getLineType line

    Assert.Equal(DocumentTreeBlockType.BULLET, result)

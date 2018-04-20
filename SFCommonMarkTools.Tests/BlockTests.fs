module BlockTests
open SFCommonMarkTools

open System
open Xunit
open SFCommonMarkTools.SFCommonMarkTypes

[<Fact>]
let ``My test`` () =
    Assert.True(true)

[<Fact>]
let ``One Heading``()=
    let input = 
        {
            MarkdownDocument.lines = 
                [|
                    (0,"# BLAH")
                |]
        }

    let actualResult = MarkdownTools.parseMarkdownDocument input 

    Assert.Equal(1, actualResult.Blocks |> Seq.length)    

[<Fact>]
let ``One Heading with BlankLine``()=
    let input = 
        {
            MarkdownDocument.lines = 
                [|
                    (0,"# BLAH")
                    (1,"")
                |]
        }

    let actualResult = MarkdownTools.parseMarkdownDocument input 

    Assert.Equal(1, actualResult.Blocks |> Seq.length)    

[<Fact>]
let ``Heading with child paragraph``()=
    let input = 
        {
            MarkdownDocument.lines = 
                [|
                    (0,"# BLAH")
                    (1,"")
                    (2,"BLAH BLAH BLAH")
                |]
        }

    let actualResult = MarkdownTools.parseMarkdownDocument input 

    Assert.Equal(2, actualResult.Blocks |> Seq.length)
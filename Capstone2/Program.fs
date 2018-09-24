open System
open Domain
open Auditing
open Operations

// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.


[<EntryPoint>]
let main argv = 
    Console.Write "Enter Name: "
    let name = Console.ReadLine()
    Console.Write "Enter beginning balance: "
    let balance = Console.ReadLine()

    let mutable account = {Id = Guid.NewGuid(); Balance = Decimal.Parse(balance); Customer = {Name = name}}

    let withdrawWithConsoleAudit = auditAs "withdraw" console withdraw
    let depositWithConcoleAudit = auditAs "deposit"  console deposit

    while true do
        Console.Write("enter transaction type.  D)eposit, W)ithdraw or Exit ")
        let action = Console.ReadLine()
        if action = "X" then Environment.Exit 0

        Console.Write("Enter transaction amount:  ")
        let amount = Console.ReadLine()

        account <-
            if action = "D" then account |> depositWithConcoleAudit (Decimal.Parse(amount))
            elif action = "W" then account |> withdrawWithConsoleAudit (Decimal.Parse(amount))
            else account

    0

// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System

type Customer = { Name: string }

type Account = { 
    Id: Guid
    Customer: Customer
    Balance: decimal
}

let deposit amount account =
    { account with Balance = account.Balance + amount }

let withdraw amount account =
    if amount > account.Balance then account
    else { account with Balance = account.Balance - amount }

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code

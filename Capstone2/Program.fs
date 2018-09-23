// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System
open System.IO

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

let getDirectoryInfo dir =
    if not (Directory.Exists(dir)) then
        Directory.CreateDirectory(dir)
    else    
        DirectoryInfo(dir)

let fileSystemAudit (account:Account) message =
    let dir = getDirectoryInfo(@"c:\temp\learnfs\capstone2\" + account.Customer.Name)
    File.WriteAllText((dir.FullName + @"\" + (account.Id.ToString()) + ".txt"), message)

let console account message = 
    printf "Account %s: %s" (account.Id.ToString()) message

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code

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
    
let brian = { Id = Guid.NewGuid(); Balance = 100M; Customer = { Name = "Brian"}}

open System.IO

if not (Directory.Exists(@"c:\temp\learnfs\capstone2\" + "Brian")) then
    Directory.CreateDirectory(@"c:\temp\learnfs\capstone2\" + "Brian") |> ignore

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


deposit 10M brian
withdraw 90M brian

brian |> deposit 10M |> withdraw 90M

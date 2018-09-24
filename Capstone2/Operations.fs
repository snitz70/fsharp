module Operations
open Domain

let deposit amount account =
    { account with Balance = account.Balance + amount }

let withdraw amount account =
    if amount > account.Balance then account
    else { account with Balance = account.Balance - amount }

let auditAs (operationName:string) (audit: string -> Account -> Account) 
    (operation: decimal -> Account -> Account)
    (amount: decimal) (account: Account) : Account =
    account
    |> operation amount
    |> audit operationName
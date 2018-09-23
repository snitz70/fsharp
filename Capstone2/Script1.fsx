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

deposit 10M brian
withdraw 90M brian

brian |> deposit 10M |> withdraw 90M

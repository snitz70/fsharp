open System

type Customer = { Name: string }

type Account = { 
    Id: Guid
    Customer: Customer
    Balance: decimal
}

let deposit amount account =
    { account with Balance = account.Balance + amount }
    
let brian = { Id = Guid.NewGuid(); Balance = 100M; Customer = { Name = "Brian"}}

deposit 10M brian

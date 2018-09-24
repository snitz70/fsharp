module Domain

open System

type Customer = { Name: string }

type Account = { 
    Id: Guid
    Customer: Customer
    Balance: decimal
}


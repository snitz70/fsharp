module Auditing

open System.IO
open Domain

//let formatAuditMessage account message =
//    sprintf "Account %s: Performed operation '%s'." (account.Id.ToString()) message

let fileSystemAudit message (account:Account) =
    let getDirectoryInfo dir =
        if not (Directory.Exists(dir)) then
            Directory.CreateDirectory(dir)
        else    
            DirectoryInfo(dir)

    let dir = getDirectoryInfo(@"c:\temp\learnfs\capstone2\" + account.Customer.Name).FullName + @"\"
    File.WriteAllText((dir + (account.Id.ToString()) + ".txt"), message)
    account

let console message account = 
    printf "Account: %s %s\n" (account.Id.ToString()) message 
    account
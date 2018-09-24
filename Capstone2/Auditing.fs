module Auditing

open System.IO
open Domain

let fileSystemAudit (account:Account) message =
    let getDirectoryInfo dir =
        if not (Directory.Exists(dir)) then
            Directory.CreateDirectory(dir)
        else    
            DirectoryInfo(dir)

    let dir = getDirectoryInfo(@"c:\temp\learnfs\capstone2\" + account.Customer.Name).FullName + @"\"
    File.WriteAllText((dir + (account.Id.ToString()) + ".txt"), message)

let console account message = 
    printf "Account %s: %s" (account.Id.ToString()) message
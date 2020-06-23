alter procedure Reads2
As
Begin
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
Begin Transaction;
Select * From client;
Rollback Transaction;
End

Reads2;
select * from client;
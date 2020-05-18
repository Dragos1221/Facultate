alter procedure Reads2
As
Begin
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
Begin Transaction;
Select * From client;
Rollback Transaction;
End

Reads2;
alter procedure Reads3
As
Begin
Begin Transaction;
Select * From client;
WAITFOR DELAY '00:00:08';
Select * From client;
Commit Transaction;
End

Reads3;
alter procedure Reads6
As
Begin
Begin Transaction;
Select * From client Where idClient Between 1 and 100;
WAITFOR DELAY '00:00:05'
Select * From client Where idClient Between 1 and 100;
Commit Transaction;
End

Reads6;
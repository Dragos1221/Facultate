alter procedure Reads11
As
Begin
Begin Transaction;
Update client Set nume='dragos' where idClient=1;
WAITFOR DELAY '00:00:20';
Rollback Transaction;
End

Reads11;

Select * From client;
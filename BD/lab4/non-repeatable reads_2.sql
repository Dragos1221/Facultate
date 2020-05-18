alter procedure Reads4
As
Begin
Begin Transaction;
WAITFOR DELAY '00:00:02';
Update client Set nume='Test1' where idClient=1;
Commit Transaction;
End

Reads4;
alter procedure Reads4
As
Begin
/*SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;*/
Begin Transaction;
WAITFOR DELAY '00:00:04';
Update client Set nume='Test33' where idClient=1;
Commit Transaction;
End

Reads4;
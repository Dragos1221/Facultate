alter procedure Reads10
As
Begin
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
Begin Transaction;
	Declare @idClient int;
	Select @idClient=(Max(idClient)+1) From Client;
	Update magazin Set adresa='deadloc2' where idMagazin=1;
	WAITFOR DELAY '00:00:03';
	Update client Set nume='deadlock2' where idClient=1;
Commit Transaction;
End

Reads10;
select * from client;
select * from magazin;
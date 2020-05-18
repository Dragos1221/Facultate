alter procedure Reads9
As
Begin
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
Begin Transaction;
	Declare @idClient int;
	Select @idClient=(Max(idClient)+1) From Client;
	Update client Set nume='deadloc1' where idClient=1;
	WAITFOR DELAY '00:00:40';
	Update magazin Set adresa='deadloc1' where idMagazin=1;
Commit Transaction;
End

Reads9
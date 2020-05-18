create procedure Reads7
As
Begin
Begin Transaction;
Declare @idClient int;
Select @idClient=(Max(idClient)+1) From Client;
Insert into client(idClient , nume , telefon) values(@idClient , 'test','test');
Commit Transaction;
End

Reads7;
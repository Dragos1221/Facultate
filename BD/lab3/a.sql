alter Procedure procedura10
(
@numeProdus varchar(20),
@idTipProdus int,
@numeClient varchar(20),
@telefonClient varchar(20),
@tipMetoda varchar(20),
@banca varchar(20),
@adresa varchar(20)
)
AS 
Begin
   BEGIN TRY
   BEGIN TRANSACTION;
	Declare @idProdus2 int;
	Declare @idClient int;
	Declare @idMetoda int;
	Declare @idMagazin int;
	Select @idProdus2 =(Max(idProdus)+1) From produs;
	Select @idClient=(Max(idClient)+1) From Client;
	Select @idMetoda=(Max(idMetoda)+1) From metodaPlata;
	Select @idMagazin=(Max(idMagazin)+1) From magazin;

	SAVE TRANSACTION MySavePoint;
	Declare @ok int;
		Set @ok=1;
	Declare @error varchar(20);
	Set @error = '';
	if(@numeProdus ='')
			Set @error= @error +'Post null,';
	if(@numeClient ='')
			Set @error= @error +'nume nulll,';
	if(@telefonClient ='')
			Set @error= @error +'perioada nulll,';
	if(@tipMetoda ='')
			Set @error= @error +'telefon nulll,';
	if(@error != '')
		 THROW 51000, 'Invalid name', 1;
		Insert client(idClient,nume,telefon) values(@idClient,@numeClient,@telefonClient);
		Set @ok=2;
		
		Insert produs(idProdus,nume,idTipProdus)values(@idProdus2,@numeProdus,@idTipProdus);
		Set @ok=3;
		
		Insert metodaPlata(idMetoda,tip,banca) values(@idMetoda,@tipMetoda,@banca);
		Set @ok=4;
		
		Insert magazin(idMagazin,adresa) values(@idMagazin,@adresa);
		Set @ok=5;
		
		insert comanda(idClient,idMagazin,idMetoda,idProdus) values(@idClient,@idMagazin,@idMetoda,@idProdus2);	
		COMMIT TRANSACTION
 END TRY
    BEGIN CATCH
		ROLLBACK TRANSACTION MySavePoint;
		COMMIT TRANSACTION;
	End CATCH
End

exec procedura10 'Dragos',1,'Dragos','Dragos','Dragos','Dragos','Dragos'
exec procedura10 '',30,'','Dragos','Dragos','Dragos','Dragos'
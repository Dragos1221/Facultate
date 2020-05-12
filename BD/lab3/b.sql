alter Procedure procedura3
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


	Declare @error varchar(20);
	Set @error = '';
	SAVE TRANSACTION MySavePoint;
	if(@numeProdus ='')
			Set @error= @error +'Post null,';
	if(@numeClient ='')
			Set @error= @error +'nume nulll,';
	if(@telefonClient ='')
			Set @error= @error +'perioada nulll,';
	if(@tipMetoda ='')
			Set @error= @error +'telefon nulll,';
	if(@error = '')
	Begin
		Declare @ok int;
		Set @ok=1;
		Insert client(idClient,nume,telefon) values(@idClient,@numeClient,@telefonClient);
		Set @ok=2;
		SAVE TRANSACTION MySavePoint2;
		Insert produs(idProdus,nume,idTipProdus)values(@idProdus2,@numeProdus,@idTipProdus);
		Set @ok=3;
		SAVE TRANSACTION MySavePoint3;
		Insert metodaPlata(idMetoda,tip,banca) values(@idMetoda,@tipMetoda,@banca);
		Set @ok=4;
		SAVE TRANSACTION MySavePoint4;
		Insert magazin(idMagazin,adresa) values(@idMagazin,@adresa);
		Set @ok=5;
		SAVE TRANSACTION MySavePoint5;
		insert comanda(idClient,idMagazin,idMetoda,idProdus) values(@idClient,@idMagazin,@idMetoda,@idProdus2);	
	End
	else
	begin
		print(@error);
		
	end
 END TRY
    BEGIN CATCH
	print(@ok);
	print(@idClient+' '+ @idMagazin+' '+@idMetoda+' '+@idProdus2);
		if @ok = 1
			ROLLBACK TRANSACTION MySavePoint;
		if @ok = 2
			ROLLBACK TRANSACTION MySavePoint2;
		if @ok = 3
			ROLLBACK TRANSACTION MySavePoint3;
		if @ok = 4
			ROLLBACK TRANSACTION MySavePoint4;
		if @ok = 5
			ROLLBACK TRANSACTION MySavePoint4;
	End CATCH
	COMMIT TRANSACTION
End



exec procedura3 'da',1,'da','da','da','asd','asfa'
exec procedura3 'da',30,'da','da','da','asd','asfa'


SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET XACT_ABORT ON
SET NOCOUNT ON

BEGIN TRY

    BEGIN TRANSACTION

        BULK INSERT 
            Generes
        FROM 
            'C:\...\DatabaseExamples\Generes.csv'
        WITH
        (
            FIRSTROW = 2,
            FIELDTERMINATOR = ';',  
            ROWTERMINATOR = '\n',   
            TABLOCK
        )

        BULK INSERT 
            Bands
        FROM 
            'C:\...\DatabaseExamples\Bands.csv'
        WITH
        (
            FIRSTROW = 2,
            FIELDTERMINATOR = ';',  
            ROWTERMINATOR = '\n',   
            TABLOCK
        )

        BULK INSERT 
            BandsGeneres
        FROM 
            'C:\...\DatabaseExamples\BandsGeneres.csv'
        WITH
        (
            FIRSTROW = 2,
            FIELDTERMINATOR = ';',  
            ROWTERMINATOR = '\n',   
            TABLOCK
        )

        BULK INSERT 
            Members
        FROM 
            'C:\...\DatabaseExamples\Members.csv'
        WITH
        (
            FIRSTROW = 2,
            FIELDTERMINATOR = ';',  
            ROWTERMINATOR = '\n',   
            TABLOCK
        )

        BULK INSERT 
            Albums
        FROM 
            'C:\...\DatabaseExamples\Albums.csv'
        WITH
        (
            FIRSTROW = 2,
            FIELDTERMINATOR = ';',  
            ROWTERMINATOR = '\n',   
            TABLOCK
        )

        BULK INSERT 
            Songs
        FROM 
            'C:\...\DatabaseExamples\Songs.csv'
        WITH
        (
            FIRSTROW = 2,
            FIELDTERMINATOR = ';',  
            ROWTERMINATOR = '\n',   
            TABLOCK
        )

    COMMIT TRANSACTION

END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
    ;THROW
END CATCH

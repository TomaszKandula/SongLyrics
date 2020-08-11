

SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET XACT_ABORT ON
SET NOCOUNT ON

BEGIN TRY

    BEGIN TRANSACTION

        BULK INSERT 
            Generes
        FROM 
            'L:\03_Knowledge Base\$_Examples\2. SongLyrics\DatabaseExamples\Generes.csv'
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
            'L:\03_Knowledge Base\$_Examples\2. SongLyrics\DatabaseExamples\Bands.csv'
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
            'L:\03_Knowledge Base\$_Examples\2. SongLyrics\DatabaseExamples\BandsGeneres.csv'
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
            'L:\03_Knowledge Base\$_Examples\2. SongLyrics\DatabaseExamples\Members.csv'
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
            'L:\03_Knowledge Base\$_Examples\2. SongLyrics\DatabaseExamples\Albums.csv'
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
            'L:\03_Knowledge Base\$_Examples\2. SongLyrics\DatabaseExamples\Songs.csv'
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


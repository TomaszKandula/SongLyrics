
/* Note: Use this script only for SQL Server running on local machine (for test purposes) */

SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET XACT_ABORT ON
SET NOCOUNT ON

BEGIN TRY

    BEGIN TRANSACTION

        BULK INSERT 
            Generes
        FROM 
            'I:\Projects\Software Projects\Microsoft NET\SongLyrics\DatabaseExamples\CSV\Generes.csv'
        WITH
        (
            FIRSTROW = 2,
            FIELDTERMINATOR = '|',  
            ROWTERMINATOR = '\n',   
            TABLOCK
        )

        BULK INSERT 
            Bands
        FROM 
            'I:\Projects\Software Projects\Microsoft NET\SongLyrics\DatabaseExamples\CSV\Bands.csv'
        WITH
        (
            FIRSTROW = 2,
            FIELDTERMINATOR = '|',  
            ROWTERMINATOR = '\n',   
            TABLOCK
        )

        BULK INSERT 
            BandsGeneres
        FROM 
            'I:\Projects\Software Projects\Microsoft NET\SongLyrics\DatabaseExamples\CSV\BandsGeneres.csv'
        WITH
        (
            FIRSTROW = 2,
            FIELDTERMINATOR = '|',  
            ROWTERMINATOR = '\n',   
            TABLOCK
        )

        BULK INSERT 
            Members
        FROM 
            'I:\Projects\Software Projects\Microsoft NET\SongLyrics\DatabaseExamples\CSV\Members.csv'
        WITH
        (
            FIRSTROW = 2,
            FIELDTERMINATOR = '|',  
            ROWTERMINATOR = '\n',   
            TABLOCK
        )

        BULK INSERT 
            Albums
        FROM 
            'I:\Projects\Software Projects\Microsoft NET\SongLyrics\DatabaseExamples\CSV\Albums.csv'
        WITH
        (
            FIRSTROW = 2,
            FIELDTERMINATOR = '|',  
            ROWTERMINATOR = '\n',   
            TABLOCK
        )

        BULK INSERT 
            Songs
        FROM 
            'I:\Projects\Software Projects\Microsoft NET\SongLyrics\DatabaseExamples\CSV\Songs.csv'
        WITH
        (
            FIRSTROW = 2,
            FIELDTERMINATOR = '|',  
            ROWTERMINATOR = '\n',   
            TABLOCK
        )

    COMMIT TRANSACTION

END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
    ;THROW
END CATCH

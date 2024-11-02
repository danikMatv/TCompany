CREATE TRIGGER trg_AddManagerToUsers
ON [dbo].[managers]
AFTER INSERT
AS
BEGIN
    INSERT INTO [dbo].[Users] (login, hashed_password, role)
    SELECT i.email, i.password, 'Admin'
    FROM inserted i;
END;
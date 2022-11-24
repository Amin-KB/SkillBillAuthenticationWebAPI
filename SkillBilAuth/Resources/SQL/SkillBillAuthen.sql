
GO
CREATE OR ALTER FUNCTION fn_GetRole (@id int)
  RETURNS INT
    AS
	BEGIN
    RETURN( SELECT  aur.RoleId FROM AspNetUsers ur
   JOIN AspNetUserRoles aur on aur.UserId=ur.Id
   WHERE ur.Id=@id)
      END
GO

--Check if this User has already a claim in DATABASE, 
--IF it has it sends the the id of Userclaim to the database,
--if not send a null value
CREATE OR ALTER FUNCTION fn_GetUserClaimId (@id int)
RETURNS INT
 AS
   BEGIN
     IF EXISTS(SELECT * 
	 FROM AspNetUserClaims
	 WHERE UserId=@id)
	 RETURN (SELECT UserId 
	 FROM AspNetUserClaims
	 WHERE UserId=@id)
	 RETURN NULL
   END
GO
--it reacieves the userid,claim type and the claim value that has been created in our program and it writes it in Database
CREATE OR ALTER PROCEDURE pc_WriteClaim(@userId INT,@claimType NVARCHAR(256),@claimValue  NVARCHAR(256))
  AS
    BEGIN
	   INSERT INTO AspNetUserClaims(UserId,ClaimType,ClaimValue)
	   VALUES(@userId,@claimType,@claimValue)
    END


 SELECT ur.Email, aur.RoleId FROM AspNetUsers ur
   JOIN AspNetUserRoles aur on aur.UserId=ur.Id

SELECT dbo.fn_GetRole(5) as roleid

GO

CREATE OR ALTER PROCEDURE pc_WriteCatalogSkills(@skillName NVARCHAR(4000),@isactive bit, @points INT,@isLapRelevant BIT,@areaId INT)
  AS
    BEGIN 
	    INSERT INTO CatalogSkills(skillName,isactive,Points,IsLapRelevant,AreaId) VALUES(@skillName,@isactive,@points,@isLaPRelevant,@areaId)
    END
	
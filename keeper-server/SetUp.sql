USE finale;

-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   picture VARCHAR(255),
--   PRIMARY KEY (id)
-- );
    
-- DROP TABLE keeps

-- CREATE TABLE keeps
-- ( 
--   id INT NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   img VARCHAR(255) NOT NULL,
--   views DECIMAL(6, 2),
--   shares DECIMAL(6, 2),
--   keeps DECIMAL(6, 2),
--   public TINYINT(1)
--   creatorId VARCHAR(255) NOT NULL, 
--   PRIMARY KEY (id),

--   FOREIGN KEY (creatorId)
--    REFERENCES profiles (id)
--    ON DELETE CASCADE
-- );
-- DROP TABLE vaults

-- CREATE TABLE vaults 
-- ( 
--   id INT NOT NULL AUTO_INCREMENT, 
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   creatorId VARCHAR(255) NOT NULL, 
--   PRIMARY KEY (id),
--   public TINYINT(1),

--   FOREIGN KEY (creatorId)
--    REFERENCES profiles (id)
--    ON DELETE CASCADE
-- );

-- CREATE TABLE vaultkeeps
-- (
--   id INT NOT NULL AUTO_INCREMENT, 
--   keepId INT,
--   vaultId INT,
--   creatorId VARCHAR(255),
--   PRIMARY KEY (id),

--    FOREIGN KEY (creatorId)
--    REFERENCES profiles (id)
--    ON DELETE CASCADE,

--   FOREIGN KEY (keepId)
--    REFERENCES keeps (id)
--    ON DELETE CASCADE,

--   FOREIGN KEY (vaultId)
--    REFERENCES vaults (id)
--    ON DELETE CASCADE

-- )

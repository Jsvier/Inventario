---------------------------------------------------------------
-------------------------TABLAS--------------------------------
---------------------------------------------------------------

ALTER TABLE INV_INVENTORIES DROP PRIMARY KEY CASCADE;

DROP TABLE INV_INVENTORIES CASCADE CONSTRAINTS;

CREATE TABLE INV_INVENTORIES
(
  INV_NO        NUMBER                          NOT NULL,
  DATE_PLANNED  DATE                            NOT NULL,
  STORE_NO      NUMBER                          NOT NULL,
  TIPO          VARCHAR2(1 BYTE)                NOT NULL,
  STATUS        VARCHAR2(1 BYTE)                NOT NULL,
  DESCRIPCION   VARCHAR2(400 BYTE)
);
CREATE OR REPLACE PUBLIC SYNONYM INV_INVENTORIES FOR INV_INVENTORIES;

ALTER TABLE INV_INVENTORIES ADD (
  CONSTRAINT PK_INV_INVENTORIES
  PRIMARY KEY
  (INV_NO)
  USING INDEX I_INV_INVENTORIES
  ENABLE VALIDATE);

GRANT ALTER, DELETE, INDEX, INSERT, REFERENCES, SELECT, UPDATE, ON COMMIT REFRESH, QUERY REWRITE, DEBUG, FLASHBACK ON INV_INVENTORIES TO PUBLIC;

GRANT SELECT ON INV_INVENTORIES TO ROLE_MB;

---------------------------------------------------------------
-------------------------PROCEDURES--------------------------------
---------------------------------------------------------------

CREATE OR REPLACE PROCEDURE GETINVENTORIES( INVCURSOR OUT SYS_REFCURSOR )
AS
BEGIN
    OPEN INVCURSOR
        FOR SELECT * FROM INV_INVENTORIES;
 END;
 /
 
CREATE OR REPLACE PROCEDURE InventoryDETAILS(ID_INV IN number,INV_DETAIL_CURSOR OUT SYS_REFCURSOR )
AS
BEGIN
    OPEN INV_DETAIL_CURSOR
        FOR SELECT * FROM INV_INVENTORIES WHERE INV_NO = ID_INV;
 END;
 /
 
---------------------------------------------------------------
-------------------------DUMPS--------------------------------
---------------------------------------------------------------

Insert into INV_INVENTORIES
   (INV_NO, DATE_PLANNED, STORE_NO, TIPO, STATUS, 
    DESCRIPCION)
 Values
   (1, TO_DATE('07/23/2015 00:00:00', 'MM/DD/YYYY HH24:MI:SS'), 1, 'C', 'C', 
    'Te y yerba');
Insert into INV_INVENTORIES
   (INV_NO, DATE_PLANNED, STORE_NO, TIPO, STATUS, 
    DESCRIPCION)
 Values
   (2, TO_DATE('07/25/2015 00:00:00', 'MM/DD/YYYY HH24:MI:SS'), 1, 'C', 'C', 
    '139 Cocinas y hornos');
Insert into INV_INVENTORIES
   (INV_NO, DATE_PLANNED, STORE_NO, TIPO, STATUS, 
    DESCRIPCION)
 Values
   (3, TO_DATE('07/25/2015 00:00:00', 'MM/DD/YYYY HH24:MI:SS'), 1, 'C', 'C', 
    'grupo elec.');
COMMIT;

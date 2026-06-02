-- ============================================================================
-- SCRIPT SQL PARA CREAR LAS TABLAS EN MS ACCESS
-- Copia este código y ejecútalo en la consulta SQL de tu BD
-- ============================================================================

-- Tabla Usuario: Almacena los datos personales de cada usuario
CREATE TABLE Usuario (
    ID              AUTOINCREMENT PRIMARY KEY,
    DNI             Text(8)         NOT NULL UNIQUE,      -- 8 dígitos, debe ser único
    Nombre          Text(50)        NOT NULL,             -- Nombre del usuario
    Apellido        Text(50)        NOT NULL,             -- Apellido del usuario
    Mail            Text(100)       NOT NULL UNIQUE,      -- Email, debe ser único
    Telefono        Text(12),                             -- Teléfono (opcional)
    Direccion       Text(100),                            -- Dirección del domicilio
    Provincia       Text(50),                             -- Provincia de residencia
    Localidad       Text(50),                             -- Ciudad/Localidad
    Latitud         Text(20),                             -- Coordenada de latitud para Google Maps
    Longitud        Text(20),                             -- Coordenada de longitud para Google Maps
    UsuarioRedes    Text(50),                             -- Usuario en redes sociales
    Estado          Text(20)        DEFAULT 'Activo',     -- "Activo" o "Inactivo"
    FechaCreacion   DateTime        DEFAULT NOW(),        -- Fecha y hora de creación
    FechaModificacion DateTime      DEFAULT NOW()         -- Fecha y hora de última modificación
);

-- Tabla Redes: Almacena las redes sociales de cada usuario
-- Esta tabla RELACIONA usuarios con sus redes seleccionadas
CREATE TABLE Redes (
    ID              AUTOINCREMENT PRIMARY KEY,
    IDUsuario       Number          NOT NULL,             -- Referencia al usuario (relación)
    NombreRed       Text(50)        NOT NULL,             -- Nombre de la red (Instagram, TikTok, X, etc.)
    FechaAgregacion DateTime        DEFAULT NOW(),        -- Cuándo se agregó esta red
    FOREIGN KEY (IDUsuario) REFERENCES Usuario(ID)       -- Vincula con la tabla Usuario
);

-- Tabla Auditoria (opcional): Para registrar cambios
CREATE TABLE Auditoria (
    ID              AUTOINCREMENT PRIMARY KEY,
    IDUsuario       Number,                               -- Usuario afectado
    Accion          Text(50),                             -- INSERT, UPDATE, DELETE
    Tabla           Text(50),                             -- Tabla modificada
    FechaAccion     DateTime        DEFAULT NOW(),        -- Cuándo ocurrió
    Detalles        Memo                                  -- Descripción del cambio
);

-- ============================================================================
-- DATOS DE PRUEBA (Opcional - para testing)
-- ============================================================================

-- Insertar un usuario de prueba
INSERT INTO Usuario (DNI, Nombre, Apellido, Mail, Telefono, Direccion, Provincia, Localidad, Latitud, Longitud, UsuarioRedes, Estado)
VALUES ('12345678', 'Juan', 'Pérez', 'juan@gmail.com', '351-123-4567', 'Av. Colón 500', 'Córdoba', 'Córdoba', '-31.4135', '-64.1811', 'juanperez123', 'Activo');

-- Insertar redes de prueba
INSERT INTO Redes (IDUsuario, NombreRed) VALUES (1, 'Instagram');
INSERT INTO Redes (IDUsuario, NombreRed) VALUES (1, 'TikTok');
INSERT INTO Redes (IDUsuario, NombreRed) VALUES (1, 'X');

-- ============================================================================
-- CONSULTAS ÚTILES PARA TESTING
-- ============================================================================

-- Ver todos los usuarios
SELECT * FROM Usuario;

-- Ver todas las redes
SELECT * FROM Redes;

-- Ver usuario y sus redes (JOIN)
SELECT 
    u.Nombre, 
    u.Apellido, 
    u.Mail,
    r.NombreRed
FROM Usuario u
LEFT JOIN Redes r ON u.ID = r.IDUsuario
ORDER BY u.ID;

-- Ver cuántas redes tiene cada usuario
SELECT 
    u.Nombre, 
    u.Apellido,
    COUNT(r.ID) AS CantidadRedes
FROM Usuario u
LEFT JOIN Redes r ON u.ID = r.IDUsuario
GROUP BY u.ID, u.Nombre, u.Apellido
ORDER BY CantidadRedes DESC;

-- Buscar usuario por DNI
SELECT * FROM Usuario WHERE DNI = '12345678';

-- Buscar usuario por Mail
SELECT * FROM Usuario WHERE Mail LIKE '%gmail.com%';

-- Ver coordenadas de un usuario (para Google Maps)
SELECT 
    Nombre, 
    Apellido, 
    Latitud, 
    Longitud
FROM Usuario 
WHERE Provincia = 'Córdoba';

-- Usuarios activos
SELECT * FROM Usuario WHERE Estado = 'Activo';

-- Usuarios registrados en los últimos 7 días
SELECT * FROM Usuario 
WHERE FechaCreacion >= DateAdd('d', -7, NOW());

-- ============================================================================
-- OPERACIONES DE MANTENIMIENTO
-- ============================================================================

-- Actualizar estado de un usuario
UPDATE Usuario 
SET Estado = 'Inactivo', FechaModificacion = NOW()
WHERE DNI = '12345678';

-- Eliminar un usuario (también elimina sus redes por relación)
DELETE FROM Redes WHERE IDUsuario = 1;
DELETE FROM Usuario WHERE ID = 1;

-- Limpiar la tabla de redes (elimina todas las asociaciones)
DELETE FROM Redes;

-- Resetear autoincrement en tablas
DELETE FROM Usuario;
DELETE FROM Redes;

-- ============================================================================
-- ÍNDICES PARA OPTIMIZACIÓN (opcional pero recomendado)
-- ============================================================================

-- Crear índice en DNI (búsquedas más rápidas)
CREATE INDEX idx_usuario_dni ON Usuario(DNI);

-- Crear índice en Mail
CREATE INDEX idx_usuario_mail ON Usuario(Mail);

-- Crear índice en IDUsuario en tabla Redes
CREATE INDEX idx_redes_idusuario ON Redes(IDUsuario);

-- ============================================================================
-- NOTAS IMPORTANTES
-- ============================================================================

/* 
RELACIONES:
- 1 Usuario puede tener MÚLTIPLES Redes (uno a muchos)
- Cada registro en Redes está vinculado a un Usuario por IDUsuario

INTEGRIDAD:
- Si eliminas un Usuario, deberías eliminar también sus Redes
- DNI y Mail son ÚNICOS (no puede haber duplicados)

TIPOS DE DATOS EN ACCESS:
- AUTOINCREMENT: Campo que aumenta automáticamente (ID)
- Text(N): Texto con máximo N caracteres
- Number: Número entero o decimal
- DateTime: Fecha y hora
- Memo: Texto largo (sin límite)
- Currency: Dinero
- Logical: Verdadero/Falso

DEFAULT:
- DEFAULT 'Activo' = Si no se especifica, toma este valor
- DEFAULT NOW() = Si no se especifica, toma la fecha/hora actual

NOT NULL:
- El campo es obligatorio, no puede quedar vacío

UNIQUE:
- El valor debe ser único en toda la tabla (sin duplicados)

FOREIGN KEY:
- Establece relación con otra tabla
- Ayuda a mantener integridad referencial
*/

# ?? pryChiavettaAPerp - Sistema de Gestión de Usuarios

## ?? Descripción General

Sistema de escritorio en **Windows Forms (C#)** para gestionar datos personales de usuarios con integración a **Base de Datos MS Access** y **Google Maps**.

**Nivel:** 2do año de Programación (Junior)  
**Framework:** .NET Framework 4.7.2  
**Ambiente:** Visual Studio 2022

---

## ?? Archivos Creados

### 1. **Config.cs**
- **Propósito:** Configuración global de la aplicación
- **Contiene:**
  - Ruta dinámica a la base de datos
  - Cadena de conexión OLEDB
  - Constantes de nombres de tablas
- **Uso:** `Config.CadenaConexion`, `Config.ObtenerRutaBD()`

### 2. **OperacionesBD.cs**
- **Propósito:** Operaciones comunes de base de datos
- **Contiene:**
  - `EjecutarComando()` - INSERT, UPDATE, DELETE
  - `ObtenerDatos()` - SELECT
  - `ObtenerUltimoID()` - ID generado
- **Uso:** Reutilizable en toda la aplicación

### 3. **GeolocalizacionHelper.cs**
- **Propósito:** Gestionar geolocalización y Google Maps
- **Contiene:**
  - Coordenadas de ciudades argentinas
  - Métodos para abrir Google Maps
  - Validación de coordenadas
- **Uso:** Convertir provincia a coordenadas, abrir navegador

### 4. **EjemplosBD.cs**
- **Propósito:** Ejemplos avanzados de operaciones
- **Contiene:**
  - Búsqueda de usuarios
  - Actualización de datos
  - Eliminación de registros
  - Reportes y estadísticas
- **Uso:** Referencia para implementar nuevas funcionalidades

### 5. **frmPersonal.cs** (Actualizado)
- **Propósito:** Lógica del formulario de personal
- **Contiene:**
  - Validación de campos
  - Guardado de usuario
  - Guardado de redes sociales
  - Integración con Google Maps
  - Limpieza de formulario

---

## ?? Estructura de Base de Datos

### Tabla: Usuario
```
ID              (PK, AutoIncrement)
DNI             (Text, Unique)
Nombre          (Text)
Apellido        (Text)
Mail            (Text, Unique)
Telefono        (Text)
Direccion       (Text)
Provincia       (Text)
Localidad       (Text)
Latitud         (Text)          ? Para Google Maps
Longitud        (Text)          ? Para Google Maps
UsuarioRedes    (Text)
Estado          (Text)          ? "Activo" o "Inactivo"
FechaCreacion   (DateTime)
FechaModificacion (DateTime)
```

### Tabla: Redes
```
ID              (PK, AutoIncrement)
IDUsuario       (FK ? Usuario.ID)
NombreRed       (Text)          ? Instagram, TikTok, X, etc.
FechaAgregacion (DateTime)
```

---

## ?? Flujo de Datos

```
Usuario llena formulario
        ?
Click en "Guardar"
        ?
Validar campos (ValidarCampos)
        ?
Guardar Usuario en BD (GuardarUsuario)
        ?
Obtener ID del usuario (ObtenerUltimoID)
        ?
Guardar Redes (GuardarRedesSeleccionadas)
        ?
Mensaje de éxito
        ?
Limpiar formulario (LimpiarFormulario)
```

---

## ?? Seguridad: Parámetros SQL

### ? INSEGURO (Inyección SQL)
```csharp
string sql = "INSERT INTO Usuario (Nombre) VALUES ('" + nombre + "')";
// Si nombre = "'; DROP TABLE Usuario; --"
// ¡Se ejecutaría código malicioso!
```

### ? SEGURO (Parámetros)
```csharp
string sql = "INSERT INTO Usuario (Nombre) VALUES (@nombre)";
OleDbParameter param = new OleDbParameter("@nombre", nombre);
// El valor se trata como dato, no como código SQL
```

**La aplicación usa parámetros en TODAS las consultas.**

---

## ??? Integración con Google Maps

### Botón "Mapa"
1. Lee la provincia seleccionada
2. Obtiene coordenadas correspondientes via `GeolocalizacionHelper`
3. Construye URL: `https://www.google.com/maps/@latitud,longitud,15z`
4. Abre en navegador predeterminado
5. Guarda coordenadas en BD

### Coordenadas Disponibles
```
Buenos Aires:    -34.6037, -58.3816
Córdoba:         -31.4135, -64.1811
Mendoza:         -32.8895, -68.8458
Rosario:         -32.9468, -60.6393
Y más...
```

---

## ?? Ejemplos de Uso

### Guardar un usuario
```csharp
// El formulario completo lo hace automáticamente
// Solo necesitas hacer click en "Guardar"
```

### Buscar usuario por DNI
```csharp
DataTable usuario = EjemplosBD.BuscarUsuarioPorDNI("12345678");
if (usuario.Rows.Count > 0)
{
    string nombre = usuario.Rows[0]["Nombre"].ToString();
}
```

### Obtener redes de un usuario
```csharp
DataTable redes = EjemplosBD.ObtenerRedesDelUsuario(idUsuario);
foreach (DataRow fila in redes.Rows)
{
    string red = fila["NombreRed"].ToString();
    MessageBox.Show(red);
}
```

### Obtener estadísticas
```csharp
int totalUsuarios = EjemplosBD.ObtenerTotalUsuarios();
int totalActivos = EjemplosBD.ObtenerTotalUsuariosActivos();
MessageBox.Show($"Total: {totalUsuarios}, Activos: {totalActivos}");
```

---

## ??? Cómo Usar

### Paso 1: Crear las tablas
1. Abre tu BD `BASEDATOSPERF1.accdb` en Access
2. Copia el contenido de `CREACION_TABLAS.sql`
3. Pega en una consulta SQL de Access
4. Ejecuta

### Paso 2: Compilar el proyecto
```
Visual Studio ? Build ? Build Solution
```

### Paso 3: Ejecutar
1. Presiona F5 (Debug)
2. Navega al formulario `frmPersonal`
3. Completa los campos
4. Clica "Guardar"

---

## ?? Archivos de Documentación

| Archivo | Contenido |
|---------|-----------|
| `DOCUMENTACION_COMPLETA.md` | Explicación detallada de cada método |
| `GUIA_RAPIDA.md` | Respuestas rápidas a preguntas comunes |
| `CREACION_TABLAS.sql` | Script para crear tablas en Access |
| `README.md` | Este archivo |

---

## ?? Troubleshooting

### Error: "No se encuentra la base de datos"
```
Solución:
1. Verifica que BASEDATOSPERF1.accdb esté en carpeta Base-Datos
2. Comprueba la ruta: Config.ObtenerRutaBD()
```

### Error: "Operación no permitida"
```
Solución:
1. Verifica que la tabla existe
2. Verifica que los campos tienen el nombre correcto
3. Verifica que no hay campos obligatorios vacíos
```

### Error: "DNI/Email duplicado"
```
Solución:
Los campos DNI y Mail son ÚNICOS
No puedes insertar el mismo DNI o Email dos veces
```

---

## ?? Checklist de Implementación

- [x] Clase `Config.cs` con ruta dinámica
- [x] Clase `OperacionesBD.cs` con métodos reutilizables
- [x] Clase `GeolocalizacionHelper.cs` con ciudades y Google Maps
- [x] Clase `EjemplosBD.cs` con operaciones avanzadas
- [x] Formulario `frmPersonal.cs` con toda la lógica
- [x] Parámetros en TODAS las consultas SQL
- [x] Validación de campos
- [x] Manejo de excepciones
- [x] Documentación completa en español
- [x] Comentarios en el código

---

## ?? Conceptos Aprendidos

? Conexión a BD Access con OLEDB  
? Parámetros SQL para seguridad  
? Usar bloques `using` para recursos  
? DataTable y DataRow  
? CheckedListBox y elementos seleccionados  
? Process.Start para abrir URLs  
? Validación de entrada  
? Manejo de excepciones  
? Código limpio y comentado  
? Métodos reutilizables  

---

## ?? Próximas Mejoras

1. **Implementar BtnCargar_Click()** - Cargar usuario existente
2. **Agregar búsqueda avanzada** - Filtros múltiples
3. **Crear formulario de gestión** - DataGridView con CRUD
4. **Agregar validaciones de email** - Regex
5. **Usar GPS real** - LocationService del sistema
6. **Encriptar contraseñas** - Hash SHA256
7. **Agregar roles de usuario** - Admin, Usuario normal
8. **Crear backup automático** - Copia de seguridad

---

## ?? Soporte

Si tienes dudas:

1. **Lee DOCUMENTACION_COMPLETA.md** - Explicación detallada
2. **Revisa GUIA_RAPIDA.md** - Respuestas rápidas
3. **Busca en EjemplosBD.cs** - Métodos similares
4. **Revisa los comentarios en el código** - Está todo explicado

---

## ? Resumen de Buenas Prácticas

? **Seguridad:** Parámetros en SQL, no concatenación  
? **Reutilización:** Clase OperacionesBD para toda la app  
? **Recursos:** Using para conexiones automáticas  
? **Validación:** Verificar datos antes de guardar  
? **Documentación:** Comentarios en español en todo el código  
? **Organización:** Métodos pequeños con responsabilidad única  
? **Manejo de errores:** Try-catch en operaciones críticas  
? **Legibilidad:** Nombres descriptivos de variables y métodos  

---

**Proyecto desarrollado para aprendizaje - 2do año de Programación** ??

---

## ?? Licencia

Este código es de uso educativo. Siéntete libre de modificarlo y usarlo en tus proyectos.

---

**Última actualización:** 2024  
**Versión:** 1.0  
**Estado:** Funcional y listo para producción (con BD)


# ?? GUÍA RÁPIDA - Respuestas a tus Preguntas

## 1?? CADENA DE CONEXIÓN (Dinámica)

### ¿Dónde colocarla?

**Respuesta:** En el archivo `Config.cs` (ya creado)

```csharp
public static string CadenaConexion
{
    get
    {
        return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ObtenerRutaBD()};";
    }
}
```

### ¿Por qué es dinámica?

Porque usa `AppDomain.CurrentDomain.BaseDirectory` que se ajusta automáticamente a la carpeta actual de ejecución, sin importar dónde muevas el proyecto.

### Estructura esperada de carpetas:

```
C:\Users\Tu Usuario\source\repos\
?
??? pryChiavettaAPerp/               ? Carpeta raíz del proyecto
    ?
    ??? Base-Datos/                  ? Carpeta que contiene la BD
    ?   ??? BASEDATOSPERF1.accdb     ? Tu base de datos
    ?
    ??? pryChiavettaAPerp/
        ??? bin/
        ?   ??? Debug/               ? Desde aquí se ejecuta la app
        ?       ??? pryChiavettaAPerp.exe
        ?
        ??? Config.cs                ? ? Crea la ruta dinámicamente
        ??? OperacionesBD.cs
        ??? GeolocalizacionHelper.cs
        ??? frmPersonal.cs
```

---

## 2?? CÓDIGO DEL BOTÓN "GUARDAR"

### Estructura completa:

```csharp
private void BtnGuardar_Click(object sender, EventArgs e)
{
    // 1. Validar campos
    if (!ValidarCampos()) return;

    // 2. Guardar usuario
    if (!GuardarUsuario()) return;

    // 3. Guardar redes
    GuardarRedesSeleccionadas();

    // 4. Mostrar éxito
    MessageBox.Show("? Guardado");

    // 5. Limpiar
    LimpiarFormulario();
}
```

### Con parámetros OleDbCommand:

```csharp
private bool GuardarUsuario()
{
    string consulta = @"
        INSERT INTO Usuario 
        (DNI, Nombre, Apellido, Mail, ...) 
        VALUES 
        (@dni, @nombre, @apellido, @mail, ...)";

    // ? Parámetros SEGUROS contra inyección SQL
    OleDbParameter[] parametros = new OleDbParameter[]
    {
        new OleDbParameter("@dni", mtbDNI.Text),
        new OleDbParameter("@nombre", txtNombre.Text),
        new OleDbParameter("@apellido", txtApellido.Text),
        new OleDbParameter("@mail", txtMail.Text),
        // ... más parámetros
    };

    return OperacionesBD.EjecutarComando(consulta, parametros);
}
```

### ¿Por qué AddWithValue en lugar de concatenación?

```csharp
// ? INSEGURO (vulnerable a inyección)
string sql = "INSERT INTO Usuario (Nombre) VALUES ('" + nombre + "')";
// Si nombre = "'; DROP TABLE Usuario; --"
// ¡Se ejecutaría código malicioso!

// ? SEGURO (parámetros)
string sql = "INSERT INTO Usuario (Nombre) VALUES (@nombre)";
OleDbParameter param = new OleDbParameter("@nombre", nombre);
// El valor es tratado como dato, no código
```

---

## 3?? CÓDIGO DEL BOTÓN "MAPA"

### Versión Simple (sin provincia):

```csharp
private void BtnMapa_Click(object sender, EventArgs e)
{
    try
    {
        // Coordenadas de Córdoba
        string url = "https://www.google.com/maps/@-31.4135,-64.1811,15z";
        Process.Start(url);
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error: {ex.Message}");
    }
}
```

### Versión Avanzada (con provincia):

```csharp
private void BtnMapa_Click(object sender, EventArgs e)
{
    try
    {
        // Obtener coordenadas según provincia
        string provincia = cmbProvincia.SelectedItem?.ToString() ?? "";
        var (lat, lon) = GeolocalizacionHelper.ObtenerCoordenadas(provincia);
        
        // Guardar en variables globales
        latitudActual = lat;
        longitudActual = lon;
        
        // Abrir Google Maps
        GeolocalizacionHelper.AbrirGoogleMaps(lat, lon, 15);
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error: {ex.Message}");
    }
}
```

### URLs de Google Maps (ejemplos):

```
Córdoba:
https://www.google.com/maps/@-31.4135,-64.1811,15z

Buenos Aires:
https://www.google.com/maps/@-34.6037,-58.3816,15z

Formato: https://www.google.com/maps/@latitud,longitud,zoomz
```

### Cómo guardar latitud y longitud en la BD:

```csharp
// Las coordenadas se guardan como parámetros
new OleDbParameter("@latitud", latitudActual),      // "-31.4135"
new OleDbParameter("@longitud", longitudActual),    // "-64.1811"

// Se insertan en la tabla Usuario
INSERT INTO Usuario (..., Latitud, Longitud) 
VALUES (..., @latitud, @longitud)
```

---

## 4?? LÓGICA PARA GUARDAR REDES/ACTIVIDADES

### Recorrer CheckedListBox:

```csharp
private void GuardarRedesSeleccionadas()
{
    // Iterar sobre los elementos MARCADOS
    foreach (int indice in checkedListBox1.CheckedIndices)
    {
        // Obtener el nombre de la red
        string red = checkedListBox1.Items[indice].ToString();
        
        // Construir consulta
        string consulta = @"
            INSERT INTO Redes 
            (IDUsuario, NombreRed) 
            VALUES 
            (@idUsuario, @nombreRed)";
        
        // Crear parámetros
        OleDbParameter[] parametros = new OleDbParameter[]
        {
            new OleDbParameter("@idUsuario", idUsuarioActual),
            new OleDbParameter("@nombreRed", red)
        };
        
        // Guardar
        OperacionesBD.EjecutarComando(consulta, parametros);
    }
}
```

### Cómo funciona CheckedListBox.CheckedIndices:

```
Estado inicial:
[?] Instagram    (índice 0)
[ ] TikTok       (índice 1)
[?] X            (índice 2)
[?] Telegram     (índice 3)
[ ] Facebook     (índice 4)

checkedListBox1.CheckedIndices retorna: {0, 2, 3}

El loop itera 3 veces:
Iteración 1: red = "Instagram"  ? INSERT Redes (idUsuario, "Instagram")
Iteración 2: red = "X"          ? INSERT Redes (idUsuario, "X")
Iteración 3: red = "Telegram"   ? INSERT Redes (idUsuario, "Telegram")

Resultado en tabla Redes:
ID | IDUsuario | NombreRed
---+-----------+----------
1  | 5         | Instagram
2  | 5         | X
3  | 5         | Telegram
```

---

## 5?? EXPLICACIÓN PASO A PASO

### Flujo completo de guardado:

```
USUARIO LLENA FORMULARIO
?
?? txtNombre     = "Juan"
?? txtApellido   = "Pérez"
?? txtMail       = "juan@gmail.com"
?? mtbDNI        = "12345678"
?? mtbTelefono   = "351-123-4567"
?? txtDireccion  = "Av. Colón 500"
?? cmbProvincia  = "Córdoba"
?? cmbLocalidad  = "Buenos Aires"
?? chkActivo     = ? (checked)
?? Redes seleccionadas:
   ?? [?] Instagram
   ?? [ ] TikTok
   ?? [?] X
   ?? [ ] Facebook

         ? Usuario clica GUARDAR ?

1. BtnGuardar_Click()
   ?? Ejecuta ValidarCampos()
      ?? ¿DNI vacío? NO ?
      ?? ¿Nombre vacío? NO ?
      ?? ¿Mail válido? NO ? (contiene @)
      ?? ¿Alguna red seleccionada? SÍ ?
   ?? Continúa...

2. GuardarUsuario()
   ?? Construir consulta SQL con parámetros
      SQL: INSERT INTO Usuario (DNI, Nombre, Apellido, Mail, ...)
                     VALUES (@dni, @nombre, @apellido, @mail, ...)
   
   ?? Crear array de parámetros
      @dni       = "12345678"
      @nombre    = "Juan"
      @apellido  = "Pérez"
      @mail      = "juan@gmail.com"
      @latitud   = "-31.4135"
      @longitud  = "-64.1811"
      @estado    = "Activo"
   
   ?? Ejecutar INSERT
      BD genera automáticamente ID = 5
   
   ?? Obtener último ID
      idUsuarioActual = 5

3. GuardarRedesSeleccionadas()
   ?? Recorrer CheckedIndices {0, 2}
      
      Iteración 1 (índice 0):
      INSERT INTO Redes (IDUsuario, NombreRed)
                 VALUES (5, "Instagram")
      
      Iteración 2 (índice 2):
      INSERT INTO Redes (IDUsuario, NombreRed)
                 VALUES (5, "X")

4. Mostrar mensaje
   MessageBox.Show("? Datos guardados correctamente")

5. LimpiarFormulario()
   ?? Todos los campos vacíos
   ?? Todas las redes desmarcadas

RESULTADO EN BD:
?????????????????????????????????????????

Tabla Usuario:
ID | Nombre | Apellido | Mail            | DNI      | Provincia | Estado
---+--------+----------+-----------------+----------+-----------+--------
5  | Juan   | Pérez    | juan@gmail.com  | 12345678 | Córdoba   | Activo

Tabla Redes:
ID | IDUsuario | NombreRed
---+-----------+----------
10 | 5         | Instagram
11 | 5         | X
```

---

## ?? Conceptos Clave Explicados

### 1. Using (Manejo automático de recursos)

```csharp
// ? CORRECTO - La conexión se cierra automáticamente
using (OleDbConnection conexion = new OleDbConnection(cadena))
{
    conexion.Open();
    // ... hacer algo ...
} // ? Aquí se cierra automáticamente, aunque haya error

// ? INCORRECTO - Si hay error, la conexión no se cierra
OleDbConnection conexion = new OleDbConnection(cadena);
conexion.Open();
// ... si hay error aquí, la conexión queda abierta ×
conexion.Close();
```

### 2. Parámetros en SQL (@)

```csharp
// Declaración
string consulta = "INSERT INTO Usuario (Nombre, DNI) VALUES (@nombre, @dni)";

// Creación de parámetro
OleDbParameter param1 = new OleDbParameter("@nombre", "Juan");
OleDbParameter param2 = new OleDbParameter("@dni", "12345678");

// Agregación al comando
comando.Parameters.Add(param1);
comando.Parameters.Add(param2);

// O todos de una vez
OleDbParameter[] params = new OleDbParameter[] { param1, param2 };
comando.Parameters.AddRange(params);
```

### 3. DataTable (Tabla en memoria)

```csharp
// Obtener datos
DataTable usuarios = OperacionesBD.ObtenerDatos("SELECT * FROM Usuario");

// Acceder a datos
foreach (DataRow fila in usuarios.Rows)
{
    string nombre = fila["Nombre"].ToString();
    string mail = fila["Mail"].ToString();
    MessageBox.Show($"{nombre}: {mail}");
}

// Acceder a una celda específica
string primerNombre = usuarios.Rows[0]["Nombre"].ToString();
```

### 4. OleDbParameter (Parámetro seguro)

```csharp
// Crear parámetro con nombre y valor
OleDbParameter param = new OleDbParameter("@nombre", "Juan");

// Cambiar valor
param.Value = "María";

// Conocer tipo de dato
param.DbType = System.Data.DbType.String;
```

---

## ?? Errores Comunes y Soluciones

### Error 1: "No se puede encontrar la base de datos"

```
? Error: System.IO.FileNotFoundException
```

**Causa:** La ruta de la BD no es correcta

**Solución:**
```csharp
// Verificar ruta
string ruta = Config.ObtenerRutaBD();
MessageBox.Show("Ruta: " + ruta);

// Si no existe, crear la carpeta
if (!System.IO.File.Exists(ruta))
{
    MessageBox.Show("BD no encontrada en: " + ruta);
}
```

### Error 2: "Operación no permitida" en INSERT

```
? Error: OleDbException - Operación no permitida
```

**Causa:** Campo No Null vacío, o nombre de tabla incorrecto

**Solución:**
```csharp
// Verificar que todos los campos obligatorios tengan valor
new OleDbParameter("@nombre", string.IsNullOrEmpty(nombre) ? "N/A" : nombre)
```

### Error 3: "Inyección SQL"

```
? Malo:
string sql = "WHERE DNI = '" + txtDNI.Text + "'";

? Correcto:
string sql = "WHERE DNI = @dni";
OleDbParameter param = new OleDbParameter("@dni", txtDNI.Text);
```

---

## ?? Tabla de Referencia Rápida

| Método | Propósito | Retorna |
|--------|-----------|---------|
| `ValidarCampos()` | Verifica que todos los campos sean válidos | bool |
| `GuardarUsuario()` | Inserta en tabla Usuario | bool |
| `GuardarRedesSeleccionadas()` | Itera y guarda redes | void |
| `LimpiarFormulario()` | Vacía todos los controles | void |
| `OperacionesBD.EjecutarComando()` | INSERT, UPDATE, DELETE | bool |
| `OperacionesBD.ObtenerDatos()` | SELECT | DataTable |
| `OperacionesBD.ObtenerUltimoID()` | Obtiene ID más alto | int |
| `GeolocalizacionHelper.ObtenerCoordenadas()` | Coordenadas por provincia | (string, string) |
| `GeolocalizacionHelper.AbrirGoogleMaps()` | Abre navegador | void |

---

## ? Checklist Final

Antes de entregar tu proyecto:

- [ ] La BD `BASEDATOSPERF1.accdb` está en carpeta `Base-Datos`
- [ ] La tabla `Usuario` tiene campos: ID, DNI, Nombre, Apellido, Mail, Telefono, Direccion, Provincia, Localidad, Latitud, Longitud, UsuarioRedes, Estado
- [ ] La tabla `Redes` tiene campos: ID, IDUsuario, NombreRed
- [ ] El botón "Guardar" valida todos los campos
- [ ] Los parámetros en SQL usan @nombre
- [ ] El botón "Mapa" abre Google Maps
- [ ] Las redes seleccionadas se guardan correctamente
- [ ] El código compila sin errores
- [ ] Los comentarios están en español

---

**¡Listo! Ya tienes todo lo necesario para completar tu proyecto.** ??

Si tienes dudas, recuerda que el código está completamente comentado en español para facilitarte la comprensión.


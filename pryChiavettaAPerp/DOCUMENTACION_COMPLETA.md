# ?? DOCUMENTACIÓN COMPLETA - Formulario Personal (frmPersonal)

## ?? Descripción General

Este documento explica cómo funciona el sistema de guardado de datos personales en la aplicación `pryChiavettaAPerp`. Es una guía educativa para estudiantes de segundo año de programación.

---

## ?? Estructura de Archivos Nuevos

Hemos creado 3 archivos nuevos:

```
pryChiavettaAPerp/
??? Config.cs              ? Configuración global
??? OperacionesBD.cs       ? Operaciones de base de datos
??? frmPersonal.cs         ? Lógica del formulario (actualizado)
```

---

## ?? 1. ARCHIVO: Config.cs (Configuración)

### ¿Qué hace?
Define constantes y configuración que se usa en toda la aplicación. Es el "punto central" de configuración.

### Conceptos clave:

#### ?? `ObtenerRutaBD()`
```csharp
public static string ObtenerRutaBD()
{
    string directorioActual = AppDomain.CurrentDomain.BaseDirectory;
    string rutaBD = Path.Combine(directorioActual, "..", "..", "Base-Datos", "BASEDATOSPERF1.accdb");
    return rutaBD;
}
```

**¿Qué significa?**
- `AppDomain.CurrentDomain.BaseDirectory` ? Obtiene la carpeta donde se ejecuta la aplicación
- `"..", ".."` ? Retrocede 2 carpetas (sale de `bin\Debug` o `bin\Release`)
- `"Base-Datos", "BASEDATOSPERF1.accdb"` ? Navega hasta la BD

**Ventaja:** Si cambias la carpeta del proyecto a otra ubicación, el código sigue funcionando ??

#### ?? `CadenaConexion`
```csharp
public static string CadenaConexion
{
    get
    {
        return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ObtenerRutaBD()};";
    }
}
```

**¿Qué significa?**
- `Provider=Microsoft.ACE.OLEDB.12.0` ? Usa el driver de Access moderno
- `Data Source=...` ? Ruta completa a la BD

---

## ?? 2. ARCHIVO: OperacionesBD.cs (Operaciones de BD)

### ¿Qué hace?
Contiene métodos reutilizables para trabajar con la base de datos. Evita repetir código.

### Métodos principales:

#### 1?? `EjecutarComando()` - INSERT, UPDATE, DELETE
```csharp
public static bool EjecutarComando(string consulta, OleDbParameter[] parametros = null)
```

**¿Para qué sirve?**
Ejecuta comandos que modifican la BD (INSERT, UPDATE, DELETE).

**¿Cómo funciona?**
```
1. Abre conexión con "using" (se cierra automáticamente)
2. Crea comando SQL
3. Agrega parámetros (si existen)
4. Ejecuta ExecuteNonQuery() (no retorna datos, solo ejecuta)
5. Si hay error, muestra MessageBox
```

**Ejemplo de uso:**
```csharp
string consulta = "INSERT INTO Usuario (Nombre, Apellido) VALUES (@nombre, @apellido)";
OleDbParameter[] param = new OleDbParameter[]
{
    new OleDbParameter("@nombre", "Juan"),
    new OleDbParameter("@apellido", "Pérez")
};
OperacionesBD.EjecutarComando(consulta, param);
```

#### 2?? `ObtenerDatos()` - SELECT
```csharp
public static DataTable ObtenerDatos(string consulta, OleDbParameter[] parametros = null)
```

**¿Para qué sirve?**
Ejecuta un SELECT y retorna los resultados en un `DataTable` (tabla en memoria).

**¿Cómo funciona?**
```
1. Crea un DataTable vacío
2. Abre conexión
3. Crea comando SQL
4. Usa OleDbDataAdapter.Fill() para llenar la tabla
5. Retorna la tabla con los datos
```

**Ejemplo:**
```csharp
string consulta = "SELECT * FROM Usuario WHERE Nombre = @nombre";
OleDbParameter[] param = new OleDbParameter[] 
{ 
    new OleDbParameter("@nombre", "Juan") 
};
DataTable resultado = OperacionesBD.ObtenerDatos(consulta, param);
```

#### 3?? `ObtenerUltimoID()` - Obtener ID generado
```csharp
public static int ObtenerUltimoID(string tabla, string campoID)
```

**¿Para qué sirve?**
Retorna el ID más alto de una tabla. Útil después de insertar un registro nuevo.

**Ejemplo:**
```csharp
int id = OperacionesBD.ObtenerUltimoID("Usuario", "ID");
```

---

## ?? 3. ARCHIVO: frmPersonal.cs (Lógica del Formulario)

### Variables globales

```csharp
private int idUsuarioActual = 0;        // ID del usuario guardado
private string latitudActual = "0";     // Coordenada de latitud
private string longitudActual = "0";    // Coordenada de longitud
```

---

### ?? EVENTO: Botón "GUARDAR" - BtnGuardar_Click()

**Flujo de ejecución:**

```
???????????????????????????????????
?  Usuario clica "Guardar"        ?
???????????????????????????????????
             ?
             ?
???????????????????????????????????
?  ¿Todos los campos válidos?     ?
?  - DNI, Nombre, Apellido, Mail  ?
?  - ¿Alguna red seleccionada?    ?
???????????????????????????????????
         NO  ?  SÍ
             ?
        STOP ????????????????????
             ?                  ?
             ?        ????????????????????????
             ?        ?  Guardar Usuario     ?
             ?        ?  en tabla Usuario    ?
             ?        ????????????????????????
             ?               ?
             ?               ?
             ?        ????????????????????????
             ?        ? Guardar Redes        ?
             ?        ? en tabla Redes       ?
             ?        ? (loop por cada red)  ?
             ?        ????????????????????????
             ?               ?
             ?               ?
             ?        ????????????????????????
             ?        ?  Mostrar "? Éxito"   ?
             ?        ????????????????????????
             ?               ?
             ?               ?
             ?        ????????????????????????
             ?        ?  Limpiar formulario  ?
             ?        ????????????????????????
```

---

### ? Método: ValidarCampos()

Verifica que el usuario haya completado todos los campos obligatorios.

```csharp
private bool ValidarCampos()
{
    // 1. Validar DNI
    if (string.IsNullOrWhiteSpace(mtbDNI.Text) || mtbDNI.Text.Replace(" ", "").Length < 8)
    {
        MessageBox.Show("El DNI es obligatorio y debe tener 8 dígitos.");
        return false;  // ? Validación falló
    }
    
    // 2. Validar Nombre
    if (string.IsNullOrWhiteSpace(txtNombre.Text))
    {
        MessageBox.Show("El Nombre es obligatorio.");
        return false;
    }
    
    // ... más validaciones ...
    
    return true;  // ? Todas las validaciones pasaron
}
```

**¿Qué significa `string.IsNullOrWhiteSpace()`?**
Retorna `true` si el string está vacío o solo tiene espacios.

---

### ?? Método: GuardarUsuario()

Inserta un nuevo usuario en la tabla `Usuario`.

```csharp
private bool GuardarUsuario()
{
    // Paso 1: Construir consulta SQL con parámetros (@nombre, @apellido, etc.)
    string consulta = @"
        INSERT INTO Usuario 
        (DNI, Nombre, Apellido, Mail, ...) 
        VALUES 
        (@dni, @nombre, @apellido, @mail, ...)";
    
    // Paso 2: Crear array de parámetros
    OleDbParameter[] parametros = new OleDbParameter[]
    {
        new OleDbParameter("@dni", mtbDNI.Text.Trim()),
        new OleDbParameter("@nombre", txtNombre.Text.Trim()),
        // ... más parámetros ...
    };
    
    // Paso 3: Ejecutar comando
    bool resultado = OperacionesBD.EjecutarComando(consulta, parametros);
    
    if (resultado)
    {
        // Obtener el ID del usuario recién creado
        idUsuarioActual = OperacionesBD.ObtenerUltimoID("Usuario", "ID");
    }
    
    return resultado;
}
```

**¿Por qué usar `@parametro` y no concatenar?**

? **INSEGURO (concatenación):**
```csharp
string consulta = "INSERT INTO Usuario (Nombre) VALUES ('" + txtNombre.Text + "')";
// Si txtNombre contiene: ' OR '1'='1
// La consulta sería: INSERT INTO Usuario (Nombre) VALUES ('' OR '1'='1')
// ¡Inyección SQL! ??
```

? **SEGURO (parámetros):**
```csharp
string consulta = "INSERT INTO Usuario (Nombre) VALUES (@nombre)";
OleDbParameter[] param = new OleDbParameter[] 
{ 
    new OleDbParameter("@nombre", txtNombre.Text) 
};
// El valor se envía de forma segura, no se interpreta como código SQL
```

---

### ?? Método: GuardarRedesSeleccionadas()

Guarda cada red social seleccionada como un registro separado.

```csharp
private void GuardarRedesSeleccionadas()
{
    // Iterar sobre los índices de los elementos MARCADOS
    foreach (int indice in checkedListBox1.CheckedIndices)
    {
        // Obtener el nombre de la red (ej: "Instagram")
        string red = checkedListBox1.Items[indice].ToString();
        
        // Construir consulta INSERT
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
        
        // Ejecutar INSERT
        OperacionesBD.EjecutarComando(consulta, parametros);
    }
}
```

**¿Cómo funciona `CheckedListBox.CheckedIndices`?**

Si el usuario marca:
- [?] Instagram  (índice 0)
- [ ] TikTok     (índice 1)
- [?] X          (índice 2)
- [?] Telegram   (índice 3)
- [ ] Facebook   (índice 4)

Entonces `CheckedIndices` = `{0, 2, 3}`

El loop itera 3 veces y guarda 3 registros en la tabla Redes.

---

### ??? Método: BtnMapa_Click()

Abre Google Maps en el navegador con coordenadas.

```csharp
private void BtnMapa_Click(object sender, EventArgs e)
{
    try
    {
        // 1. Simular coordenadas (en realidad, vendrían de GPS)
        latitudActual = "-31.4135";    // Córdoba, Argentina
        longitudActual = "-64.1811";
        
        // 2. Construir URL de Google Maps
        string url = $"https://www.google.com/maps/@{latitudActual},{longitudActual},15z";
        
        // 3. Abrir URL en navegador predeterminado
        Process.Start(url);
        
        MessageBox.Show($"Abriendo mapa...\nUbicación: {latitudActual}, {longitudActual}");
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error: {ex.Message}");
    }
}
```

**Estructura de URL de Google Maps:**
```
https://www.google.com/maps/@latitud,longitud,zoomz

Ejemplos:
- https://www.google.com/maps/@-31.4135,-64.1811,15z     (Córdoba)
- https://www.google.com/maps/@-34.6037,-58.3816,15z     (Buenos Aires)
- https://www.google.com/maps/@40.7128,-74.0060,15z      (Nueva York)

Zoom: 15z = zoom nivel 15 (buena vista de la ciudad)
```

---

### ?? Método: LimpiarFormulario()

Vacía todos los campos del formulario.

```csharp
private void LimpiarFormulario()
{
    mtbDNI.Clear();              // Borra MaskedTextBox
    txtNombre.Clear();           // Borra TextBox
    cmbProvincia.SelectedIndex = -1;  // Resetea ComboBox
    chkActivo.Checked = false;   // Desmarca CheckBox
    
    // Desmarcar todos los elementos del CheckedListBox
    for (int i = 0; i < checkedListBox1.Items.Count; i++)
    {
        checkedListBox1.SetItemChecked(i, false);
    }
}
```

---

## ?? Estructura de Base de Datos Esperada

### Tabla: Usuario
```sql
CREATE TABLE Usuario (
    ID              AutoIncrement PRIMARY KEY,
    DNI             Text(8),
    Nombre          Text(50),
    Apellido        Text(50),
    Mail            Text(100),
    Telefono        Text(12),
    Direccion       Text(100),
    Provincia       Text(50),
    Localidad       Text(50),
    Latitud         Text(20),
    Longitud        Text(20),
    UsuarioRedes    Text(50),
    Estado          Text(20)      -- "Activo" o "Inactivo"
);
```

### Tabla: Redes
```sql
CREATE TABLE Redes (
    ID              AutoIncrement PRIMARY KEY,
    IDUsuario       Number,       -- Referencia a Usuario.ID
    NombreRed       Text(50)      -- Instagram, TikTok, X, Telegram, Facebook
);
```

---

## ?? Relación entre tablas

**Tabla Usuario:**
```
ID | Nombre | Apellido | Mail
---+--------+----------+-----
1  | Juan   | Pérez    | juan@gmail.com
2  | María  | García   | maria@gmail.com
```

**Tabla Redes:**
```
ID | IDUsuario | NombreRed
---+-----------+----------
1  | 1         | Instagram
2  | 1         | TikTok
3  | 1         | X
4  | 2         | Facebook
5  | 2         | Telegram
```

Juan tiene 3 redes (Instagram, TikTok, X) y María tiene 2 (Facebook, Telegram).

---

## ?? Conceptos Importantes

### 1. Using (Gestión automática de recursos)
```csharp
using (OleDbConnection conexion = new OleDbConnection(cadena))
{
    conexion.Open();
    // ... hacer algo ...
} // La conexión se cierra automáticamente aquí
```

**Ventaja:** Aunque haya error, la conexión se cierra de todas formas.

### 2. Parámetros en SQL (@)
```csharp
// SEGURO (parámetros)
string sql = "SELECT * FROM Usuario WHERE DNI = @dni";
cmd.Parameters.AddWithValue("@dni", "12345678");

// INSEGURO (concatenación)
string sql = "SELECT * FROM Usuario WHERE DNI = '" + dni + "'";
```

### 3. DataTable
Es como una tabla en memoria que podemos recorrer fácilmente.

```csharp
DataTable tabla = OperacionesBD.ObtenerDatos("SELECT * FROM Usuario");

// Recorrer filas
foreach (DataRow fila in tabla.Rows)
{
    string nombre = fila["Nombre"].ToString();
}
```

### 4. OleDbParameter
Es un contenedor seguro para valores que se envían a SQL.

```csharp
OleDbParameter param = new OleDbParameter("@nombre", "Juan");
// Nombre del parámetro y valor
```

---

## ?? Flujo Completo: De Usuario a Base de Datos

```
1. Usuario llena formulario
   ??> DNI: 12345678
   ??> Nombre: Juan
   ??> Apellido: Pérez
   ??> Mail: juan@gmail.com
   ??> Redes: Instagram, TikTok

2. Usuario clica "Guardar"
   ??> ValidarCampos() ? ¿Todo válido? ?
   
3. GuardarUsuario()
   ??> INSERT INTO Usuario VALUES (...)
   ??> BD devuelve ID = 5
   ??> idUsuarioActual = 5
   
4. GuardarRedesSeleccionadas()
   ??> Itera sobre redes marcadas
   ??> INSERT INTO Redes (5, 'Instagram')
   ??> INSERT INTO Redes (5, 'TikTok')
   
5. Mostrar mensaje "? Guardado"

6. LimpiarFormulario()
   ??> Todos los campos vacíos
   ??> Listo para otro usuario
```

---

## ?? Debugging: Cómo verificar errores

### Ver errores de conexión:
```csharp
try
{
    // Código aquí
}
catch (OleDbException ex)
{
    MessageBox.Show($"Error OLEDB: {ex.Message}");
}
catch (Exception ex)
{
    MessageBox.Show($"Error general: {ex.Message}");
}
```

### Verificar si la BD existe:
```csharp
string ruta = Config.ObtenerRutaBD();
if (File.Exists(ruta))
    MessageBox.Show("? BD encontrada");
else
    MessageBox.Show("? BD NO encontrada en: " + ruta);
```

---

## ?? Resumen de Buenas Prácticas Aplicadas

? **Código limpio:** Métodos pequeños con responsabilidad única  
? **Reutilización:** Clase OperacionesBD usable en toda la app  
? **Seguridad:** Parámetros en SQL para evitar inyección  
? **Gestión de recursos:** Using para conexiones  
? **Manejo de errores:** Try-catch en lugares críticos  
? **Comentarios:** Explicación de cada sección  
? **Legibilidad:** Nombres descriptivos de métodos y variables  

---

## ?? Próximos Pasos (Para aprender más)

1. **Implementar BtnCargar_Click()** - Cargar usuario existente
2. **Agregar validaciones de email** - Regex
3. **Usar API real de geolocalización** - GPS del dispositivo
4. **Agregar tabla de Auditoría** - Registrar cambios
5. **Cifrar contraseñas** - Hash SHA256

---

**Creado para fines educativos - 2do año de Programación** ??

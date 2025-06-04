# Enviroments Release Notes
Este archivo contiene las notas de versi�n de la aplicaci�n para los diferentes ambientes de despliegue: desarrollo (dev), aseguramiento (QA), Producci�n (prod).
Aqui se documentan los cambios, mejoras y correcciones implementadas en cada versi�n desplegada en cada uno de estos ambientes.

## Men� de Navegaci�n
| [Desarrollo (dev)](#desarrollo-dev) | [Aseguramiento de Calidad (QA)](#aseguramiento-de-calidad-qa) | [Producci�n (prod)](#producci�n-prod) | [LTS dev](#lts-dev)| [LTS QA](#lts-qa) | [LTS prod](#lts-prod)

## Estrucutra del Archivo

- **Desarrollo (dev)**: Notas de las versiones desplegadas en el ambiente de desarrollo.
- **Aseguramiento de Calidad (QA)**: Notas de las versiones desplegadas en el ambiente QA.
- **Producci�n (prod)**: Notas de las versiones desplegadas en el ambiente de producci�n.

Cada Secci�n debe incluir la siguiente informaci�n para cada versi�n:

- **Fecha de Despliegue**: La fecha en la que la versi�n fue esplegada.
- **Versi�n**: El n�mero de versi�n de la aplicaci�n.
- **Descripci�n**: Descripci�n detallada de los cambios, mejoras y correcciones. Se debe incluir los n�mero de historias trabajadas.
- **Notas Adicionales** (opcional): Cualquier otra informaci�n relevante.

## Prop�sito del archivo:
El objetivo de este archivo es proporcionar un registro detallado y organizado de las actualizaciones de la aplicaci�n en sus diferentes etapas de desarrollo y despliegue. Esto facilita el seguimiento de los cambios y ayuda a los equipos de desarrollo, QA y operaciones a comprender el historial de versiones y los contextos espec�ficos de cada despliegue.

---

## Desarrollo (dev)
| [Desarrollo (dev)](#desarrollo-dev) | [Aseguramiento de Calidad (QA)](#aseguramiento-de-calidad-qa) | [Producci�n (prod)](#producci�n-prod) | [LTS dev](#lts-dev)| [LTS QA](#lts-qa) | [LTS prod](#lts-prod)

### Version 0.0.1
- **Fecha de Despliegue**: 2024-05-27
- **Descripci�n**:
	- Se incluye archivo env-relese-notes.md para control de versiones.
- **Notas Adicionales**: (eg.) Las pruebas deben ejecutarse nuevametne con el despliegue.

### Version 0.0.2
- **Fecha de Despliegue**: 2024-05-28
- **Descripci�n**:
	- Se agrega WellnessTestType al modelo de WellnessAssessment (Dominio) y modificaciones en las clases dependientes afectadas por el cambio

### Version 0.0.3

- **Fecha de Despliegue**: 2024-05-29
- **Descripci�n**:
	- Fix WellnessCommandValidator. Se usa When para definir que cuando IsInPain == true se deba considerar la regla que valida las affectedZones.
Caso contrario (si es falso) se ignora.

### Version 0.1.4

- **Fecha de Despliegue**: 2024-06-03
- **Descripci�n**:
	- Se agrega la primer implementaci�n de los cambios para MER-322 (ficha Nutricional - Nivel jugador). Falta revisar los fluentValidations y lo de objetivos nutricionales

### Version 0.1.5
- **Fecha de Despliegue**: 2024-06-03
- **Descripci�n**:
	- Se cambian los nombres de los estados de las alertas de valoraciones (sem�foro):
	
	Verde -> "Bien"
	Naranja -> "Regular"
	Rojo "Mal"

### Version 0.1.6
- **Fecha de Despliegue**: 2024-06-03
- **Descripcion**:
	- Se agregan endpoints para:
	1. Obtener entrenamientos de valoraciones fisicas cuantitativas.
	2. Obtener las valoraciones de los jugadores asignados a un entrenamiento.


### Version 0.1.7
- **Fecha de Despliegue**: 2024-06-05
- **Descripcion**:
- Se agrega la segunda y tercera implementacion de los cambios para MER-322
	- Se agregan endpoints para:
	1. Obtener los ultimos objetivos nutricionales del jugador (incluido el historico)
	2. Obtener el listado de jugadores, sus nombres y estados nutricionales.

### Version 0.1.8
- **Fecha de Despliegue**: 2024-06-05
- **US relacionadas**: MER-322, MER-502/MER-358 (Relacionado al alta y salida de datos de Wellness)
- **Descripcion**:Se corrigen varias cosas:
	1. Se corrige el repository para objetivos: Se quita el .Include(TrackingLevel) ya que en realidad no es una propiedad de navegacion, y se Incluye User ya que es necesario para la salida (propiedad CreatedBy)
	2. Se agrega la propiedad faltante (TrackingLevel) en el constructor publico y privado de Objective (Create method)
	3. Se agrega TrackingLevel VeryHigh
	4. Se corrige el endpoint GetLastObjectivesAssessments para usar la query correcta en el controlador (GetLastObjectiveAssessmentsByPlayerQuery)
- **Notas Adicionales**:
	1. Se agrega Rol de tablet para el usuario especifico que visualizara los datos de wellness . (Migracion y cambios en el snapshot agregada)

### Version 0.1.9

- **Fecha de Despliegue**: 2024-06-06
- **US relacionadas**: MER-322, MER-338 (valoracion fisica cuantitativa condicional)
- **Descripcion**:
 1. Se crea endpoint y todos los cambios asociados para obtener las valoraciones cuantitativas fisicas por jugador
- **Notas Adicionales**:
 1. Se corrige el permiso para ambos endpoints get-quantitative-assessments
 2. Se corrige/mejora logica de la aplicacion de la paginacion  en los repos que lo usan (nutritionalAssessment, NutritionalHabit, Objective)

### Version 0.1.10

- **Fecha de Despliegue**: 2024-06-06
- **US relacionadas**: MER-322
- **Descripcion**:
 1. Se agrega el parametro de entrada y salida "Type" para el query que obtiene los ultimos objetivos nutricionales (historico y parcial)  + otros cambios menores en la firmas de los metodos relacionados.
 2. Se agrega validacion fluent en dicha query
 3. Se Agregan los Ids de las entidades relevantes en la salida de los siguientes endpoints:
aquellos para obtener los ultimos objetivos, mediciones nutricionales y habitos nutricionales
- **Notas Adicionales**:			
 1. Se corrige logica de paginado
 2. Se corrige N° de User Story en el env-release notes version 0.1.9

### Version 0.1.11

- **Fecha de Despliegue**: 2024-06-10
- **US relacionadas**: MER-421 Ficha nutricional equipo
- **Descripcion**:
 1. Se agregan endpoints para la ficha de equipo
	1. api/v1/teams/nutritional-objectives-history
	2. api/v1/teams/nutritional-habits-history
	3. api/v1/teams/nutritional-assessments-history
	4. api/v1/teams/lastest-mophosis
	5. api/v1/assessments/get-nutritional-assessment
	6. api/v1/assessments/get-objective-tracking-levels
	7. api/v1/assessments/update-objective-tracking-level
	8. api/v1/nutritional-habits/get-nutritional-habit
	9. api/v1/assessmets/get-nutritional-objective
	 

### Version 0.1.12

- **Fecha de Despliegue**: 2024-06-10
- **US relacionadas**: MER_359_valoracion_fisica_cuantitativo_condicional
- **Descripcion**:
- Se agrega campo created_date en la entidad AssessmentTraining para permitir la logica de ordenamiento de las valoraciones por fecha de creacion del entrenamiento. (Dominio)
	- se realizan cambios dependientes en las capas de aplicacion e infraestructura

**Notas Adicionales**:			

- Creacion de SeedData con entrenamientos cuantitativos condicionales con diferentes jugadores y metricas.
- Modificacion de getter en CreatedDate (sin private set), y se agrego un metodo de sobrecarga extra "Create" en AssessmentTraining

### Version 0.1.13
- **Fecha de Despliegue**: 2024-06-12
- **US relacionadas**: MER-358 Alta de Wellness
- **Descripcion**:
	- Se agrega permiso "CreateWellnessAssessment" al rol de Admin 
**Notas Adicionales**:
	- Nuevo snapshot y archivo de migracion generado

### Version 0.3.14

- **Fecha de Despliegue**: 2024-06-14
- **US relacionadas**: MER-593, MER-387
- **Descripcion**:
	- Se agregan los campos para ambas piernas en los quantitative assessments que corresponde.
	- Se invierten los userStates "Creado" y "Pendiente".
	- Se fixea bugcito menor en la ImcAlert y en la altura de madre/padre del createPlayer
**Notas Adicionales**:
	- Nuevo snapshot y archivo de migracion generado

### Version 0.3.15

- **Fecha de Despliegue**: 2024-06-18
- **US relacionadas**: MER-426 - Calculo de mediciones del test CPRD
- **Descripcion**:
	- Se agregan 2 endpoints para obtener CPRD assessments: uno para obtener los datos del assessment a traves de su id y otro para obtener la lista de assessments por id de jugador (con paginacion)
	- Varios cambios en la entidad Assessment y clases vinculadas
	- Al crear un nuevo CPRD assessment los calculos ya se realizan con las respuestas de las preguntas suministradas al endpoint de creacion de CPRD. Se persisten en bd el puntaje de cada valoracion asociada al subgrupo de preguntas, asi como la alerta general de la valoracion en conjunto.. que resulta ser aquella que fue la peor de todas del subgrupo 
**Notas Adicionales**:
	- Nuevo snapshot y archivos de migracion generados

### Version 0.3.16

- **Fecha de Despliegue**: 2024-06-18
- **US relacionadas**: Bugs MER-511 y MER-550 
- **Descripcion**:

	- Se fixea el formato del mail para el cambio de contraseña exitoso
	- No se pudo reproducir el error MER-550, pero se hicieron mejoras en torno a dicho circuito: Ya no se devuelve el parametro ""resetLink"" en la respuesta HTTP de la operacion "reset-password".
**Notas Adicionales**:
	- Se guarda el formato del mail y operaciones de armado del mismo en una clase aparte

### Version 0.3.17

- **Fecha de Despliegue**: 2024-06-19
- **US relacionadas**: Bug MER-550 
- **Descripcion**:

	- Se  modifica el tipo y mensaje de respuesta cuando el email no se encuentra registrado en el sistema.
Se utiliza el tipo "Internal Server Error (500)" con el siguiente mensaje: "Ha ocurrido un error durante el proceso de restablecimiento de la contraseña. Por favor, intente más tarde."

### Version 0.3.18
- **Fecha de Despliegue**: 2024-06-19
- **US relacionadas**: MER-345 Carga Objetivos
- **Descripcion**:
- 
Primera implementacion. Se crea un endpoint para poder cargar objetivos al jugador.  POST api/v1/players/objective

Notas adicionales:
- Nuevo snapshot y archivos de migracion generados: Tablas afectadas: "permissions y roles_permissions"
- Se corrige la fecha de despliegue de Version 0.3.17

### Version 0.3.19
- **Fecha de Despliegue**: 2024-06-20
- **US relacionadas**: MER-101 Agregar foto en Alta
- **Descripcion**:
	- Primera implementacion. Se crea un endpoint para poder cargar la foto del jugador.  POST api/v1/users/upload-user-image
Se implementa nuevo repositorio FileRepository en Infrastructure para la integración con Blobstorage de azure

Notas adicionales:
- Se agrega en appsettings.json ConnectionStrings:BlobStorageConnection y ContainerName.

### Version 0.3.20

- **Fecha de Despliegue**: 2024-06-21
- **US relacionadas**: MER-485 Visualizar historial de valoraciones cualitativas
- **Descripcion**:
	- Se crea endpoint para obtener el historial de valoraciones cualitativas por equipo y por jugador
	- Se crea endpoint para obtener el detalle de una valoracion cualitativa por su id

### Version 0.4.21

- **Fecha de Despliegue**: 2024-06-26
- **US relacionadas**: MER-658 Refactor de SeedDataExtension
- **Descripcion**:
- Se encapsula en metodos "idempotentes" (Antes de insertar registros en la tabla correspondiente, realiza validaciones  de existencia, para evitar registros duplicados) la creacion de las registros para las diferentes entidades de la aplicacion.
En cada metodo se trae directamente desde la base la data de las entidades relacionadas/dependientes (creadas en metodos anteriores)  y asi no tienen dependencia con variables creadas anteriormente.
-Lista oficial de entidades/relaciones agregadas en el seed hasta ahora : Usuarios, Equipos, metricas IMC, jugadores, datos de jugadores en cada equipo (PlayerTeams), habitos nutricionales, objetivos (nutricional,fisico,psicologico), Entrenamientos, Evaluacion CPRD, Sesiones psicologica, Wellness, Qualitative Assessments (Gimnasio y Campo), nutritional Assessments
- Se agregan mas usuarios y jugadores (15 en total)

- Notas adicionales:
- Formateo de la clase y otras mejores menores
- Se quita async de metodos sincronos en dicha clase (SeedData)
- Correccion de  comentarios
- Quitado de comentarios innecesarios
- quitado de usings innecesarios
 Se agrega nuevo parametro de Order en la creacion de los WellnessAssessments


### Version 0.4.22

- **Fecha de Despliegue**: 2024-06-27
- **US relacionadas**: MER-643 Gestión de imágenes de usuario
- **Notas adicionales**:
	- funcionalidades agregadas:
		-Borrar del storage imagenes al editar
		-Edicion de fotos vista de administracion de usuarios
		-Endpoint para carrousel de jugadores de equipo

### Version 0.4.23

- **Fecha de Despliegue**: 2024-06-27
- **US relacionadas**: MER-658 Refactor de SeedDataExtension, MER-5 Menú de usuario y edición de datos propios
- **Descripcion**:

Nuevo endpoint para obtener informacion del usuario usando el token de autorizacion y con datos.
Fix metodo CreateUsers en SeedDataExtension : Agregado de telefono y nacionalidad a los usuarios creados programaticamente

- **Notas adicionales**:
Fix de ordenamiento en GetQualitativeFieldAssessments
Nuevo snapshot y migracion para agregar permisos al nuevo endpoint. Todos los roles, excepto tablet, pueden ver su perfil

### Version 0.4.24

- **Fecha de Despliegue**: 2024-06-28
- **US relacionadas**: MER-640 Gestión de imágenes de usuario
- **Descripcion**:

Nuevo endpoint para obtener la foto del usuario a partir de un id de usuario

- **Notas adicionales**:
Nuevo snapshot y migracion para agregar permisos al nuevo endpoint. Por el momento, solo el rol de jugador puede obtener su foto

### Version 0.4.25

- **Fecha de Despliegue**: 2024-06-28
- **US relacionadas**: 
- **Descripcion**: N/A

- **Notas adicionales**:
Nuevo snapshot y migracion creada y borrado de las anteriores (Puesta en 0)

### Version 0.5.26
- **Fecha de Despliegue**: 2024-06-28
- **US relacionadas**: 
- **Descripcion**: Refactor en controladores para regresar el objeto result en respuestas OK

### Version 0.6.27

- **Fecha de Despliegue**: 2024-07-1
- **US relacionadas**: 
- **Descripcion**: Refactor endpoints


### Version 0.6.28

- **Fecha de Despliegue**: 2024-07-01
- **US relacionadas**: MER-637/MER-662
- **Descripcion**: 
Primera implementacion del endpoint para salir de sesion
Aplicacion de nonce token en el circuito de login para luego invalidarlo en aquel de cierre de sesion. Se persiste dicho token en db
Se agregan permisos a RolePermissionConfiguration de Player y Tablet.
Se cambia Endpoint
 Images/user/session a Images/user/context
Players/session a Player/context

- **Notas adicionales**:
- Se cambia el nombre de la tabla "reset-token" a "active-tokens"
- Se cambia el nombre de ResetPasswordToken a Token para generalizar su uso. Se cambian clases relacionadas
- Se agrega permiso especifico para usar el endpoint. Asignado a todos los roles
- Nueva migracion creada
- Se cambia de nombre el metodo GenerateToken por GenerateLoginToken
- EDIT:Se mueve el endpoint al controlador auth (estaba en user antes)
- EDIT:Se edita a mano la migracion (dps se tendra que quizas hacer un wipeout y reset a 0 nuevamente) para que no asigne el nuevo permiso a los roles

### Version 0.7.29
- **Fecha de Despliegue**: 2024-07-03
- **US relacionadas**: MER-658/MER-687 Crear endpoint nuevo para wellness
- **Descripcion**:
- 
Se separan en 2 carpetas los casos de usos de wellness (byplayerId, byusercontext)
Renombrado de clases para evitar ambiguedad
Se hizo obligatorio el parametro de PlayerId en CreateWellnessAssessmentByPlayerIdCommandRequest
Refactor logica  CreateWellnessAssessmentByUserContextCommandHandler y CreateWellnessAssessmentByPlayerIdContextCommandHandler
Se extrae WellnessAssessmentDTO en una clase aparte y comun a ambos casos de uso.
Refactor CreateWellnessAssessmentByPlayerIdCommandRequest  para que use formato POCO (hay que cambiar en el FE tambien)

- **Notas adicionales**:
Fix y mejoras en fluentValidator :
(se corrige error cuando IsInPain == true y affectedZones esta null o vacio) tirando excepcion interna 500.
Se agrega validaciones "semanticas" de restriccion numerica a los campos MuscleFatigue,GeneralFatigue,SleepHours,Weight
Y se corrige para que no evalue por NotNull() -> FluentValidation ya lo hace internamente. Si no es nullable, se establece el valor por default (para short = 0)
Los valores semanticamente correctos son los mismos que en el seedData:
- 
new Weight(r.Next(0, 300)),
new SleepHours((short)r.Next(0, 24)),
new GeneralFatigue((short)r.Next(0, 11)),
new MuscleFatigue((short)r.Next(0, 11)),

### Version 0.7.30

- **Fecha de Despliegue**: 2024-07-03
- **US relacionadas**:  MER-659 Refactor SeedDataExtension
- **Descripcion**:

bugfix seedDataExtension II  Se corrige el punto flotante para que sea de 2 digitos para todos los flotantes posibles.

- **Notas adicionales**:
Se corrigen los floats de  NutritionalAssessments.BasicMeasurement para usar 2 digitos.
Se corrigen los floats de  NutritionalAssessments.SkinFold para usar 2 digitos.


### Version 0.8.31
- **Fecha de Despliegue**: 2024-07-08
- **US relacionadas**:  MER-688 Crear endpoint completo para editar jugador usando UserContext(Modificar el de por PlayerId)
- **Descripcion**:

- Implementacion del endpoint para actualizar jugador por contexto (UpdatePlayerByUserContext)

- Se separo en carpetas diferentes los casos de uso UpdatePlayer( por playerId, y userContext)
- Se modifico el endpoint UpdatePlayerById para ajustarse al modelo RESTFUL. Se hizo refactor de la clase request para que solo use los campos necesarios  (cambiar en el FE?)
- Se modifico el endpoint UpdatePlayerById  para usar una clase POCO como request (tambien creado en la capa de presentacion API) en vez de un DTO anidado, o con clases de la capa de dominio.

Se mueve PlayerDTO a carpeta Players(en Application layer). La idea es que sea usado por todos los casos de uso
Se mueve PlayerTeamInfoDTO a Carpeta Players (en Application layer). Usado en PlayerDTO

Dato adicional: Se renombran las otras clases de PlayerDTO esparcidos en los diferentes casos de uso para evitar la ambiguedad
Algunos comentarios con TODOs de mejora de otras entidades, que fui encontrado y que para no olvidarme las agrego en este commit)

Algunas modificaciones en PlayerValidatorService y PlayerErrors

Agregado de Domain Event aparte para PlayerUpdatedByUserContext. Refactor y renombrado del existente UpdatePlayerDomainEvent (por UpdatePlayerByPlayerIdDomainEvent)
Segregado de los DomainEventHandler en 2 para cada caso.
Agregado de sobrecarga para UserUpdate cuando se actualiza jugador por contexto.

Refactor: Renombrado de GetByUser por GetByUserAsync
Refactor: Cambios en UserValidatorService

### Version 0.9.32

- **Fecha de Despliegue**: 2024-07-08
- **US relacionadas**:  Bugfix: MER-699 & MER-698
- **Descripcion**:


- MER-699:  Diferencias entre el mail enviado y template. Corregidos
- MER-698: No se disparo el Mail de activación de usuario. Corregidos

- Notas adicionales:
Se mueve la clase HTMLTemplatesBuilder fuera de Application.Users.ForgotPasswordUser y se coloca dentro de Application.Emailing
Se refactoriza la clase HTMLTemplatesBuilder para solo usar un metodo general "CreateFormattedEmail" con los parametros adicionales "title" y "paragraph" , (ya que el formato  de los correos no varia entre los casos de uso que tenemos hasta ahora)
Refactor de las clases handlers que usan el HTMLTemplatesBuilder
Renombrado de archivo HtmlTemplates a HTMLTemplatesBuilder
Application.Tests.ChangeUsersStateTests modificado con nueva firma del ChangeUsersStateCommandHandler

### Version 0.10.33
- **Fecha de Despliegue**: 2024-07-10
- **US relacionadas**:  Bugfix: MER-745
- **Descripcion**:
	-Se ordena el historial de wellness en orden descendente	
	-Se agrega decorador [FromForm] al endpoint de fotos de usuarios por userid


### Version 0.10.34
- **Fecha de Despliegue**: 2024-07-10
- **US relacionadas**:  Bugfix: TODO: TBD:
- **Descripcion**:


Se agregan permisos a player y Tablet:

Agregado 5 permisos tablet role:

imagesGetMinImagesUsersByTeam
wellnessGet
wellnessGetById
wellnessGetSumaryByTeam
wellnessGetDetailsByTeam
wellnessGetAffectedZones (agregado en commit anterior)

Y Agregado permiso a jugador:

imagesGetByUser

- Notas adicionales:
Nueva migracion y snapshot

### Version 1.12.36

- **Fecha de Despliegue**: 2024-07-11
- **US relacionadas**:  Bugfix:MER-755 El semaforo en wellness siempre marca rojo


### Version 1.17.42
- **Fecha de Despliegue**: 2024-07-11
- **US relacionadas**:  Bugfix:MER-779 Wellness - Aparece fatigado en zonas de dolor, aunque no esten fatigados

### Version 1.17.43
- **Fecha de Despliegue**: 2024-07-17
- **US relacionadas**:  US: MER-756 Sacar obligatoriedad de los campos de padres para el primer equipo y el rayo

**Descripci�n**:

Primera implementacion
Se agrego el campo IsAdultsOnly a la tabla Teams.. y se agrego dicho campo a la respuesta de GetAllTeamsHandler

Notas adicionales:
Migracion creada

### Version 1.17.44
- **Fecha de Despliegue**: 2024-07-18
- **US relacionadas**:  MER-421 - Página nutricional por equipo
- **Descripción**: 
	- Se hacen retoques múltiples en las respuestas de los endpoints nutricionales por equipo para que se ajusten a los nuevos diseños
	- Se arreglan las rutas y permisos de algunos endpoints de la parte de objetivos, que estaban confusos en su nombre.
- - **Notas adicionales**: Migracion creada

### Version 1.18.45
- **Fecha de Despliegue**: 2024-07-19
- **US relacionadas**:  MER-
- **Descripción**: no estaba cargado el campo is_adults_team de la tabla teams

### Version 1.18.46

- **Fecha de Despliegue**: 2024-07-22
- **US relacionadas**:  MER-837: No hay ningun tipo de bloqueo para la carga de wellness por parte del jugador
- **Descripción**: Se agrega la logica para impedir la carga del mismo wellness por el mismo jugador en el dia

### Version 1.18.47

- **Fecha de Despliegue**: 2024-07-21
- **US relacionadas**:  MERx - Usuario equipo
- **Descripción**: 
	-Se refactoriza el endpoint de historial de wellness
	-Se agrega el control de equipos por usuario mediante token
	-mejora del endpoint de teams para que segun el context busque corrobore si el usuario puede ver un equipo
    -fix wellness summary: se repiten zonas de dolor

### Version 1.20.49

- **Fecha de Despliegue**: 2024-07-23
- **Descripción**: 
	-Se valida que el rol player pueda ver todos los equipos
	- y que los demas usuarios tengan que hacerlo através de user team

### Version 1.20.50

- **Fecha de Despliegue**: 2024-07-24
- **US:** MER-847 El historial de wellness no muestra los wellness cargados por jugadores
- **Descripción**: 
	-Se corrige el paginado de wellness history	agregando campo date time 
	-Se corrige case sensitive en la busqueda de historial de wellness

### Version 1.20.51

- **Fecha de Despliegue**: 2024-07-29
- **US:** MER-864 Configuración y validación de permisos por roles y equipos en wellnesses
- **Descripción**: 
Se le dio permisos de lectura al preparador fisico (Entrenador fisico) para usar los endpoints de wellness.
Se cambia el nombre de entrenador fisico a Preparador fisico, lo mismo con Player y Admin
Se agrega nuevo tipo de Assessment (Medicos)
- Importante: Nueva migracion creada

### Version 1.20.52

- **Fecha de Despliegue**: 2024-07-29
- **US:** MER-864 Configuración y validación de permisos por roles y equipos en wellnesses
- **Descripción**: 
Se le termino de dar mas permisos a varios roles. (preparados fisico, nutricionista,medico y psicologo, tablet)
- Importante: Nueva migracion creada

### Version 1.24.53
- **Fecha de Despliegue**: 2024-07-29
- **US:** MER-864 Configuración y validación de permisos por roles y equipos en wellnesses
- **Descripción**: 
Se le termino de dar mas permisos faltantes de wellness al rol de nutricionista)
- Importante: Nueva migracion creada

### Version 1.24.54
- **Fecha de Despliegue**: 2024-07-30
- **US:** MER-883  
- **Descripción**: se corrige unAuthorized cuando hay errores con la imagenes

### Version 1.24.55

- **Fecha de Despliegue**: 2024-07-30
- **US:** MER-794  
- **Descripción**: Se limitan los assessmentTrainings a un solo equipo y se ajustan los endpoints relacionados

### Version 1.25.56

- **Fecha de Despliegue**: 2024-07-31
- **US:** MER-613 Alta de lesiones 
- **Descripción**: Se crean los endpoints para obtener los parametros de una lesión y para crearla

### Version 1.25.57

- **Fecha de Despliegue**: 2024-08-02
- **US:** (Bug) MER-898 Al usuario nutricionista le faltan varios permisos
- **Descripción**: Se agregan los permisos faltantes al rol de nutricionista..
- Ademas se agregan muchos otros permisos faltantes a otros roles

### Version 1.28.58
- **Fecha de Despliegue**: 2024-08-02
	- Se elimina Authorization Service e implementaciones

### Version 1.29.59

- **Fecha de Despliegue**: 2024-08-05
- **US:** (Bug) MER-613 Crear un endpoint que a partir de un jugador te traiga las lesiones
- **Descripción**: Implementacion final. Falta testing
- Nueva migracion para agregar el permiso a varios roles

### Version 1.29.60

- **Fecha de Despliegue**: 2024-08-06
- **US:**
	- (Bug) MER-614 Varias Mejoras y correcciones GENERALES a los endpoints de tratamientos medicos
	- MER-948 Acortar el link de alta
- **Descripción**: Implementacion final. Falta testing
- Nueva migracion para agregar el permiso a varios roles y reconfiguracion de la entidad

### Version 1.30.61

- **Fecha de Despliegue**: 2024-08-06
- **US:** (Bug) MER-614 Varias Mejoras y correcciones GENERALES a los endpoints de tratamientos medicos
- **Descripción**: 
Correccion/mejora del modelo de requests para que puedan pasarse ids, en vez de strings TreatmentTypeName, y treatmentName

Y esto aplica a FluentValidations, etc
Y Solo se necesita TreatmentTypeId en los requests ya que la categoria se infiere a partir de dicho id.
Limpieza de comentarios innecesarios

### Version 1.30.62

- **Fecha de Despliegue**: 2024-08-06
- **US:** (Bug) Sin definir
- **Descripción**: 
Se mueve el SeedDataAuthentication dentro de app.Environment.IsDevelopment() para evitar que corra en prod

### Version 1.31.63

- **Fecha de Despliegue**: 2024-08-07
- **US:** (Bug) MER-614: Varias Mejoras y correcciones GENERALES a los endpoints de tratamientos medicos P2
- **Descripción**: 
- Se cambia Category para que no sea private set y se pueda asignar la categoria por fuera del constructor (Por practicidad)
- Fix Category que viene null (se implementa metodo en CategoryEnum para obtener la categoria a partir del TypeId
- Correccion StatusId  en GetMedicalTreatmentsByInjuryIdQueryHandler
- Fix endpoint para operacion UPDATE : No hace falta pasar en el body el CategoryId, solo a partir de TypeId
	Se fixeo el bug que tiraba error cuando le pasabas un mismo TypeId que el que tenia anteriormente (TypeId sin cambiar).
	Se hace evitando attachear las entidades aggregate (RecoveryType y Type) , las cuales son obtenidas  y asignadas al tratamiento medico pero a partir de los enums.FindValue()  y en vez estas se buscan manualmente desde base a traves del repositorio  (desde el Handler)

- Normalizacion de nombres de variables de request y response
- Se usa GetMedicalTreatmentByIdReadOnly en vez de GetMedicalTreatmentById en GetMedicalTreatmentByIdQueryHandler ya que solo se necesita para la lectura
- Se hace async el PatchStatusById

### Version 1.31.64

- **Fecha de Despliegue**: 2024-08-08
- **US:** (Bug) MER-614: Varias Mejoras y correcciones GENERALES a los endpoints de tratamientos medicos P3 (se corrige el PATCH)
- **Descripción**:

Fix error en metodo PatchStatusById (se cambia UpdatedBy por CreatedBy). Ademas se instancia UpdatedDateTime por fuera del SetProperty() para evitar excepcion < a LINQ no le gustaba que se hiciera ahi mosmo>
Correccion menor semantica en MedicalTreatmentConfiguration de UpdatedDateTime
Borrado de comentarios innecesarios

Fix CategoryId viniendo en 0
Otros fixes a nivel modelo de response y handlers
Fix typeId viniendo en 0

### Version 1.31.65
- **Fecha de Despliegue**: 2024-08-08
- **US:** MER-614: alta de tratamientos medicos
- **Descripción**:

- Crear 1 endpoint adicional PATCH para cambiar el estado de los tratamientos medicos a completado a partir de una lesion
Nueva migracion creada para agregar el permiso al medico.

### Version 1.31.66
**Fecha de Despliegue**: 2024-08-09
**US:** MER-327/611: ficha medica (salida)
**Descripción**:
	- Se crean los endpoints de wellness para la salida de la ficha medica
	- Se corrige el calculo de promedio de horas de sueño de wellness para solo tener en cuenta a los pre-entreno
**US:** 
**Descripción**:
	- Se crea configuración de tiempos de expiración de tokens:



### Version 1.31.67

- **Fecha de Despliegue**: 2024-08-09
- **US:** Subtask: MER-1025: Crear una columna para lesion real_discharge_date y setearla a la fecha de hoy cuando se finaliza una lesion.
- **Descripción**:
(Se corrige que antes estaba seteando discharge_date en vez 
Varios cambios en todas las capas. Se hace que los gets de injury puedan devolver  este campo.
Agregado de varias propiedades en InjuryDTO
Se agrega .Include(x => x.MedicalTreatments) en GetAllByPlayerIdAsyncReadOnly
Endpoints de injury devuelven mas informacion
Nueva migracion creada

### Version 1.31.68

**Fecha de Despliegue**: 2024-08-14
**Descripción**:
   Se agrega api version a injuries
	
```
  "TokenExpireTimesInHours": {
    "Register": "10",
    "Login": "10",
    "ResetPassword": "2",
    "EmailConfirmation": "48"
  },
```

### Version 1.31.69
- **Fecha de Despliegue**: 2024-08-12
- **US:** Subtask: MER-614: Se agregan nuevos tipos de tratamientos medicos para gestion de cargas
- **Descripción**:
Nueva migracion creada

### Version 1.31.70

**Fecha de Despliegue**: 2024-08-15

**US:**
- MER-948 Acortar el link de alta

**Descripción**:
   Se modifica la creación de url para registro de usuario, regresando la url minificada.
   Se agrega endpoint /redirect/{id} para obtener la url a redireccionar.

Response:
```
  {
  "value": {
    "id": "19154CDEB9CQGp",
    "shorterUrl": "http://localhost:3000/r/19154CDEB9CQGp",
    "redirectUrl": "http://localhost:3000/email-confirmation/jpnGl6zg4D..."
  },
  "isSuccess": true,
  "isFailure": false,
  "error": {
    "code": "",
    "name": ""
  }
}
```

### Version 1.32.71


**Fecha de Despliegue**: 2024-08-15

**Descripción**:
 -injuries refactor name properties
 -permitir discharge date e injury treatment en nulo

### Version 1.32.72

**Fecha de Despliegue**: 2024-08-16
** US **:  MER-632, MER-614, MER-613
**Descripción**:
- Fix nombre incorrecto a validar del blobStorage de imagenes de usuario en FileRepository : ContainerUserImagesName en vez de ContainerName

- Alta tareas de entrenamiento (MER-632)
Se implementan los endpoints necesarios para el alta (sin la vinculacion con sesiones de entrenamiento)
Nueva migracion

- Alta lesiones y tratamientos medicos (MER-613/MER-614)
Se Corrigen varios errores y se termina de integrar con tratamientos


### Version 1.34.73

**Fecha de Despliegue**: 2024-08-20
** US **:  MER-631, MER-634
**Descripción**: Alta de Sesiones de entrenamiento y Control de asistencia respectivamente


### Version 1.34.74

**Fecha de Despliegue**: 2024-08-20
** US **:  MER-678: Alta de usuario no jugador
**Descripción**:
Primera Implementacion. Se crean las entidades correspondientes a los roles, excepto el jugador:
Se crean las clases de repositorios para cada uno
Se crea Handler para La creacion del usuario no jugador
Se crea endpoint  para La creacion del usuario no jugador
Se crea contrato de endpoint
Se crean las tablas correspondientes
Se deja Members de placeholder para futuro refactor
Se crea fluent validators

Se agregan columnas comunes de player a user (en player quedaran redundantes) pero era una simplificacion para no tener que crear una tabla nueva "members"
Se impide que un usuario pueda estar registrado con diferentes entidades de roles simultaneamente.


### Version 1.34.75

**Fecha de Despliegue**: 2024-08-20
** US **:  MER-327/611: Ficha medica para jugador y equipo
**Descripción**:
	- Se crean endpoints para las fichas medicas (lesiones y tratamientos)
	- Se agrega progresión de lesiones (incluye migración)


### Version 1.34.76

**Fecha de Despliegue**: 2024-08-20
** US **:  MER-1043 Ajustes en tareas de entrenamiento
**Descripción**:
	- Se cambia que al consultar la tarea devuelva la url  de la imagen y no solo el nombre
	- Se corrige en docker-compose.override el nombre de la variable de entorno ASPNETCORE_ENVIRONMENT.

### Version 1.34.77

**Fecha de Despliegue**: 2024-08-20
** US **:  MER-678: Alta de usuario no jugador
**Descripción**:
Se modifica la salida de usuarios para devolver todos los equipos al que esta asociado
Se refactoriza GetAllQuery para ser mas eficiente y generar el mismo resultado.. ademas de devolver los teams para los usuarios no jugadores ( a traves de user_team)
Se ajusta el parametro TeamId para que sea un listado. Se puede asociar en el alta muchos equipos a un usuario
Se crea GetTeamsByIds para  traer los equipos por sus ids. por ahora Se reusa GetAll y se filtra en el handler. queda en TODO: implementar GetTeamsByIds en DapperRepository(comentado)
Reconfiguracion del handler para que evalue primero si el usuario ya se habia registrado antes de validar los equipos y demas
Se agrega attach de los teams para evitar insercion duplicada por EFC

### Version 1.34.78

**Fecha de Despliegue**: 2024-08-20
** US **:  MER-631, MER-634
**Descripción**: Se agrega obtención causas de asistencia

### Version 1.34.79

**Fecha de Despliegue**: 2024-08-22
** US **:  MER-486
**Descripción**: Se agrega edición de entrenamientos de valoración

### Version 1.35.80

**Fecha de Despliegue**: 2024-08-28
** US **:  MER-635 - Visualización de sesiones de entrenamientos

### Version 1.35.81

**Fecha de Despliegue**: 2024-08-28
** US **:  MER-1044 - Visualización de tareas de entrenamiento

### Version 1.35.82

**Fecha de Despliegue**: 2024-08-29
** US **:  MER-XXX - Se agregan permisos faltantes al medico, nutricionista y psicologo
Nueva migracion Creada
 -Se adiciona 3 días al tiempo de expiracion del token de imagenes

### Version 1.36.83
**Fecha de Despliegue**: 2024-08-29
**Descripción**: Se crean dos migraciones para insertar permisos faltantes en nutrición y tratamientos médicos

### Version 1.37.84

**Fecha de Despliegue**: 2024-09-02
**US**: MER-1108 CA - Dejar solo los pliegues como obligatorios para el alta de datos nutricionales

### Version 1.39.85

**Fecha de Despliegue**: 2024-09-03
** US **:  MER-1108
** Comentarios ** :
     - Se fixea la query para completar el registro nutricional con los valores pasados
     - Se fixean las query de registros nutricionales y habitos nutricionales que traían solo hasta 10 registros

### Version 1.39.86

**Fecha de Despliegue**: 2024-09-03
** US **:
** Comentarios ** :
     - Se fixean los endpoints de salida de lesiones para soportar valores nulos en donde están permitidos

### Version 1.39.87

**Fecha de Despliegue**: 2024-09-04
** US **:
** Comentarios ** :
     - Fix de bug en tareas al entrar a tab tareas en entrenamientos

### Version 1.39.88

**Fecha de Despliegue**: 2024-09-05
** US **: MER-1095
** Comentarios ** :
     - Se agregan endpoints para obtener toda la info de un usuario por id y por context
	 - Se agregan endpoints para editar la info de un usuario por id y por context

**Fecha de Despliegue**: 2024-09-05
** US **: MER 631 Alta de Sesión de entrenamiento
** Comentarios ** :
     - Se agrega endpoint para traer todas las tools agrupadas y se hace fix ataque sin balón que no tenía items

### Version 1.40.89

**Fecha de Despliegue**: 2024-09-06
**US**: MER 518 - Ficha Psicologica nivel jugador ,MER 527 Ficha Psicologica nivel equipo

### Version 1.40.90

**Fecha de Despliegue**: 2024-09-06

**US**: (sin definir)

**Comentarios** :

Fix tipos de respuestas en varios endpoints

endpoints:
reset-password-link : Se devuelve 401 en vez de 500 cuando es necesario
login: Se crea error de contraseña invalida cuando es el caso, y se lo separa de InvalidCredentials (error en el email y/o contraseña).


### Version 1.42.91

**Fecha de Despliegue**: 2024-09-09
**US**: MER-945 Administracion de equipos


### Version 1.42.92

**Fecha de Despliegue**: 2024-09-09
**US**: MER-1125
**Comentarios** :
     - Se modifica el endpoint de crear habito nutricional para que sea utilizado por administradores y nutricionistas (no jugadores)

### Version 1.42.93

**Fecha de Despliegue**: 2024-09-09
**Comentarios**: Se realiza Fix de Ficha de CPRD de equipo y jugador.


### Version 1.42.94

**Fecha de Despliegue**: 2024-09-09

**US**: MER-673, y otros fixes

**Comentarios** :

- Se implementa la posibilidad de especificar los campos de contrato, fechas de inicio y fin, primera y segunda posicion en el alta de jugador.
Asimismo, se permite al administrador editar dichos campos mencionados.. y el jugador podra incluso editar los terminos y condiciones.
Los terminos y condiciones, junto a los campos relacionados al contrato y a las posiciones se devuelven en los endpoints de busqueda de jugador por Id o por userId
- Se fixea un error en el flujo de cambio de contraseña en donde la respuesta venia en 400 en vez de 404

### Version 1.46.95

**Fecha de Despliegue**: 2024-09-10

**US**: MER-673

**Comentarios** : Se fixea columna "HasContract" por "has_contract" en una query

### Version 1.46.96
**Fecha de Despliegue**: 2024-09-10

**US**: MER-673

**Comentarios** : Fixes en dominio y queries (Se quita alias en campos) para query GetPlayersInfoByTeamId.
Se hace nulleable Terms y Conditions en un metodo de la entidad de dominio Players.
Se resetean algunas queries como recursos incrustados (de lo contrario ReadQuery no puede encontrar dicho recurso de query)


### Version 1.46.97
**Fecha de Despliegue** : 2024-09-11
**Comentarios**:
   Fix Cprd valores para porcentaje de equipos - Fix nombre en trainingSesssion
  

### Version 1.46.98

**Fecha de Despliegue** : 2024-09-12
**US**: MER-673
**Comentarios**:
   Se corrige error en repositorio EFC donde no se traigan las posiciones (porque faltaba el include).
   Endpoints afectados:

   GET "players/context"
   GET "players/user/{userId}"

### Version 1.47.99
**Fecha de Despliegue** : 2024-09-12
**Comentarios**:
Fix CPRD porcentajes de jugador para casos en los que no este dentro del rango adecuado
Fix de imagenes de jugadores en cprd
Fix wellness filter

### Version 1.48.100
**Fecha de Despliegue** : 2024-09-12
**Comentarios**:
Fix paginado

### Version 1.49.102

**Fecha de Despliegue** : 2024-09-12

**Comentarios**:
 Fix filtro para wellness regulares


### Version 1.48.103

**Fecha de Despliegue** : 2024-09-12

**Comentarios**:

Se quita permiso nutritionalHabitsCreate al player y se lo agrega al nutricionista. Migracion Creada

### Version 1.48.104

**Fecha de Despliegue** : 2024-09-12

**Comentarios**:

**US**: BugFix:  MER-673

Se corrige error con las posiciones que causaban excepcion en el back
Se quita validacion de fecha de inicio de contrato

Se agrega validacion en el handler para que la fecha de fin de contrato sea siempre posterior a la de inicio

Se agrega metodos de repositorios para obtener todas las posiciones y la posicion por Id (Dapper en construccion, por EFC listo)
Borro comentarios innecesarios

### Version 1.48.105
**Fecha de Despliegue** : 2024-09-12

**Comentarios**: Fix filtro regulares


### Version 1.48.106

**Fecha de Despliegue** : 2024-09-12

**Comentarios**:

**US**: BugFix:  MER-673

Se permite que se pueda editar/crear un jugador con ambas posiciones en sin asignar.


### Version 1.51.107

**Fecha de Despliegue** : 2024-09-16

**Comentarios**:

**US**: Sin definir

Se setea el valor del teamPlayer.position  del player creado o editado asociado con el valor de la primer posicion que se paso como parametro en dichos flows
Se refactoriza un poco CreatePlayerHandler y UpdatePlayerByPlayerIdCommandHandler

Se crea repositorio de Teamplayer
Se agrega nuevo rol Scout y algunos permisos basicos
Se agrega endpoint para obtener las posiciones (todas las capas)
Nueva migracion creada

### Version 1.51.108

**Fecha de Despliegue** : 2024-09-16

**Comentarios**: Se realizan cambios en el detalle de sessiones de entrenamiento,
para que un detalle pueda aceptar muchas fases e intenciones


### Version 1.51.109

**Fecha de Despliegue** : 2024-09-16

**Comentarios**: 
- Se agrega validacion de nombres de equipo para el alta de equipos y migraciones para el llenado de generos.
- Fix orden de cprds por jugador y por equipo
- Fix de campos date en contrato del jugador

### Version 1.52.110

**Fecha de Despliegue** : 2024-09-17

**Comentarios**: 
- Fix en conversión de datetime a date en fechas de contrato sin alterar domain

### Version 1.52.111

**Fecha de Despliegue** : 2024-09-18

**Comentarios**: 
- Fix en las positions de searchPlayerById (se usa el handler de EFC porque el de dapper esta reventado)

### Version 1.52.112

**Fecha de Despliegue** : 2024-09-20

**Comentarios**: 
- Agregador de permisos a endpoint para obtener usuarios por team y role

### Version 1.56.113

**Fecha de Despliegue** : 2024-09-23
**US**: MER-1195
**Comentarios**: 
- Se le agrega a TeamPlayersInfoDTO los campos de imagen del jugador y si está lesionado o no
- En el endpoint de obtener todos los jugadores del sistema, ahora solo se traen los jugadores pertenecientes a los equipos del usuario solicitante.

### Version 1.56.114

**Fecha de Despliegue** : 2024-09-24

**US**: MER-230

**Comentarios**: 
- Se agregan 3 endpoints completos relacionados a la nueva entidad Season:
    - GET /api/v1/seasons -> obtiene todas temporadas ordenadas de manera descendiente (mas nuevo arriba)
    - POST /api/v1/seasons -> Crea una temporada
    - PUT /api/v1/seasons/{id} -> Edita una temporada dada

- otros cambios menores

### Version 1.56.115
**Fecha de Despliegue** : 2024-09-24
**Comentarios**: 
- Se agrega sessionId ,created by,categoryId y categoryName a la consulta de sessiones de entrenamiento por equipo y fecha
- Se corrige la creacion de tareas, Estaba poniendo el titulo en la descripcion y viceversa
- Se corrige imagenes de tareas para endpoint de sessiones

### Version 1.56.116
**Fecha de Despliegue** : 2024-09-25
**Comentarios**: 
- Se agrega dominio y endpoint para las solicitudes de ayuda, con envío de email incluido.
**Notas**:
- Incluye migración nueva

### Version 1.57.117
**Fecha de Despliegue** : 2024-09-26
**Comentarios**: 
- Se agrega booleano de lesionado al playerDTO para la ficha de jugador
- Se deja en appSettings los emails del cliente para los pedidos de ayuda (igual no van a pasar del mailgun)

### Version 1.57.118
**Fecha de Despliegue** : 2024-09-26
**Comentarios**: 
- se corrige las imagenes en sessiones de entrenamiento
- se  agrega imagenes a jugadores

### Version 1.57.119
**Fecha de Despliegue** : 2024-09-26
**Comentarios**: 
- se agrega que se pueda mandar a muchos emails

### Version 1.60.120
**Fecha de Despliegue** : 2024-09-27
**Comentarios**: 
- Se le agregan al psicologo los permisos nutricionales que le faltaban (incluye migración)

### Version 1.61.121
**Fecha de Despliegue** : 2024-09-30
**US**: MER-1245 : El entrenador no esta viendo los tratamientos activos en la ficha de jugador.
**Comentarios**: 
- Se le dio los permisos necesarios al rol de preparador fisico

### Version 1.61.122
**Fecha de Despliegue** : 2024-10-01
**US**: MER-679
**Comentarios**: 
- Se agrega a los usuarios cuenta bancaria y salario, y se permite cargar dichos valores desde la edición de usuario (no jugadores y jugadores contratados) y desde createMember
- Incluye migración

### Version 1.62.123
**Fecha de Despliegue** : 2024-10-02
**US**: MER-682 Alta Scouting
**Comentarios**: Incluye migración

### Version 1.62.124
**Fecha de Despliegue** : 2024-10-02
**US**: MER-1202
**Comentarios**: 
- Se agrega columna orden a la tabla de equipos (incluye migración)
- Se crea endpoint para setear orden de los equipos y se actualiza el de obtener equipos para que los entregue ordenados

### Version 1.63.125
**Fecha de Despliegue** : 2024-10-04
**US**: MER-1276
**Comentarios**: 
- Se fixea la query de dapper de obtener todos los equipos, que se rompió al agregarle orden a los equipos

### Version 1.63.126
**Fecha de Despliegue** : 2024-10-07
**Comentarios**: 
- Se hace fix de sessiones de entrenamiento para que en caso de momentos e intenciones ABP admita nulos en fases
- fix imagenes de tareas en modal de tareas de sesiones de entrenamientos

### Version 1.64.127
**Fecha de Despliegue** : 2024-10-09

**US**: MER-230

**Comentarios**: 
- Se agrega el filtro de temporadas a todos los endpoints correspondientes

### Version 1.65.128
**Fecha de Despliegue** : 2024-10-09

**US**: MER-1145

### Version 1.65.129

**Fecha de Despliegue** : 2024-10-15

**US**: MER-1299, MER-1298, MER-1301

**Comentarios**: 

Fix MER-1299 filtro de temporadas: Cambiar el endpoint wellness/teams/{teamId}/weight para filtrar por temporada. Si la temporada seleccionada no incluye la fecha actual, entonces se tomara como referencia la fecha de fin de temporada como pivote. Caso contrario, se usa la actual

Fix MER-1298: Ajustar la query de mophosis para poner filtro de temporadas

Fix MER-1301:  Sacar restriccion de fecha de inicio al crear Temporadas
Se cambia la firma de algunos metodos de PlayerDapperRepository para que los parametros  DateOnly sean del tipo CreatedDate.

- Cambiado de nombre de variables en tasks por metodologias y tipos


### Version 1.65.130
**Fecha de Despliegue** : 2024-10-16

**US**: MER-95 - Eliminacion de usuarios

**Comentarios**: 

- Se implementa endpoint completo para eliminar usuarios jugadores y no jugadores en estado creado o pendiente

- Se cambia el ORM a usar para el delete de EFC a Dapper.

- Se cambia interfaz e implementacion en UserDapperRepository

- Se agrega metodo para obtener la entidad de usuario a partir del email y a partir del Id del usuario

- Se agrega metodo para obtener la entidad de jugador a partir del userId (playerDapperRepository)

- Mini refactor general de UserDapperRepository y PlayerDapperRepository

- Se agrega metodo de fabrica  Of(..) en entidad BirthDate y User


### Version 1.66.131
**Fecha de Despliegue** : 2024-10-16

**Comentarios**: Fix de permisos de combo de entrenadores en sesiones de entrenamientos.
Agregado de endpoint para impresion de sesiones de entrenamiento

### Version 1.67.132
**Fecha de Despliegue** : 2024-10-18

**Comentarios**: Fix de permisos de combo de entrenadores en sesiones de entrenamientos.

### Version 1.67.133
**Fecha de Despliegue** : 2024-10-18

**US**: MER-1144 INACTIVACION de usuarios y tratamientos pendientes

**Comentarios**: 

- Fix logica de envio de correo para solo enviarse cuando se activa un usuario.. y extraer logica del handler

- Se ajustan las queries para filtrar por jugadores con usuarios activos

- Se ajusta las query que trae todos los equipos para descartar el de inactivos

- Se fixea el updateo innecesario en la tabla de user_state cada vez que se cambia el estado de un usuario:

- Se crea logica para setear el equipo de inactivos a los usuarios que cambien su estado a inactivo,


### Version 1.68.134
**Fecha de Despliegue** : 2024-10-18

**Comentarios**: 
 - Descomentado del método que aplica migraciones en archivo program.cs
 
### Version 1.69.135
**Fecha de Despliegue** : 2024-10-21

**Comentarios**: se corrige retorno de sessiones de entrenamiento para al obtener por equipo y fecha , y por training session Id
 
### Version 1.70.136
**Fecha de Despliegue** : 2024-10-22
**US**: MER-1281
**Comentarios**: 
	- Endpoints para la nueva seccion de objetivos
	- Creación de objetivos con fecha custom
	- Agregado de seguimiento anterior en objetivos al ser updateados

### Version 1.70.137
**Fecha de Despliegue** : 2024-10-23
**US**: MER-1343 En sesiones, el espacio debe ser un campo alfanumérico
 - Fix MER-1346 Fallo en la creación de tareas en varias categorías si ya existe una tarea de ese tipo  
 - Fix Paginacion de historial CPRD 

### Version 1.71.138
**Fecha de Despliegue** :  2024-10-23

**US**: MER-1205

**Comentarios**:  se agrega edicion de valores nutricionales

### Version 1.71.139

**Fecha de Despliegue** :  2024-10-28

**US**: MER-1324 - Mejora en la carga de lesionados/tratamientos

**Comentarios**:  

Cambian el endpoint de creacion/actualizacion de lesion.. Ahora se le puede pasar o no el realDischargeDate y el isPlayerAttendedByFootballersMutual (default falso). Ejemplo:

>{
  "categoryId": 1,
  "complexInjury": "string",
  "mechanismId": 1,
  "natureId": 1,
  "appearanceModeId": 1,
  "bodyZoneId": 1,
  "placeId": 1,
  "microcicleDayId": 1,
  "medicTreatmentId": 1,
  "comments": "string",
  "occurrenceDate": "2024-10-20",
  "dischargeDate": "2024-10-27",
  "isPlayerAttendedByFootballersMutual": true,
  "realDischargeDate": "2024-10-26"
}

Y en el payload de la creacion/actualizacion de un tratamiento medico:

>{
  "injuryId": "fb645665-f8a0-4983-a36d-7c9324ff2555",
  "typeId": 3,
  "type2Id": 10,
  "recoveryDetails": "string",
  "recoveryPhaseId": 3
}

default de typeId y type2Id es 0, se trata como que no tiene tipos asociados (y es obligatorio pasarle el recoveryDetails

y en todos los GETS de tratamiento/lesion por id, por jugador y por equipo se incluyen los nuevos campos agregados/movidos

>lesion: realDischargeDate, isPlayerAttendedByFootballersMutual
tratamiento medico: type2Id

### Version 1.71.140
**Fecha de Despliegue** :  2024-10-29

**US**: bugfix MER-1324 - Mejora en la carga de lesionados/tratamientos

**Comentarios**:

Falto incluir "Otros - Caida"  en la configuracion en InjuryMechanismConfiguration.
Se crea migracion

### Version 1.71.141
**Fecha de Despliegue** :  2024-10-31

**US**: bugfix MER-1324 - Mejora en la carga de lesionados/tratamientos

**Comentarios**:

Correcciones de bugs y otras mejoras.. Se deberia poder ya:

Editar lesiones ya cargadas 
Que se pueda poner en todos los  lesiones tratamientos médicos? ambos tratamientos tipos de tratamientos médicos? (fisioterapéuticos y readaptación)   
Que tipo de tratamiento sea multiselect y que los detalles sean obligatorios si no hay tratamientos  (la primer parte se logra en el FE, y la obligatoriedad de los detalles en ambos) 
Cambiar el toggle de mutua que está en tratamientos para que quede en lesiones 
Habilitar un ingreso libre en lesiones complejas (esto ya estaba antes en el BE, creo que faltaria en el FE)
Añadir en mecanismo lesional “otros” te deje cargar un valor nuevo, “caída” 
Añadir en localización “clavícula”, “huesos de la cara” 
Añadir en clasificación de la lesión muscular “latigazo cervical”, y tendinoso “dolor inguinal”  
Necesitaría dar de baja una lesión sin tener que meter tratamiento, o que se permita cerrar una lesión a través de alta cambiando la fecha 
Hay que cambiar los endpoints de creacion y actualizacion para poder setear la fecha de creacion a partir del parametro que se pase desde el front. Actualmente la fecha de creacion que se asigna es la actual del sistema, no la que se pasa por parametro.
Añadir el aggregate de Lateralidad a la Lesion y realizar todos los cambios en todas las capas correspondientes

FALTA corregir que tipo de tratamiento sea multiselect

### Version 1.72.142

**Fecha de Despliegue** :  2024-11-04
**US**:
**Comentarios**: se modifica el nombre de los objetivos físicos por "técnico-tácticos"

### Version 1.73.143

**Fecha de Despliegue** :  2024-11-05
**US**:
**Comentarios**: se agregan los objetivos "técnico-tácticos" manteniendo a los objetivos físicos (incluye migración)

### Version 1.73.144

**Fecha de Despliegue** :  2024-11-06

**US**: MER-1324: Mejoras en la carga de lesiones y tratamientos

**Comentarios**:

- Se ajustan todos los endpoints  y clases dependientes relacionados a los tratamientos medicos, impactados por el cambio de multiseleccion de tipos de tratamientos (flujos de creacion y de lectura de la entidad).

	- POST player/playerId,

	- PUT player/playerId

	- Todos los GEts que obtienen los recursos de tratamientos medicos

- Se renombra la clase MedicalTreatmentsTypesDTO a MedicalTreatmentTypeDTO en GetAllMedicalTreatmentTypes

- Se agrega metodo Of en MedicalTreatmentTypeId y MedicalTreatmentId

- Se agrega metodo ToDomain en MedicalTreatmentsTypeDTO para convertir el dto a entidad de dominio.

- Se agrega metodo FromTypeId en MedicalTreatmentRecoveryTypeEnum para obtener el tipo de recuperacion a la que pertence un tipo de tratamiento medico

- mini refactor: Se renombra propiedad MedicalTreatmentType a MedicalTreatmentRecoveryTypes en MedicalTreatmentRecoveryTypesEnum

- Se cambian y mejoran los metodos del MedicalTreatmentRepository.

- Se cambian y mejoran los metodos del MedicalTreatmentDapperRepository y queries relacionadas. Se hace nulleable RecoveryTypeId de las queriesResults (ya que en la db es nullable)

### Version 1.74.145
**Fecha de Despliegue** :  2024-11-08

**US**: MER-708: Adjuntar estudios medicos

**Comentarios**:

- Primera implementacion de la funcionalidad de adjuntar/ver/borrar adjuntos medicos de un jugador.

- Endpoints creados con operaciones de POST, GET, DELETE.

### Version 1.74.146
**Fecha de Despliegue** :  2024-11-08

**US**: MER-1405: Bugfix: User.Fullname no se estaba actualizando en las operaciones de actualizacion.

**Comentarios**:


### Version 1.74.147
**Fecha de Despliegue** :  2024-11-12

**US**: MER-1205: Mejora - Mejoras varias en el área de nutrición


### Version 1.74.148
**Fecha de Despliegue** :  2024-11-13
**Comentarios**: Fix Scouting Position null reference en historial

### Version 1.74.149
**Fecha de Despliegue** :  2024-11-14
**Comentarios**: ordenado de combos de scouting y quitado de obligatoriedad para equipo y club rival

### Version 1.75.150
**Fecha de Despliegue** :  2024-11-14
**Comentarios**: se fixea la inactivación y activación masiva de usuarios

### Version 1.76.151
**Fecha de Despliegue** :  2024-11-19
**Comentarios**: fix scouting players by team code

### Version 1.76.152
**Fecha de Despliegue** :  2024-11-20
**US**: MER 1249 CPRD Club

### Version 1.77.153
**Fecha de Despliegue** :  2024-11-20
**US**: MER 1492 Scouting - Diferencia entre nombre de habilidades y las de la US 

### Version 1.78.154
**Fecha de Despliegue** :  2024-11-21
**US**: MER 1397 - Mejoras Ficha nutricional nivel jugador - Endpoint nuevo para los graficos

### Version 1.78.155
**Fecha de Despliegue** :  2024-11-21
**Comentarios** : Fix Historial de scouting - se acomoda ordenamiento

### Version 1.78.156
**Fecha de Despliegue** :  2024-11-22
**Comentarios** :
	- Historial de CPRD
	- Historial de sesiones psicologicas
	- Sesiones psicologicas con multiples jugadores o todo el equipo
	- Habitos nutricionales creados por todos (jugadores y staff)

### Version 1.78.157
**Fecha de Despliegue** :  2024-11-25
**Comentarios** :
	MER 1397 - Mejoras Ficha nutricional nivel jugador -se crea una nueva query para obtener las mediciones por mes tomando la mas actualizada

### Version 1.78.158
**Fecha de Despliegue** :  2024-11-26
**Comentarios** :
	MER 708 - Adjuntar Estudios medicos 
	FIX MER 1500 - Cuando entro como Tecnico a scouting la app esta crashea
	MER 1481 - Rol Scouter: agregado al alta y a la modificación. 

### Version 1.79.159
**Fecha de Despliegue** :  2024-11-27
**Comentarios** :
 - MER 1514 fix avatar 
 - Se agrega migración para actualizar los pliegues de los equipos
 - Fix Formula valoraciones nutricionales

### Version 1.80.160
**Fecha de Despliegue** :  2024-12-02
**Comentarios** :
 - Se fixea la asignación de equipos a usuarios no jugador
 - Se le agrega promedios del equipo al endpoint para obtener la progresión de fatiga y sueño

### Version 1.80.161
**Fecha de Despliegue** :  2024-12-03
**Comentarios** :
- MER-1539 El historial de CPRD me esta mostrando jugadores a los cuales no debería ver (trae todos)
- MER-1538 En la ficha psicologica de club esta trayendo a todos los equipos con jugadores y no solo los que tengo asignados (con jugadores)

### Version 1.82.162
**Fecha de Despliegue** :  2024-12-04
**Comentarios** :
- MER-1398 - Mejoras - Ficha nutricional nivel equipo - Endpoint nuevo

### Version 1.83.163
**Fecha de Despliegue** :  2024-12-05
**Comentarios** :
- MER-1549 - Ficha nutricional nivel jugador y equipo - se agrega permiso al rol Medic y Psychologist 

### Version 1.84.164
**Fecha de Despliegue** :  2024-12-05
**Comentarios** :
- MER-1550 - En el historial del CPRD el páginado esta funcionando incorrectamente
- MER-1538 -En la ficha psicologica de club esta trayendo a todos los equipos con jugadores y no solo los que tengo asignados (con jugadores)

### Version 1.85.165
**Fecha de Despliegue** :  2024-12-05
**Comentarios** :

MER-1538-En la ficha psicologica de club esta trayendo a todos los equipos con jugadores y no solo los que tengo asignados (con jugadores) 
MER-1549- al ingresar como psicologo o medico me crashea la app     

### Version 1.86.166
**Fecha de Despliegue** :  2024-12-06
**Comentarios** :
  MER-1538-En la ficha psicologica de club esta trayendo a todos los equipos con jugadores y no solo los que tengo asignados (con jugadores)(re fix)   

### Version 1.87.167
**Fecha de Despliegue** :  2024-12-06
**Comentarios** :
   -  fix grafico cprd de jugador 

### Version 1.88.168
**Fecha de Despliegue** :  2024-12-10
**Comentarios** :
   -  MER-1398_mejoras_ficha_nutricional - Nuevo endpoint para el ultimo historial de equipo/jugador (sin paginado)

### Version 1.88.169
**Fecha de Despliegue** :  2024-12-10
**US** : MER-1250 / Vista Club de la ficha médica
**Comentarios** :
	- Se corrigen errores y se mejoran los endpoints para obtener los historiales de lesiones y tratamientos
	- Se agregan endpoints de salida de wellness y lesiones para vista de club


### Version 1.88.170
**Fecha de Despliegue** :  2024-12-11
**US** : MER-1517 Edición Scouting

### Version 1.88.171
**Fecha de Despliegue** :  2024-12-11
**Comentarios** :
   -  MER-1398_mejoras_ficha_nutricional - Nuevo endpoint para el ultimo historial de equipo/jugador (con paginado)
   
### Version 1.88.172
**Fecha de Despliegue** :  2024-12-11
**Comentarios** :
   -  Fix permisos de scouting

 ### Version 1.90.173
**Fecha de Despliegue** :  2024-12-12
**Comentarios** :
   -  MER-1398_mejoras_ficha_nutricional: Historiales: se agrega filtro por status.
       y en Habitos Nutricionales: se agrega el nombre del equipo en el resultado.

### Version 1.90.174
**Fecha de Despliegue** :  2024-12-12
**Comentarios** :
   -  MER-1398_mejoras_ficha_nutricional- Habitos Nutricionales: se agrega el filtro por statusName.

### Version 1.90.175
**Fecha de Despliegue** :  2024-12-12
**Comentarios** :
   -  MER-1505: Mejoras Scouting

### Version 1.91.176
**Fecha de Despliegue** :  2024-12-12
**Comentarios** :
   -  FIX: ScoutingScouters: se corrige el .csporj de infrastructure para incluir el query.

### Version 1.91.177
**Fecha de Despliegue** :  2024-12-13
**Comentarios** :
	- Se agrega edición de sesiones psicológicas
	- Se corrigen levemente los endpoints de archivos médicos

### Version 1.93.178
**Fecha de Despliegue** :  2024-12-17
**Comentarios** :
	- Fix MER-1563, se aplica el mismo filtro de usuario activo a los siguientes endpoints:
		/nutritional-assessments/team/:teamId/history
		/nutritional-assessments/mophosis/team/:teamId
		/nutritional-assessments/team/:teamId/paged

### Version 1.93.179
**Fecha de Despliegue** :  2024-12-18
**Comentarios** :
	MER-1565- FIX BUG El campo Nombre en el historial de mediciones es case sensitive

### Version 1.94.180
**Fecha de Despliegue** :  2024-12-18
**Comentarios** :
	- Endpoints para los cambios a Scouting
	- Se fixean bugs varios de lesiones
	- Se mueve una query de lugar a ver si eso soluciona los crasheos de la base de datos

### Version 1.95.181
**Fecha de Despliegue** :  2024-12-19
**Comentarios** :
	- FIX: MER-1562: En mediciones nutricionales no me trae la ultima de todos los jugadores.

### Version 1.96.182
**Fecha de Despliegue** :  2024-12-19
**Comentarios** :
	- Creo un endpoint para obtener los clubes de scouting que tengan reportes creados

### Version 1.97.183
**Fecha de Despliegue** :  2024-12-20
**Comentarios** :
	-MER-1251-Nuevos endpoints para ficha nutricional a nivel club

### Version 1.97.184
**Fecha de Despliegue** :  2024-12-20
**Comentarios** :
	- Permisos para scouting al entrenador (incluye migración)
	- Fix lesión que no se abre a nivel club


### Version 1.97.185

**Fecha de Despliegue** :  2024-12-20
**Comentarios** :
	- MER-1578: Cambio de formula de % grasa para mujeres.
	- Se modifica "skinfold fat" y porcentaje.


### Version 1.98.186

**Fecha de Despliegue** :  2024-12-24
**Comentarios** :
	- Se agrega endpoint morphosis/team/average


### Version 1.99.187

**Fecha de Despliegue** :  2024-12-26
**Comentarios** :
	- Fix endpoint de obtener todos los equipos


### Version 1.100.188

**Fecha de Despliegue** :  2024-12-26
**Comentarios** :
	- Fix paginado de historiales nutricionales cuando se filtra por estado


### Version 1.101.189
**Fecha de Despliegue** :  2024-12-27
**Comentarios** :
	- Se agregan datos adicionales al endpoint del historial de objetivos


### Version 1.101.190

**Fecha de Despliegue** :  2025-01-02
**Comentarios** :
	- MER-1623- Ficha nutricional - Club - fix bug semaforo


### Version 1.101.191

**Fecha de Despliegue** :  2025-01-02
**Comentarios** :
	- Cambios y mejoras en metodología (incluye migraciones)


### Version 1.102.192

**Fecha de Despliegue** :  2025-01-03
**Comentarios** :
	- Corrijo la edición de tareas de entrenamiento

### Version 1.102.193

**Fecha de Despliegue** :  2025-01-03
**Comentarios** :
	- MER-1621- fix bug error en calculos 


### Version 1.102.194

**Fecha de Despliegue** :  2025-01-03
**Comentarios** :
	- MER-1620- Ficha nutricional - Club - Se agregan validaciones de permisos por usuario equipo


### Version 1.104.195

**Fecha de Despliegue** :  2025-01-07
**Comentarios** :
	- MER-1620- Fix NutritionalAssesments/team/last/paged permisos por usuario equipo


### Version 1.104.196

**Fecha de Despliegue** :  2025-01-08
**Comentarios** :
	- MER-1231- Creación y edición de tipos de tareas de entrenamiento


### Version 1.105.198

**Fecha de Despliegue** :  2025-01-08
**Comentarios** :
	- Corrijo el ordenamiento de varios listados de las sesiones de entrenamiento (herramientas, fases, intenciones, etc)


### Version 1.105.199

**Fecha de Despliegue** :  2025-01-09
**Comentarios** :
	MER - 1398- Mejoras en objetivos:
	-Se agrega nuevo endpoint 'objectives/{id}' para editar un objetivo
	-'objectives/history' - Se agrega posibilidad de ordenar por nombre de jugador
	-'objectives/tracking-levels/teams' - Se agrega filtro por tipo


### Version 1.105.200

**Fecha de Despliegue** :  2025-01-09
**Comentarios** :
	- Ultimos cambios a las herramientas e intenciones de sesiones de entrenamiento


### Version 1.106.201

**Fecha de Despliegue** :  2025-01-10
**Comentarios** :
	- MER-1634: se fixea un bug donde se creaban las sesiones de entrenamiento en el día incorrecto dependiendo de la zona horaria
	- MER-1640: se crea endpoint para obtener las fechas que tienen al menos una sesion de entrenamiento creada
	- MER-1171: se agrega mensaje de error al intentar editarle el email a un usuario con un email ya existente
	- MER-753: se agrega mensaje de error al intentar registrarse con un email ya existente


### Version 1.109.202

**Fecha de Despliegue** :  2025-01-13
**Comentarios** :
	- MER-1644: Nivel club- fix calculos promedios cuando hay valores menores o iguales a 0.
	

### Version 1.109.203

**Fecha de Despliegue** :  2025-01-13
**Comentarios** :
	MER-1593- se fixea bug en team/last/paged :  'El historial de nutrición esta trayendo la ultima medición mensual de los jugadores por default'.


### Version 1.110.204

**Fecha de Despliegue** :  2025-01-13
**Comentarios** :
	- MER-1639: Se acomodan correctamente las fases dentro de los momentos correspondientes al obtener una sesion de entrenamiento por id
	- MER-836: El semaforo de wellness ahora marca rojo si hay zonas de dolor, sin importar lo demás
	- MER-1558: Se agrega eliminado de usuarios no-jugadores en estado pendiente

### Version 1.110.205
**Fecha de Despliegue** :  2025-01-14
**Comentarios** :
	MER-1498: se fixea el 'status' de un jugador dependiendo del valor en team/is_adults_team.

### Version 1.111.206
**Fecha de Despliegue** :  2025-01-15
**Comentarios** :
	MER-1628:  Scouting - Mejoras - Que los preparadores físicos, solo puedan ver los jugadores que ellos cargan y no los de los demás

### Version 1.112.207
**Fecha de Despliegue** :  2025-01-15
**Comentarios** :  
	- Se eliminan dos momentos e intenciones redundantes en las sesiones de entrenamiento
	- Se le asigna metodología futbol11 a 5 de las categorías de tareas de entrenamiento predefinidas (dejan de ser globales)

### Version 1.113.208
**Fecha de Despliegue** :  2025-01-16
**Comentarios** :  
	- Se hacen opcionales los momentos/intenciones y las fases en las sesiones de entrenamiento

### Version 1.114.209
**Fecha de Despliegue** :  2025-01-21
**Comentarios** :  
	- Se fixean calculos con valores nulos en GetLastestAverageMorphosisQueryHandler

### Version 1.115.210
**Fecha de Despliegue** :  2025-01-22
**Comentarios** :  
	- Se fixea error al no haber datos nutricionales al momento de calcular el averageMorphosis

### Version 1.115.211
**Fecha de Despliegue** :  2025-01-23
**Comentarios** :  
	- Se agrega el control de teams por user en morphosis/team/average

### Version 1.116.212
**Fecha de Despliegue** :  2025-01-23
**Comentarios** :  
	- Multitenancy MER 168

### Version 1.117.213

**Fecha de Despliegue** :  2025-01-23
**Comentarios** : Se le agrega multitenancy a tareas de entrenamiento (por medio de las metodologías)

### Version 1.120.214

**Fecha de Despliegue** :  2025-01-23
**Comentarios** : Se le agrega multitenancy a Seasons

### Version 1.121.215

**Fecha de Despliegue** :  2025-01-28
**Comentarios** : Se le agrega multitenancy a Scouting

### Version 1.122.216

**Fecha de Despliegue** :  2025-02-03
**Comentarios** : Se corrige fallo del endpoint de promedio mensual de pliegues cuando se carga un único registro nutricional pero sin pliegues

### Version 1.123.217

**Fecha de Despliegue** :  2025-02-05
**Comentarios** : Se agrega nuevo rol "administrador de equipo"

### Version 1.124.218

**Fecha de Despliegue** :  2025-02-06
**Comentarios** : Se devuelve el objetivo privado en lugar del público en el historial de objetivos

### Version 1.125.219
#### LTS DEV

**Fecha de Despliegue** :  2025-02-14
**Comentarios** : 
	- Se agrega edición de equipos
	- Se agrega limpieza de tokens expirados

### Version 1.125.220
- **Fecha de Despliegue**: 2025-04-15
- **Descripción**:
  - Se agrega soporte multitenant a la entidad `InjuryCategory` (tenant_id en BD).
  - Primera implementación del controlador y servicio para informes PowerBI:
    - Creación de DTOs para reportes.
    - Configuración en `appsettings.json`.
  - Mejoras en logs y manejo de errores en `PowerBiService`.
  - Migraciones para personalización de tenant.
- **Notas Adicionales**:
  - Nuevas configuraciones requeridas en `appsettings.json` (`PowerBiConfig`).
  - Scripts pos-despliegue en carpeta `/pos-deployment` para queries manuales.

---

## Aseguramiento de Calidad (QA)
| [Desarrollo (dev)](#desarrollo-dev) | [Aseguramiento de Calidad (QA)](#aseguramiento-de-calidad-qa) | [Producci�n (prod)](#producci�n-prod) | [LTS dev](#lts-dev)| [LTS QA](#lts-qa) | [LTS prod](#lts-prod)

### Version 0.0.1
- **Fecha de Despliegue**: 2024-05-27
- **Descripci�n**:
	- Se incluye archivo env-relese-notes.md para control de versiones.
- **Notas Adicionales**: (eg.) Las pruebas deben ejecutarse nuevametne con el despliegue.

### Version 0.1.3
- **Fecha de Despliegue**: 2024-05-29
- **Descripci�n**:
	- Fix WellnessCommandValidator. Se usa When para definir que cuando IsInPain == true se deba considerar la regla que valida las affectedZones.
Caso contrario (si es falso) se ignora.

### Version 0.1.8
- **Fecha de Despliegue**: 2024-06-05
- **US relacionadas**: MER-322, MER-502/MER-358 (Relacionado al alta y salida de datos de Wellness)

### Version 0.2.10
- **Fecha de Despliegue**: 2024-06-06
- **US relacionadas**: MER-322, MER-338 (valoracion fisica cuantitativa condicional). MER-421 Ficha nutricional equipo

### Version 0.3.12
- **Fecha de Despliegue**: 2024-06-10
- **US relacionadas**: MER_359_valoracion_fisica_cuantitativo_condicional

**Notas Adicionales**:		
- Creacion de SeedData con entrenamientos cuantitativos condicionales con diferentes jugadores y metricas.
- Modificacion de getter en CreatedDate (sin private set), y se agrego un metodo de sobrecarga extra "Create" en AssessmentTraining

### Version 0.4.20
- **Fecha de Despliegue**: 2024-06-24
- **US relacionadas**: 
	- MER-485 Visualizar historial de valoraciones cualitativas
	- MER-358 Alta de Wellness
	- MER-593, MER-387
	- Bugs MER-511 y MER-550 
	- Bug MER-550
	- MER-345 Carga Objetivos
	- MER-101 Agregar foto en Alta
	- MER-485 Visualizar historial de valoraciones cualitativas

### Version 0.5.25

- **Fecha de Despliegue**: 2024-06-27
- **US relacionadas**: 
	- MER-643 Gestión de imágenes de usuario
	- MER-658 Refactor de SeedDataExtension
	- MER-5 Menú de usuario y edición de datos propios

### Version 0.6.26
- **Fecha de Despliegue**: 2024-06-28

### Version 0.7.28
- **Fecha de Despliegue**: 2024-07-03
- **US relacionadas**: MER-637/MER-662

### Version 0.8.30

- **Fecha de Despliegue**: 2024-07-04
- **US relacionadas**:  
	- MER-659 Refactor SeedDataExtension
	- MER-658/MER-687 Crear endpoint nuevo para wellness

	
### Version 0.9.31

- **Fecha de Despliegue**: 2024-07-08
- **US relacionadas**:  MER-688 Crear endpoint completo para editar jugador usando UserContext(Modificar el de por PlayerId)


### Version 0.10.32
- **Fecha de Despliegue**: 2024-07-08
- **US relacionadas**:  Bugfix: MER-699 & MER-698

### Version 0.11.34
- **Fecha de Despliegue**: 2024-07-10
- **US relacionadas**:  Bugfix: TODO: TBD:, Bugfix: MER-745

### Version 0.12.35
- **Fecha de Despliegue**: 2024-07-10
- **US relacionadas**:  Se aumenta la duración del token  de email confimation

### Version 0.12.36
- **Fecha de Despliegue**: 2024-07-11
- **US relacionadas**: MER-548 Salida Wellness para el club
  **Descripcion**:  Se agrega userId al endpoint de obtener wellness por id

### Version 0.13.37
- **Fecha de Despliegue**: 2024-07-11

### Version 0.14.38
- **Fecha de Despliegue**: 2024-07-11

### Version 0.15.39
- **Fecha de Despliegue**: 2024-07-11

### Version 0.16.40
- **Fecha de Despliegue**: 2024-07-11
- - **US relacionadas**: Get Images por equipo

### Version 1.17.41

- **Fecha de Despliegue**: 2024-07-11

### Version 1.18.44
- **Fecha de Despliegue**: 2024-07-18
- **US relacionadas**:  MER-421 - Página nutricional por equipo

### Version 1.19.47

- **Fecha de Despliegue**: 2024-07-23
- **US relacionadas**: 
	- MERx - Usuario equipo
	- MER-837: No hay ningun tipo de bloqueo para la carga de wellness por parte del jugador
	- MER-421 - Página nutricional por equipo
- **Descripción**: 
	-Se refactoriza el endpoint de historial de wellness
	-Se agrega el control de equipos por usuario mediante token


### Version 1.20.48

- **Fecha de Despliegue**: 2024-07-21
- **US relacionadas**:  MERx - Usuario equipo
- **Descripción**: 
	-Se refactoriza el endpoint de historial de wellness
	-Se agrega el control de equipos por usuario mediante token
	-mejora del endpoint de teams para que segun el context busque corrobore si el usuario puede ver un equipo
    -fix wellness summary: se repiten zonas de dolor

### Version 1.21.49

- **Fecha de Despliegue**: 2024-07-23
- **Descripción**: 
	-Se valida que el rol player pueda ver todos los equipos
	- y que los demas usuarios tengan que hacerlo através de user team


### Version 1.22.50

- **Fecha de Despliegue**: 2024-07-24
- **US:** MER-847 El historial de wellness no muestra los wellness cargados por jugadores
- **Descripción**: 
	-Se corrige el paginado de wellness history	agregando campo date time 
	-Se corrige case sensitive en la busqueda de historial de wellness

### Version 1.23.51

- **Fecha de Despliegue**: 2024-07-29
- **US:** MER-864 Configuración y validación de permisos por roles y equipos en wellnesses
- **Descripción**: 
Se le dio permisos de lectura al preparador fisico (Entrenador fisico) para usar los endpoints de wellness.
Se cambia el nombre de entrenador fisico a Preparador fisico, lo mismo con Player y Admin
Se agrega nuevo tipo de Assessment (Medicos)
- Importante: Nueva migracion creada

### Version 1.24.52

- **Fecha de Despliegue**: 2024-07-29
- **US:** MER-864 Configuración y validación de permisos por roles y equipos en wellnesses
- **Descripción**: 
Se le termino de dar mas permisos a varios roles. (preparados fisico, nutricionista,medico y psicologo, tablet)
- Importante: Nueva migracion creada

### Version 1.25.55

- **Fecha de Despliegue**: 2024-07-31
- **US:** 
	- MER-864 Configuración y validación de permisos por roles y equipos en wellnesses
	- MER-883 
	- MER-794
- **Descripción**: 				
	- Se le termino de dar mas permisos faltantes de wellness al rol de nutricionista)
	- se corrige unAuthorized cuando hay errores con la imagenes
	- Se limitan los assessmentTrainings a un solo equipo y se ajustan los endpoints relacionados
- Importante: Nueva migracion creada


### Version 1.27.57
- **Fecha de Despliegue**: 2024-08-02
- **US:** (Bug) MER-898 Al usuario nutricionista le faltan varios permisos
- **Descripción**: 
	- Se agregan los permisos faltantes al rol de nutricionista..
	- Ademas se agregan muchos otros permisos faltantes a otros roles
- **US:** MER-613 Alta de lesiones 
- **Descripción**: 
	- Se crean los endpoints para obtener los parametros de una lesión y para crearla

### Version 1.28.58

- **Fecha de Despliegue**: 2024-08-02
	- Se elimina Authorization Service e implementaciones

### Version 1.29.60

 **Fecha de Despliegue**: 2024-08-06

 **US:**
	- (Bug) MER-614 Varias Mejoras y correcciones GENERALES a los endpoints de tratamientos medicos
	- MER-948 Acortar el link de alta

 **Descripción**: Implementacion final. Falta testing
	- Nueva migracion para agregar el permiso a varios roles y reconfiguracion de la entidad

 **US:** (Bug) MER-613 Crear un endpoint que a partir de un jugador te traiga las lesiones

 **Descripción**: 
	- Implementacion final. Falta testing
	- Nueva migracion para agregar el permiso a varios roles

### Version 1.30.62

- **Fecha de Despliegue**: 2024-08-06
- **US:** (Bug) Sin definir
- **Descripción**: 
Se mueve el SeedDataAuthentication dentro de app.Environment.IsDevelopment() para evitar que corra en prod

- - **Fecha de Despliegue**: 2024-08-06
- **US:** (Bug) MER-614 Varias Mejoras y correcciones GENERALES a los endpoints de tratamientos medicos
- **Descripción**: 
Correccion/mejora del modelo de requests para que puedan pasarse ids, en vez de strings TreatmentTypeName, y treatmentName

Y esto aplica a FluentValidations, etc
Y Solo se necesita TreatmentTypeId en los requests ya que la categoria se infiere a partir de dicho id.
Limpieza de comentarios innecesarios

### Version 1.31.67

- **Fecha de Despliegue**: 2024-08-07
- **US:** (Bug) MER-614: Varias Mejoras y correcciones GENERALES a los endpoints de tratamientos medicos P2
- **Descripción**: 
- Se cambia Category para que no sea private set y se pueda asignar la categoria por fuera del constructor (Por practicidad)
- Fix Category que viene null (se implementa metodo en CategoryEnum para obtener la categoria a partir del TypeId
- Correccion StatusId  en GetMedicalTreatmentsByInjuryIdQueryHandler
- Fix endpoint para operacion UPDATE : No hace falta pasar en el body el CategoryId, solo a partir de TypeId
	Se fixeo el bug que tiraba error cuando le pasabas un mismo TypeId que el que tenia anteriormente (TypeId sin cambiar).
	Se hace evitando attachear las entidades aggregate (RecoveryType y Type) , las cuales son obtenidas  y asignadas al tratamiento medico pero a partir de los enums.FindValue()  y en vez estas se buscan manualmente desde base a traves del repositorio  (desde el Handler)

- Normalizacion de nombres de variables de request y response
- Se usa GetMedicalTreatmentByIdReadOnly en vez de GetMedicalTreatmentById en GetMedicalTreatmentByIdQueryHandler ya que solo se necesita para la lectura
- Se hace async el PatchStatusById

- **Fecha de Despliegue**: 2024-08-08
- **US:** (Bug) MER-614: Varias Mejoras y correcciones GENERALES a los endpoints de tratamientos medicos P3 (se corrige el PATCH)
- **Descripción**:

Fix error en metodo PatchStatusById (se cambia UpdatedBy por CreatedBy). Ademas se instancia UpdatedDateTime por fuera del SetProperty() para evitar excepcion < a LINQ no le gustaba que se hiciera ahi mosmo>
Correccion menor semantica en MedicalTreatmentConfiguration de UpdatedDateTime
Borrado de comentarios innecesarios

Fix CategoryId viniendo en 0
Otros fixes a nivel modelo de response y handlers
Fix typeId viniendo en 0

- **Fecha de Despliegue**: 2024-08-08
- **US:** MER-614: alta de tratamientos medicos
- **Descripción**:

- Crear 1 endpoint adicional PATCH para cambiar el estado de los tratamientos medicos a completado a partir de una lesion
Nueva migracion creada para agregar el permiso al medico.

- **Fecha de Despliegue**: 2024-08-09
- **US:** MER-327/611: ficha medica (salida)
- **Descripción**:
	- Se crean los endpoints de wellness para la salida de la ficha medica
	- Se corrige el calculo de promedio de horas de sueño de wellness para solo tener en cuenta a los pre-entreno

**US:**  NA
**Descripción**:
	- Se crea configuración de tiempos de expiración de tokens:
	
```
  "TokenExpireTimesInHours": {
    "Register": "10",
    "Login": "10",
    "ResetPassword": "2",
    "EmailConfirmation": "48"
  },
```

- **Fecha de Despliegue**: 2024-08-09
- **US:** Subtask: MER-1025: Crear una columna para lesion real_discharge_date y setearla a la fecha de hoy cuando se finaliza una lesion.
- **Descripción**:
(Se corrige que antes estaba seteando discharge_date en vez 
Varios cambios en todas las capas. Se hace que los gets de injury puedan devolver  este campo.
Agregado de varias propiedades en InjuryDTO
Se agrega .Include(x => x.MedicalTreatments) en GetAllByPlayerIdAsyncReadOnly
Endpoints de injury devuelven mas informacion
Nueva migracion creada

### Version 1.32.69

**Fecha de Despliegue**: 2024-08-12

**US:** Subtask:
- MER-614: Se agregan nuevos tipos de tratamientos medicos para gestion de cargas

**Descripción**:
Nueva migracion creada


### Version 1.33.71

**Fecha de Despliegue**: 2024-08-15

**Descripción**:
 -injuries refactor name properties
 -permitir discharge date e injury treatment en nulo

 **US:**
- MER-948 Acortar el link de alta

**Descripción**:
   Se modifica la creación de url para registro de usuario, regresando la url minificada.
   Se agrega endpoint /redirect/{id} para obtener la url a redireccionar.

Response:
```
  {
  "value": {
    "id": "19154CDEB9CQGp",
    "shorterUrl": "http://localhost:3000/r/19154CDEB9CQGp",
    "redirectUrl": "http://localhost:3000/email-confirmation/jpnGl6zg4D..."
  },
  "isSuccess": true,
  "isFailure": false,
  "error": {
    "code": "",
    "name": ""
  }
}
```

### Version 1.34.72

**Fecha de Despliegue**: 2024-08-16
** US **:  MER-632, MER-614, MER-613
**Descripción**:
- Fix nombre incorrecto a validar del blobStorage de imagenes de usuario en FileRepository : ContainerUserImagesName en vez de ContainerName

- Alta tareas de entrenamiento (MER-632)
Se implementan los endpoints necesarios para el alta (sin la vinculacion con sesiones de entrenamiento)
Nueva migracion

- Alta lesiones y tratamientos medicos (MER-613/MER-614)
Se Corrigen varios errores y se termina de integrar con tratamientos


### Version 1.35.79

**Fecha de Despliegue**: 2024-08-20
** US **:  MER-631, MER-634
**Descripción**: Alta de Sesiones de entrenamiento y Control de asistencia respectivamente

**Fecha de Despliegue**: 2024-08-20
** US **:  MER-678: Alta de usuario no jugador
**Descripción**:
Primera Implementacion. Se crean las entidades correspondientes a los roles, excepto el jugador:
Se crean las clases de repositorios para cada uno
Se crea Handler para La creacion del usuario no jugador
Se crea endpoint  para La creacion del usuario no jugador
Se crea contrato de endpoint
Se crean las tablas correspondientes
Se deja Members de placeholder para futuro refactor
Se crea fluent validators

Se agregan columnas comunes de player a user (en player quedaran redundantes) pero era una simplificacion para no tener que crear una tabla nueva "members"
Se impide que un usuario pueda estar registrado con diferentes entidades de roles simultaneamente.

**Fecha de Despliegue**: 2024-08-20
** US **:  MER-327/611: Ficha medica para jugador y equipo
**Descripción**:
	- Se crean endpoints para las fichas medicas (lesiones y tratamientos)
	- Se agrega progresión de lesiones (incluye migración)

**Fecha de Despliegue**: 2024-08-20
** US **:  MER-1043 Ajustes en tareas de entrenamiento
**Descripción**:
	- Se cambia que al consultar la tarea devuelva la url  de la imagen y no solo el nombre
	- Se corrige en docker-compose.override el nombre de la variable de entorno ASPNETCORE_ENVIRONMENT.

**Fecha de Despliegue**: 2024-08-20
** US **:  MER-678: Alta de usuario no jugador
**Descripción**:
Se modifica la salida de usuarios para devolver todos los equipos al que esta asociado
Se refactoriza GetAllQuery para ser mas eficiente y generar el mismo resultado.. ademas de devolver los teams para los usuarios no jugadores ( a traves de user_team)
Se ajusta el parametro TeamId para que sea un listado. Se puede asociar en el alta muchos equipos a un usuario
Se crea GetTeamsByIds para  traer los equipos por sus ids. por ahora Se reusa GetAll y se filtra en el handler. queda en TODO: implementar GetTeamsByIds en DapperRepository(comentado)
Reconfiguracion del handler para que evalue primero si el usuario ya se habia registrado antes de validar los equipos y demas
Se agrega attach de los teams para evitar insercion duplicada por EFC

**Fecha de Despliegue**: 2024-08-20
** US **:  MER-631, MER-634
**Descripción**: Se agrega obtención causas de asistencia

**Fecha de Despliegue**: 2024-08-22
** US **:  MER-486
**Descripción**: Se agrega edición de entrenamientos de valoración

**Fecha de Despliegue**: 2024-08-22
**Descripción**: 
	- Eliminamos permiso de CreateMember
	- Usiario no jugador puede obtener todos los equipos si está en estado creado 1


### Version 1.36.82

**Fecha de Despliegue**: 2024-08-28
** US **:  MER-635 - Visualización de sesiones de entrenamientos

**Fecha de Despliegue**: 2024-08-28
** US **:  MER-1044 - Visualización de tareas de entrenamiento

**Fecha de Despliegue**: 2024-08-29
** US **:  MER-XXX - Se agregan permisos faltantes al medico, nutricionista y psicologo
Nueva migracion Creada
 -Se adiciona 3 días al tiempo de expiracion del token de imagenes

### Version 1.37.83

**Fecha de Despliegue**: 2024-08-29
**Descripción**: Se crean dos migraciones para insertar permisos faltantes en nutrición y tratamientos médicos

### Version 1.38.84

**Fecha de Despliegue**: 2024-09-02
**US**: MER-1108 CA - Dejar solo los pliegues como obligatorios para el alta de datos nutricionales

### Version 1.39.85


**Fecha de Despliegue**: 2024-09-03
** US **:  MER-1108
** Comentarios ** :
     - Se fixea la query para completar el registro nutricional con los valores pasados
     - Se fixean las query de registros nutricionales y habitos nutricionales que traían solo hasta 10 registros

### Version 1.40.87

**Fecha de Despliegue**: 2024-09-03
** US **:
** Comentarios ** :
     - Se fixean los endpoints de salida de lesiones para soportar valores nulos en donde están permitidos

**Fecha de Despliegue**: 2024-09-04
** US **:
** Comentarios ** :
     - Fix de bug en tareas al entrar a tab tareas en entrenamientos

### Version 1.41.90

**Fecha de Despliegue**: 2024-09-05
**US**: MER-1095
**Comentarios** :
     - Se agregan endpoints para obtener toda la info de un usuario por id y por context
	 - Se agregan endpoints para editar la info de un usuario por id y por context

**Fecha de Despliegue**: 2024-09-05
**US**: MER 631 Alta de Sesión de entrenamiento
**Comentarios** :
     - Se agrega endpoint para traer todas las tools agrupadas y se hace fix ataque sin balón que no tenía items

**Fecha de Despliegue**: 2024-09-06
**US**: MER 518 - Ficha Psicologica nivel jugador ,MER 527 Ficha Psicologica nivel equipo

**Fecha de Despliegue**: 2024-09-06
**US**: (sin definir)

**Comentarios** :
	Fix tipos de respuestas en varios endpoints
	
	endpoints:
	- reset-password-link : Se devuelve 401 en vez de 500 cuando es necesario
	- login: Se crea error de contraseña invalida cuando es el caso, y se lo separa de InvalidCredentials (error en el email y/o contraseña).


### Version 1.42.94

**Fecha de Despliegue**: 2024-09-09
**US**: MER-945 Administracion de equipos


**Fecha de Despliegue**: 2024-09-09
**US**: MER-1125
**Comentarios** :
     - Se modifica el endpoint de crear habito nutricional para que sea utilizado por administradores y nutricionistas (no jugadores)

**Fecha de Despliegue**: 2024-09-09
**Comentarios**: Se realiza Fix de Ficha de CPRD de equipo y jugador.


**Fecha de Despliegue**: 2024-09-09
**US**: MER-673, y otros fixes
**Comentarios** :

- Se implementa la posibilidad de especificar los campos de contrato, fechas de inicio y fin, primera y segunda posicion en el alta de jugador.
Asimismo, se permite al administrador editar dichos campos mencionados.. y el jugador podra incluso editar los terminos y condiciones.
Los terminos y condiciones, junto a los campos relacionados al contrato y a las posiciones se devuelven en los endpoints de busqueda de jugador por Id o por userId
- Se fixea un error en el flujo de cambio de contraseña en donde la respuesta venia en 400 en vez de 404


### Version 1.43.94 -1.44.94 - 1.45.94

**Fecha de Despliegue**: 2024-09-09
**US**: Corrección de migración en columna first position.


### Version 1.46.96


**Fecha de Despliegue**: 2024-09-10
**US**: MER-673
**Comentarios** : Se fixea columna "HasContract" por "has_contract" en una query

**Fecha de Despliegue**: 2024-09-10
**US**: MER-673
**Comentarios** : Fixes en dominio y queries (Se quita alias en campos) para query GetPlayersInfoByTeamId.
Se hace nulleable Terms y Conditions en un metodo de la entidad de dominio Players.
Se resetean algunas queries como recursos incrustados (de lo contrario ReadQuery no puede encontrar dicho recurso de query)

### Version 1.46.98

**Fecha de Despliegue** : 2024-09-11
**Comentarios**:
   Fix Cprd valores para porcentaje de equipos - Fix nombre en trainingSesssion

**Fecha de Despliegue** : 2024-09-12
**US**: MER-673
**Comentarios**:
   Se corrige error en repositorio EFC donde no se traigan las posiciones (porque faltaba el include).
   Endpoints afectados:

   GET "players/context"
   GET "players/user/{userId}"


### Version 1.48.99

**Fecha de Despliegue** : 2024-09-12
**Comentarios**:
Fix CPRD porcentajes de jugador para casos en los que no este dentro del rango adecuado
Fix de imagenes de jugadores en cprd
Fix wellness filter

### Version 1.49.101

**Fecha de Despliegue** : 2024-09-12
**Comentarios**:
Fix paginado

**Fecha de Despliegue** : 2024-09-12

**Comentarios**:
Se quita permiso nutritionalHabitsCreate al player y se lo agrega al nutricionista. Migracion Creada


### Version 1.50.104

**Fecha de Despliegue** : 2024-09-12

**Comentarios**:
 Fix filtro para wellness regulares


**Fecha de Despliegue** : 2024-09-12

**Comentarios**:
Se quita permiso nutritionalHabitsCreate al player y se lo agrega al nutricionista. Migracion Creada


**Fecha de Despliegue** : 2024-09-12

**Comentarios**:
**US**: BugFix:  MER-673

Se corrige error con las posiciones que causaban excepcion en el back
Se quita validacion de fecha de inicio de contrato

Se agrega validacion en el handler para que la fecha de fin de contrato sea siempre posterior a la de inicio

Se agrega metodos de repositorios para obtener todas las posiciones y la posicion por Id (Dapper en construccion, por EFC listo)
Borro comentarios innecesarios


### Version 1.51.106

**Fecha de Despliegue** : 2024-09-12

**Comentarios**: Fix filtro regulares


**Fecha de Despliegue** : 2024-09-12

**Comentarios**:

**US**: BugFix:  MER-673

Se permite que se pueda editar/crear un jugador con ambas posiciones en sin asignar.


### Version 1.52.109

**Fecha de Despliegue** : 2024-09-16

**Comentarios**:

**US**: Sin definir

Se setea el valor del teamPlayer.position  del player creado o editado asociado con el valor de la primer posicion que se paso como parametro en dichos flows
Se refactoriza un poco CreatePlayerHandler y UpdatePlayerByPlayerIdCommandHandler

Se crea repositorio de Teamplayer
Se agrega nuevo rol Scout y algunos permisos basicos
Se agrega endpoint para obtener las posiciones (todas las capas)
Nueva migracion creada


**Fecha de Despliegue** : 2024-09-16

**Comentarios**: Se realizan cambios en el detalle de sessiones de entrenamiento,
para que un detalle pueda aceptar muchas fases e intenciones

**Fecha de Despliegue** : 2024-09-16

**Comentarios**: 
- Se agrega validacion de nombres de equipo para el alta de equipos y migraciones para el llenado de generos.
- Fix orden de cprds por jugador y por equipo
- Fix de campos date en contrato del jugador

### Version 1.53.110

**Fecha de Despliegue** : 2024-09-17

**Comentarios**: 
- Fix en conversión de datetime a date en fechas de contrato sin alterar domain

### Version 1.54.110


**Fecha de Despliegue** : 2024-09-17

**Comentarios**: 
- Fix en conversión de datetime a date en fechas de contrato sin alterar domain en endpoints faltantes

### Version 1.55.111

**Fecha de Despliegue** : 2024-09-18

**Comentarios**: 
- Fix en las positions de searchPlayerById (se usa el handler de EFC porque el de dapper esta reventado)


### Version 1.56.112

**Fecha de Despliegue** : 2024-09-20

**Comentarios**: 
- Agregador de permisos a endpoint para obtener usuarios por team y role


### Version 1.57.116

**Fecha de Despliegue** : 2024-09-23
**US**: MER-1195
**Comentarios**: 
- Se le agrega a TeamPlayersInfoDTO los campos de imagen del jugador y si está lesionado o no
- En el endpoint de obtener todos los jugadores del sistema, ahora solo se traen los jugadores pertenecientes a los equipos del usuario solicitante.

**Fecha de Despliegue** : 2024-09-24

**US**: MER-230

**Comentarios**: 
- Se agregan 3 endpoints completos relacionados a la nueva entidad Season:
    - GET /api/v1/seasons -> obtiene todas temporadas ordenadas de manera descendiente (mas nuevo arriba)
    - POST /api/v1/seasons -> Crea una temporada
    - PUT /api/v1/seasons/{id} -> Edita una temporada dada

- otros cambios menores

**Fecha de Despliegue** : 2024-09-24
**Comentarios**: 
- Se agrega sessionId ,created by,categoryId y categoryName a la consulta de sessiones de entrenamiento por equipo y fecha
- Se corrige la creacion de tareas, Estaba poniendo el titulo en la descripcion y viceversa
- Se corrige imagenes de tareas para endpoint de sessiones

**Fecha de Despliegue** : 2024-09-25
**Comentarios**: 
- Se agrega dominio y endpoint para las solicitudes de ayuda, con envío de email incluido.
**Notas**:
- Incluye migración nueva

### Version 1.58.117

**Fecha de Despliegue** : 2024-09-26
**Comentarios**: 
- Se agrega booleano de lesionado al playerDTO para la ficha de jugador
- Se deja en appSettings los emails del cliente para los pedidos de ayuda (igual no van a pasar del mailgun)


### Version 1.59.118

**Fecha de Despliegue** : 2024-09-26
**Comentarios**: 
- se corrige las imagenes en sessiones de entrenamiento
- se  agrega imagenes a jugadores

### Version 1.60.119

**Fecha de Despliegue** : 2024-09-26
**Comentarios**: 
- se agrega que se pueda mandar a muchos emails


### Version 1.61.120

**Fecha de Despliegue** : 2024-09-27
**Comentarios**: 
- Se le agregan al psicologo los permisos nutricionales que le faltaban (incluye migración)

### Version 1.62.122

**Fecha de Despliegue** : 2024-09-30
**US**: MER-1245 : El entrenador no esta viendo los tratamientos activos en la ficha de jugador.
**Comentarios**: 
- Se le dio los permisos necesarios al rol de preparador fisico

**Fecha de Despliegue** : 2024-10-01
**US**: MER-679
**Comentarios**: 
- Se agrega a los usuarios cuenta bancaria y salario, y se permite cargar dichos valores desde la edición de usuario (no jugadores y jugadores contratados) y desde createMember
- Incluye migración

### Version 1.63.124

**Fecha de Despliegue** : 2024-10-02
**US**: MER-682 Alta Scouting
**Comentarios**: Incluye migración

**Fecha de Despliegue** : 2024-10-02
**US**: MER-1202
**Comentarios**: 
- Se agrega columna orden a la tabla de equipos (incluye migración)
- Se crea endpoint para setear orden de los equipos y se actualiza el de obtener equipos para que los entregue ordenados

### Version 1.64.125

**Fecha de Despliegue** : 2024-10-04
**US**: MER-1276
**Comentarios**: 
- Se fixea la query de dapper de obtener todos los equipos, que se rompió al agregarle orden a los equipos

### Version 1.65.127

**Fecha de Despliegue** : 2024-10-07
**Comentarios**: 
- Se hace fix de sessiones de entrenamiento para que en caso de momentos e intenciones ABP admita nulos en fases
- fix imagenes de tareas en modal de tareas de sesiones de entrenamientos

**Fecha de Despliegue** : 2024-10-09
**US**: MER-230
**Comentarios**: 
- Se agrega el filtro de temporadas a todos los endpoints correspondientes


### Version 1.66.130

**Fecha de Despliegue** : 2024-10-09
**US**: MER-1145


**Fecha de Despliegue** : 2024-10-15
**US**: MER-1299, MER-1298, MER-1301

**Comentarios**: 

Fix MER-1299 filtro de temporadas: Cambiar el endpoint wellness/teams/{teamId}/weight para filtrar por temporada. Si la temporada seleccionada no incluye la fecha actual, entonces se tomara como referencia la fecha de fin de temporada como pivote. Caso contrario, se usa la actual

Fix MER-1298: Ajustar la query de mophosis para poner filtro de temporadas

Fix MER-1301:  Sacar restriccion de fecha de inicio al crear Temporadas
Se cambia la firma de algunos metodos de PlayerDapperRepository para que los parametros  DateOnly sean del tipo CreatedDate.

- Cambiado de nombre de variables en tasks por metodologias y tipos


**Fecha de Despliegue** : 2024-10-16
**US**: MER-95 - Eliminacion de usuarios

**Comentarios**: 

- Se implementa endpoint completo para eliminar usuarios jugadores y no jugadores en estado creado o pendiente

- Se cambia el ORM a usar para el delete de EFC a Dapper.

- Se cambia interfaz e implementacion en UserDapperRepository

- Se agrega metodo para obtener la entidad de usuario a partir del email y a partir del Id del usuario

- Se agrega metodo para obtener la entidad de jugador a partir del userId (playerDapperRepository)

- Mini refactor general de UserDapperRepository y PlayerDapperRepository

- Se agrega metodo de fabrica  Of(..) en entidad BirthDate y User


### Version 1.67.131

**Fecha de Despliegue** : 2024-10-16

**Comentarios**: Fix de permisos de combo de entrenadores en sesiones de entrenamientos.
Agregado de endpoint para impresion de sesiones de entrenamiento


### Version 1.68.133

**Fecha de Despliegue** : 2024-10-18

**Comentarios**: Fix de permisos de combo de entrenadores en sesiones de entrenamientos.


**Fecha de Despliegue** : 2024-10-18

**US**: MER-1144 INACTIVACION de usuarios y tratamientos pendientes

**Comentarios**: 

- Fix logica de envio de correo para solo enviarse cuando se activa un usuario.. y extraer logica del handler

- Se ajustan las queries para filtrar por jugadores con usuarios activos

- Se ajusta las query que trae todos los equipos para descartar el de inactivos

- Se fixea el updateo innecesario en la tabla de user_state cada vez que se cambia el estado de un usuario:

- Se crea logica para setear el equipo de inactivos a los usuarios que cambien su estado a inactivo,

### Version 1.69.134

**Fecha de Despliegue** : 2024-10-18

**Comentarios**: 
 - Descomentado del método que aplica migraciones en archivo program.cs


### Version 1.70.135


**Fecha de Despliegue** : 2024-10-21

**Comentarios**: se corrige retorno de sessiones de entrenamiento para al obtener por equipo y fecha , y por training session Id
 info: Microsoft.EntityFrameworkCore.Migrations[20405]
      No migrations were applied. The database is already up to date.



### Version 1.71.137

**Fecha de Despliegue** : 2024-10-22
**US**: MER-1281
**Comentarios**: 
	- Endpoints para la nueva seccion de objetivos
	- Creación de objetivos con fecha custom
	- Agregado de seguimiento anterior en objetivos al ser updateados

**Fecha de Despliegue** : 2024-10-23
**US**: MER-1343 En sesiones, el espacio debe ser un campo alfanumérico
 - Fix MER-1346 Fallo en la creación de tareas en varias categorías si ya existe una tarea de ese tipo  
 - Fix Paginacion de historial CPRD 



### Version 1.72.140

**Fecha de Despliegue** :  2024-10-23

**US**: MER-1205

**Comentarios**:  se agrega edicion de valores nutricionales


**Fecha de Despliegue** :  2024-10-28

**US**: MER-1324 - Mejora en la carga de lesionados/tratamientos

**Comentarios**:  

Cambian el endpoint de creacion/actualizacion de lesion.. Ahora se le puede pasar o no el realDischargeDate y el isPlayerAttendedByFootballersMutual (default falso). Ejemplo:

>{
  "categoryId": 1,
  "complexInjury": "string",
  "mechanismId": 1,
  "natureId": 1,
  "appearanceModeId": 1,
  "bodyZoneId": 1,
  "placeId": 1,
  "microcicleDayId": 1,
  "medicTreatmentId": 1,
  "comments": "string",
  "occurrenceDate": "2024-10-20",
  "dischargeDate": "2024-10-27",
  "isPlayerAttendedByFootballersMutual": true,
  "realDischargeDate": "2024-10-26"
}

Y en el payload de la creacion/actualizacion de un tratamiento medico:

>{
  "injuryId": "fb645665-f8a0-4983-a36d-7c9324ff2555",
  "typeId": 3,
  "type2Id": 10,
  "recoveryDetails": "string",
  "recoveryPhaseId": 3
}

default de typeId y type2Id es 0, se trata como que no tiene tipos asociados (y es obligatorio pasarle el recoveryDetails

y en todos los GETS de tratamiento/lesion por id, por jugador y por equipo se incluyen los nuevos campos agregados/movidos

>lesion: realDischargeDate, isPlayerAttendedByFootballersMutual
tratamiento medico: type2Id

**Fecha de Despliegue** :  2024-10-29

**US**: bugfix MER-1324 - Mejora en la carga de lesionados/tratamientos

**Comentarios**:

Falto incluir "Otros - Caida"  en la configuracion en InjuryMechanismConfiguration.
Se crea migracion


### Version 1.73.142

**Fecha de Despliegue** :  2024-10-31

**US**: bugfix MER-1324 - Mejora en la carga de lesionados/tratamientos

**Comentarios**:

Correcciones de bugs y otras mejoras.. Se deberia poder ya:

Editar lesiones ya cargadas 
Que se pueda poner en todos los  lesiones tratamientos médicos? ambos tratamientos tipos de tratamientos médicos? (fisioterapéuticos y readaptación)   
Que tipo de tratamiento sea multiselect y que los detalles sean obligatorios si no hay tratamientos  (la primer parte se logra en el FE, y la obligatoriedad de los detalles en ambos) 
Cambiar el toggle de mutua que está en tratamientos para que quede en lesiones 
Habilitar un ingreso libre en lesiones complejas (esto ya estaba antes en el BE, creo que faltaria en el FE)
Añadir en mecanismo lesional “otros” te deje cargar un valor nuevo, “caída” 
Añadir en localización “clavícula”, “huesos de la cara” 
Añadir en clasificación de la lesión muscular “latigazo cervical”, y tendinoso “dolor inguinal”  
Necesitaría dar de baja una lesión sin tener que meter tratamiento, o que se permita cerrar una lesión a través de alta cambiando la fecha 
Hay que cambiar los endpoints de creacion y actualizacion para poder setear la fecha de creacion a partir del parametro que se pase desde el front. Actualmente la fecha de creacion que se asigna es la actual del sistema, no la que se pasa por parametro.
Añadir el aggregate de Lateralidad a la Lesion y realizar todos los cambios en todas las capas correspondientes

FALTA corregir que tipo de tratamiento sea multiselect


**Fecha de Despliegue** :  2024-11-04
**US**:
**Comentarios**: se modifica el nombre de los objetivos físicos por "técnico-tácticos"



### Version 1.74.144

**Fecha de Despliegue** :  2024-11-05
**US**:
**Comentarios**: se agregan los objetivos "técnico-tácticos" manteniendo a los objetivos físicos (incluye migración)


**Fecha de Despliegue** :  2024-11-06
**US**: MER-1324: Mejoras en la carga de lesiones y tratamientos
**Comentarios**:

- Se ajustan todos los endpoints  y clases dependientes relacionados a los tratamientos medicos, impactados por el cambio de multiseleccion de tipos de tratamientos (flujos de creacion y de lectura de la entidad).

	- POST player/playerId,

	- PUT player/playerId

	- Todos los GEts que obtienen los recursos de tratamientos medicos

- Se renombra la clase MedicalTreatmentsTypesDTO a MedicalTreatmentTypeDTO en GetAllMedicalTreatmentTypes

- Se agrega metodo Of en MedicalTreatmentTypeId y MedicalTreatmentId

- Se agrega metodo ToDomain en MedicalTreatmentsTypeDTO para convertir el dto a entidad de dominio.

- Se agrega metodo FromTypeId en MedicalTreatmentRecoveryTypeEnum para obtener el tipo de recuperacion a la que pertence un tipo de tratamiento medico

- mini refactor: Se renombra propiedad MedicalTreatmentType a MedicalTreatmentRecoveryTypes en MedicalTreatmentRecoveryTypesEnum

- Se cambian y mejoran los metodos del MedicalTreatmentRepository.

- Se cambian y mejoran los metodos del MedicalTreatmentDapperRepository y queries relacionadas. Se hace nulleable RecoveryTypeId de las queriesResults (ya que en la db es nullable)


### Version 1.75.148

**Fecha de Despliegue** :  2024-11-08

**US**: MER-708: Adjuntar estudios medicos

**Comentarios**:

- Primera implementacion de la funcionalidad de adjuntar/ver/borrar adjuntos medicos de un jugador.

- Endpoints creados con operaciones de POST, GET, DELETE.


**Fecha de Despliegue** :  2024-11-08

**US**: MER-1405: Bugfix: User.Fullname no se estaba actualizando en las operaciones de actualizacion.

**Comentarios**:


**Fecha de Despliegue** :  2024-11-12

**US**: MER-1205: Mejora - Mejoras varias en el área de nutrición


**Fecha de Despliegue** :  2024-11-13

**Comentarios**: Fix Scouting Position null reference en historial


### Version 1.76.150

**Fecha de Despliegue** :  2024-11-14
**Comentarios**: ordenado de combos de scouting y quitado de obligatoriedad para equipo y club rival


**Fecha de Despliegue** :  2024-11-14
**Comentarios**: se fixea la inactivación y activación masiva de usuarios

### Version 1.77.152

**Fecha de Despliegue** :  2024-11-19
**Comentarios**: fix scouting players by team code

**Fecha de Despliegue** :  2024-11-20
**US**: MER 1249 CPRD Club

### Version 1.78.153

**Fecha de Despliegue** :  2024-11-20
**US**: MER 1492 Scouting - Diferencia entre nombre de habilidades y las de la US 


### Version 1.79.158


**Fecha de Despliegue** :  2024-11-21
**US**: MER 1397 - Mejoras Ficha nutricional nivel jugador - Endpoint nuevo para los graficos

**Fecha de Despliegue** :  2024-11-21
**Comentarios** : Fix Historial de scouting - se acomoda ordenamiento

**Fecha de Despliegue** :  2024-11-22
**Comentarios** :
	- Historial de CPRD
	- Historial de sesiones psicologicas
	- Sesiones psicologicas con multiples jugadores o todo el equipo
	- Habitos nutricionales creados por todos (jugadores y staff)

**Fecha de Despliegue** :  2024-11-25
**Comentarios** :
	MER 1397 - Mejoras Ficha nutricional nivel jugador -se crea una nueva query para obtener las mediciones por mes tomando la mas actualizada


**Fecha de Despliegue** :  2024-11-26
**Comentarios** :
	MER 708 - Adjuntar Estudios medicos 
	FIX MER 1500 - Cuando entro como Tecnico a scouting la app esta crashea
	MER 1481 - Rol Scouter: agregado al alta y a la modificación. 

### Version 1.80.159

**Fecha de Despliegue** :  2024-11-27
**Comentarios** :
 - MER 1514 fix avatar 
 - Se agrega migración para actualizar los pliegues de los equipos
 - Fix Formula valoraciones nutricionales

 ### Version 1.81.160

**Fecha de Despliegue** :  2024-12-02
**Comentarios** :
 - Se fixea la asignación de equipos a usuarios no jugador
 - Se le agrega promedios del equipo al endpoint para obtener la progresión de fatiga y sueño


### Version 1.82.161

**Fecha de Despliegue** :  2024-12-03
**Comentarios** :
- MER-1539 El historial de CPRD me esta mostrando jugadores a los cuales no debería ver (trae todos)
- MER-1538 En la ficha psicologica de club esta trayendo a todos los equipos con jugadores y no solo los que tengo asignados (con jugadores)


### Version 1.83.162

**Fecha de Despliegue** :  2024-12-04
**Comentarios** :
- MER-1398 - Mejoras - Ficha nutricional nivel equipo - Endpoint nuevo


### Version 1.84.163

**Fecha de Despliegue** :  2024-12-05
**Comentarios** :
- MER-1549 - Ficha nutricional nivel jugador y equipo - se agrega permiso al rol Medic y Psychologist 


### Version 1.85.164

**Fecha de Despliegue** :  2024-12-05
**Comentarios** :
- MER-1550 - En el historial del CPRD el páginado esta funcionando incorrectamente
- MER-1538 -En la ficha psicologica de club esta trayendo a todos los equipos con jugadores y no solo los que tengo asignados (con jugadores)

### Version 1.86.165

**Fecha de Despliegue** :  2024-12-05
**Comentarios** :

MER-1538-En la ficha psicologica de club esta trayendo a todos los equipos con jugadores y no solo los que tengo asignados (con jugadores) 
MER-1549- al ingresar como psicologo o medico me crashea la app   


### Version 1.87.166

**Fecha de Despliegue** :  2024-12-06
**Comentarios** :
  MER-1538-En la ficha psicologica de club esta trayendo a todos los equipos con jugadores y no solo los que tengo asignados (con jugadores)(re fix)   


### Version 1.88.167

**Fecha de Despliegue** :  2024-12-06
**Comentarios** :
   -  fix grafico cprd de jugador 

### Version 1.89.171

**Fecha de Despliegue** :  2024-12-10
**Comentarios** :
   -  MER-1398_mejoras_ficha_nutricional - Nuevo endpoint para el ultimo historial de equipo/jugador (sin paginado)

**Fecha de Despliegue** :  2024-12-10
**US** : MER-1250 / Vista Club de la ficha médica
**Comentarios** :
	- Se corrigen errores y se mejoran los endpoints para obtener los historiales de lesiones y tratamientos
	- Se agregan endpoints de salida de wellness y lesiones para vista de club

**Fecha de Despliegue** :  2024-12-11
**US** : MER-1517 Edición Scouting

**Fecha de Despliegue** :  2024-12-11
**Comentarios** :
   -  MER-1398_mejoras_ficha_nutricional - Nuevo endpoint para el ultimo historial de equipo/jugador (con paginado)


### Version 1.90.172

**Fecha de Despliegue** :  2024-12-11
**Comentarios** :
   -  Fix permisos de scouting


### Version 1.91.175

**Fecha de Despliegue** :  2024-12-12
**Comentarios** :
   -  MER-1398_mejoras_ficha_nutricional: Historiales: se agrega filtro por status.
       y en Habitos Nutricionales: se agrega el nombre del equipo en el resultado.

**Fecha de Despliegue** :  2024-12-12
**Comentarios** :
   -  MER-1398_mejoras_ficha_nutricional- Habitos Nutricionales: se agrega el filtro por statusName.

**Fecha de Despliegue** :  2024-12-12
**Comentarios** :
   -  MER-1505: Mejoras Scouting


### Version 1.92.176

**Fecha de Despliegue** :  2024-12-12
**Comentarios** :
   -  FIX: ScoutingScouters: se corrige el .csporj de infrastructure para incluir el query.


### Version 1.93.177

**Fecha de Despliegue** :  2024-12-13
**Comentarios** :
	- Se agrega edición de sesiones psicológicas
	- Se corrigen levemente los endpoints de archivos médicos



### Version 1.94.179

**Fecha de Despliegue** :  2024-12-17
**Comentarios** :
	- Fix MER-1563, se aplica el mismo filtro de usuario activo a los siguientes endpoints:
		/nutritional-assessments/team/:teamId/history
		/nutritional-assessments/mophosis/team/:teamId
		/nutritional-assessments/team/:teamId/paged

**Fecha de Despliegue** :  2024-12-18
**Comentarios** :
 MER-1565- FIX BUG El campo Nombre en el historial de mediciones es case sensitive


### Version 1.95.180

**Fecha de Despliegue** :  2024-12-18
**Comentarios** :
	- Endpoints para los cambios a Scouting
	- Se fixean bugs varios de lesiones
	- Se mueve una query de lugar a ver si eso soluciona los crasheos de la base de datos


### Version 1.96.181

**Fecha de Despliegue** :  2024-12-19
**Comentarios** :
	- FIX: MER-1562: En mediciones nutricionales no me trae la ultima de todos los jugadores.

### Version 1.97.182



**Fecha de Despliegue** :  2024-12-19
**Comentarios** :
	- Creo un endpoint para obtener los clubes de scouting que tengan reportes creados


### Version 1.97.184

**Fecha de Despliegue** :  2024-12-20
**Comentarios** :
	-MER-1251-Nuevos endpoints para ficha nutricional a nivel club

**Fecha de Despliegue** :  2024-12-20
**Comentarios** :
	- Permisos para scouting al entrenador (incluye migración)
	- Fix lesión que no se abre a nivel club


### Version 1.98.185

**Fecha de Despliegue** :  2024-12-20
**Comentarios** :
	- MER-1578: Cambio de formula de % grasa para mujeres.
	- Se modifica "skinfold fat" y porcentaje.


### Version 1.99.186

**Fecha de Despliegue** :  2024-12-24
**Comentarios** :
	- Se agrega endpoint morphosis/team/average


### Version 1.100.187

**Fecha de Despliegue** :  2024-12-26
**Comentarios** :
	- Fix endpoint de obtener todos los equipos


### Version 1.101.188

**Fecha de Despliegue** :  2024-12-26
**Comentarios** :
	- Fix paginado de historiales nutricionales cuando se filtra por estado


### Version 1.102.191

**Fecha de Despliegue** :  2024-12-27
**Comentarios** :
	- Se agregan datos adicionales al endpoint del historial de objetivos


**Fecha de Despliegue** :  2025-01-02
**Comentarios** :
	- MER-1623- Ficha nutricional - Club - fix bug semaforo

**Fecha de Despliegue** :  2025-01-02
**Comentarios** :
	- Cambios y mejoras en metodología (incluye migraciones)


### Version 1.103.193

**Fecha de Despliegue** :  2025-01-03
**Comentarios** :
	- Corrijo la edición de tareas de entrenamiento

**Fecha de Despliegue** :  2025-01-03
**Comentarios** :
	- MER-1621- fix bug error en calculos 


### Version 1.104.194

**Fecha de Despliegue** :  2025-01-03
**Comentarios** :
	- MER-1620- Ficha nutricional - Club - Se agregan validaciones de permisos por usuario equipo


### Version 1.105.195


**Fecha de Despliegue** :  2025-01-07
**Comentarios** :
	- MER-1620- Fix NutritionalAssesments/team/last/paged permisos por usuario equipo


### Version 1.106.196

**Fecha de Despliegue** :  2025-01-08
**Comentarios** :
	- MER-1231- Creación y edición de tipos de tareas de entrenamiento


### Version 1.107.198

**Fecha de Despliegue** :  2025-01-08
**Comentarios** :
	- Corrijo el ordenamiento de varios listados de las sesiones de entrenamiento (herramientas, fases, intenciones, etc)


### Version 1.108.199

**Fecha de Despliegue** :  2025-01-09
**Comentarios** :
	MER - 1398- Mejoras en objetivos:
	-Se agrega nuevo endpoint 'objectives/{id}' para editar un objetivo
	-'objectives/history' - Se agrega posibilidad de ordenar por nombre de jugador
	-'objectives/tracking-levels/teams' - Se agrega filtro por tipo



### Version 1.109.200

**Fecha de Despliegue** :  2025-01-09
**Comentarios** :
	- Ultimos cambios a las herramientas e intenciones de sesiones de entrenamiento


### Version 1.110.201

**Fecha de Despliegue** :  2025-01-10
**Comentarios** :
	- MER-1634: se fixea un bug donde se creaban las sesiones de entrenamiento en el día incorrecto dependiendo de la zona horaria
	- MER-1640: se crea endpoint para obtener las fechas que tienen al menos una sesion de entrenamiento creada
	- MER-1171: se agrega mensaje de error al intentar editarle el email a un usuario con un email ya existente
	- MER-753: se agrega mensaje de error al intentar registrarse con un email ya existente



### Version 1.111.205

**Fecha de Despliegue** :  2025-01-13
**Comentarios** :
	- MER-1644: Nivel club- fix calculos promedios cuando hay valores menores o iguales a 0.
	

**Fecha de Despliegue** :  2025-01-13
**Comentarios** :
	MER-1593- se fixea bug en team/last/paged :  'El historial de nutrición esta trayendo la ultima medición mensual de los jugadores por default'.


**Fecha de Despliegue** :  2025-01-13
**Comentarios** :
	- MER-1639: Se acomodan correctamente las fases dentro de los momentos correspondientes al obtener una sesion de entrenamiento por id
	- MER-836: El semaforo de wellness ahora marca rojo si hay zonas de dolor, sin importar lo demás
	- MER-1558: Se agrega eliminado de usuarios no-jugadores en estado pendiente

**Fecha de Despliegue** :  2025-01-14
**Comentarios** :
	MER-1498: se fixea el 'status' de un jugador dependiendo del valor en team/is_adults_team.


### Version 1.112.206

**Fecha de Despliegue** :  2025-01-15
**Comentarios** :
	MER-1628:  Scouting - Mejoras - Que los preparadores físicos, solo puedan ver los jugadores que ellos cargan y no los de los demás


### Version 1.113.207

**Fecha de Despliegue** :  2025-01-15
**Comentarios** :  
	- Se eliminan dos momentos e intenciones redundantes en las sesiones de entrenamiento
	- Se le asigna metodología futbol11 a 5 de las categorías de tareas de entrenamiento predefinidas (dejan de ser globales)


### Version 1.114.208

**Fecha de Despliegue** :  2025-01-16
**Comentarios** :  
	- Se hacen opcionales los momentos/intenciones y las fases en las sesiones de entrenamiento


### Version 1.115.209

**Fecha de Despliegue** :  2025-01-21
**Comentarios** :  
	- Se fixean calculos con valores nulos en GetLastestAverageMorphosisQueryHandler


### Version 1.116.210

**Fecha de Despliegue** :  2025-01-22
**Comentarios** :  
	- Se fixea error al no haber datos nutricionales al momento de calcular el averageMorphosis


### Version 1.117.211

**Fecha de Despliegue** :  2025-01-23
**Comentarios** :  
	- Se agrega el control de teams por user en morphosis/team/average


### Version 1.118.212

**Fecha de Despliegue** :  2025-01-23
**Comentarios** :  
	- Multitenancy MER 168

### Version 1.119.213

**Fecha de Despliegue** :  2025-01-23
**Comentarios** : Se le agrega multitenancy a tareas de entrenamiento (por medio de las metodologías)


### Version 1.120.214

**Fecha de Despliegue** :  2025-01-23
**Comentarios** : Se le agrega multitenancy a Seasons


### Version 1.121.215

**Fecha de Despliegue** :  2025-01-28
**Comentarios** : Se le agrega multitenancy a Scouting


### Version 1.122.216

**Fecha de Despliegue** :  2025-02-03
**Comentarios** : Se corrige fallo del endpoint de promedio mensual de pliegues cuando se carga un único registro nutricional pero sin pliegues


### Version 1.123.217

**Fecha de Despliegue** :  2025-02-05
**Comentarios** : Se agrega nuevo rol "administrador de equipo"


### Version 1.124.218

#### LTS QA

**Fecha de Despliegue** :  2025-02-06
**Comentarios** : Se devuelve el objetivo privado en lugar del público en el historial de objetivos

---
## Produccion (prod)
| [Desarrollo (dev)](#desarrollo-dev) | [Aseguramiento de Calidad (QA)](#aseguramiento-de-calidad-qa) | [Producci�n (prod)](#producci�n-prod) | [LTS dev](#lts-dev)| [LTS QA](#lts-qa) | [LTS prod](#lts-prod)

### Version 0.0.1
- **Fecha de Despliegue**: 2024-05-27
- **Descripci�n**:
	- Se incluye archivo env-relese-notes.md para control de versiones.
- **Notas Adicionales**: (eg.) Las pruebas deben ejecutarse nuevametne con el despliegue.


### Version 1.64.125
**Fecha de Despliegue** : 2024-10-04

### Version 2.78.154
#### LTS PROD
**Fecha de Despliegue** : 2024-11-21

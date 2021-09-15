# Webapp_Ganadera
Proyecto Ciclo 3 - MinTIC2022 - WebApp con .NET, SQL, Razor

Planteamiento del Proyecto

Aplicación Web para registrar el ganado que adquiere el propietario, además de hacer el registro de las vacunas aplicadas a un ganado, y el registro cuando algún ejemplar del ganado este enfermo y necesite cuidados veterinarios:
    • Registrar los datos personales del administrador del ganado.
    • Registrar los datos personales del veterinario.
    • Registrar las vacunas que se le van a aplicar a un ganado.
    • Consulta por parte del administrador y veterinario sobre las diferentes vacunas que se le han aplicado a un ganado. 
    • Consultar la historia clínica de cada ejemplar que requiere consulta con el veterinario.
Los datos solo pueden ser accedidos mediante el ingreso de credenciales de acceso por parte del administrador del ganado y del veterinario.


Requisitos:

    • Registro de un perfil para ganadero (tener condiciones mínimas de seguridad en la contraseña), registrar la ubicación geográfica
    • Registro de un perfil para veterinario (tener condiciones mínimas de seguridad en la contraseña), registrar la ubicación geográfica
    • Crear menús para los diferentes perfiles
    • Registrar vacuna (Nombre, Descripción, Lote, Fecha de vencimiento, etc.)
    • Registrar el ganado (Fecha de ingreso, número de ejemplares, Nombre, etc)
    • Registrar las vacunas que se le aplican a un ganado en particular (Selecciono la vacuna, Descripción, Fecha, Personas que realizo la vacunación, etc)
    • Poder visualizar una lista con los diferentes registros de ganado que ha agregado el administrador, y con esta lista poder visualizar que vacunas se le han         aplicado
    • Registrar un ejemplar y hacer la solicitud para que el veterinario lo revise
    • El veterinario debería poder visualizar estas solicitudes de os ejemplares que se le han asignado y atenderlas.
      Estado PENDIENTE, y cuando el veterinario lo revisa para a un estado RESUELTO
    • El ganadero debería poder observar las solicitudes que se hacen al veterinario y su respectiva respuesta.
    • Poder visualizar la historia clínica de cada ejemplar (vacunas se le ha puesto, y las revisiones que se han tenido con el veterinario)
    • Login de acceso para los dos perfiles (Ganadero, Veterinario), la contraseña debe de estar cifrada MD5
    • Poder cambiar la información de mi perfil (Nombre, apellidos, Tipo de identificación, identificación, contraseña, etc)
    • Estadístico la cantidad de ejemplares que se han enviado a la veterinaria, ejemplares en estado pendiente, ejemplares en estado resuelto, ETC

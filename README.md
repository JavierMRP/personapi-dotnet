# personapi-dotnet

Descripcion del proyecto:


Un proyecto en monolito, para la gestion de profesiones y estudiantes, documentado con swagger y que dispone de un api por cada tabla que tiene su respectivo crud.


![Imagen11](https://user-images.githubusercontent.com/58142219/235403831-4118242b-727d-411c-8cfd-d1be83fe9632.png)

![Imagen12](https://user-images.githubusercontent.com/58142219/235403993-8c4b5b39-276f-4ce2-bd31-16d955049d86.png)

diagrama base datos de nuestra autoria:

![Imagen-1](https://user-images.githubusercontent.com/58142219/235404909-8096a467-c890-4fa8-a94f-3c04dc87a1b8.png)


DESPLIEGUE:
1. Para desplegar la aplicación se requiere instalar el conjunto de hospedaje de .Net Core, una vez instalado se abre la aplicación de Internet Information Systems IIS y se crea un nuevo sitio en este caso WebAppArqui. 
![Imagen1](https://user-images.githubusercontent.com/58142219/235403523-547a5762-da9f-40f4-89ff-0d7636d972f0.png)


![Imagen2](https://user-images.githubusercontent.com/58142219/235403554-b03098ba-fb96-427b-85d2-5dcaddd20ee4.png)

2. En el grupo de aplicaciones se modifica la opción de  versión de .Net CLR a la opción Sin código administrado. 
![Imagen3](https://user-images.githubusercontent.com/58142219/235403563-8dfa4047-73b3-42d2-92d3-03805115f098.png)

3. Luego de esto en la configuración del sitio se le asignan las credenciales dando la opción Usuario específico. 
![Imagen4](https://user-images.githubusercontent.com/58142219/235403571-697a149c-13c6-436e-a8ef-1bbd731c946f.png)

4. Se asignan las credenciales del paso anterior en Grupos de aplicaciones, configuración avanzada, identidad.  
![Imagen5](https://user-images.githubusercontent.com/58142219/235403614-0faafce1-8aa9-4ebb-b3bc-780b4414301b.png)

5. En Visual Studio se click izquierdo en la solución y se selecciona la opción publicar en IIS. 
![Imagen6](https://user-images.githubusercontent.com/58142219/235403625-468b12dd-1f06-45e8-aebe-e3f632214841.png)

6. Se digitan los datos del sitio creado en los pasos anteriores y se valida la conexión. 
![Imagen7](https://user-images.githubusercontent.com/58142219/235403631-04478ce2-3784-42a6-ab91-62ed2d19eca6.png)

7. Finalmente se le da a la opción de publicar y Visual Studio empieza el proceso de compilación y  se entra a la página para ver su funcionameineto en la URL localhost:8089 


![Imagen8](https://user-images.githubusercontent.com/58142219/235403641-97b51c64-351e-4f0c-a1e2-dfb13dcfae0d.png)


![Imagen9](https://user-images.githubusercontent.com/58142219/235403649-293f04ed-5db0-493b-8b34-385b3d69906a.png)


![Imagen10](https://user-images.githubusercontent.com/58142219/235403650-92e0b23a-3bf6-4a0c-b1e2-446ea47a888b.png)

BASE DE DATOS:
1. En la primera parte del script se desactivan las comprobaciones de unicidad y de claves foráneas, y establece un modo SQL específico.
2. Se crea la tabla persona con los campos cc, nombre, apellido, género y edad, donde cc es la clave primaria de la tabla.
3. Se crea la tabla profesion con los campos id, nom y des, donde id es la clave primaria de la tabla.
4. Crea la tabla estudios con los campos id_prof, cc_per, fecha y univer, donde id_prof y cc_per forman la clave primaria de la tabla, y ambos campos son claves foráneas de las tablas profesión y persona respectivamente.
5. Crea la tabla telefono con los campos num, oper y duenio, donde num es la clave primaria de la tabla, y duenio llave foránea que referencia a la columna cc de la tabla persona.
6. Se ejecuta el script y luego se crea la base de datos, se crea un diagrama de la base de datos dando click izquierdo en la Database Digrams como se muestra en la imagen.




![Imagen13](https://user-images.githubusercontent.com/58142219/235404553-8ad77eb3-9ab6-456c-b744-a67a6223d459.png)




7. Finalmente se obtiene un diagrama de la base de datos como se muestra en la siguiente imagen.
